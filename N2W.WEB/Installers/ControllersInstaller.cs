using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace N2W.WEB.Installers
{
  public class ControllersInstaller : IWindsorInstaller
  {
    public void Install(IWindsorContainer container, IConfigurationStore store)
    {
      container.Register(Classes.FromThisAssembly()
        .BasedOn<IController>()
        .LifestyleTransient());
    }
  }
}