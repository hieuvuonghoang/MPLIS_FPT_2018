using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPLIS.Web.FrameWork.PluginManager
{
    public interface IStartupTask
    {
        void Execute();
    }
}
