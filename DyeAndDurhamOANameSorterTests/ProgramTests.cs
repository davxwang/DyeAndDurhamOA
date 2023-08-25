using Microsoft.VisualStudio.TestTools.UnitTesting;
using DyeAndDurhamOANameSorter;

namespace DyeAndDurhamOANameSorter.Tests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void Test_HelperStringToINameList_Whitespace()
        {
            string testString = "    ";

            List<IName> result = Program.HelperStringToINameList(testString, Environment.NewLine);

            Assert.AreEqual(result.Count, 0);
        }

        [TestMethod]
        public void Test_HelperStringToINameList_Basic_Case()
        {
            string testString = "A" + Environment.NewLine + "B" + Environment.NewLine + "C";

            List<IName> result = Program.HelperStringToINameList(testString, Environment.NewLine);

            StringAssert.Equals(result[0].FullName, "A");
            StringAssert.Equals(result[1].FullName, "B");
            StringAssert.Equals(result[2].FullName, "C");
            Assert.AreEqual(result.Count, 3);
        }

        [TestMethod]
        public void Test_HelperStringToINameList_Extra_Delimiters()
        {
            string testString = "A" + Environment.NewLine + Environment.NewLine + "B" + Environment.NewLine + Environment.NewLine + Environment.NewLine + "C";

            List<IName> result = Program.HelperStringToINameList(testString, Environment.NewLine);

            StringAssert.Equals(result[0].FullName, "A");
            StringAssert.Equals(result[1].FullName, "B");
            StringAssert.Equals(result[2].FullName, "C");
            Assert.AreEqual(result.Count, 3);
        }

        [TestMethod]
        public void Test_HelperStringToINameList_NonStandard_Delimiters()
        {
            string testString = "ADBDC";

            List<IName> result = Program.HelperStringToINameList(testString, "D");

            StringAssert.Equals(result[0].FullName, "A");
            StringAssert.Equals(result[1].FullName, "B");
            StringAssert.Equals(result[2].FullName, "C");
            Assert.AreEqual(result.Count, 3);
        }

        [TestMethod]
        public void Test_HelperStringToINameList_Names_Have_Space()
        {
            string testString = "A A-B B B-C C C C";

            List<IName> result = Program.HelperStringToINameList(testString, "-");

            StringAssert.Equals(result[0].FullName, "A A");
            StringAssert.Equals(result[1].FullName, "B B B");
            StringAssert.Equals(result[2].FullName, "C C C C");
            Assert.AreEqual(result.Count, 3);
        }
    }
}
