using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    [Serializable]
    public class Employee
    {
        public int num;
        public string name;
        public int age;
        public string job;
        public Employee() { }
        public Employee(int num, string name, int age, string job)
        {
            this.num = num;
            this.name = name;
            this.age = age;
            this.job = job;
        }
    }
}
