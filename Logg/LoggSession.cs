using System;
using System.Configuration;
using System.IO;
using System.Reflection;

namespace Logg
{
    sealed class LoggSession
    {
        public static WriteTo WriteTo
        {
            get
            {
                return
                    !string.IsNullOrEmpty(ConfigurationManager.AppSettings["WriteTo"])
                        ? (WriteTo)Enum.Parse(typeof(WriteTo), ConfigurationManager.AppSettings["WriteTo"], true)
                        : WriteTo.WriteToFile;
            }
        }

        public static string WriteToPath
        {
            get
            {
                string _writeToPath;

                if (string.IsNullOrEmpty(ConfigurationManager.AppSettings["WriteToPath"]))
                {
                    var assembly = Assembly.GetExecutingAssembly();
                    var local = Path.GetDirectoryName(assembly.Location);

                    _writeToPath = Path.Combine(local, "Dump");
                }
                else
                {
                    _writeToPath = Path.Combine(ConfigurationManager.AppSettings["WriteToPath"], "Dump");
                }

                if (!Directory.Exists(_writeToPath))
                    Directory.CreateDirectory(_writeToPath);

                return _writeToPath;
            }
        }

        public LoggSession() { }
    }
}
