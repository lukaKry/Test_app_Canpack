using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_app_consoleApp
{
    public static class MapperService
    {
        public static DatabaseDataModel MapDataToDatabaseFormat(RejectDataResponse data)
        {
            // poniższe zapytania linq zakładają poprawnie sformatowany plik xml
            // wydaje mi się, że powinna być jakaś możliwość wyłapania błędu, gdyby jednak coś poszło nie tak

            decimal tested = data.Body.Source.Sample.Select(q => new { data = q.Data.FirstOrDefault(p => p.Name == "TESTED") }).Select(p => new { value = p.data.Text }).Sum(q => q.value);
            decimal rejected = data.Body.Source.Sample.Select(q => new { data = q.Data.FirstOrDefault(p => p.Name == "REJECTED") }).Select(p => new { value = p.data.Text }).Sum(q => q.value);

            return new DatabaseDataModel
            {
                CurrentDate = DateTime.Now,
                ProcessingStatus = "processed",
                Efficiency = rejected / tested
            };
        }
    }
}
