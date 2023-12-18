using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceReference1.ServiceClient httpClient = new ServiceReference1.ServiceClient();
            Console.WriteLine("Add result: " + httpClient.Add(15, 25));
            Console.WriteLine("Concat result: " + httpClient.Concat("Concat", 25.5));
            ServiceReference1.A a1 = new ServiceReference1.A();
            a1.F = 0.5f;
            a1.S = "a1String";
            a1.K = 15;
            ServiceReference1.A a2 = new ServiceReference1.A();
            a2.F = 1.5f;
            a2.S = "a2String";
            a2.K = 30;
            ServiceReference1.A result = httpClient.Sum(a1, a2);
            Console.WriteLine("Sum result: ");
            Console.WriteLine("S: " + result.S);
            Console.WriteLine("K: " + result.K);
            Console.WriteLine("F: " + result.F);
            Console.Read();

        }
    }
}
