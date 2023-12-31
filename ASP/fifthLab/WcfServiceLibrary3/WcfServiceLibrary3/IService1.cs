﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary3
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IService1" в коде и файле конфигурации.
    [ServiceContract]
    public interface IService
    {

        [OperationContract]
        int Add(int x, int y);
        [OperationContract]
        string Concat(string s, double d);
        [OperationContract]
        A Sum(A a1, A a2);

    }

    [DataContract]
    public class A
    {
        string s;
        int k;
        float f;
        [DataMember]
        public string S { get; set; }
        [DataMember]
        public int K { get; set; }
        [DataMember]
        public float F { get; set; }
    }
  

}
