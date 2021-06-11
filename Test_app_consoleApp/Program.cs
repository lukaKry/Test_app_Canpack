using System;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Test_app_consoleApp
{
    class Program
    {
        public  static void  Main()
        {

            MyScheduler.IntervalInDays(21, 16, 1, async () =>
            {

                // Create db context for saving data
                var factory = new TestDatabaseContextFactory();
                using var dbContext = factory.CreateDbContext();

                // read data from file
                var rawDataFromFile = new RejectDataResponse();
                rawDataFromFile = XTest();

                // map data to database format
                var mappedData = MapperService.MapDataToDatabaseFormat(rawDataFromFile);

                // save changes to the database
                dbContext.DatabaseRecords.Add(mappedData);
                await dbContext.SaveChangesAsync();

                // send e mail 
                MailService ms = new();
                ms.sendMessage("kryszak.lukasz@gmail.com", "test", $"New record added to database with id:  {mappedData.Id}.");

                // end
                Console.WriteLine($"End of operation. Id: {mappedData.Id}");

            });

            MyScheduler.IntervalInSeconds(21, 16, 5, () => { Console.WriteLine("hi"); });

                Console.ReadLine();


        }


        // tą metodę zdecydowanie trzeba przenieść do osobnej klasy
        static RejectDataResponse XTest()
        {
            using (TextReader reader = new StreamReader(@"C:\Efficiency\eff.xml"))
            {
                XmlSerializer serializer = new(typeof(RejectDataResponse));
                return (RejectDataResponse)serializer.Deserialize(reader);
            }
        }


    }
}
