using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkMyList
{
    class BSTNode<T>
    {
        public T Element { get; set; }
        public BSTNode<T> Left { get; set; }
        public BSTNode<T> Right { get; set; }

        public BSTNode(T element)
        {
            this.Element = element;
        }
        public override string ToString()
        {
            string nodeString = "[" + Element + " ";

            // Leaf node
            if (Left == null && Right == null)
            {
                nodeString += " (Leaf) ";
            }

            if (Left != null)
            {
                nodeString += "Left: " + Left.ToString();
            }

            if (Right != null)
            {
                nodeString += "Right: " + Right.ToString();
            }

            nodeString += "] ";

            return nodeString;
        }
    }
}
