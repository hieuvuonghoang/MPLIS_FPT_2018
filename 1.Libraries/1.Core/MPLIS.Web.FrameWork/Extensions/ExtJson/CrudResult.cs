using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MPLIS.Web.FrameWork.Extensions
{
    public class CrudResult
    {
        private object _data;

        public bool State { get; set; }

        public string Message { get; set; }

        public object Data
        {
            get { return _data; }
            set
            {
                if (value != null)
                {
                    _data = value;
                    DataType = _data.GetType().ToString();
                }
            }
        }

        public string DataType { get; private set; }
    }
}
