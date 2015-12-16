using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public abstract class Writer : IWriter // Реализация базовой логики для записи данных
    {
        public List<Employee> Data { protected get; set; }
        public abstract void Write(string file);
    }
}
