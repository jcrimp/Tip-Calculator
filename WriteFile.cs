using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assignment10
{
    class WriteFile
    {
        StreamWriter writer;

        //constructor
        public WriteFile(string path)
        {
            writer = new StreamWriter(path, false);
        }

        //methods
        public void AddToFile(string result)
        {
            writer.WriteLine(result);
        }

        public void CloseFile()
        {
            writer.Close();
        }
    }
}
