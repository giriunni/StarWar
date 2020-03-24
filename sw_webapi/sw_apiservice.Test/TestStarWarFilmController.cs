using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using sw_apiservice.Controllers;

namespace sw_apiservice.Test
{
    public class TestStarWarFilmController
    {
        [Test]
        public void TestGetLongestOpeningCrawlTitle()
        {
            var testResult = GetTestResultByTasks(1);
            var testController = new StarWarFilmController();

            var result = testController.GetLongestOpeningCrawlTitle().ToString();
            Assert.AreEqual(testResult[0].ToString(), result.ToString());
        }

        [Test]
        public void TestGetMostAppearedCharacter()
        {
            var testResult = GetTestResultByTasks(2);
            var testController = new StarWarFilmController();

            var result = testController.GetMostAppearedCharacter().ToString();
            Assert.AreEqual(testResult[0].ToString(), result.ToString());
        }

        [Test]
        public void TestGetMostAppearedSpeciesWithCount()
        {
            var testResult = GetTestResultByTasks(3);
            var testController = new StarWarFilmController();

            var result = testController.GetMostAppearedSpeciesWithCount().ToList();
            Assert.AreEqual(testResult, result);
        }

        [Test]
        public void TestGetLargestNumberOfVehiclePilot()
        {
            var testResult = GetTestResultByTasks(4);
            var testController = new StarWarFilmController();

            var result = testController.GetLargestNumberOfVehiclePilot().ToList();
            Assert.AreEqual(testResult, result);
        }

        private List<string> GetTestResultByTasks(int taskNo)
        {
            List<string> testResultValue = new List<string>();

            if (taskNo == 1) { testResultValue.Add("A New Hope"); }
            else if (taskNo == 2) { testResultValue.Add("Obi-Wan Kenobi"); }
            else if (taskNo == 3) 
            { 
                testResultValue.Add("Human (6)\n");
                testResultValue.Add("Droid (6)\n");
            }
            else if (taskNo == 4)
            {
                testResultValue.Add("Planet:Naboo - Pilots: (11) Dooku - Human, Chewbacca - Wookie, Darth Maul - Zabrak, Zam Wesell - Clawdite, Grievous - Kaleesh\n");
                testResultValue.Add("Planet:Coruscant - Pilots: (11) Dooku - Human, Chewbacca - Wookie, Darth Maul - Zabrak, Zam Wesell - Clawdite, Grievous - Kaleesh\n");
                testResultValue.Add("Planet:Tatooine - Pilots: (11) Dooku - Human, Chewbacca - Wookie, Darth Maul - Zabrak, Zam Wesell - Clawdite, Grievous - Kaleesh\n");
            }
            return testResultValue;
        }
    }
}
