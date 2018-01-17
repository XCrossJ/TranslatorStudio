using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTranslatorStudio.Utilities
{
    public static class OnlineStudioHelper
    {
        public static IHtmlString ToJson(this HtmlHelper helper, object obj)
        {
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            settings.Converters.Add(new JavaScriptDateTimeConverter());
            return helper.Raw(JsonConvert.SerializeObject(obj, settings));
        }

        public static string ToJson(object obj)
        {
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            settings.Converters.Add(new JavaScriptDateTimeConverter());
            return JsonConvert.SerializeObject(obj, settings);
        }
    }
}