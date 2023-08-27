namespace DyeAndDurhamOANameSorter
{
    /// <summary>
    /// Interface for NameSorters. 
    /// ICollection used for flexibility.
    /// </summary>
    public interface INameSorter
    {
        void Add(IName name);
        void Remove(IName name);
        void Clear();
        void Replace(ICollection<IName> names);
        ICollection<IName> GetResult();
    }
}
