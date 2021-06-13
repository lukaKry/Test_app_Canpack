using NUnit.Framework;
using Test_app_consoleApp;
using Test_app_consoleApp.Helpers;

namespace Test_app_UnitTests
{
    [TestFixture]
    public class FileReaderTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ReadRawData_FileExists_ReturnDeserializedData()
        {
            var result = FileReader.ReadRawData();

            Assert.That(result, Is.TypeOf<RejectDataResponse>());
        }

        [Test]
        [Ignore("lack of skills")]
        public void ReadRawData_IncorrectFilePath_ThrowException()
        {
            // brakuje mi jeszcze wiedzy, jak poprawnie zbudowaæ klasê z elementami statycznymi, ¿eby napisaæ do niej prawid³owe testy jednostkowe; prawdopodobnie musia³bym u¿yæ DependencyInjection
        }

    }
}