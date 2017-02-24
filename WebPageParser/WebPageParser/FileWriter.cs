using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPageParser
{
    class FileWriter : IFileWriter
    {
        Logger logger = LogManager.GetLogger("fileLogger");
        public void AppendText(string filePath, string contents)
        {
            try
            {
                File.AppendAllText(filePath, contents);
            }
            catch (Exception e)
            {
                logger.Error("Exception {0}", e.ToString());
            }
        }

        public void CreateFile(string filePath)
        {
            try
            {
                File.Create(filePath);
            }
            catch (Exception e)
            {
                logger.Error("Exception {0}", e.ToString());
            }
        }
    }
}
