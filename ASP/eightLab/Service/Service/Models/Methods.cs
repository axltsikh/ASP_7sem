using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Service.Models
{
    public class Methods
    {
        public static IJsonResponse SetM(ReqJsonRPC jsonreq)
        {
            HttpContext.Current.Session[jsonreq.Params[0].ToString()] = jsonreq.Params[1];
            var response = new ResJsonRPC(
                jsonreq.Id,
                jsonreq.Jsonrpc,    
                jsonreq.Method,
                int.Parse(HttpContext.Current.Session[jsonreq.Params[0].ToString()].ToString())
                );

            return response;
        }
        private static ErrorJsonRPC getError(ReqJsonRPC a, int code, string message)
        {
            return a == null ? new ErrorJsonRPC("0", "0", new Error(code, message)) : new ErrorJsonRPC(a.Id, a.Jsonrpc, new Error(code, message));
        }
        public static IJsonResponse GetM(ReqJsonRPC jsonreq)
        {
            if (HttpContext.Current.Session[jsonreq.Params[0].ToString()] == null)
            {
                return getError(jsonreq, -32002, "No entry with that key");
            }
            if (HttpContext.Current.Session[jsonreq.Params[0].ToString()] == null)
            {
                return getError(jsonreq, -32002, "");
            }
            Debug.WriteLine("GetM: " + HttpContext.Current.Session.SessionID.ToString());
            var response = new ResJsonRPC(
                jsonreq.Id,
                jsonreq.Jsonrpc,
                jsonreq.Method,
                int.Parse(HttpContext.Current.Session[jsonreq.Params[0].ToString()].ToString())
                );
            return response;
        }

        public static IJsonResponse AddM(ReqJsonRPC jsonreq)
        {
            if (HttpContext.Current.Session[jsonreq.Params[0].ToString()] == null)
            {
                return getError(jsonreq, -32002, "No entry with that key");
            }
            int buffer = int.Parse(HttpContext.Current.Session[jsonreq.Params[0].ToString()].ToString());
            buffer += jsonreq.Params[1];
            HttpContext.Current.Session[jsonreq.Params[0].ToString()] = buffer;
            var response = new ResJsonRPC(
                jsonreq.Id,
                jsonreq.Jsonrpc,
                jsonreq.Method,
                int.Parse(HttpContext.Current.Session[jsonreq.Params[0].ToString()].ToString())
                );

            return response;
        }

        public static IJsonResponse SubM(ReqJsonRPC jsonreq)
        {
            if (HttpContext.Current.Session[jsonreq.Params[0].ToString()] == null)
            {
                return getError(jsonreq, -32002, "No entry with that key");
            }
            int buffer = int.Parse(HttpContext.Current.Session[jsonreq.Params[0].ToString()].ToString());
            buffer -= jsonreq.Params[1];
            HttpContext.Current.Session[jsonreq.Params[0].ToString()] = buffer;
            var response = new ResJsonRPC(
                jsonreq.Id,
                jsonreq.Jsonrpc,
                jsonreq.Method,
                int.Parse(HttpContext.Current.Session[jsonreq.Params[0].ToString()].ToString())
                );

            return response;
        }

        public static IJsonResponse MulM(ReqJsonRPC jsonreq)
        {
            if (HttpContext.Current.Session[jsonreq.Params[0].ToString()] == null)
            {
                return getError(jsonreq, -32002, "No entry with that key");
            }
            int buffer = int.Parse(HttpContext.Current.Session[jsonreq.Params[0].ToString()].ToString());
            buffer *= jsonreq.Params[1];
            HttpContext.Current.Session[jsonreq.Params[0].ToString()] = buffer;
            var response = new ResJsonRPC(
                jsonreq.Id,
                jsonreq.Jsonrpc,
                jsonreq.Method,
                int.Parse(HttpContext.Current.Session[jsonreq.Params[0].ToString()].ToString())
                );
            HttpContext.Current.Response.StatusCode = 200;
            return response;
        }

        public static IJsonResponse DivM(ReqJsonRPC jsonreq)
        {
            if (HttpContext.Current.Session[jsonreq.Params[0].ToString()] == null)
            {
                return getError(jsonreq, -32002, "No entry with that key");
            }
            int buffer = int.Parse(HttpContext.Current.Session[jsonreq.Params[0].ToString()].ToString());
            buffer /= jsonreq.Params[1];
            HttpContext.Current.Session[jsonreq.Params[0].ToString()] = buffer;
            var response = new ResJsonRPC(
               jsonreq.Id,
               jsonreq.Jsonrpc,
               jsonreq.Method,
               int.Parse(HttpContext.Current.Session[jsonreq.Params[0].ToString()].ToString())
               );
            return response;
        }

    }
}