using Autofac;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac.Integration.Mvc;
namespace MPLIS.Web.FrameWork.PluginManager
{
    public static class MPLISStartUp
    {
        private const string _pluginPath_view = "Modules";
        private const string _pluginPath_dll = "bin";

        private static readonly string _fullPluginPath_view = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _pluginPath_view);
        private static readonly string _fullPluginPath_dll = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _pluginPath_dll);
        private const string _defaultMaster = "Site";
        private const string _defaultRazorMaster = "_Layout";

        public static void Load()
        {
            //Container container = new Container();
            //container.
            AppDomain.CurrentDomain.AssemblyResolve += PluginAssemblyResolve;
            //Listtask startup
            List<IStartupTask> startupTasks = new List<IStartupTask>();
            Assembly asm = Assembly.GetExecutingAssembly();
            //------------------------------
            var assemblies = new List<Assembly>();
            List<string> pluginsName = new List<string>();
            foreach (var file in Directory.EnumerateFiles(_fullPluginPath_dll, "MPLIS.Modules.*.dll"))
            {
                try
                {
                    if (File.Exists(file))
                    {
                        // load the assembly
                        assemblies.Add(Assembly.LoadFile(file));
                        asm = Assembly.LoadFrom(file);
                        pluginsName.Add(asm.GetName().Name);
                        // get all types from the assembly that inherit IStartupTask
                        var query = from t in asm.GetTypes()
                                    where t.IsClass && t.GetInterface(typeof(IStartupTask).FullName) != null
                                    select t;

                        // add types to list of startup tasks
                        foreach (Type type in query)
                        {
                            startupTasks.Add((IStartupTask)Activator.CreateInstance(type));
                        }
                    }
                }
                catch (Exception ex)
                {
                    //Exceptions.LogException(ex);
                }

            }
            foreach (IStartupTask task in startupTasks)
            {
                task.Execute();
            }
            //  plugins discovery
            var plugins = new List<IMPLISPlugin>();
            foreach (IMPLISPlugin plugin in ServiceLocator.Current.GetAllInstances<IMPLISPlugin>())
            {
                plugins.Add(plugin);
                plugin.RegisterRoutes(RouteTable.Routes);
            }

            // Register ControllerFactory with site
            IControllerFactory myControllerFactory = new MPLISControllerFactory();
            ControllerBuilder.Current.SetControllerFactory(myControllerFactory);

            // Setup ViewEngines
            //var myWebFormViewEngine =
            //    new MyWebFormViewEngine(_pluginPath_view, pluginsName, _defaultMaster);

            var myRazorViewEngine =
                new MPLISRazorViewEngine(_pluginPath_view, pluginsName, _defaultRazorMaster);

            // Register ViewEngines with site
            ViewEngines.Engines.Clear();
            //ViewEngines.Engines.Add(myWebFormViewEngine);
            myRazorViewEngine.ViewLocationCache = new TwoLevelViewCache(myRazorViewEngine.ViewLocationCache);
            ViewEngines.Engines.Add(myRazorViewEngine);
        }


        private static Assembly PluginAssemblyResolve(object sender, ResolveEventArgs resolveArgs)
        {
            var currentAssemblies = AppDomain.CurrentDomain.GetAssemblies();
            // Check we don't already have the assembly loaded
            foreach (Assembly assembly in currentAssemblies)
            {
                if (assembly.FullName == resolveArgs.Name || assembly.GetName().Name == resolveArgs.Name)
                    return assembly;
            }

            // Load from directory
            return LoadAssemblyFromPath(resolveArgs.Name, _fullPluginPath_dll);
        }

        private static Assembly LoadAssemblyFromPath(string assemblyName, string directoryPath)
        {
            foreach (string file in Directory.GetFiles(directoryPath))
            {
                Assembly assembly;

                if (TryLoadAssemblyFromFile(file, assemblyName, out assembly))
                    return assembly;
            }

            return null;
        }

        private static bool TryLoadAssemblyFromFile(string file, string assemblyName, out Assembly assembly)
        {
            try
            {
                // Convert the filename into an absolute file name for use with LoadFile. 
                file = new FileInfo(file).FullName;

                if (AssemblyName.GetAssemblyName(file).Name == assemblyName)
                {
                    assembly = Assembly.LoadFile(file);
                    return true;
                }
            }
            catch
            {
            }

            assembly = null;
            return false;
        }
    }
}
