using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dispose
{
    public class Writer : IDisposable 
    {
        private string _path;
        private StreamWriter _file;

        public Writer(string path)
        {
            _path = path;
            _file = new StreamWriter(path);
        }

        public void Dispose()
        {
            _file.Close();
        }

        public void Write(string texto)
        {
            _file.WriteLine(texto);
        }
  
    }
}
