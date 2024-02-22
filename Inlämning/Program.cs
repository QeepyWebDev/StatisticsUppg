using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Inlämning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Uppgift 1
            String[] array = [ "Anders", "Olle", "Karin", "Alexander", "Michelle", "Anna" ]; //En array med olika namn.
            
            foreach (String s in array) //Skriver ut alla strängar i arrayen, för att testa att det funkar.
            {
                Console.WriteLine(s);
            }

            Console.WriteLine("\n"); //Skippa en rad för bättre läsbarhet i konsolen.
            GroupItemsCreateFiles(array); //Ropar på metod med arrayen som argument.
            Console.WriteLine("List files created successfully."); //Låter användaren veta att filerna har skapats.

            //Uppgift 2
            //MakeList(array); //Ropar på metod med arrayen som argument.

            //static void MakeList(string[] array)
            //{
            //    List<string> startsWithA = []; //Initierar array.

            //    foreach (string str in array) //Foreach loop som kontrollerar varje sträng om den börjar på "a", om så är fallet så läggs strängen till i en lista.
            //    {
            //        if (str.StartsWith('a') || str.StartsWith('A'))
            //        {
            //            startsWithA.Add(str);
            //        }
            //    }

            //    foreach (string str in startsWithA) //Skriver ut listan med alla strängar som börjar på "a".
            //    {
            //        Console.WriteLine(str);
            //    }

            //    string folderPath = "./Lists/A"; //Bestämmer vart den nya mappen ska skapas och vad den ska heta.
            //    Directory.CreateDirectory(folderPath); //Skapar mappen.

            //    string filePath = Path.Combine(folderPath, "List A.txt"); //Bestämmer filens namn och lägger till.
            //    using StreamWriter writer = new StreamWriter(filePath); //Skriver info till filen.
            //    {
            //        foreach (string item in startsWithA) //Lägger till varje sträng i listan till filen.
            //        {
            //            writer.WriteLine(item);
            //        }
            //    }

            //    Console.WriteLine("\n List created."); //Låter användaren veta att filen har skapats.
            //}

            //Vidareutveckling för uppgift 2 - Jag valde att göra om metoden på ett bättre, enklare sätt.
            static void GroupItemsCreateFiles(string[] array)
            {
                List<string> list = array.ToList(); //Omvandlar arrayen till en lista.
                var groupedItems = list.GroupBy(item => item[0]); //Gruppera strängarna i listan med hjälp av första bokstaven (index 0).

                foreach (var group in groupedItems) //Foreach loop som tar grupperna och skapar filer och lägger dessa i skapade mappar.
                {
                    string folderName = $"{group.Key}"; //Mappens namn blir första bokstaven av gruppen.
                    string folderPath = $"./Lists/{folderName}"; //Bestämmer vart mappen ska skapas.
                    Directory.CreateDirectory(folderPath); //Skapar sökvägen för mappen.

                    string filePath = Path.Combine(folderPath, $"{group.Key}.txt"); //Den nya filen döps till första bokstaven i gruppen.
                    using StreamWriter writer = new (filePath); //Skriver info till filen.
                    {
                        foreach (string item in group) //Foreach loop som lägger till varje sträng i gruppen till filen.
                        {
                            writer.WriteLine(item);
                        }
                    }
                }
            }
        }
    }
}
