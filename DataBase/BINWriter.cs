using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace DataBase
{
    class BINWriter:Writer
    {
        public override void Write(string file)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(file, FileMode.Open))
            {
                formatter.Serialize(fs, Data);
            }
        }
    }
}
