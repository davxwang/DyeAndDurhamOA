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
            NameSorterDefault testClass = new NameSorterDefault();

            Assert.IsTrue(testClass.GetSortedString(Environment.NewLine) == "");
        }

        [TestMethod]
        public void Test_NameSorter_Constructor_List()
        {
            List<IName> testList = new List<IName>();
            testList.Add(new NameLastFirsts("A"));
            testList.Add(new NameLastFirsts("B"));
            testList.Add(new NameLastFirsts("C"));

            NameSorterDefault testClass = new NameSorterDefault(testList);

            Assert.IsTrue(testClass.GetSortedString(" ") == "A B C");
        }

        [TestMethod]
        public void Test_NameSorter_Constructor_List_Empty()
        {
            List<IName> testList = new List<IName>();

            NameSorterDefault testClass = new NameSorterDefault(testList);

            Assert.IsTrue(testClass.GetSortedString(" ") == "");
        }

        [TestMethod]
        public void Test_NameSorter_Constructor_Add()
        {
            List<IName> testList = new List<IName>();
            NameSorterDefault testClass = new NameSorterDefault(testList);

            testClass.Add(new NameLastFirsts("A"));

            Assert.IsTrue(testClass.GetSortedString(" ") == "A");
        }

        [TestMethod]
        public void Test_NameSorter_Constructor_Replace()
        {
            List<IName> testList = new List<IName>();
            testList.Add(new NameLastFirsts("A"));
            testList.Add(new NameLastFirsts("B"));
            testList.Add(new NameLastFirsts("C"));
            NameSorterDefault testClass = new NameSorterDefault(testList);
            testList = new List<IName>();
            testList.Add(new NameLastFirsts("D"));
            testList.Add(new NameLastFirsts("E"));
            testList.Add(new NameLastFirsts("F"));

            testClass.Replace(testList);

            Assert.IsTrue(testClass.GetSortedString(" ") == "D E F");
        }

        [TestMethod]
        public void Test_NameSorter_Constructor_GetSortedString_Simple()
        {
            List<IName> testList = new List<IName>();
            testList.Add(new NameLastFirsts("B"));
            testList.Add(new NameLastFirsts("A"));
            testList.Add(new NameLastFirsts("C"));
            NameSorterDefault testClass = new NameSorterDefault(testList);

            Assert.IsTrue(testClass.GetSortedString(" ") == "A B C");
        }

        [TestMethod]
        public void Test_NameSorter_Constructor_GetSortedString_Including_Space_Mixed_Lastname()
        {
            List<IName> testList = new List<IName>();
            testList.Add(new NameLastFirsts("AAA ZZZ"));
            testList.Add(new NameLastFirsts("AAA AAA"));
            testList.Add(new NameLastFirsts("AAA AAA AAA"));
            testList.Add(new NameLastFirsts("AAA BBB AAA"));
            testList.Add(new NameLastFirsts("YYY"));
            testList.Add(new NameLastFirsts("AAA YYY"));

            NameSorterDefault testClass = new NameSorterDefault(testList);

            Assert.IsTrue(testClass.GetSortedString("|") == "AAA AAA|AAA AAA AAA|AAA BBB AAA|YYY|AAA YYY|AAA ZZZ");
        }

        [TestMethod]
        public void Test_NameSorter_Constructor_Clear()
        {
            List<IName> testList = new List<IName>();
            testList.Add(new NameLastFirsts("A"));
            testList.Add(new NameLastFirsts("B"));
            testList.Add(new NameLastFirsts("C"));
            NameSorterDefault testClass = new NameSorterDefault(testList);

            testClass.Clear();

            Assert.IsTrue(testClass.GetSortedString(" ") == "");
        }
    }
}
