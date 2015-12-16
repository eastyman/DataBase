using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace DataBase
{
    class XMLWriter:Writer
    {
        public override void Write(string file)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<Employee>));
            using (FileStream fs = new FileStream(file, FileMode.Open))
            {
                formatter.Serialize(fs, Data);
            }
        }
    }
}
