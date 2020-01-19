using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;

namespace EPICCentralUnitTest.MockObjects
{
    public class MockControllerFactory : DefaultControllerFactory
    {
        protected override Type GetControllerType(RequestContext requestContext, string controllerName)
        {
            if(!controllerName.EndsWith("Controller"))
                controllerName += "Controller";
            var controllerType =
                MockVirtualPathFactory.Assemblies.SelectMany(x => x.Value.GetTypes()).FirstOrDefault(
                    x => x.Name == controllerName && typeof(Controller).IsAssignableFrom(x));
            return controllerType;
        }
    }
}