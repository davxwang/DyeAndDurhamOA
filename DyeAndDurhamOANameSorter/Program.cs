namespace DyeAndDurhamOANameSorter
{
    public class Program
    {
        public static List<IName> HelperStringToINameList(string stringBlockNames, string delimiter)
        {
            string[] stringNames;
            List<IName> names;
            
            // edge case. Handle by giving a blank string array.
            if (stringBlockNames == null)
            {
                stringNames = new string[] { "" };
            }
            else
            {
                // split string block into names based on the newline character. 
                stringNames = stringBlockNames.Split(delimiter);
            }

            names = new List<IName>(stringNames.Length);
            foreach (string stringName in stringNames)
            {
                if (!string.IsNullOrWhiteSpace(stringName))
                {
                    names.Add(new Name(stringName));
                }
            }

            return names;
        }

        public static void Main(string[] args)
        {
            NameSorter nSorter;
            string stringBlobName = null;
            string outputString;
            // error handling in case of unexpected failure while reading
            try
            {
                // Open the text file asynchronously using the stream reader.
                using (StreamReader sr = new StreamReader("./unsorted-names-list.txt"))
                {
                    // Read the file as a string
                    stringBlobName = sr.ReadToEnd();
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file read failed:");
                Console.WriteLine(e.Message);
            }


            // generate output string
            nSorter = new NameSorter(HelperStringToINameList(stringBlobName, Environment.NewLine));
            outputString = nSorter.GetSortedString(Environment.NewLine);

            // write output to console and file
            Console.WriteLine(outputString);
            using (StreamWriter sw = new StreamWriter("sorted-names-list.txt"))
            {
                sw.Write(outputString);
            }
        }
    }
}
