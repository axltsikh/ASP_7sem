using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WcfServiceLibrary3;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(Service));
            host.Open();
            Console.WriteLine("Service hosted successfully");
            Console.Read();
        }
    }
}
