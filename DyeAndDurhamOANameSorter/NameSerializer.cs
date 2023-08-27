namespace DyeAndDurhamOANameSorter
{
    /// <summary>
    /// Functions for serializing a name to a string.
    /// Cannot be instanciated, but can be inherited from. 
    /// </summary>
    public class NameSerializer
    {
        /// <summary>
        /// Class only contains functions. Instanciation is not allowed.
        /// </summary>
        private NameSerializer() { }

        /// <summary>
        /// Function that returns the string representation of the IName.
        /// </summary>
        /// <param name="name">IName to be serialized.</param>
        /// <returns></returns>
        public static string INameToString(IName name)
        {
            return name.FullName;
        }

        /// <summary>
        /// Function that returns a string of all the string representation of IName in order, delimited by the given string delimiter.
        /// </summary>
        /// <param name="delimiter">delimiter between each fullname.</param>
        /// <param name="names">ICollection filled with the names to be serialized.</param>
        /// <returns></returns>
        public static string INameICollectionToStringBlock(string delimiter, ICollection<IName> names)
        {
            string[] stringNames = new string[names.Count];
            IName[] namesArray = names.ToArray();

            for (int i = 0; i < names.Count; i++)
            {
                stringNames[i] = namesArray[i].FullName;
            }

            return string.Join(delimiter, stringNames);
        }
    }
}
