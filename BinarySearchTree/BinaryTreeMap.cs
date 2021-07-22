using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    class BinaryTreeMap<Key, Value> where Key : IComparable
    {
        private BinaryTreeNode<Key, Value> root = null;

        int count = 0;

        public int Count
        {
            get { return count; }
            set { count = value; }
        }

        public BinaryTreeNode<Key, Value> Root
        {
            get { return root; }
        }

        public void Add(Key key, Value value)
        {
            if (null == root)
            {
                root = new BinaryTreeNode<Key, Value>(key, value, null);
                ++count;
                return;
            }
                

            root.Add(key, value);
            ++count;
        }

        private BinaryTreeNode<Key, Value> FindNode(Key key)
        {
            BinaryTreeNode<Key, Value> t = root;
            while (null != t)
            {
                int KeyComp = t.NodeKey.CompareTo(key);
                if (0 == KeyComp)
                {
                    return t;
                }

                if (1 == KeyComp)
                {
                    t = t.left;
                }
                else
                {
                    t = t.right;
                }
            }

            throw new ArgumentException($"Key {key} not found in map!");
            
        }

        public Value Find(Key key)
        {
            BinaryTreeNode<Key, Value> t;
            try
            {
                t = FindNode(key);
            }
            catch(ArgumentException e)
            {
                Console.WriteLine(e.Message);
                return default;
            }
 
            return t.NodeValue;
        }

        public void Delete(Key key)
        {
            BinaryTreeNode<Key, Value> t = FindNode(key), t_child, next;

            
            // если нет детей у узла
            if (0 == t.ChildNodesCount())
            {
                int KeyComp = t.parent.NodeKey.CompareTo(t.NodeKey);
                if (-1 == KeyComp)
                {
                    t.parent.right = null;
                } 
                else
                {
                    t.parent.left = null;
                }
            }
            // если есть один ребенок
            else if (1 == t.ChildNodesCount())
            {
                if (null != t.left)
                {
                    t_child = t.left;
                }
                else
                {
                    t_child = t.right;
                }

                if (t.IsLeftChild())
                {
                    t.parent.left = t_child;
                }
                else
                {
                    t.parent.right = t_child;
                }
            }
            // если есть два ребенка у узла
            else if (2 == t.ChildNodesCount())
            {
                next = NextNode(t);

                t.NodeKey = next.NodeKey;
                t.NodeValue = next.NodeValue;

                if (next == next.parent.left)
                {
                    next.parent.left = next.right;
                }
                else
                {
                    next.parent.right = next.right;
                }
            }
        }

        private BinaryTreeNode<Key, Value> MinNode(BinaryTreeNode<Key, Value> node = null)
        {
            if (null == node)
            {
                node = root;
            }

            while (true)
            {
                if (null == node.left)
                {
                    return node;
                }
                node = node.left;
            }
        }

        public BinaryTreeNode<Key, Value> Min()
        {
            BinaryTreeNode<Key, Value> t = MinNode();
            BinaryTreeNode<Key, Value> res = new BinaryTreeNode<Key, Value>(t.NodeKey, t.NodeValue, null);
            return res;
        }

        private BinaryTreeNode<Key, Value> MaxNode(BinaryTreeNode<Key, Value> node = null)
        {
            if (null == node)
            {
                node = root;
            }

            while (true)
            {
                if (null == node.right)
                {
                    return node;
                }
                node = node.right;
            }
        }

        public BinaryTreeNode<Key, Value> Max()
        {
            BinaryTreeNode<Key, Value> t = MaxNode();
            BinaryTreeNode<Key, Value> res = new BinaryTreeNode<Key, Value>(t.NodeKey, t.NodeValue, null);
            return res;
        }

        private BinaryTreeNode<Key, Value> NextNode(BinaryTreeNode<Key, Value> node = null)
        {
            if (null == node)
            {
                node = root;
            }

            // если правого поддерева нет
            if (null == node.right)
            {
                while (true)
                {
                    // если текущий элемент явл левым ребенком своего родителя
                    if (node == node.parent.left)
                    {
                        return node;
                    }
                    // если дошли до корня
                    if (null == node.parent)
                    {
                        return node;
                    }
                    // иначе поднимаемся вверх по дереву
                    else 
                    {
                        node = node.parent;
                    }
                }
            }
            // если правое поддерево есть
            // возвращаем минимальный в правом поддереве
            else
            {
                return MinNode(node.right);
            }
        }

        public Key Next()
        {
            return NextNode().NodeKey;
        }
        
        private void InOrder(BinaryTreeNode<Key, Value> tree)
        // left - root - right
        // InOrderTraversal
        {
            if (null == tree)
            {
                return;
            }

            InOrder(tree.left); // go through left tree

            Console.Write($"{tree.NodeKey} ");

            InOrder(tree.right); // go through right tree
        }

        public void InOrder()
        {
            Console.WriteLine("In order: Left - Root - Right: ");
            InOrder(root);
            Console.WriteLine();
        }
        private void InOrder_Reverse(BinaryTreeNode<Key, Value> tree)
        // right - root - left
        // InOrderTraversal
        {
            if (null == tree)
            {
                return;
            }

            InOrder_Reverse(tree.right);
            Console.Write($"{tree.NodeKey} ");

            InOrder_Reverse(tree.left);
        }

        public void InOrder_Reverse()
        {
            Console.WriteLine("\nIn reverse order: Right - Root - Left: ");
            InOrder_Reverse(root);
            Console.WriteLine();
        }

        private void PreOrder(BinaryTreeNode<Key, Value> tree)
        // Roor-Left_Right
        {
            if (null == tree)
            {
                return;
            }

            Console.Write($"{tree.NodeKey} ");

            PreOrder(tree.left);
            PreOrder(tree.right);
        }

        public void PreOrder()
        {
            Console.WriteLine("\nPreOrder: Root-Left-Right: ");
            PreOrder(root);
            Console.WriteLine();
        }

        private void PostOrder(BinaryTreeNode<Key, Value> tree)
        // Left-Right-Root
        {
            if (null == tree)
            {
                return;
            }

            PostOrder(tree.left);
            PostOrder(tree.right);

            Console.Write($"{tree.NodeKey} ");
        }

        public void PostOrder()
        {
            Console.WriteLine("\nPostOrder: Left-Right-Root: ");
            PostOrder(root);
            Console.WriteLine();
        }

        
        public BinaryTreeNode<Key, Value>[] BreadthFirst() // обход в ширину
        {
            Queue<BinaryTreeNode<Key, Value>> queue = new Queue<BinaryTreeNode<Key, Value>>();
            BinaryTreeNode<Key, Value> t;
            BinaryTreeNode<Key, Value>[] res = new BinaryTreeNode<Key, Value>[this.count];
            int i = 0;

            queue.Enqueue(root);
            while (queue.Count != 0)
            {
                t = queue.Dequeue();
                res[i++] = new BinaryTreeNode<Key, Value>(t.NodeKey, t.NodeValue, null);

                if (null != t.left)
                {
                    queue.Enqueue(t.left);
                }
                if (null != t.right)
                {
                    queue.Enqueue(t.right);
                }
            }

            return res;
        }

        public void PrintBreadthFirst()
        {
            BinaryTreeNode<Key, Value>[] nodes = BreadthFirst();

            Console.WriteLine("\nBreadth First traversal: ");
            foreach (BinaryTreeNode<Key, Value> node in nodes)
            {
                Console.Write($"{node.NodeKey} ");
            }
            Console.WriteLine();
        }


    }
}
