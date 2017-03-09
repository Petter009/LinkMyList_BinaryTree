using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkMyList
{
    class HashADT
    {
        private IComparable[] cmArray { get; set; }

        public HashADT(int sizeOfArray)
        {
            cmArray = new IComparable[sizeOfArray];
        }

        public void Insert(IComparable data)
        {
            int placeholder = data.GetHashCode() % cmArray.Length;
            if (placeholder < 0)
            {
                placeholder = placeholder * -1;
            }
            cmArray[placeholder] = data; 
        }

        public int Search(IComparable data)
        {
            int placeholder = data.GetHashCode() % cmArray.Length;
            if (placeholder < 0)
            {
                return placeholder * - 1;
            }
            if (cmArray[placeholder] == null)
            {
                return -1;
            }
            else
            {
                return placeholder;
            }
        }

        public IComparable GetElement(int idx)
        {
                return cmArray[idx];    
        }

        public bool IndexInUse (int idx)
        {
            if (cmArray[idx] == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public int GetIndex(IComparable element)
        {
            int placeholder = element.GetHashCode() % cmArray.Length;

            if (placeholder < 0)
            {
                return placeholder * -1;
            }
            else
            {
                return placeholder;
            }
        }

    }
}
