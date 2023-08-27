using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DyeAndDurhamOANameSorter.Tests
{
    [TestClass]
    public class NameSorterDefaultTests
    {
        // constructors

        [TestMethod("constructor default")]
        public void Test_NameSorterDefault_Constructor_Default()
        {
            NameSorterDefault testClass = new NameSorterDefault();

            ICollection<IName> result = testClass.GetResult();

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod("constructor list: empty list")]
        public void Test_NameSorterDefault_Constructor_List_Empty()
        {
            List<IName> testList = new List<IName>();

            NameSorterDefault testClass = new NameSorterDefault(testList);
            IName[] result = testClass.GetResult().ToArray();

            Assert.IsTrue(result.Length == 0);
        }

        [TestMethod("constructor list: basic case")]
        public void Test_NameSorterDefault_Constructor_List()
        {
            List<IName> testList = new List<IName>
            {
                new NameLastFirsts("A"),
                new NameLastFirsts("B"),
                new NameLastFirsts("C")
            };

            NameSorterDefault testClass = new NameSorterDefault(testList);
            IName[] result = testClass.GetResult().ToArray();

            Assert.IsTrue(result[0].FullName + result[1].FullName + result[2].FullName == "ABC");
            Assert.IsTrue(result.Length == 3);
        }

        // Add

        [TestMethod("Add: basic case")]
        public void Test_NameSorterDefault_Add()
        {
            NameSorterDefault testClass = new NameSorterDefault();

            testClass.Add(new NameLastFirsts("A"));
            IName[] result = testClass.GetResult().ToArray();

            Assert.IsTrue(result[0].FullName == "A");
            Assert.IsTrue(result.Length == 1);
        }

        // Replace

        [TestMethod("Replace: empty case")]
        public void Test_NameSorterDefault_Replace_Null()
        {
            List<IName> testList = new List<IName>();
            NameSorterDefault testClass = new NameSorterDefault();

            testClass.Replace(testList);
            IName[] result = testClass.GetResult().ToArray();

            Assert.IsTrue(result.Length == 0);
        }

        [TestMethod("Replace: basic case")]
        public void Test_NameSorterDefault_Replace()
        {
            List<IName> testList = new List<IName>
            {
                new NameLastFirsts("A"),
                new NameLastFirsts("B"),
                new NameLastFirsts("C")
            };
            NameSorterDefault testClass = new NameSorterDefault(testList);
            testList = new List<IName>
            {
                new NameLastFirsts("D"),
                new NameLastFirsts("E"),
                new NameLastFirsts("F")
            };

            testClass.Replace(testList);
            IName[] result = testClass.GetResult().ToArray();

            Assert.IsTrue(result[0].FullName + result[1].FullName + result[2].FullName == "DEF");
        }

        // GetResult

        [TestMethod("GetResult: empty list case")]
        public void Test_NameSorterDefault_GetResult_Empty()
        {
            NameSorterDefault testClass = new NameSorterDefault();

            IName[] result = testClass.GetResult().ToArray();

            Assert.IsTrue(result.Length == 0);
        }

        [TestMethod("GetResult: basic case")]
        public void Test_NameSorterDefault_GetResult_Basic()
        {
            List<IName> testList = new List<IName>
            {
                new NameLastFirsts("B"),
                new NameLastFirsts("A"),
                new NameLastFirsts("C")
            };
            NameSorterDefault testClass = new NameSorterDefault(testList);

            IName[] result = testClass.GetResult().ToArray();

            Assert.IsTrue(result[0].FullName + result[1].FullName + result[2].FullName == "ABC");
        }

        [TestMethod("GetResult: last name sort")]
        public void Test_NameSorterDefault_GetResult_Including_Space_Mixed_Lastname()
        {
            List<IName> testList = new List<IName>
            {
                new NameLastFirsts("AAA ZZZ"),
                new NameLastFirsts("AAA AAA"),
                new NameLastFirsts("AAA AAA AAA"),
                new NameLastFirsts("AAA BBB AAA"),
                new NameLastFirsts("YYY"),
                new NameLastFirsts("AAA YYY")
            };
            NameSorterDefault testClass = new NameSorterDefault(testList);

            IName[] result = testClass.GetResult().ToArray();

            string resultString = result[0].FullName;
            for (int i = 1; i < result.Length; i++)
            {
                resultString += "|" + result[i].FullName;
            }
            Assert.IsTrue(resultString == "AAA AAA|AAA AAA AAA|AAA BBB AAA|YYY|AAA YYY|AAA ZZZ");
        }

        // Clear

        [TestMethod("Clear")]
        public void Test_NameSorterDefault_Clear()
        {
            List<IName> testList = new List<IName>
            {
                new NameLastFirsts("A"),
                new NameLastFirsts("B"),
                new NameLastFirsts("C")
            };
            NameSorterDefault testClass = new NameSorterDefault(testList);

            testClass.Clear();
            IName[] result = testClass.GetResult().ToArray();

            Assert.IsTrue(result.Length == 0);
        }
    }
}
