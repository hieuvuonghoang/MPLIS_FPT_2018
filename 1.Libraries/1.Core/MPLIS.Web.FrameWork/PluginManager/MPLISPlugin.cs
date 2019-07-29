using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Routing;

namespace MPLIS.Web.FrameWork.PluginManager
{
    public abstract class MPLISPlugin : IMPLISPlugin 
    {
        protected Assembly PluginAssembly;

        public MPLISPlugin()
        {
            PluginAssembly = Assembly.GetAssembly(GetType());
        }

        public string AssemblyName
        {
            get
            {
                return PluginAssembly.GetName().Name;
            }
        }

        public virtual string PluginName
        {
            get
            {
                return AssemblyName;
            }
        }

        public IMPLISPlugin IMyPlugin
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public virtual void RegisterRoutes(RouteCollection routes)
        {
        }

        public override string ToString()
        {
            return string.Format("{0}", PluginName);
        }

        public string GetControllerName<TController>()
        {
            return typeof(TController).Name.Replace("Controller", string.Empty);
        }
    }
}
