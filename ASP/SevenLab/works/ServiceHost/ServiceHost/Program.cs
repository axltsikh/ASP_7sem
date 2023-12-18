﻿using SyndicationServiceLibrary2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace ServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri baseAddress = new Uri("http://localhost:8000/BlogService");
            WebServiceHost svcHost = new WebServiceHost(typeof(Feed1), baseAddress);
            svcHost.Open();
            Console.WriteLine("Host open");
            Console.ReadLine();
        }
    }
}
