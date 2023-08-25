namespace DyeAndDurhamOANameSorter
{
    /// <summary>
    /// Sorts objects that implements IName. 
    /// </summary>
    public class NameSorter
    {
        private List<IName> names;

        /// <summary>
        /// Default constructor. Creates an empty Names list.
        /// </summary>
        public NameSorter()
        {
            this.names = new List<IName>();
        }

        /// <summary>
        /// List constructor. Makes a shallow copy of the list, and store it.
        /// </summary>
        /// <param name="names">List of objects that implement INames</param>
        public NameSorter(List<IName> names)
        {
            Replace(names);
        }

        /// <summary>
        /// Add a name to the list.
        /// </summary>
        /// <param name="name">object that implements IName</param>
        public void Add(IName name)
        {
            this.names.Add(name);
        }

        /// <summary>
        /// Makes a shallow copy of the list, and store it.
        /// </summary>
        /// <param name="names">List of objects that implement INames</param>
        public void Replace(List<IName> names)
        {
            this.names = new List<IName>(names);
        }

        /// <summary>
        /// Sort and return the list as a string.
        /// </summary>
        /// <param name="delimiter">separator between names</param>
        /// <returns></returns>
        public string GetSortedString(string delimiter)
        {
            string[] stringNames = new string[names.Count];
            // comparer is implemented by object
            names.Sort();
            for (int i = 0; i < names.Count; i++)
            {
                stringNames[i] = names[i].FullName;
            }

            return string.Join(delimiter, stringNames);
        }
        
        /// <summary>
        /// Empties the Names list.
        /// </summary>
        public void Clear()
        {
            this.names.Clear();
        }
    }
}
