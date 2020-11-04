using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ServerEntities
{
    public enum Method
    {
        Get,
        Post,
        Put,
        Patch,
        Delete,
        Options,
        Head,
        Unknown
    }

    public static class MethodResolver
    {
        public static Method FromString(string methodStr)
        {
            return methodStr switch
            {
                "GET" => Method.Get,
                "POST" => Method.Post,
                "PUT" => Method.Put,
                "PATCH" => Method.Patch,
                "OPTIONS" => Method.Options,
                "DELETE" => Method.Delete,
                "HEAD" => Method.Head,
                _ => Method.Unknown
            };
        }
    }
}
