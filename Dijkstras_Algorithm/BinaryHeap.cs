using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstras_Algorithm
{
    class BinaryHeap<T> where T : IComparable
    {
        public int Count
        {
            get
            {
                return items.Count();
            }
        }

        private List<T> items = new List<T>();

        public void Add(T new_item)
        {
            items.Add(new_item);

            int i = Count - 1;

            int parent = GetParentIndex(i);

            while (i > 0 && LeftBiggerThanRigth(items[parent], items[i])) // items[i] > items[parent]
            {
                Swap(i, parent);

                i = parent;
                parent = GetParentIndex(i);     
            }
        }


        public void Heapify(int i)
        {
            int largestChild;
            int leftChild;
            int smallestChild;

            while (true)
            {
                leftChild = 2 * i + 1;
                smallestChild = 2 * i + 2;
                largestChild = i;

                if (leftChild < Count && LeftBiggerThanRigth(items[largestChild], items[leftChild]))
                {
                    largestChild = leftChild;
                }

                if (smallestChild < Count && LeftBiggerThanRigth(items[largestChild], items[smallestChild]))
                {
                    largestChild = smallestChild;
                }

                if (largestChild == i)
                {
                    break;
                }

                Swap(i, largestChild);
                i = largestChild;
            }
        }

        public T DeleteMin()
        {
            if (items.Count == 0)
            {
                return default;
            }

            T res = items[0];
            items[0] = items[Count - 1];
            items.RemoveAt(Count - 1);

            Heapify(0);
            
            return res;
        }
        
        private bool LeftBiggerThanRigth(T left, T right)
        {
            return left.CompareTo(right) == 1;
        }


        private void Swap(int currIndex, int otherIndex)
        {
            T temp;
            temp = items[currIndex];           
            items[currIndex] = items[otherIndex];
            items[otherIndex] = temp;
        }


        private int GetParentIndex(int currIndex)
        {
            return (currIndex - 1) / 2;
        }

        public T Min()
        {
            if (items.Count > 0)
                return items[0];
            else 
                return default(T);
        }

        public List<T> ToArray()
        {
            return new List<T>(items);
        }
    }
}
