using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace fourthLab
{
    public class A
    {
        public string s;
        public int k;
        public float f;
        public A(string _s,int _k, float _f)
        {
            s = _s;
            k = _k;
            f = _f;
        }
        public A()
        {
            s = "";
            k = 0;
            f = 0;
        }
    }
}