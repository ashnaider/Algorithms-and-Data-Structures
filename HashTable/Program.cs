
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTables
{
    class Program
    {
        static void Main(string[] args)
        {
            TestHashTable();

            //HashTable<string> d = new HashTable<string>(5);

            //d.Add("one", "1");

            //d["zero"] = "null";
            //d["one"] = "first";
            //d["two"] = "second";
            //d["three"] = "third";
            //d["four"] = "fourth";
            //d["five"] = "fifth";
            //d["six"] = "6";
            //d["seven"] = "7";
            //d["eight"] = "8";
            //d["nine"] = "9";


            //Console.WriteLine(d["zero"]);
            //Console.WriteLine(d["one"]);
            //Console.WriteLine(d["two"]);
            //Console.WriteLine(d["three"]);
            //Console.WriteLine(d["four"]);
            //Console.WriteLine(d["five"]);
            //Console.WriteLine(d["six"]);
            //Console.WriteLine(d["seven"]);
            //Console.WriteLine(d["eight"]);
            //Console.WriteLine(d["nine"]);

            //// d["ten"] = "10";

            //d.Delete("nine");
            //d.Delete("eight");

            //d["ten"] = "10";

            ////Console.WriteLine(d["three"]);

        }

        static void TestHashTable()
        {
            Console.Write("Enter size of table: ");
            int size = Int32.Parse(Console.ReadLine());
            if (size < 1)
            {
                return;
            }
            HashTable<string> d = new HashTable<string>(size);

            Console.WriteLine("Operations: Add[key value], Del[- key], Get[key], Set[key value]");
            string[] operands;
            while (true)
            {
                Console.Write("Enter operation: ");
                operands = Console.ReadLine().Split();

                if (operands.Length == 0)
                {
                    continue;
                }
                else if (operands[0] == "-" && operands.Length == 2)
                {
                    try
                    {
                        d.Delete(operands[1]);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Unable to delete element. What: " + e.Message);
                    }
                }
                else if (operands.Length == 2)
                {
                    try
                    {
                        d[operands[0]] = operands[1];
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Unable to add element. What:" + e.Message);
                    }
                }
                else if (operands.Length == 1)
                {
                    try
                    {
                        Console.WriteLine("Found: " + d[operands[0]]);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Can not find key {operands[0]}. What: {e.Message}");
                    } 
                }

                d.PrintTable();
            }


        }
    }
}
