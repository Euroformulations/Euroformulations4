using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Euroformulations4.Library
{
    public sealed class IniFileUnicode
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool WritePrivateProfileString
            (string section, string key, string value, string fileName);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        private static extern uint GetPrivateProfileString
            (string section, string key, string defaultValue,
            StringBuilder returnValue, uint size, string fileName);
        private string _fileName;

        public IniFileUnicode(string fileName)
        {
            _fileName = fileName;
        }

        public void Write(string section, string key, string value)
        {
            WritePrivateProfileString(section, key, value, _fileName);
        }

        public string Read(string section, string key)
        {
            StringBuilder stringBuilder = new StringBuilder(255);
            GetPrivateProfileString(section, key, string.Empty,
                stringBuilder, 255, _fileName);
            return stringBuilder.ToString();
        }
    }
    
}