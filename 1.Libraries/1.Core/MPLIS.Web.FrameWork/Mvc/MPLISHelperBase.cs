using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MPLIS.Web.FrameWork.Mvc
{
    public abstract class MPLISHelperBase : IHtmlString
    {
        protected MPLISHelperBase()
        {
        }
        private string Do()
        {
            return this.Render();
        }
        internal abstract string Render();
        public string ToHtmlString()
        {
            return this.Do();
        }
        public override string ToString()
        {
            return this.Do();
        }
    }
}
