using ServerEntities;

using System;
using System.Collections.Generic;
using System.Text;

namespace ServerCore.Responses
{
    public class ResponseGenerator
    {
        public static Response MakeRequestErrorResponse(Exception ex, bool debugMode)
        {
            var response = Response.EmptyResponse;
            response.Status = StatusCode.BadRequest;
            response.Body = debugMode ? ex.ToString() : "Error Occured";
            return response;
        }
    }
}
