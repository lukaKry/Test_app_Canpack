using NUnit.Framework;
using Test_app_consoleApp.Services;

namespace Test_app_UnitTests
{
    [TestFixture]
    class SchedulerServiceTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ScheduleTask_WhenCalled_CreateNewTimer()
        {
            SchedulerService.Instance.ScheduleTask(10, 10, 10, () => System.Console.WriteLine("test"));

            // i ponownie nie wiem jak sprawdzić pole prywatne klasy:(
            // Assert.That( ShcedulerService.Instance.timers.Count > 0 );
        }
    }
}