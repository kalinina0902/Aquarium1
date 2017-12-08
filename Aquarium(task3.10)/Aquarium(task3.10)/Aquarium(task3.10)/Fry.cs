using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquarium_task3._10_
{
    class Fry:Dweller
    {
        private string kind;
        private int age;
        public string Kind { get { return kind; } set { kind = value; } }
        public int Age { get { return age; } set { age = value; } }
        public Fry(int age,string kind)
        {
            this.Age = age;
            this.Kind = kind;
        }
        public void Create()
        {
            
        }
    }
}
