using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AgentSqlMonitor
{
    public class IniFileReader
    {
        private readonly string _filePath;

        public IniFileReader(string filePath)
        {
            _filePath = filePath;
        }

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        private static extern int GetPrivateProfileString(string section, string key, string defaultValue, StringBuilder returnValue, int size, string filePath);

        public string Read(string section, string key, string defaultValue = "")
        {
            var returnValue = new StringBuilder(255);
            GetPrivateProfileString(section, key, defaultValue, returnValue, 255, _filePath);
            return returnValue.ToString();
        }
    }
}