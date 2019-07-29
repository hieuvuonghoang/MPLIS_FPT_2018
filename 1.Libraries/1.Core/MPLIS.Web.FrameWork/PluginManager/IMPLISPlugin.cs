using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Routing;

namespace MPLIS.Web.FrameWork.PluginManager
{
    public interface IMPLISPlugin
    {
        string PluginName { get; }
        void RegisterRoutes(RouteCollection routes);
    }
}
