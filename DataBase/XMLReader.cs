using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace DataBase
{
    class XMLReader:Reader
    {
        public override void Read(string file)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<Employee>));
            FileInfo fileInfo = new FileInfo(file);
            if (fileInfo.Exists)                
            {
                if (fileInfo.Length > 0)
                {
                    using (FileStream fs = new FileStream(file, FileMode.Open))
                    {
                        Data = (List<Employee>)formatter.Deserialize(fs);
                    }
                }
            }            
        }
    }
}
