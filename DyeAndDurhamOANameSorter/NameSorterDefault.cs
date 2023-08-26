namespace DyeAndDurhamOANameSorter
{
    /// <summary>
    /// Sorts objects that implements IName. 
    /// </summary>
    public class NameSorterDefault : INameSorter
    {
        private List<IName> names;

        /// <summary>
        /// Default constructor. Creates an empty Names list.
        /// </summary>
        public NameSorterDefault()
        {
            names = new List<IName>();
        }

        /// <summary>
        /// ICollection constructor. Makes a shallow copy of the list, and stores it.
        /// </summary>
        /// <param name="names">List of objects that implement INames</param>
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
        /// Add a name to the list.
        /// </summary>
        /// <param name="name">object that implements IName</param>
        public void Add(IName name)
        {
            names.Add(name);
        }

        public void Remove(IName name)
        {
            names.Remove(name);
        }

        public ICollection<IName> GetResult()
        {
            return names;
        }

        /// <summary>
        /// Makes a shallow copy of the list, and store it.
        /// </summary>
        /// <param name="names">List of objects that implement INames</param>
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