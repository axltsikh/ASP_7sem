using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary3
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде и файле конфигурации.
    public class Service : IService
    {
        public int Add(int x, int y)
        {
            return x + y;
        }
        public string Concat(string s, double d)
        {
            return s + d.ToString();
        }
        public A Sum(A a1, A a2)
        {
            a1.S += a2.S;
            a1.F += a2.F;
            a1.K += a2.K;
            return a1;
        }

    }
}
