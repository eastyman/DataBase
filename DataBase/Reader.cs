using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public abstract class Reader : IReader // Реализация базовой логики для считывания данных
    {
        public List<Employee> Data { get; protected set; }
        public abstract void Read(string file);
    }
}
