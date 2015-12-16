using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public interface IWriter
    {
        List<Employee> Data { set; } // Свойство для хранения данных, которые будут записываться
        void Write(string file); // Метод записи данных
    }
}
