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
        public override void Read()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<Employee>));
            FileInfo fileInfo = new FileInfo(FileName);
            if (fileInfo.Exists)                
            {
                if (fileInfo.Length > 0)
                {
                    using (FileStream fs = new FileStream(FileName, FileMode.Open))
                    {
                        Data = (List<Employee>)formatter.Deserialize(fs);
                    }
                }
            }            
        }
    }
}
