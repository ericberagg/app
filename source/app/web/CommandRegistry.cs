using System.Collections.Generic;
using System.Linq;

namespace app.web
{
    public class CommandRegistry : IFindCommandsThatCanProcessRequests
    {
        private readonly IEnumerable<IProcessOneRequest> commands;

        public CommandRegistry(IEnumerable<IProcessOneRequest> commands)
        {
            this.commands = commands;
        }

        public IProcessOneRequest get_the_command_that_can_process(IProvideRequestDetails request)
        {
            return commands.Single(x => x.can_process(request));
        }
    }
}