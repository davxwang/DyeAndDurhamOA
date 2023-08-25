using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DyeAndDurhamOANameSorter.Tests
{
    [TestClass]
    public class NameTests
    {
        [TestMethod]
        public void Test_Name_Constructor_Default()
        {
            Name testClass = new Name();

            Assert.AreEqual(testClass.FullName, "");
        }

        [TestMethod]
        public void Test_Name_Constructor_String_Empty()
        {
            Name testClass = new Name();

            Assert.AreEqual(testClass.FullName, "");
        }

        [TestMethod]
        public void Test_Name_Constructor_String_Whitespace()
        {
            string testString = " ";

            Name testClass = new Name(testString);

            Assert.AreEqual(testClass.FullName, "");
        }

        [TestMethod]
        public void Test_Name_String_Whitespace_Many()
        {
            string testString = "        ";

            Name testClass = new Name(testString);

            Assert.AreEqual(testClass.FullName, "");
        }

        [TestMethod]
        public void Test_Name_String_Set_Fullname()
        {
            string testString = "AAA ZZZ";
            Name testClass = new Name();

            testClass.FullName = testString;

            Assert.AreEqual(testClass.FullName, testString);
        }

        [TestMethod]
        public void Test_Name_Comparison_Basic()
        {
            Name testClass1 = new Name("AAA");
            Name testClass2 = new Name("BBB");

            Assert.IsTrue(testClass1.CompareTo(testClass2) < 0);
        }

        [TestMethod]
        public void Test_Name_Comparison_Equal()
        {
            Name testClass1 = new Name("AAA");
            Name testClass2 = new Name("AAA");

            Assert.IsTrue(testClass1.CompareTo(testClass2) == 0);
        }

        [TestMethod]
        public void Test_Name_Comparison_Lastname()
        {
            Name testClass1 = new Name("AAA ZZZ");
            Name testClass2 = new Name("ZZZ AAA");

            Assert.IsTrue(testClass1.CompareTo(testClass2) > 0);
        }

        [TestMethod]
        public void Test_Name_Comparison_Many_Firstnames()
        {
            Name testClass1 = new Name("AAA AAA BBB AAA");
            Name testClass2 = new Name("AAA AAA AAA AAA");

            Assert.IsTrue(testClass1.CompareTo(testClass2) > 0);
        }

        [TestMethod]
        public void Test_Name_Comparison_Firstname_Length_Mismatch()
        {
            Name testClass1 = new Name("AAA AAA");
            Name testClass2 = new Name("AAA AAA AAA AAA");

            Assert.IsTrue(testClass1.CompareTo(testClass2) < 0);
        }
    }
}