using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DyeAndDurhamOANameSorter.Tests
{
    [TestClass()]
    public class NameSerializerTests
    {
        // INameToString

        [TestMethod("INameToString: Null case")]
        public void Test_INameToString_Null()
        {
            IName? testClass = null;

            string result = NameSerializer.INameToString(testClass);

            StringAssert.Equals(result, "");
        }

        [TestMethod("INameToString: Empty case")]
        public void Test_INameToString_Empty()
        {
            IName testClass = new NameLastFirsts("");

            string result = NameSerializer.INameToString(testClass);

            StringAssert.Equals(result, testClass.FullName);
        }

        [TestMethod("INameToString: Basic case")]
        public void Test_INameToString_Basic()
        {
            IName testClass = new NameLastFirsts("AAA BBB");

            string result = NameSerializer.INameToString(testClass);

            StringAssert.Equals(result, testClass.FullName);
        }

        // INameICollectionToStringBlock

        [TestMethod("INameICollectionToStringBlock: Empty case")]
        public void Test_INameICollectionToStringBlock_Empty()
        {
            List<IName> testList = new List<IName>();

            string result = NameSerializer.INameICollectionToStringBlock("|", testList);

            StringAssert.Equals(result, "");
        }

        [TestMethod("INameICollectionToStringBlock: Basic case")]
        public void Test_INameICollectionToStringBlock_Basic()
        {
            List<IName> testList = new List<IName>
            {
                new NameLastFirsts("A"),
                new NameLastFirsts("B"),
                new NameLastFirsts("C")
            };

            string result = NameSerializer.INameICollectionToStringBlock("|", testList);

            StringAssert.Equals(result, "A|B|C");
        }
    }
}