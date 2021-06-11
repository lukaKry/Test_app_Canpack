using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Test_app_consoleApp.Helpers
{
    public static class FileReader
    {
        private static readonly string filePath = @"C:\Efficiency\eff.xml";

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
