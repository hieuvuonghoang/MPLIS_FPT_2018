using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MPLIS.Web.FrameWork.PluginManager
{
    public class MPLISRazorViewEngine : RazorViewEngine
    {
        public MPLISRazorViewEngine(string pluginPath, IEnumerable<string> plugins, string defaultMaster)
            : base()
        {
            //// This property contains the locations where the view engine will search to find a partial view in an area-enabled application.
            //AreaViewLocationFormats = new[] { 
            //    "~/Areas/{2}/Views/{1}/{0}.cshtml",
            //    "~/Areas/{2}/Views/{1}/{0}.vbhtml",
            //    "~/Areas/{2}/Views/Shared/{0}.cshtml",
            //    "~/Areas/{2}/Views/Shared/{0}.vbhtml" };

            //// This property contains the locations where the view engine will search to find a master view in an area-enabled application.
            //AreaMasterLocationFormats = new[] { 
            //    "~/Areas/{2}/Views/{1}/{0}.cshtml",
            //    "~/Areas/{2}/Views/{1}/{0}.vbhtml",
            //    "~/Areas/{2}/Views/Shared/{0}.cshtml",
            //    "~/Areas/{2}/Views/Shared/{0}.vbhtml" };

            ////This property contains the locations where the view engine will search to find a partial view in an area-enabled application.
            //AreaPartialViewLocationFormats = new[] { 
            //    "~/Areas/{2}/Views/{1}/{0}.cshtml",
            //    "~/Areas/{2}/Views/{1}/{0}.vbhtml",
            //    "~/Areas/{2}/Views/Shared/{0}.cshtml",
            //    "~/Areas/{2}/Views/Shared/{0}.vbhtml" };

            var partialViewLocationFormats = new List<string> { 
                "~/Views/{1}/{0}.cshtml",
                //"~/Views/{1}/{0}.vbhtml",
                "~/Views/Shared/{0}.cshtml"
                //"~/Views/Shared/{0}.vbhtml" 
            };

            var masterLocationFormats = new List<string> { 
                "~/Views/{1}/{0}.cshtml",
                //"~/Views/{1}/{0}.vbhtml",
                "~/Views/Shared/{0}.cshtml",
                //"~/Views/Shared/{0}.vbhtml" 
            };

            // register all razor view locations for each plugin (e.g. web\plugin\%assemblyname%\views)
            foreach (var plugin in plugins)
            {
                masterLocationFormats.Add("~/Modules/Views/" + plugin + "/{1}/{0}.cshtml");
                //masterLocationFormats.Add("~/Modules/Views/" + plugin + "/{1}/{0}.vbhtml");
                masterLocationFormats.Add("~/Modules/Views/" + plugin + "/Shared/{1}/{0}.cshtml");
                //masterLocationFormats.Add("~/Modules/Views/" + plugin + "/Shared/{1}/{0}.vbhtml");

                partialViewLocationFormats.Add("~/Modules/Views/" + plugin + "/{1}/{0}.cshtml");
                //partialViewLocationFormats.Add("~/Modules/Views/" + plugin + "/{1}/{0}.vbhtml");
                partialViewLocationFormats.Add("~/Modules/Views/" + plugin + "/Shared/{1}/{0}.cshtml");
                //partialViewLocationFormats.Add("~/Modules/Views/" + plugin + "/Shared/{1}/{0}.vbhtml");
            }

            // This property contains the locations where the view engine will search to find a view.
            ViewLocationFormats = partialViewLocationFormats.ToArray();
            // This property contains the locations where the view engine will search to find a master view.
            MasterLocationFormats = masterLocationFormats.ToArray();
            // This property contains the locations where the view engine will search to find a partial view.
            PartialViewLocationFormats = partialViewLocationFormats.ToArray();
        }

        //protected override bool FileExists(ControllerContext controllerContext, string virtualPath)
        //{
        //    try
        //    {
        //        return File.Exists(controllerContext.HttpContext.Server.MapPath(virtualPath));
        //    }
        //    catch (HttpException exception)
        //    {
        //        if (exception.GetHttpCode() != 0x194)
        //        {
        //            throw;
        //        }
        //        return false;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        //public override ViewEngineResult FindView(ControllerContext controllerContext, string viewName, string masterName, bool useCache)
        //{
        //    string[] strArray;
        //    string[] strArray2;

        //    if (controllerContext == null)
        //    {
        //        throw new ArgumentNullException("controllerContext");
        //    }
        //    if (string.IsNullOrEmpty(viewName))
        //    {
        //        throw new ArgumentException("viewName must be specified.", "viewName");
        //    }

        //    var requiredString = controllerContext.RouteData.GetRequiredString("controller");

        //    var viewPath = GetPath(controllerContext, ViewLocationFormats, "ViewLocationFormats", viewName, requiredString, "View", useCache, out strArray);
        //    var masterPath = GetPath(controllerContext, MasterLocationFormats, "MasterLocationFormats", masterName, requiredString, "Master", useCache, out strArray2);

        //    if (!string.IsNullOrEmpty(viewPath) && (!string.IsNullOrEmpty(masterPath) || string.IsNullOrEmpty(masterName)))
        //    {
        //        return new ViewEngineResult(CreateView(controllerContext, viewPath, masterPath), this);
        //    }
        //    return new ViewEngineResult(strArray.Union(strArray2));
        //}

        //public override ViewEngineResult FindPartialView(ControllerContext controllerContext, string partialViewName, bool useCache)
        //{
        //    string[] strArray;
        //    if (controllerContext == null)
        //    {
        //        throw new ArgumentNullException("controllerContext");
        //    }
        //    if (string.IsNullOrEmpty(partialViewName))
        //    {
        //        throw new ArgumentException("partialViewName must be specified.", "partialViewName");
        //    }

        //    var requiredString = controllerContext.RouteData.GetRequiredString("controller");
        //    var partialViewPath = GetPath(controllerContext, PartialViewLocationFormats, "PartialViewLocationFormats", partialViewName, requiredString, "Partial", useCache, out strArray);
        //    return string.IsNullOrEmpty(partialViewPath) ? new ViewEngineResult(strArray) : new ViewEngineResult(CreatePartialView(controllerContext, partialViewPath), this);
        //}

        //private static readonly string[] _emptyLocations;

        //private string GetPath(ControllerContext controllerContext, string[] locations, string locationsPropertyName, string name, string controllerName, string cacheKeyPrefix, bool useCache, out string[] searchedLocations)
        //{
        //    searchedLocations = _emptyLocations;
        //    if (string.IsNullOrEmpty(name))
        //    {
        //        return string.Empty;
        //    }
        //    if ((locations == null) || (locations.Length == 0))
        //    {
        //        throw new InvalidOperationException("locations must not be null or emtpy.");
        //    }

        //    bool flag = IsSpecificPath(name);
        //    string key = CreateCacheKey(cacheKeyPrefix, name, flag ? string.Empty : controllerName);
        //    if (useCache)
        //    {
        //        var viewLocation = ViewLocationCache.GetViewLocation(controllerContext.HttpContext, key);
        //        if (viewLocation != null)
        //        {
        //            return viewLocation;
        //        }
        //    }
        //    return !flag ? GetPathFromGeneralName(controllerContext, locations, name, controllerName, key, ref searchedLocations)
        //                : GetPathFromSpecificName(controllerContext, name, key, ref searchedLocations);
        //}

        //private static bool IsSpecificPath(string name)
        //{
        //    var ch = name[0];
        //    if (ch != '~')
        //    {
        //        return (ch == '/');
        //    }
        //    return true;
        //}

        //private string CreateCacheKey(string prefix, string name, string controllerName)
        //{
        //    return string.Format(
        //        CultureInfo.InvariantCulture,
        //        ":ViewCacheEntry:{0}:{1}:{2}:{3}",
        //        new object[] { GetType().AssemblyQualifiedName, prefix, name, controllerName });
        //}

        //private string GetPathFromGeneralName(ControllerContext controllerContext, string[] locations, string name, string controllerName, string cacheKey, ref string[] searchedLocations)
        //{
        //    var virtualPath = string.Empty;
        //    searchedLocations = new string[locations.Length];
        //    for (var i = 0; i < locations.Length; i++)
        //    {
        //        var str2 = string.Format(CultureInfo.InvariantCulture, locations[i], new object[] { name, controllerName });

        //        if (FileExists(controllerContext, str2))
        //        {
        //            searchedLocations = _emptyLocations;
        //            virtualPath = str2;
        //            ViewLocationCache.InsertViewLocation(controllerContext.HttpContext, cacheKey, virtualPath);
        //            return virtualPath;
        //        }
        //        searchedLocations[i] = str2;
        //    }
        //    return virtualPath;
        //}

        //private string GetPathFromSpecificName(ControllerContext controllerContext, string name, string cacheKey, ref string[] searchedLocations)
        //{
        //    var virtualPath = name;
        //    if (!FileExists(controllerContext, name))
        //    {
        //        virtualPath = string.Empty;
        //        searchedLocations = new[] { name };
        //    }
        //    ViewLocationCache.InsertViewLocation(controllerContext.HttpContext, cacheKey, virtualPath);
        //    return virtualPath;
        //}
    }

    public class MyWebFormViewEngine : WebFormViewEngine
    {
        public MyWebFormViewEngine(string pluginPath, IEnumerable<string> plugins, string defaultMaster)
            : base()
        {
            IList<string> masterLocationFormats = new List<string> { 
                "~/Views/{1}/{0}.master",
                "~/Views/Shared/{0}.master" };


            AreaMasterLocationFormats = new[] { 
                "~/Areas/{2}/Views/{1}/{0}.master",
                "~/Areas/{2}/Views/Shared/{0}.master" };

            IList<string> viewLocationFormats = new List<string> { 
                "~/Views/{1}/{0}.aspx",
                "~/Views/{1}/{0}.ascx",
                "~/Views/Shared/{0}.aspx",
                "~/Views/Shared/{0}.ascx" };

            AreaViewLocationFormats = new[] { 
                "~/Areas/{2}/Views/{1}/{0}.aspx",
                "~/Areas/{2}/Views/{1}/{0}.ascx",
                "~/Areas/{2}/Views/Shared/{0}.aspx",
                "~/Areas/{2}/Views/Shared/{0}.ascx" };

            // register all forms (non-razor) view locations for each plugin (e.g. web\plugin\%assemblyname%\views)
            foreach (var plugin in plugins)
            {
                masterLocationFormats.Add("~/Modules/Views/" + plugin + "/{1}/{0}.master");
                masterLocationFormats.Add("~/Modules/Views/" + plugin + "/Shared/{1}/{0}.master");

                viewLocationFormats.Add("~/Modules/Views/" + plugin + "/{1}/{0}.aspx");
                viewLocationFormats.Add("~/Modules/Views/" + plugin + "/{1}/{0}.ascx");
                viewLocationFormats.Add("~/Modules/Views/" + plugin + "/Shared/{1}/{0}.aspx");
                viewLocationFormats.Add("~/Modules/Views/" + plugin + "/Shared/{1}/{0}.ascx");
            }

            MasterLocationFormats = masterLocationFormats.ToArray();
            ViewLocationFormats = viewLocationFormats.ToArray();
            PartialViewLocationFormats = ViewLocationFormats;
            AreaPartialViewLocationFormats = AreaViewLocationFormats;
        }
    }

    public class TwoLevelViewCache : IViewLocationCache
    {
        private readonly static object s_key = new object();
        private readonly IViewLocationCache _cache;

        public TwoLevelViewCache(IViewLocationCache cache)
        {
            _cache = cache;
        }

        private static IDictionary<string, string> GetRequestCache(HttpContextBase httpContext)
        {
            var d = httpContext.Items[s_key] as IDictionary<string, string>;
            if (d == null)
            {
                d = new Dictionary<string, string>();
                httpContext.Items[s_key] = d;
            }
            return d;
        }

        public string GetViewLocation(HttpContextBase httpContext, string key)
        {
            var d = GetRequestCache(httpContext);
            string location;
            if (!d.TryGetValue(key, out location))
            {
                location = _cache.GetViewLocation(httpContext, key);
                d[key] = location;
            }
            return location;
        }

        public void InsertViewLocation(HttpContextBase httpContext, string key, string virtualPath)
        {
            _cache.InsertViewLocation(httpContext, key, virtualPath);
        }
    }
}
