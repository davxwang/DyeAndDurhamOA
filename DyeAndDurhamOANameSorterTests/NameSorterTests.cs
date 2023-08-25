using Microsoft.VisualStudio.TestTools.UnitTesting;
using DyeAndDurhamOANameSorter;

namespace DyeAndDurhamOANameSorter.Tests
{
    [TestClass]
    public class NameSorterTests
    {
        [TestMethod]
        public void Test_NameSorter_Constructor_Default()
        {
            NameSorter testClass = new NameSorter();

            Assert.IsTrue(testClass.GetSortedString(Environment.NewLine) == "");
        }

        [TestMethod]
        public void Test_NameSorter_Constructor_List()
        {
            List<IName> testList = new List<IName>();
            testList.Add(new Name("A"));
            testList.Add(new Name("B"));
            testList.Add(new Name("C"));

            NameSorter testClass = new NameSorter(testList);

            Assert.IsTrue(testClass.GetSortedString(" ") == "A B C");
        }

        [TestMethod]
        public void Test_NameSorter_Constructor_List_Empty()
        {
            List<IName> testList = new List<IName>();

            NameSorter testClass = new NameSorter(testList);

            Assert.IsTrue(testClass.GetSortedString(" ") == "");
        }

        [TestMethod]
        public void Test_NameSorter_Constructor_Add()
        {
            List<IName> testList = new List<IName>();
            NameSorter testClass = new NameSorter(testList);

            testClass.Add(new Name("A"));

            Assert.IsTrue(testClass.GetSortedString(" ") == "A");
        }

        [TestMethod]
        public void Test_NameSorter_Constructor_Replace()
        {
            List<IName> testList = new List<IName>();
            testList.Add(new Name("A"));
            testList.Add(new Name("B"));
            testList.Add(new Name("C"));
            NameSorter testClass = new NameSorter(testList);
            testList = new List<IName>();
            testList.Add(new Name("D"));
            testList.Add(new Name("E"));
            testList.Add(new Name("F"));

            testClass.Replace(testList);

            Assert.IsTrue(testClass.GetSortedString(" ") == "D E F");
        }

        [TestMethod]
        public void Test_NameSorter_Constructor_GetSortedString_Simple()
        {
            List<IName> testList = new List<IName>();
            testList.Add(new Name("B"));
            testList.Add(new Name("A"));
            testList.Add(new Name("C"));
            NameSorter testClass = new NameSorter(testList);

            Assert.IsTrue(testClass.GetSortedString(" ") == "A B C");
        }

        [TestMethod]
        public void Test_NameSorter_Constructor_GetSortedString_Including_Space_Mixed_Lastname()
        {
            List<IName> testList = new List<IName>();
            testList.Add(new Name("AAA ZZZ"));
            testList.Add(new Name("AAA AAA"));
            testList.Add(new Name("AAA AAA AAA"));
            testList.Add(new Name("AAA BBB AAA"));
            testList.Add(new Name("YYY"));
            testList.Add(new Name("AAA YYY"));

            NameSorter testClass = new NameSorter(testList);

            Assert.IsTrue(testClass.GetSortedString("|") == "AAA AAA|AAA AAA AAA|AAA BBB AAA|YYY|AAA YYY|AAA ZZZ");
        }

        [TestMethod]
        public void Test_NameSorter_Constructor_Clear()
        {
            List<IName> testList = new List<IName>();
            testList.Add(new Name("A"));
            testList.Add(new Name("B"));
            testList.Add(new Name("C"));
            NameSorter testClass = new NameSorter(testList);

            testClass.Clear();

            Assert.IsTrue(testClass.GetSortedString(" ") == "");
        }
    }
}
