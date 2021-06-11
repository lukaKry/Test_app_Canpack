using Microsoft.Data.SqlClient;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Test_app_consoleApp.Helpers;

namespace Test_app_consoleApp
{
    class Program
    {
        public async static Task Main()
        {

            //MyScheduler.IntervalInDays(19, 58, 1, async () =>
            //{
                string status = "success";
                int id = -1;

                try
                {
                    Console.WriteLine("Checking input file...");

                    // Create db context for saving data
                    var factory = new TestDatabaseContextFactory();
                    using var dbContext = factory.CreateDbContext();

                    // read data from file
                    var rawDataFromFile = new RejectDataResponse();
                    rawDataFromFile = FileReader.ReadRawData();

                    Console.WriteLine("File succesfully read");
                    Console.WriteLine("Saving data to the database...");

                    // map data to database format
                    var mappedData = Mapper.MapDataToDatabaseFormat(rawDataFromFile);

                    // save changes to the database
                    dbContext.DatabaseRecords.Add(mappedData);
                    await dbContext.SaveChangesAsync();

                    Console.WriteLine("Changes saved to the database successfully.");
                    id = mappedData.Id;

                }
                catch (SqlException es)
                {
                    Console.WriteLine("Error number: " + es.Number + " - " + es.Message);
                    status = "sql error";
                }
                catch (ArgumentException ea)
                {
                    Console.WriteLine(ea.Message);
                    status = "input file error";
                }
                catch (FormatException ef)
                {
                    Console.WriteLine(ef.Message);
                    status = "file content error";
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    status = "generic error";
                }
                finally
                {
                    try
                    {
                        Console.WriteLine("Sending e-mail...");

                        string message = status;
                        if (message == "success") message += $"\nNew record added to database with id: {id}.";
                        // send e-mail 
                        MailService.Instance.SendMessage("kryszak.lukasz@gmail.com", "test", message);

                        // end
                        Console.WriteLine("Mail sent successfully.");
                        Console.WriteLine($"New database record Id: {(id == -1 ? "none" : id)}");
                    }
                    catch ( Exception e )
                    {
                        Console.WriteLine(e.Message);
                    }
                    finally
                    {
                        Console.WriteLine($"End of operation with status: {status}");
                    }
                }
            //});


            Console.ReadLine();
        }
    }
}
