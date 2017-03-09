using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkMyList
{
    class BinarySearchTree<T>
    {
        public BSTNode<T> Root { get; set; }
        public BinarySearchTree()
        {
            Root = null;
        }
        public void Insert(T x)
        {
            Root = Insert(x, Root);
        }
        public T Find(T x)
        {
            return ElementAt(Find(x, Root));
        }

        private T ElementAt(BSTNode<T> node)
        {
            return node == null ? default(T) : node.Element;
        }
        private BSTNode<T> Find(T x, BSTNode<T> node)
        {
            while (node != null)
            {
                if ((x as IComparable).CompareTo(node.Element) < 0)
                {
                    node = node.Left;
                }
                else if ((x as IComparable).CompareTo(node.Element) > 0)
                {
                    node = node.Right;
                }
                else
                {
                    return node;
                }
            }

            return null;
        }
        protected BSTNode<T> Insert(T x, BSTNode<T> node)
        {
            if (node == null)
            {
                node = new BSTNode<T>(x);
            }
            else if ((x as IComparable).CompareTo(node.Element) < 0)
            {
                node.Left = Insert(x, node.Left);
            }
            else if ((x as IComparable).CompareTo(node.Element) > 0)
            {
                node.Right = Insert(x, node.Right);
            }

            return node;
        }
    }
}
