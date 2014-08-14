using System;

namespace app.container
{
  public class Dependency
  {
    public static ICreateTheContainerFacade create_the_container = delegate
    {
      throw new NotImplementedException("This needs to be configured by a startup process");
    };

    public static IFetchDependencies fetch
    {
      get { return create_the_container(); }
    }
  }
}