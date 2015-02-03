using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assignment10
{
    class ReadFile
    {
        private StreamReader reader;
        string filePath = null;
        //constructor
        public ReadFile(string path)
        {
            filePath = path;//assign the path that is passed in to the variable
            
        }

        //method
        public string GetFile()
        {
            string line = null;
            try
            {
                reader = new StreamReader(filePath);//no true/false here because we aren't adding anything, just reading.
                line = reader.ReadToEnd();//ReadToEnd will read the entire file from beginning to end, losing formatting
            }
            catch(FileNotFoundException fnf)//you can have as many catches as you want
            {
                throw fnf;
            }
            catch(Exception ex)//this cathches everything else
            {
                throw ex;
            }
            
            return line;
        }
    }
}
