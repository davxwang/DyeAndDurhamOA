namespace DyeAndDurhamOANameSorter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            NameSorterDefault NameSorterDefault = new NameSorterDefault();
            NameLastFirstsFactory nameLastFirstsFactory = new NameLastFirstsFactory();
            List<IName> names = new List<IName>();

            // error handling in case of unexpected failure while reading
            try
            {
                // Open the text file asynchronously using the stream reader.
                using (StreamReader sr = new StreamReader("./unsorted-names-list.txt"))
                {
                    string? inputName;
                    // Read and deserialize one line at a time. Stop once eof is reached.
                    while((inputName = sr.ReadLine()) is not null)
                    {
                        names.Add(NameDeserializer.SingleStringNameToIName(inputName, nameLastFirstsFactory));
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file read failed:");
                Console.WriteLine(e.Message);
            }


            // sort
            NameSorterDefault.Replace(names);
            // in case it somehow returns null, assume it intended to mean empty list
            names = NameSorterDefault.GetResult() as List<IName> ?? new List<IName>();

            // write output to console and file
            using (StreamWriter sw = new StreamWriter("sorted-names-list.txt"))
            {
                foreach (IName name in names)
                {
                    string outputString = NameSerializer.INameToString(name);

                    sw.Write(outputString);
                    Console.WriteLine(outputString);
                }
            }
        }
    }
}
