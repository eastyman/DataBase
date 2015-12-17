using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace DataBase
{
    class BINReader : Reader
    {
        public override void Read()
        {
            BinaryFormatter formatter = new BinaryFormatter();
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
