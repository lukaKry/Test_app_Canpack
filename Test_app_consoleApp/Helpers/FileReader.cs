using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Test_app_consoleApp.Services;

namespace Test_app_consoleApp.Helpers
{
    public static class FileReader
    {
        // private static readonly string filePath = @"C:\Efficiency\eff.xml";
        private static readonly string filePath = ConfigurationDataService.Instance.Data.inputFilePath;

        public static RejectDataResponse ReadRawData()
        {
            if (File.Exists(filePath))
            {
                using TextReader reader = new StreamReader(filePath);
                XmlSerializer serializer = new(typeof(RejectDataResponse));
                return (RejectDataResponse)serializer.Deserialize(reader);
            }
            else
            {
                throw new ArgumentException("File not found");
            }
        }
    }
}
