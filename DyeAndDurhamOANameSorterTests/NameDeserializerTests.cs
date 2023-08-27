using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DyeAndDurhamOANameSorter.Tests
{
    [TestClass()]
    public class NameDeserializerTests
    {
        // SingleStringNameToIName
        
        [TestMethod("SingleStringNameToIName: Empty string")]
        public void Test_SingleStringNameToIName_Empty()
        {
            string testString = "";

            IName result = NameDeserializer.SingleStringNameToIName(testString, new NameLastFirstsFactory());

            Assert.AreEqual(result.FullName, "");
        }

        [TestMethod("SingleStringNameToIName: White space only")]
        public void Test_SingleStringNameToIName_Whitespace()
        {
            string testString = "    ";

            IName result = NameDeserializer.SingleStringNameToIName(testString, new NameLastFirstsFactory());

            Assert.AreEqual(result.FullName, "");
        }

        [TestMethod("SingleStringNameToIName: Basic case")]
        public void Test_SingleStringNameToIName_Basic()
        {
            string testString = "AAA AA AAAA";

            IName result = NameDeserializer.SingleStringNameToIName(testString, new NameLastFirstsFactory());

            Assert.AreEqual(result.FullName, "AAA AA AAAA");
        }

        // BlockStringNameToINameTest

        [TestMethod("BlockStringNameToIName: Empty string")]
        public void Test_BlockStringNameToIName_Empty()
        {
            string testString = "";
            string testDelimiter = Environment.NewLine;
            List<IName> testList = new List<IName>();
            NameLastFirstsFactory testFactory = new NameLastFirstsFactory();

            ICollection<IName> result = NameDeserializer.BlockStringNameToIName(testString, testDelimiter, testFactory, testList);

            Assert.AreEqual(result.Count, 0);
        }

        [TestMethod("BlockStringNameToIName: White space only with delimiter")]
        public void Test_BlockStringNameToIName_Whitespace()
        {
            string testString = "      " + Environment.NewLine + "         ";
            string testDelimiter = Environment.NewLine;
            List<IName> testList = new List<IName>();
            NameLastFirstsFactory testFactory = new NameLastFirstsFactory();

            ICollection<IName> result = NameDeserializer.BlockStringNameToIName(testString, testDelimiter, testFactory, testList);

            Assert.AreEqual(result.Count, 0);
        }

        [TestMethod("BlockStringNameToIName: Basic case")]
        public void Test_BlockStringNameToIName_Basic_Case()
        {
            string testString = "A" + Environment.NewLine + "B" + Environment.NewLine + "C";
            string testDelimiter = Environment.NewLine;
            List<IName> testList = new List<IName>();
            NameLastFirstsFactory testFactory = new NameLastFirstsFactory();

            IName[] result = NameDeserializer.BlockStringNameToIName(testString, testDelimiter, testFactory, testList).ToArray();

            StringAssert.Equals(result[0].FullName, "A");
            StringAssert.Equals(result[1].FullName, "B");
            StringAssert.Equals(result[2].FullName, "C");
            Assert.AreEqual(result.Length, 3);
        }

        [TestMethod("BlockStringNameToIName: Extra delimiters")]
        public void Test_BlockStringNameToIName_Extra_Delimiters()
        {
            string testString = "A" + Environment.NewLine + Environment.NewLine + "B" + Environment.NewLine + Environment.NewLine + Environment.NewLine + "C";
            string testDelimiter = Environment.NewLine;
            List<IName> testList = new List<IName>();
            NameLastFirstsFactory testFactory = new NameLastFirstsFactory();

            IName[] result = NameDeserializer.BlockStringNameToIName(testString, testDelimiter, testFactory, testList).ToArray();

            StringAssert.Equals(result[0].FullName, "A");
            StringAssert.Equals(result[1].FullName, "B");
            StringAssert.Equals(result[2].FullName, "C");
            Assert.AreEqual(result.Length, 3);
        }

        [TestMethod("BlockStringNameToIName: Nonstandard delimiters")]
        public void Test_BlockStringNameToIName_NonStandard_Delimiters()
        {
            string testString = "ADBDC";
            string testDelimiter = "D";
            List<IName> testList = new List<IName>();
            NameLastFirstsFactory testFactory = new NameLastFirstsFactory();

            IName[] result = NameDeserializer.BlockStringNameToIName(testString, testDelimiter, testFactory, testList).ToArray();

            StringAssert.Equals(result[0].FullName, "A");
            StringAssert.Equals(result[1].FullName, "B");
            StringAssert.Equals(result[2].FullName, "C");
            Assert.AreEqual(result.Length, 3);
        }

        [TestMethod("BlockStringNameToIName: Names have spaces")]
        public void Test_BlockStringNameToIName_Names_Have_Space()
        {
            string testString = "A A-B B B-C C C C";
            string testDelimiter = "-";
            List<IName> testList = new List<IName>();
            NameLastFirstsFactory testFactory = new NameLastFirstsFactory();

            IName[] result = NameDeserializer.BlockStringNameToIName(testString, testDelimiter, testFactory, testList).ToArray();

            StringAssert.Equals(result[0].FullName, "A A");
            StringAssert.Equals(result[1].FullName, "B B B");
            StringAssert.Equals(result[2].FullName, "C C C C");
            Assert.AreEqual(result.Length, 3);
        }
    }
}