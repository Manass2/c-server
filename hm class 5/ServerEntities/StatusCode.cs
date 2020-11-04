using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ServerEntities
{
    public enum StatusCode
    {
        [Description("OK")]
        OK = 200,

        [Description("Created")]
        Created = 201,

        [Description("No Content")]
        NoContent = 204,

        [Description("Not Modified")]
        NotModified = 304,

        [Description("Bad Request")]
        BadRequest = 400,

        [Description("Unauthorized")]
        Unauthorized = 401,

        [Description("Forbidden")]
        Forbidden = 403,

        [Description("Not Found")]
        NotFound = 404,

        [Description("Server Error")]
        ServerError = 500,

        [Description("Invalid")]
        Invalid = 0
    }

    public static class StatusCodes
    {
        public static string GetDescription(this StatusCode statusCode)
        {
            return typeof(StatusCode)
                .GetMember(statusCode.ToString())
                .First()
                .GetCustomAttribute<DescriptionAttribute>()
                ?.Description ?? string.Empty;
        }

        /*
                void Main()
                {
	                var weko = GetWeko();
	                // var w2 = (weko != null) ? weko.ToUpper() : null;
	                var w2 = weko?.ToUpper();
	
	                // var w3 = (w2 != null) ? w2 : "DEFAULT";
	                var w3 = w2 ?? "DEFAULT";
	
	                w3.Dump();
                }

                string GetWeko() {
	                Random r = new Random();
	                return (r.NextDouble() > 0.5) ? "Wekoslav" : null;
                }
         
         
         */
    }


}