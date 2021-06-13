using NUnit.Framework;
using Test_app_consoleApp;
using Test_app_consoleApp.Helpers;

namespace Test_app_UnitTests
{
    [TestFixture]
    class MapperTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void MapDataToDatabaseFormat_CorrectInputData_ReturnFromattedData()
        {
            var data = FileReader.ReadRawData();

            var result = Mapper.MapDataToDatabaseFormat(data);

            Assert.That(result, Is.TypeOf<DatabaseDataModel>());
        }

        [Test]
        public void MapDataToDatabaseFormat_IncorrectInputData_ThrowFormatException()
        {
            var data = new RejectDataResponse();

            Assert.That(() => Mapper.MapDataToDatabaseFormat(data), Throws.Exception);
        }
    }
}
