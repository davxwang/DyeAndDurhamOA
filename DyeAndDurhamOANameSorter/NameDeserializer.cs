namespace DyeAndDurhamOANameSorter
{
    /// <summary>
    /// Functions for deserializing a name from a string. Needs a NameFactory instance as a parameter for functions.
    /// Cannot be instanciated, but can be inherited from. 
    /// </summary>
    public class NameDeserializer
    {
        /// <summary>
        /// Class only contains functions. Instanciation is not allowed.
        /// </summary>
        private NameDeserializer() { }
        
        /// <summary>
        /// Function that produces a name from a string given a factory.
        /// </summary>
        /// <param name="fullName">string of a single name.</param>
        /// <param name="nameProducer">Factory instance of the needed concrete name.</param>
        /// <returns>result of the factory cast as IName</returns>
        public static IName SingleStringNameToIName(string fullName, INameFactory nameProducer)
        {
            return nameProducer.ProduceName(fullName);
        }

        /// <summary>
        /// Function that parses a string of names delimited by a character, produces INames from the factory, and inserts the result into the ICollection.
        /// White space names are ignored.
        /// </summary>
        /// <param name="fullNameBlock">string of names delimited by the specified character</param>
        /// <param name="delimiter">delimiter of the string parameter</param>
        /// <param name="nameProducer">Factory instance of the needed concrete name.</param>
        /// <param name="nameCollection">ICollection instance for storing the INames</param>
        /// <returns>ICollection instance filled with INames.</returns>
        public static ICollection<IName> BlockStringNameToIName(string fullNameBlock, string delimiter, INameFactory nameProducer, ICollection<IName> nameCollection)
        {
            string[] stringNames;

            // edge case of a null parameter. Handle by assuming a blank string array.
            if (fullNameBlock == null)
            {
                stringNames = new string[] { "" };
            }
            else
            {
                // split string block into names based on the newline character. 
                stringNames = fullNameBlock.Split(delimiter);
            }

            // insert
            foreach (string stringName in stringNames)
            {
                if (!string.IsNullOrWhiteSpace(stringName))
                {
                    nameCollection.Add(nameProducer.ProduceName(stringName));
                }
            }

            return nameCollection;
        }
    }
}
