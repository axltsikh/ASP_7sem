using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WcfServiceLibrary3;

namespace TcpClient
{
    class Program
    {
        static void Main(string[] args)
        {
            NetTcpBinding binding = new NetTcpBinding();
            EndpointAddress addr = new EndpointAddress("net.tcp://localhost:5002/service");
            ChannelFactory<IService> chn = new ChannelFactory<IService>(binding, addr);
            IService channel = chn.CreateChannel();
            Console.WriteLine("Add result: " + channel.Add(15, 25));
            Console.WriteLine("Concat result: " + channel.Concat("Concat", 25.5));
            A a1 = new A();
            a1.F = 0.5f;
            a1.S = "a1String";
            a1.K = 15;
            A a2 = new A();
            a2.F = 1.5f;
            a2.S = "a2String";
            a2.K = 30;
            A result = channel.Sum(a1, a2);
            Console.WriteLine("Sum result: ");
            Console.WriteLine("S: " + result.S);
            Console.WriteLine("K: " + result.K);
            Console.WriteLine("F: " + result.F);
            Console.Read();
        }
    }
}
