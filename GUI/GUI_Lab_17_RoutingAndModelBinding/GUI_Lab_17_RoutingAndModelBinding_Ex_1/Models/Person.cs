using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GUI_Lab_17_RoutingAndModelBinding_Ex_1.Models
{
    public class Person
    {
        public Person()
        {

        }
        public Person(string name, int age, double height)
        {
            Name_ = name;
            Age_ = age;
            Height_ = height;
        }

        public string Name_ { get; set; }
        public int Age_ { get; set; }
        public double Height_ { get; set; }
    }
}
