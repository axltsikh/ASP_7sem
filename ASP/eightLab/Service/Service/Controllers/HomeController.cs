using Service.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Service.Controllers
{
    //[System.Web.Http.RoutePrefix("api/Home")]
    [EnableCors(origins: "https://localhost:44371",headers:"*",methods:"*",SupportsCredentials =true)]
    public class HomeController : ApiController
    {
        private static bool ignoreMethods = false;
        //[HttpPost]
        //public ResJsonRPC SetM([FromBody] ReqJsonRPC jsonreq)
        //{
        //    //Debug.WriteLine(jsonreq.ToString());
        //    //Debug.WriteLine("method: " + jsonreq.Method);
        //    //string name = jsonreq.Params[0].ToString();
        //    //int value = int.Parse(jsonreq.Params[1].ToString());
        //    //Debug.WriteLine(jsonreq.Params[1]);
        //    //HttpContext.Current.Session.Add(name,value);
        //    Debug.WriteLine("SetM: " + HttpContext.Current.Session.SessionID.ToString());

        //    HttpContext.Current.Session[jsonreq.Params[0].ToString()] = jsonreq.Params[1];
        //    var response = new ResJsonRPC(
        //        jsonreq.Id,
        //        jsonreq.Jsonrpc,
        //        jsonreq.Method,
        //        int.Parse(HttpContext.Current.Session[jsonreq.Params[0].ToString()].ToString())
        //        );

        //    return response;
        //}

        //[HttpPost]
        //public ResJsonRPC GetM([FromBody] ReqJsonRPC jsonreq)
        //{
        //    Debug.WriteLine("GetM: " + HttpContext.Current.Session.SessionID.ToString());
        //    var response = new ResJsonRPC(
        //        jsonreq.Id,
        //        jsonreq.Jsonrpc,
        //        jsonreq.Method,
        //        int.Parse(HttpContext.Current.Session[jsonreq.Params[0].ToString()].ToString())
        //        );
        //    return response;
        //}

        //[HttpPost]
        //public ResJsonRPC AddM([FromBody] ReqJsonRPC jsonreq)
        //{
        //    int buffer = int.Parse(HttpContext.Current.Session[jsonreq.Params[0].ToString()].ToString());
        //    buffer += jsonreq.Params[1];
        //    HttpContext.Current.Session[jsonreq.Params[0].ToString()] = buffer;
        //    var response = new ResJsonRPC(
        //        jsonreq.Id,
        //        jsonreq.Jsonrpc,
        //        jsonreq.Method,
        //        int.Parse(HttpContext.Current.Session[jsonreq.Params[0].ToString()].ToString())
        //        );

        //    return response;
        //}

        //[HttpPost]
        //public ResJsonRPC SubM([FromBody] ReqJsonRPC jsonreq)
        //{
        //    int buffer = int.Parse(HttpContext.Current.Session[jsonreq.Params[0].ToString()].ToString());
        //    buffer -= jsonreq.Params[1];
        //    HttpContext.Current.Session[jsonreq.Params[0].ToString()] = buffer;
        //    var response = new ResJsonRPC(
        //        jsonreq.Id,
        //        jsonreq.Jsonrpc,
        //        jsonreq.Method,
        //        int.Parse(HttpContext.Current.Session[jsonreq.Params[0].ToString()].ToString())
        //        );

        //    return response;
        //}

        //[HttpPost]
        //public ResJsonRPC MulM([FromBody] ReqJsonRPC jsonreq)
        //{
        //    int buffer = int.Parse(HttpContext.Current.Session[jsonreq.Params[0].ToString()].ToString());
        //    buffer *= jsonreq.Params[1];
        //    HttpContext.Current.Session[jsonreq.Params[0].ToString()] = buffer;
        //    var response = new ResJsonRPC(
        //        jsonreq.Id,
        //        jsonreq.Jsonrpc,
        //        jsonreq.Method,
        //        int.Parse(HttpContext.Current.Session[jsonreq.Params[0].ToString()].ToString())
        //        );
        //    HttpContext.Current.Response.StatusCode = 200;
        //    return response;
        //}

        //[HttpPost]
        //public ResJsonRPC DivM([FromBody] ReqJsonRPC jsonreq)
        //{

        //    int buffer = int.Parse(HttpContext.Current.Session[jsonreq.Params[0].ToString()].ToString());
        //    buffer /= jsonreq.Params[1];
        //    HttpContext.Current.Session[jsonreq.Params[0].ToString()] = buffer;
        //    var response = new ResJsonRPC(
        //       jsonreq.Id,
        //       jsonreq.Jsonrpc,
        //       jsonreq.Method,
        //       int.Parse(HttpContext.Current.Session[jsonreq.Params[0].ToString()].ToString())
        //       );
        //    return response;
        //}


        [HttpPost]
        public IJsonResponse[] executeBatch([FromBody] ReqJsonRPC[] jsonreq)
        {

            IJsonResponse response;
            IJsonResponse[] buffer = new IJsonResponse[jsonreq.Length];
            int counter = 0;

            foreach (var a in jsonreq)
            {
                if (a == null)
                {
                    response = getError(a, -32700, "Parse error	");
                }
                if (a.Id == null || a.Jsonrpc == null || a.Params == null)
                {
                    response = getError(a, -32602, "Invalid params");
                }
                try
                {
                    switch (a.Method)
                    {
                        case "SetM":
                            {
                                response = Methods.SetM(a);
                                break;
                            }
                        case "GetM":
                            {
                                response = Methods.GetM(a);
                                break;
                            }
                        case "AddM":
                            {
                                response = Methods.AddM(a);
                                break;
                            }
                        case "SubM":
                            {
                                response = Methods.SubM(a);
                                break;
                            }
                        case "MulM":
                            {
                                response = Methods.MulM(a);
                                break;
                            }
                        case "DivM":
                            {
                                response = Methods.DivM(a);
                                break;
                            }
                        default:
                            {
                                response = getError(a, -32601, "Method not found");
                                break;
                            }
                    }
                }
                catch (Exception e)
                {
                    if (e is IndexOutOfRangeException)
                    {
                        response = getError(a, -32602, "Invalid params");
                    }
                    response = getError(a, -32603, "Internal error");
                }
                buffer[counter] = response;
                counter++;
            }
            return buffer;
        }

        [HttpPost]
        public IJsonResponse executeSingle([FromBody] ReqJsonRPC a)
        {
            if (ignoreMethods)
            {
                return getError(a, -32001, "ErrorExit was executed");
            }

            IJsonResponse response = new ResJsonRPC();
            if (a == null)
            {
                return getError(a, -32700, "Parse error	");
            }
            if (a.Id == null || a.Jsonrpc == null || a.Params == null)
            {
                return getError(a, -32602, "Invalid params");
            }
            try
            {
                switch (a.Method)
                {
                    case "SetM":
                        {
                            response = Methods.SetM(a);
                            break;
                        }
                    case "GetM":
                        {
                            response = Methods.GetM(a);
                            break;
                        }
                    case "AddM":
                        {
                            response = Methods.AddM(a);
                            break;
                        }
                    case "SubM":
                        {
                            response = Methods.SubM(a);
                            break;
                        }
                    case "MulM":
                        {
                            response = Methods.MulM(a);
                            break;
                        }
                    case "DivM":
                        {
                            response = Methods.DivM(a);
                            break;
                        }
                    case "ErrorExit":
                        {
                            response = ErrorExit();
                            break;
                        }
                    default:
                        {
                            response = getError(a, -32601, "Method not found");
                            break;
                        }
                }
            }
            catch(Exception e)
            {
                if (e is IndexOutOfRangeException)
                {
                    return getError(a, -32602, "Invalid params");
                }
                return getError(a, -32603, "Internal error");
            }
            return response;
        }

        private ErrorJsonRPC getError(ReqJsonRPC a, int code, string message)
        {
            return a == null ? new ErrorJsonRPC("0", "0", new Error(code, message)) : new ErrorJsonRPC(a.Id, a.Jsonrpc, new Error(code, message));
        }

        private static IJsonResponse ErrorExit()
        {
            HttpContext.Current.Application.Clear();
            var response = new ResJsonRPC(
                "",
                "",
                "",
                -1
                );
            ignoreMethods = true;
            return response;
        }



    }
}