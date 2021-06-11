using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_app_consoleApp
{
    public static class Mapper
    {
        public static DatabaseDataModel MapDataToDatabaseFormat(RejectDataResponse data)
        {
            decimal tested = GetDecimalValueFromData(data, "TESTED");

            decimal rejected = GetDecimalValueFromData(data, "REJECTED");

            return new DatabaseDataModel
            {
                CurrentDate = DateTime.Now,
                ProcessingStatus = "processed",
                Efficiency = rejected / tested
            };
        }

        private static decimal GetDecimalValueFromData(RejectDataResponse data, string name)
        {
            return data.Body.Source.Sample
                .Select(q => new
                {
                    data = q.Data.FirstOrDefault(p => p.Name == name)
                })
                .Select(p =>
                {
                    if (p.data is null) throw new FormatException("Invalid file content.");
                    return new { value = p.data.Text };
                })
                .Sum(q => q.value);
        }
    }
}
