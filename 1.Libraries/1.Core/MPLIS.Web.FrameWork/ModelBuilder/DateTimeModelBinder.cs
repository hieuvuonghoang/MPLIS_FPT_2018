using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MPLIS.Web.FrameWork.ModelBuilder
{
    public class DateTimeBinder : IModelBinder
    {
        public object BindModel(System.Web.Mvc.ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (!string.IsNullOrEmpty(bindingContext.ModelMetadata.EditFormatString) && bindingContext.ModelMetadata.EditFormatString.Contains("dd/MM/yyyy"))
            {
                var date = value.ConvertTo(typeof(DateTime), CultureInfo.GetCultureInfo("en-GB"));
                return date;
            }
            else
            {
                //return value.ConvertTo(typeof(DateTime));
                var date = value.ConvertTo(typeof(DateTime), CultureInfo.GetCultureInfo("vi-VN"));
                return date;
            }
        }
    }
    public class NullableDateTimeBinder : IModelBinder
    {
        public object BindModel(System.Web.Mvc.ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (value != null)
            {
                if (!string.IsNullOrEmpty(bindingContext.ModelMetadata.EditFormatString) && bindingContext.ModelMetadata.EditFormatString.Contains("dd/MM/yyyy"))
                {
                    var date = value.ConvertTo(typeof(DateTime), CultureInfo.GetCultureInfo("en-GB"));
                    return date;
                }
                else
                {

                    // return value.ConvertTo(typeof(DateTime));
                    var date = value.ConvertTo(typeof(DateTime), CultureInfo.GetCultureInfo("vi-VN"));
                    return date;
                }
            }
            return null;
        }
    }
}
