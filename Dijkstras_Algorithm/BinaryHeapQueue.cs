using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstras_Algorithm
{
    class BinaryHeapQueue<T> where T : IComparable
    {
        private BinaryHeap<T> bh = new BinaryHeap<T>();

        public int Count => bh.Count;

        public void Queue(T new_item)
        {
            bh.Add(new_item);
        }

        public T Dequeue()
        {
            return bh.DeleteMin();
        }

        public List<T> ToArray()
        {
            return bh.ToArray();
        }
    }
}
