using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DyeAndDurhamOANameSorter.Tests
{
    [TestClass]
    public class NameLastFirstsTests
    {
        [TestMethod]
        public void Test_NameLastFirsts_Constructor_Default()
        {
            NameLastFirsts testClass = new NameLastFirsts();

            Assert.AreEqual(testClass.FullName, "");
        }

        [TestMethod]
        public void Test_NameLastFirsts_Constructor_String_Empty()
        {
            NameLastFirsts testClass = new NameLastFirsts();

            Assert.AreEqual(testClass.FullName, "");
        }

        [TestMethod]
        public void Test_NameLastFirsts_Constructor_String_Whitespace()
        {
            string testString = " ";

            NameLastFirsts testClass = new NameLastFirsts(testString);

            Assert.AreEqual(testClass.FullName, "");
        }

        [TestMethod]
        public void Test_NameLastFirsts_String_Whitespace_Many()
        {
            string testString = "        ";

            NameLastFirsts testClass = new NameLastFirsts(testString);

            Assert.AreEqual(testClass.FullName, "");
        }

        [TestMethod]
        public void Test_NameLastFirsts_String_Set_Fullname()
        {
            string testString = "AAA ZZZ";
            NameLastFirsts testClass = new NameLastFirsts();

            testClass.FullName = testString;

            Assert.AreEqual(testClass.FullName, testString);
        }

        [TestMethod]
        public void Test_NameLastFirsts_Comparison_Basic()
        {
            NameLastFirsts testClass1 = new NameLastFirsts("AAA");
            NameLastFirsts testClass2 = new NameLastFirsts("BBB");

            Assert.IsTrue(testClass1.CompareTo(testClass2) < 0);
        }

        [TestMethod]
        public void Test_NameLastFirsts_Comparison_Equal()
        {
            NameLastFirsts testClass1 = new NameLastFirsts("AAA");
            NameLastFirsts testClass2 = new NameLastFirsts("AAA");

            Assert.IsTrue(testClass1.CompareTo(testClass2) == 0);
        }

        [TestMethod]
        public void Test_NameLastFirsts_Comparison_Lastname()
        {
            NameLastFirsts testClass1 = new NameLastFirsts("AAA ZZZ");
            NameLastFirsts testClass2 = new NameLastFirsts("ZZZ AAA");

            Assert.IsTrue(testClass1.CompareTo(testClass2) > 0);
        }

        [TestMethod]
        public void Test_NameLastFirsts_Comparison_Many_Firstnames()
        {
            NameLastFirsts testClass1 = new NameLastFirsts("AAA AAA BBB AAA");
            NameLastFirsts testClass2 = new NameLastFirsts("AAA AAA AAA AAA");

            Assert.IsTrue(testClass1.CompareTo(testClass2) > 0);
        }

        [TestMethod]
        public void Test_NameLastFirsts_Comparison_Firstname_Length_Mismatch()
        {
            NameLastFirsts testClass1 = new NameLastFirsts("AAA AAA");
            NameLastFirsts testClass2 = new NameLastFirsts("AAA AAA AAA AAA");

            Assert.IsTrue(testClass1.CompareTo(testClass2) < 0);
        }
    }
}