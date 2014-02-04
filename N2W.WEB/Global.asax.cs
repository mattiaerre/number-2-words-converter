using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using N2W.CORE.Handlers;
using N2W.CORE.Services;
using N2W.WEB.Plumbing;

namespace N2W.WEB
{
  public class MvcApplication : HttpApplication
  {
    private static IWindsorContainer _container;

    protected void Application_Start()
    {
      AreaRegistration.RegisterAllAreas();
      RouteConfig.RegisterRoutes(RouteTable.Routes);

      BootstrapContainer();
    }

    private static void BootstrapContainer()
    {
      _container = new WindsorContainer().Install(FromAssembly.This());
      var controllerFactory = new WindsorControllerFactory(_container.Kernel);
      ControllerBuilder.Current.SetControllerFactory(controllerFactory);

      // services
      _container.Register(Component.For<INumberToWordsService>().ImplementedBy<NumberToWordsService>());
      _container.Register(Component.For<IDecompositionService>().ImplementedBy<DecompositionService>());

      // CoR
      _container.Register(Component.For<EndOfChainHandler>()); // tail
      _container.Register(Component.For<Range100900Handler>().DependsOn(new { handler = _container.Resolve<EndOfChainHandler>() }));
      _container.Register(Component.For<Range2090Handler>().DependsOn(new { handler = _container.Resolve<Range100900Handler>() }));
      _container.Register(Component.For<IRangeHandler>().ImplementedBy<Range119Handler>().DependsOn(new { handler = _container.Resolve<Range2090Handler>() })); // head
    }

    protected void Application_End()
    {
      _container.Dispose();
    }
  }
}
