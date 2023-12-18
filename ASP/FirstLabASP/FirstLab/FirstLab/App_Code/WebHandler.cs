using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstLab.App_Code
{
    public class WebHandler : IHttpHandler
    {
        int result = 0;
        Stack<int> addValues = new Stack<int>();
        public bool IsReusable { get { return true;  } }

        public void ProcessRequest(HttpContext context)
        {
            switch (context.Request.RequestType)
            {
                case "GET": {
                        if (addValues.Count > 0){
                            context.Response.Write(result + addValues.Peek());
                        }
                        else
                        {
                            context.Response.Write(result);
                        }
                        context.Response.End();
                        break;
                    }
                case "POST": {
                        int buffer = int.Parse(context.Request.QueryString["RESULT"].ToString());
                        context.Response.Write(buffer);
                        result+=buffer;
                        break;
                    }
                case "PUT": {
                        int buffer = int.Parse(context.Request.QueryString["ADD"].ToString());
                        addValues.Push(buffer);
                        break;
                    }
                case "DELETE": {
                        if (addValues.Count > 0)
                        {
                            addValues.Pop();
                        }
                        break;
                    }
            }
        }
    }
}