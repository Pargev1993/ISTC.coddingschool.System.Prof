﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISTC.codingschool.OOP.Attributes
{
    [AttInfo("Coustomor",Code =15)]
  public  class User:System.Attribute
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public User(string n,int a)
        {
            Name = n;
            Age = a;
        }
        private int Payment(int hours, int perhour)
        {
            return hours * perhour;
        }
    }
}