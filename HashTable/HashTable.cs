using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTables
{
    class HashTable<T> where T : IComparable
    {
        public int Size { get; private set; }

        private Cell<T>[] table;

        public HashTable(int size)
        {
            if (size < 0)
            {
                throw new IndexOutOfRangeException();
            }

            Size = size;
            table = new Cell<T>[Size];
        }
        public int Hash(string str)
        {
            ulong h = 0, HASH_MUL = 26;

            foreach (char symbol in str)
            {
                h = h * HASH_MUL + (ulong)symbol;
            }

            return (int)(h % (ulong)Size);
        }

        public void Add(string key, T value)
        {
            int h = Hash(key);

            if (null == table[h])
            {
                table[h] = new Cell<T>(key, value);
            }
            else
            {
                int i = 1;
                int first = (h + i * i) % Size;
                int curr = first;
                ++i;

                while (true)
                {
                    if (null == table[curr])
                    {
                        table[curr] = new Cell<T>(key, value);
                        break;
                    }

                    curr = (h + i * i) % Size;
                    ++i;

                    if (curr == first)
                    {
                        throw new IndexOutOfRangeException("Table is full. Unable to add element");
                    }

                }

            }
        }

        public int LookupForIndex(string key)
        {
            int h = Hash(key);
            if (null == table[h])
            {
                throw new IndexOutOfRangeException("No such element with key " + key);
            }
            else
            {
                if (table[h].Value.CompareTo(key) == 0)
                {
                    return h;
                }
            }

            int i = 1;
            int first = (h + 1) & Size;
            int curr = first;
            ++i;

            while (true)
            {
                if (null != table[curr])
                {
                    if (table[curr].Key.CompareTo(key) == 0)
                    {
                        return curr;
                    }
                }

                curr = (h + i * i) % Size;
                ++i;

                //if (curr == first)
                //{
                //    throw new IndexOutOfRangeException("No such element with key " + key);
                //}
            }
        }
        public Cell<T> Lookup(string key) 
        {
            return table[LookupForIndex(key)];
        }

        public void Delete(string key)
        {
            int i = LookupForIndex(key);
            table[i] = null;
        }

        public T this[string key]
        {
            get
            {
                return Lookup(key).Value;
            }
            set
            {
                try
                {
                    Cell<T> t = Lookup(key);
                    t.Value = value;
                }
                catch (Exception e) 
                { 
                    Add(key, value);
                }
            }
        }

        public void PrintTable()
        {
            int i = 0;
            foreach (Cell<T> c in table)
            {
                if (null == c)
                {
                    Console.WriteLine($"{i}: null");
                }
                else
                {
                    Console.WriteLine($"{i}. {c.Key} : {c.Value}");
                }
                ++i;
            }
        }


    }
}
