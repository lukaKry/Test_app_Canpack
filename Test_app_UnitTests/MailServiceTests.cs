using NUnit.Framework;
using Test_app_consoleApp;

namespace Test_app_UnitTests
{
    [TestFixture]
    class MailServiceTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void InstanceGetter_InstanceIsNull_ReturnsNewInstance()
        {
            var result = MailService.Instance;

            Assert.That(result, Is.TypeOf<MailService>());
        }

        [Test]
        public void InstanceGetter_InstanceIsNotNull_ReturnsField()
        {
            var init = MailService.Instance;
            var result = MailService.Instance;
            Assert.That(result, Is.TypeOf<MailService>());
        }

        [Test]
        [Ignore("for testing time")]

        public void SendMessage_CorrectCredentials_MessageSent()
        {
            MailService.Instance.SendMessage("kryszak.lukasz@gmail.com", "test", "The test has been invoked. Your application is being checked.");
        }

        [Test]
        [Ignore("lack of skills")]
        public void SendMessage_IncorrectCredentials_ThrowException()
        {
        }

    }
}
