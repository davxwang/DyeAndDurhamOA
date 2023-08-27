using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DyeAndDurhamOANameSorter.Tests
{
    [TestClass()]
    public class NameLastFirstsFactoryTests
    {
        // Constructor

        [TestMethod("Constructor")]
        public void Test_ProduceName_Constructor()
        {
            NameLastFirstsFactory testClass = new NameLastFirstsFactory();

            IName result = testClass.ProduceName();

            StringAssert.Equals(result.FullName, "");
        }

        [TestMethod("Constructor string: Empty case")]
        public void Test_ProduceName_Constructor_String_Empty()
        {
            NameLastFirstsFactory testClass = new NameLastFirstsFactory();

            IName result = testClass.ProduceName("");

            StringAssert.Equals(result.FullName, "");
        }

        [TestMethod("Constructor string: Basic case")]
        public void Test_ProduceName_Constructor_String_Basic()
        {
            NameLastFirstsFactory testClass = new NameLastFirstsFactory();

            IName result = testClass.ProduceName("AAA BBB");

            StringAssert.Equals(result.FullName, "AAA BBB");
        }
    }
}