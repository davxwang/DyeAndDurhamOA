namespace DyeAndDurhamOANameSorter
{
    /// <summary>
    /// Interface for name factories.
    /// </summary>
    public interface INameFactory
    {
        IName ProduceName();
        IName ProduceName(string fullName);
    }
}
