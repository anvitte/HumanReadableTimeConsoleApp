using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp.Library.Interfaces;
using ConsoleApp.Library.Services;

namespace ConsoleApp.Tests
{
    /// <summary>
    /// This is Time to Human Readable Test Class which will do the below test method testing
    /// </summary>
    [TestClass]
    public class TimeToHumanReadableTest
    {
        private ITimeToHumanReadable _timeToHumanReadable { get; set; }
        public TimeToHumanReadableTest()
        {
            _timeToHumanReadable = new TimeToHumanReadableService();
        }

        /// <summary>
        /// This test method will test the below inputs and based on that it will pass and fail the test cases
        /// </summary>
        /// <param name="time"></param>
        /// <param name="humanReadableText"></param>
        [TestMethod]
        //Pass Test Cases
        [DataRow("02:16", "Sixteen past two")]
        [DataRow("03:57", "Three to four")]
        //Fail Test cases
        [DataRow("03:57", "Four to three")]
        [DataRow("01:30", "Half past four")]
        public void TestTimeToHumanReadableConverter(string time,string humanReadableText)
        {
            _timeToHumanReadable.ConvertTimeToHumanReadble(time);
            string humanReadableMessageOutputObjective1 = _timeToHumanReadable.ReturnHumanReadableTime();
            Assert.AreEqual(humanReadableMessageOutputObjective1, humanReadableText);        
        }
    }
}
