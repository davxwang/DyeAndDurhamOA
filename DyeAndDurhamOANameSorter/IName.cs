namespace DyeAndDurhamOANameSorter
{
    /// <summary>
    /// Interface for names. 
    /// Inherits IComparable to enforce CompareTo implementation.
    /// </summary>
    public interface IName : IComparable
    {
        string FullName { get; set; }
    }
}
