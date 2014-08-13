 using System.Collections.Generic;
 using System.Linq;
 using app.web;
 using Machine.Specifications;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace app.specs
{  
  [Subject(typeof(CommandRegistry))]  
  public class CommandRegistrySpecs
  {
    public abstract class concern : Observes<IFindCommandsThatCanProcessRequests,
      CommandRegistry>
    {
        
    }

   
    public class when_finding_a_command_that_can_process_a_request : concern
    {
      public class and_it_has_the_command
      {
        Establish c = () =>
        {
          request = fake.an<IProvideRequestDetails>();
          the_command_that_can_process = fake.an<IProcessOneRequest>();
          all_the_commands = Enumerable.Range(1, 1000).Select(x => fake.an<IProcessOneRequest>()).ToList();
          all_the_commands.Add(the_command_that_can_process);

          depends.on<IEnumerable<IProcessOneRequest>>(all_the_commands);

          the_command_that_can_process.setup(x => x.can_process(request)).Return(true);
        };
           
        Because b = () =>
          result = sut.get_the_command_that_can_process(request);

        It returns_the_command = () =>
          result.ShouldEqual(the_command_that_can_process);

        static IProcessOneRequest result;
        static IProcessOneRequest the_command_that_can_process;
        static IProvideRequestDetails request;
        static List<IProcessOneRequest> all_the_commands;
      }    
        
    }
  }
}
