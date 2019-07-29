using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MPLIS.Web.FrameWork.PluginManager
{
    public abstract class MPLISController : Controller, IMPLISController
    {
        public string ControllerName
        {
            get
            {
                return GetType().Name.Replace("Controller", string.Empty);
            }
        }
    }
}
