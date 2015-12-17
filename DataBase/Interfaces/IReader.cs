using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public interface IReader
    {
        List<Employee> Data { get; } // Свойство для храннения считанных данных
        string FileName { get; set; }
        void Read(); // Метод считывания данных        
    }
}
