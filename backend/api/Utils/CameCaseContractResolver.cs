using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.Utils
{
    public class CamelCaseContractResolver : DefaultContractResolver
    {
        protected override string ResolvePropertyName(string propertyName)
        {
            var firstChar = propertyName[0].ToString();
            return firstChar.ToLower() + propertyName.Substring(1, propertyName.Length - 1);
        }
    }
}