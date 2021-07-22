using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTreeMap<int, string> bt = new BinaryTreeMap<int, string>();

            //int[] arr = { 50, 72, 54, 76, 67, 17, 23, 12, 19, 9, 14 };

            //BuildTree(arr);


            TestTask();

            //FillTreeAsInEx(bt);

            //Console.WriteLine(bt.Find(40));
            //bt.Delete(40);
            //Console.WriteLine(bt.Find(40));

            //Console.WriteLine(bt.Min());

            //Console.WriteLine(bt.Max());

            // TestTask();
        }

        static public void BuildTree(int[] arr)
        {
            BinaryTreeMap<int, string> bt = new BinaryTreeMap<int, string>();

            foreach (int i in arr)
            {
                bt.Add(i, i.ToString());
            }

            BTreePrinter.PrintTree(bt.Root);

        }

        static public void FillTree(BinaryTreeMap<int, string> tree)
        {
            int key;
            string input;
            Console.WriteLine("Enter q to stop input");
            while (true)
            {
                Console.Write("Enter key to add: ");
                input = Console.ReadLine();

                if ("q" == input)
                {
                    break;
                }

                if (Int32.TryParse(input, out key))
                {
                    tree.Add(key, key.ToString());
                }
            }
        }

        static public void FillTreeAsInEx(BinaryTreeMap<int, string> tree)
        {
            int[] arr = { 60, 40, 80, 35, 55, 77, 90, 44, 58, 79 };

            foreach (int i in arr)
            {
                tree.Add(i, i.ToString());
            }
        }

        static public void TestTraversal()
        {
            BinaryTreeMap<int, string> bt = new BinaryTreeMap<int, string>();

            FillTreeAsInEx(bt);

            TestTraversal(bt);
        }

        static public void TestTraversal(BinaryTreeMap<int, string> bt)
        {
            Console.WriteLine("\nTesting traversals: \n");

            bt.InOrder();

            bt.InOrder_Reverse();

            bt.PreOrder();

            bt.PostOrder();

            bt.PrintBreadthFirst();

            Console.WriteLine();
        }

        static public void TestFind(BinaryTreeMap<int, string> bt, int key)
        {
            string val = bt.Find(key);
            Console.WriteLine($"Key {key}: {val}");
        }

        static public void TestDelete(BinaryTreeMap<int, string> bt, int key)
        {
            Console.WriteLine($"Deleting node with key: {key}");
            bt.Delete(key);
            BTreePrinter.PrintTree(bt.Root);
            Console.WriteLine();
        }

        static public void TestTask()
        {
            BinaryTreeMap<int, string> bt = new BinaryTreeMap<int, string>();

            bt.Add(56, "fifty six");
            bt.Add(23, "twenty three");
            bt.Add(36, "thirty six");
            bt.Add(22, "twenty two");
            bt.Add(87, "eighty seven");
            bt.Add(44, "fourty four");
            bt.Add(25, "twenty five");
            bt.Add(73, "seventy three");
            bt.Add(11, "eleven");

            BTreePrinter.PrintTree(bt.Root);

            TestTraversal(bt);

            TestFind(bt, 23);
            TestFind(bt, 56);
            TestFind(bt, 36);

            Console.WriteLine();
            BinaryTreeNode<int, string> t = bt.Min();
            Console.WriteLine($"Min key {t.NodeKey}: {t.NodeValue}");

            Console.WriteLine();
            t = bt.Max();
            Console.WriteLine($"Max key {t.NodeKey}: {t.NodeValue}");

            BTreePrinter.PrintTree(bt.Root);
            Console.WriteLine();

            TestDelete(bt, 23);
            TestDelete(bt, 56);
            TestDelete(bt, 36);

        }

    }
}
