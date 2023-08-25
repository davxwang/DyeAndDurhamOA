namespace DyeAndDurhamOANameSorter
{
    /// <summary>
    /// Class that stores names as first names[], last name, and full name
    /// </summary>
    public class Name : IName
    {
        private List<string> firstNames;
        private string lastName, fullName;

        public string FullName
        {
            get { return fullName; }
            set { SetFullName(value); }
        }

        /// <summary>
        /// Default constructor populates lastName and fullName with empty strings, and firstNames with an empty list
        /// </summary>
        public Name()
        {
            fullName = "";
            firstNames = new List<string>();
            lastName = "";
        }
        /// <summary>
        /// Populates the name fields based on the fullName. Null, empty, or whitespace fullName fallsback to default constructor behavior. Single name fullName assumes there is only a lastName and no firstNames.
        /// </summary>
        /// <param name="fullName">full name</param>
        public Name(string fullName)
        {
            SetFullName(fullName);
        }

        private void SetFullName(string newFullName)
        {
            // edge case handling: null and whitespace
            if (string.IsNullOrWhiteSpace(newFullName))
            {
                this.fullName = "";
                this.firstNames = new List<string>();
                this.lastName = "";
            }
            else
            {
                this.fullName = newFullName;
                this.firstNames = new List<string>(newFullName.Split(' ', StringSplitOptions.RemoveEmptyEntries));
                System.Diagnostics.Debug.Assert(firstNames.Count > 0, "Exceptional name found");    // should never trigger
                this.lastName = firstNames[firstNames.Count - 1];
                this.firstNames.RemoveAt(firstNames.Count - 1);
            }
        }

        /// <summary>
        /// Sort based on last name, then first name. Empty names go to the top
        /// </summary>
        /// <param name="obj">Name</param>
        /// <returns></returns>
        public int CompareTo(object obj)
        {
            // default behavior?
            if (obj == null) return 1;

            Name otherName = obj as Name;
            if (otherName != null)
                // same last name. Check first names.
                if (this.lastName == otherName.lastName)
                {
                    for (int i = 0; i < Math.Min(this.firstNames.Count, otherName.firstNames.Count); i++)
                    {
                        int innerComparisonResult = string.Compare(this.firstNames[i], otherName.firstNames[i]);
                        if (innerComparisonResult != 0)
                        {
                            return innerComparisonResult;
                        }
                    }
                    // all first names up to the shorter of two to names are the same

                    if (this.firstNames.Count == otherName.firstNames.Count)
                    {
                        return 0;
                    }
                    else
                    {
                        if (this.firstNames.Count < otherName.firstNames.Count)
                        {
                            return -1;
                        }
                        else
                        {
                            return 1;
                        }
                    }
                }
                // different last names. Comparison depends on it.
                else
                {
                    return string.Compare(this.lastName, otherName.lastName);
                }
            else
                throw new ArgumentException("Object is not a Name");
        }
    }
}
