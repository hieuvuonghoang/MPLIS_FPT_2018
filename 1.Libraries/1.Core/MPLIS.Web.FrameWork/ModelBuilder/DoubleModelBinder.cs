using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MPLIS.Web.FrameWork.ModelBuilder
{
    public class DoubleBinder : DefaultModelBinder
    {
        public override object BindModel(System.Web.Mvc.ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (!string.IsNullOrEmpty(bindingContext.ModelMetadata.EditFormatString) && bindingContext.ModelMetadata.EditFormatString.Contains("{0:N}"))
            {
                var provider = new NumberFormatInfo();
                provider.NumberDecimalSeparator = ".";
                provider.NumberGroupSeparator = ",";
                provider.NumberGroupSizes = new int[] { 3 };
                return value == null ? base.BindModel(controllerContext, bindingContext) : Convert.ToDouble(value.AttemptedValue, provider);
            }
            return base.BindModel(controllerContext, bindingContext);
        }
    }
    public class NullableDoubleBinder : DefaultModelBinder
    {
        public override object BindModel(System.Web.Mvc.ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (value != null)
            {
                if (!string.IsNullOrEmpty(bindingContext.ModelMetadata.EditFormatString) && bindingContext.ModelMetadata.EditFormatString.Contains("{0:N}"))
                {
                    var provider = new NumberFormatInfo();
                    provider.NumberDecimalSeparator = ".";
                    provider.NumberGroupSeparator = ",";
                    provider.NumberGroupSizes = new int[] { 3 };
                    return value == null ? base.BindModel(controllerContext, bindingContext) : Convert.ToDouble(value.AttemptedValue, provider);
                }
                return base.BindModel(controllerContext, bindingContext);
            }
            return null;
        }
    }
}
