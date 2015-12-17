using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class Driver
    {
        public Driver() { } // Конструктор по умолчанию
        public Driver(IReader reader, IWriter writer) // Конструктор для инъекции зависимостей
        {
            Reader = reader;
            Writer = writer;
        }
        public List<Employee> Data { get; set; }
        public string FileName { get; set; }
        public IReader Reader { get; set; } // Свойство для инъекции зависимости, которая представляет реализацию считывания данных
        public IWriter Writer { get; set; } // Свойство для инъекции зависимости, которая представляет реализацию записи данных

        public void Read()
        {
            Reader.FileName = FileName;
            Reader.Read();
            Data = Reader.Data;
        }

        public void Write()
        {
            Writer.FileName = FileName;
            Writer.Data = Data;
            Writer.Write();
        }
    }
}
