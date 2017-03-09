using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkMyList
{
    enum Sorting
    {
        ByMemberID,
        ByFirstName,
        ByAge
    }
    class MyList
    {
        private Node Head { get; set; }

        public void Insert(object element)
        {
            Node node = new Node();
            node.Data = element;
            node.Next = Head.Next;
            Head.Next = node;
        }
        public void Insert(object element, int index)
        {
            Node node = new Node();
            node.Data = element;
            if (index == 0)
            {
                Insert(element);
            }
            if (index > 0)
            {
                Node current = Search(index);
                Node previous = Search(index - 1);
                if (previous.Next == null)
                {
                    previous.Next = node;
                }
                node.Next = current;
                previous.Next = node;
            }

        }
        public void Delete()
        {
            Node temp = Head.Next;
            Head.Next = Head.Next.Next;
            temp = null;
        }

        public void Delete(int index)
        {
            if (index == 0)
            {
                Delete();
            }
            if (index > 0)
            {
                Node cur = Search(index);
                Node prev = Search(index - 1);
                prev.Next = cur.Next;
                cur = null;
            }
        }
        public Node Search(int index)
        {
            Node temp = new Node();
            temp = Head.Next;

            for (int i = 0; i < index; i++)
            {
                if (temp.Next == null)
                {
                    return temp;
                }
                temp = temp.Next;
            }

            return temp;
        }
        public override string ToString()
        {
            string data = "";
            Node temp = new Node();
            temp = Head;

            while (temp.Next != null)
            {
                data = data + temp.Next.Data + "\n";
                temp = temp.Next;
            }
            return data;
        }

        public MyList()
        {
            this.Head = new LinkMyList.Node();
            Head.Next = null;
            Head.Data = null;
        }

        public void Sort(Sorting input)
        {
            switch (input)
            {
                case Sorting.ByMemberID:
                    break;
                case Sorting.ByFirstName:
                    break;
                case Sorting.ByAge:
                    break;
                default:
                    break;
            }
        }

        public void Swap(Node n1, Node n2)
        {
            Node temp = new Node();
            temp = n1;

            n1 = n2;
            n2 = temp;

        }
        public void SortByID()
        {
            ClubMember cm1 = new ClubMember();
            ClubMember cm2 = new ClubMember();

            for (Node ptr = Head.Next; ptr.Next != null; ptr = ptr.Next)
            {

                for (Node newptr = ptr.Next; newptr != null; newptr = newptr.Next)
                {
                    cm1 = (ClubMember)ptr.Data;
                    cm2 = (ClubMember)newptr.Data;

                    if (cm1.Nr > cm2.Nr)
                    {
                        Swap(ptr, newptr);
                    }
                }
            }
        }

        public bool Contains(Object obj)
        {
            ClubMember cm = obj as ClubMember;
            Node temp = new Node();
            temp = Head;

            while (temp.Next != null)
            {
                if (cm.Equals(temp.Data))
                {
                    return true;
                }
                temp = temp.Next;
            }
            return false;
        }

        public int IndexOf(object obj)
        {
            ClubMember cm = obj as ClubMember;
            Node temp = new Node();
            int counter = 0;
            temp = Head;

            while (temp.Next != null)
            {
                counter++;
                if (cm.Equals(temp.Data))
                {
                    return counter;
                }
                temp = temp.Next;
            }
            return -1;
        }
    }
}
