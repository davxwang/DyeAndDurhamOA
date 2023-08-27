namespace DyeAndDurhamOANameSorter
{
    /// <summary>
    /// Concrete factory for producing NameLastFirsts instances.
    /// </summary>
    public class NameLastFirstsFactory : INameFactory
    {
        /// <summary>
        /// Produces a NameLastFirsts with a default constructor.
        /// </summary>
        /// <returns>NameLastFirsts instance with default values.</returns>
        public IName ProduceName()
        {
            return new NameLastFirsts();
        }

        /// <summary>
        /// Produces a NameLastFirsts with the string constructor.
        /// </summary>
        /// <param name="name">string that represents the fullname.</param>
        /// <returns>NameLastFirsts instance with fullName set to the constructor.</returns>
        public IName ProduceName(string fullName)
        {
            return new NameLastFirsts(fullName);
        }
    }
}
