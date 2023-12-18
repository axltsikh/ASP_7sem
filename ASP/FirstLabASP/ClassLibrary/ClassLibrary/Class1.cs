using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web;

namespace ClassLibrary
{
    public class WebHandler:IHttpHandler
    {
        int result = 0;
        Stack<int> addValues = new Stack<int>();
        public bool IsReusable { get { return true; } }

        public void ProcessRequest(HttpContext context)
        {
            switch (context.Request.RequestType)
            {
                case "GET":
                    {
                        context.Response.ContentType = "application/json; charset=utf-8";

                        if (addValues.Count > 0)
                        {
                            int ResultValue = result + addValues.Peek();
                            context.Response.Write(JsonConvert.SerializeObject(ResultValue));
                        }
                        else
                        {
                            int ResultValue = result;
                            context.Response.Write(JsonConvert.SerializeObject(ResultValue));
                        }
                        context.Response.End();
                        break;
                    }
                case "POST":
                    {
                        int buffer = int.Parse(context.Request.QueryString["RESULT"].ToString());
                        context.Response.Write(buffer);
                        result += buffer;
                        break;
                    }
                case "PUT":
                    {
                        int buffer = int.Parse(context.Request.QueryString["ADD"].ToString());
                        addValues.Push(buffer);
                        context.Response.Write(buffer);
                        break;
                    }
                case "DELETE":
                    {
                        if (addValues.Count > 0)
                        {
                            context.Response.Write(1);
                            addValues.Pop();
                        }
                        else
                        {
                            context.Response.Write(0);
                        }
                        break;
                    }
            }
        }
    }
}
