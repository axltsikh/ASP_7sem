using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WcfServiceLibrary3;

namespace TcpEndpoint
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(Service));
            NetTcpBinding binding = new NetTcpBinding();
            host.AddServiceEndpoint(typeof(IService), binding, new Uri("net.tcp://localhost:5002/service"));
            host.Open();
            Console.WriteLine("TCP endpoint started");
            Console.Read();
        }
    }
}
