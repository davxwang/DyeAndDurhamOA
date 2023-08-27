namespace DyeAndDurhamOANameSorter
{
    /// <summary>
    /// Sorts objects that implements IName. Results in a sorted list. 
    /// </summary>
    public class NameSorterDefault : INameSorter
    {
        private List<IName> names;

        /// <summary>
        /// Default constructor. Creates an empty names list.
        /// </summary>
        public NameSorterDefault()
        {
            names = new List<IName>();
        }

        /// <summary>
        /// ICollection constructor. Makes a shallow copy of the ICollection, and stores as names.
        /// </summary>
        /// <param name="names">ICollection of objects that implement INames</param>
        public NameSorterDefault(ICollection<IName> names)
        {
            Replace(names);
            
            // should never run. Replace handles initializing names.
            if (this.names is null)
            {
                this.names = new List<IName>();
            }
        }

        /// <summary>
        /// Add a name to the names list.
        /// </summary>
        /// <param name="name">object that implements IName</param>
        public void Add(IName name)
        {
            names.Add(name);
        }

        /// <summary>
        /// Removes a name from the names list. Note that the name object must be the same rather than the members.
        /// </summary>
        /// <param name="name">object that implements IName</param>
        public void Remove(IName name)
        {
            names.Remove(name);
        }

        /// <summary>
        /// Returns the list of sorted names cast as ICollection. Default sorting order of name used.
        /// </summary>
        /// <returns>sorted list of names cast as ICollection</returns>
        public ICollection<IName> GetResult()
        {
            names.Sort();
            return names;
        }

        /// <summary>
        /// Makes a shallow copy of the list, and store it as names.
        /// </summary>
        /// <param name="names">ICollection of objects that implement INames</param>
        public void Replace(ICollection<IName> names)
        {
            this.names = new List<IName>(names);
        }
        
        /// <summary>
        /// Empties the names list.
        /// </summary>
        public void Clear()
        {
            names.Clear();
        }
    }
}