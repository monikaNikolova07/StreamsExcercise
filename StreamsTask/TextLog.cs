using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamsTask
{
    public class TextLog
    {
        private string filePath;
        public TextLog(string filePath)
        {
            this.filePath = filePath;
        }

        public void Log(string message)
        {
            File.AppendAllText(filePath, message + Environment.NewLine);
        }
    }
}
