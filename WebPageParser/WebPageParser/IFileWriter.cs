using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPageParser
{
   public interface IFileWriter
    {
        void CreateFile(string filePath);
        void AppendText(string filePath, string contents);
    }
}
