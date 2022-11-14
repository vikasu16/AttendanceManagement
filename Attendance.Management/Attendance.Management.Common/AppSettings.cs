using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attendance.Management.Common
{
    public sealed class AppSettings
    {
        private static AppSettings instance;
        private static readonly object padlock = new object();

        public static AppSettings Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        var baseDir = AppDomain.CurrentDomain.BaseDirectory;
                        baseDir = baseDir.Replace(@"bin\Debug\net5.0\", @"");

                        string settingsFile = Path.Combine(baseDir, "appsettings.json");

                        instance = JsonConvert.DeserializeObject<AppSettings>(File.ReadAllText(settingsFile));
                    }
                    return instance;
                }
            }
        }

        public ConnectionStrings ConnectionStrings { get; set; }
        public Logging Logging { get; set; }
        public JWT JWT { get; set; }
        public string AllowedHosts { get; set; }
    }

    public class ConnectionStrings
    {
        public string AttendanceSystem { get; set; }
    }

    public class LogLevel
    {
        public string Default { get; set; }
    }

    public class Logging
    {
        public LogLevel LogLevel { get; set; }
    }

    public class JWT
    {
        public string ValidIssuer { get; set; }
        public string Secret { get; set; }
    }
}
