using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    public class BinaryTreeNode<Key, Value> where Key : IComparable
    {
        public BinaryTreeNode<Key, Value> parent = null;
        public BinaryTreeNode<Key, Value> left = null;
        public BinaryTreeNode<Key, Value> right = null;

        private Key key;

        private Value value;

        public Key NodeKey
        {
            get { return key; }
            set { key = value; }
        }

        public Value NodeValue
        {
            get { return value; }
            set { this.value = value; }
        }

        public BinaryTreeNode(Key key, Value value, BinaryTreeNode<Key, Value> parent)
        {
            this.key = key;
            this.value = value;
            this.parent = parent;
        }

        public int ChildNodesCount()
        {
            if (null == left && null == right)
            {
                return 0;
            }
            if (null != left && null != right)
            {
                return 2;
            }

            return 1;
        }

        public bool IsLeftChild() // является ли текущий узлел левым у своего родителя       
        {
            if (this == parent.left)
            {
                return true;
            }
            return false;
        }


        public void Add(Key key, Value value)
        {
            int KeyComp = this.NodeKey.CompareTo(key);
            if (-1 == KeyComp)
            {
                if (null == right)
                {
                    right = new BinaryTreeNode<Key, Value>(key, value, this);
                }
                else
                {
                    right.Add(key, value);
                }
            }
            else if (1 == KeyComp)
            {
                if (null == left)
                {
                    left = new BinaryTreeNode<Key, Value>(key, value, this);
                }
                else
                {
                    left.Add(key, value);
                }
            }
            else if (0 == KeyComp)
            {
                throw new ArgumentException($"Key with value {value} already exists");
            }
            
        }
    }
}
