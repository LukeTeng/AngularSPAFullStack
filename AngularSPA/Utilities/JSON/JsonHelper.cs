using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;


namespace AngularSPA.Utilities.JSON
{
    public static class JsonHelper
    {
        static readonly JsonSerializerSettings settings = new JsonSerializerSettings()
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };

        public static string GetCamelCaseJsonString(object responseBody)
        {
            if (responseBody == null)
            {
                return string.Empty;
            }
            return JsonConvert.SerializeObject(responseBody, settings);
        }

    }
}


