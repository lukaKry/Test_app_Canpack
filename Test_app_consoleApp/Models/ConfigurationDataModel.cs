using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_app_consoleApp.Models
{
    public class ConfigurationDataModel
    {
        public ConnectionStrings connectionStrings { get; set; }
        public string inputFilePath { get; set; }
        public string mailToAddress { get; set; }
        public string time { get; set; }
        public string mailFromAddress { get; set; }
        public string smtpHostPassword { get; set; }


        public class ConnectionStrings
        {
            public string DefaultConnection { get; set; }
        }
    }
}
