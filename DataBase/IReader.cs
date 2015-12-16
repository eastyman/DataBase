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
        void Read(string file); // Метод считывания данных        
    }
}
