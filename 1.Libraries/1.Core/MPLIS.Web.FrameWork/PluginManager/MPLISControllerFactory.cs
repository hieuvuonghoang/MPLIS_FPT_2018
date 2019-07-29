using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.Practices.ServiceLocation;
using System.Web.Routing;

namespace MPLIS.Web.FrameWork.PluginManager
{
    public class MPLISControllerFactory : DefaultControllerFactory
    {
        protected override Type GetControllerType(RequestContext requestContext, 
            string controllerName)
        {
            var controllerType = base.GetControllerType(requestContext, controllerName);

            if (controllerType == null)
            {
                var controller = ServiceLocator.Current.GetAllInstances<IController>().ToList()
                .OfType<IMPLISController>()
                .SingleOrDefault(c => c.ControllerName == controllerName);

                if (controller != null)
                {
                    return controller.GetType();
                }
            }

            return controllerType;
        }
    }
}
