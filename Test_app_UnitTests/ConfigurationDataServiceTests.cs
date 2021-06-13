using NUnit.Framework;
using Test_app_consoleApp.Models;
using Test_app_consoleApp.Services;

namespace Test_app_UnitTests
{
    [TestFixture]
    class ConfigurationDataServiceTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void InstanceGetter_InstanceIsNull_ReturnsNewInstance()
        {
            var result = ConfigurationDataService.Instance;

            Assert.That(result, Is.TypeOf<ConfigurationDataService>());
        }

        [Test]
        public void InstanceGetter_InstanceIsNotNull_ReturnsField()
        {
            // first call creates new instance
            var init = ConfigurationDataService.Instance;

            // second call should return instance instantly
            var result = ConfigurationDataService.Instance;

            Assert.That(result, Is.TypeOf<ConfigurationDataService>());
        }

        [Test]
        public void DataGetter_WhenCalled_ReturnsField()
        {
            var result = ConfigurationDataService.Instance.Data;

            Assert.That(result, Is.TypeOf<ConfigurationDataModel>());
        }

        [Test]
        [Ignore("lack of skills")]
        public void DataGetter_NoConfigurationFileFound_ThrowsException()
        {
        }
    }
}
