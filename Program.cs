using System.Linq;
using System.Collections.Generic;
using System;
using System.IO; // Convert text file to store in a List
using System.Diagnostics; 

namespace Lab2_
{
    internal class Program
    {
        // Case 1: Store text file in a list
        static IList<string> StoreWordInList(string fileName)
        {
            IList<string> words = new List<string>();
            using (var file = new StreamReader(fileName))
            {
                string s;
                while ((s = file.ReadLine()) != null)
                {
                    foreach (var word in s.Split(' ', StringSplitOptions.RemoveEmptyEntries)) {
                        words.Add(word);
                    }
                }
            }
            return words;
        }

        // Case 2: Perform a bubble sort algorithm
        static IList<string> BubbleSort(IList<string> words)
        {
            var time = Stopwatch.StartNew(); // count the time process
            bool swap;

            do
            {
                swap = false;
                for (int i = 0; i < words.Count - 1; i++)
                {
                    if (string.Compare(words[i], words[i + 1], StringComparison.OrdinalIgnoreCase) > 0) // Compare less sensitive -> 'This' === 'this'
                    {
                        var temp = words[i];
                        words[i] = words[i + 1];
                        words[i + 1] = temp;
                        swap = true;
                    }
                }
            } while (swap);
            time.Stop();
            Console.WriteLine($"Compile at {time.ElapsedMilliseconds} ms");
            return words;
        }

        // Case 3: Perform a LINQ sort algorithm
        static IList<string> LINQSort(IList<string> words)
        {
            var time = Stopwatch.StartNew();
            var lambdaSort = words.OrderBy(x => x).ToList();
            time.Stop();
            Console.WriteLine($"Compile at {time.ElapsedMilliseconds} ms");
            return lambdaSort;
        }

        static void Main(string[] args)
        {
            IList<string> words = null;
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("(1) Import Words from File");
                Console.WriteLine("(2) Bubble Sort words (alphabetically ascending)");
                Console.WriteLine("(3) LINQ/ Lambda sort words (alphabetically ascending");
                Console.WriteLine("(4) Count the distinct words");
                Console.WriteLine("(5) Take the first 10 words");
                Console.WriteLine("(6) Reverse each word and print the list");
                Console.WriteLine("(7) Get and display the words that end with 'a' and display the count");
                Console.WriteLine("(8) Get and display the words that start with letter 'm' and display the count");
                Console.WriteLine("(9) Get and display the words that are more than 5 characters long and contain the letter 's' and display the count");
                Console.Write("Choose from 1 to 9 or X to exit: ");
                string str = Console.ReadLine();

                switch (str)
                {
                    case "1":
                        words = StoreWordInList("../../../Words.txt");
                        Console.WriteLine($"There are {words.Count} words in Words.txt \n");
                        break;

                    case "2":
                        if (words == null)
                        {
                            Console.WriteLine("Please import Words.txt from case 1 \n");
                            break;
                        }
                        var bubbleSort = BubbleSort(words);
                        Console.WriteLine("Words sorted: ");
                        foreach (var word in bubbleSort)
                        {
                            Console.Write(word + " | ");
                        }
                        Console.WriteLine("\n");
                        break;

                    case "3":
                        if (words == null)
                        {
                            Console.WriteLine("Please import Words.txt from case 1 \n");
                            break;
                        }
                        var linqSort = LINQSort(words);
                        foreach (var word in linqSort)
                        {
                            Console.Write(word + " | ");
                        }
                        Console.WriteLine("\n");
                        break;

                    case "4":
                        if(words == null)
                        {
                            Console.WriteLine("Please import Words.txt from case 1 \n");
                            break;
                        }
                        int count = words.Distinct().Count();
                        Console.WriteLine($"Distinct: {count} \n");
                        break;

                    case "5":
                        if (words == null)
                        {
                            Console.WriteLine("Please import Words.txt from case 1 \n");
                            break;
                        }
                        var tenWords = words.Take(10);
                        Console.Write("First 10 words: ");
                        foreach (var word in tenWords)
                        {
                            Console.Write(word + " | ");
                        }
                        Console.WriteLine("\n");
                        break;

                    case "6":
                        if (words == null)
                        {
                            Console.WriteLine("Please import Words.txt from case 1 \n");
                            break;
                        }
                        var wordReverse = words.Select(word => new string(word.Reverse().ToArray()));
                        Console.Write("Reverse words: ");
                        foreach (var word in wordReverse)
                        {
                            Console.Write(word + " | ");
                        }
                        Console.WriteLine("\n");
                        break;

                    case "7":
                        if (words == null)
                        {
                            Console.WriteLine("Please import Words.txt from case 1 \n");
                            break;
                        }
                        var wordEndWithA = words.Where(word => word.EndsWith("a", StringComparison.OrdinalIgnoreCase));
                        Console.Write($"There are {wordEndWithA.Count()} words end with 'a': ");
                        foreach (var word in wordEndWithA)
                        {
                            Console.Write(word + " | ");
                        }
                        Console.WriteLine("\n");
                        break;

                    case "8":
                        if (words == null)
                        {
                            Console.WriteLine("Please import Words.txt from case 1 \n");
                            break;
                        }
                        var wordStartWithM = words.Where(word => word.StartsWith("m", StringComparison.OrdinalIgnoreCase));
                        Console.Write($"There are {wordStartWithM.Count()} words start with 'm': ");
                        foreach (var word in wordStartWithM)
                        {
                            Console.Write(word + " | ");
                        }
                        Console.WriteLine("\n");
                        break;

                    case "9":
                        if (words == null)
                        {
                            Console.WriteLine("Please import Words.txt from case 1 \n");
                            break;
                        }
                        var wordContainMore5CharAndLetterS = words.Where(word => word.Length > 5 && word.Contains("s", StringComparison.OrdinalIgnoreCase));
                        Console.WriteLine($"There are {wordContainMore5CharAndLetterS.Count()} words more than 5 characters and contains 's': ");
                        foreach (var word in wordContainMore5CharAndLetterS)
                        {
                            Console.Write(word + " | ");
                        }
                        Console.WriteLine("\n");
                        break;

                    case "X":
                    case "x":
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid! Please select from 1 to 9\n");
                        break;
                }
            }
        }
    }
}
