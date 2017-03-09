using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkMyList
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Setup
            int smallSize = 1000;
            int largeSize = smallSize * 100;

            ClubMember[] smallLinear = new ClubMember[smallSize];
            ClubMember[] largeLinear = new ClubMember[largeSize];

            ClubMember[] smallBinary = new ClubMember[smallSize];
            ClubMember[] largeBinary = new ClubMember[largeSize];

            BinarySearchTree<ClubMember> SmallCmTree = new BinarySearchTree<ClubMember>();
            BinarySearchTree<ClubMember> LargeCmTree = new BinarySearchTree<ClubMember>();

            HashADT smallHashADT = new HashADT(smallSize);
            HashADT largeHashADT = new HashADT(largeSize);

            for (int i = 0; i < smallSize; i++)
            {
                smallHashADT.Insert(CMFactory.GetClubMember());
            }

            for (int i = 0; i < largeSize; i++)
            {
                largeHashADT.Insert(CMFactory.GetClubMember());
            }

            for (int i = 0; i < smallSize; i++)
            {
                SmallCmTree.Insert(CMFactory.GetClubMember());   
            }

            for (int i = 0; i < largeSize; i++)
            {
                LargeCmTree.Insert(CMFactory.GetClubMember());
            }


            for (int i = 0; i < smallSize; i++)
            {
                smallLinear[i] = CMFactory.GetClubMember();
                smallBinary[i] = CMFactory.GetClubMember();
            }

            for (int i = 0; i < largeSize; i++)
            {
                largeLinear[i] = CMFactory.GetClubMember();
                largeBinary[i] = CMFactory.GetClubMember();
            }
            #endregion
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();

            #region Linear search
            Console.WriteLine("Linear Searching:");
            SearchLinear(smallLinear);
            Console.WriteLine(sw.Elapsed);

            sw.Restart();
            SearchLinear(largeLinear);
            Console.WriteLine(sw.Elapsed);
            #endregion

            #region Binary Search
            Console.WriteLine();
            Console.WriteLine("Sorting small array:");
            sw.Restart();
            InsertionSort(smallBinary);
            Console.WriteLine(sw.Elapsed);

            Console.WriteLine();
            Console.WriteLine("Searching small binary");
            sw.Restart();
            SearchBinary(smallBinary);
            Console.WriteLine(sw.Elapsed);

            Console.WriteLine();
            Console.WriteLine("Sorting large array:");
            sw.Restart();
            InsertionSort(largeBinary);
            Console.WriteLine(sw.Elapsed);

            Console.WriteLine();
            Console.WriteLine("Searching large binary");
            sw.Restart();
            SearchBinary(largeBinary);
            Console.WriteLine(sw.Elapsed);
            #endregion

            #region Binary Search Tree
            Console.WriteLine();
            Console.WriteLine("Searching small binary tree");
            sw.Restart();
            SearchBST(SmallCmTree);
            Console.WriteLine(sw.Elapsed);

            Console.WriteLine();
            Console.WriteLine("Searching large binary tree");
            sw.Restart();
            SearchBST(LargeCmTree);
            Console.WriteLine(sw.Elapsed);
            #endregion

            #region HashADTs
            Console.WriteLine("HashADT");
            Console.WriteLine("Searching small Hash ADT");
            sw.Restart();
            SearchHashADT(smallHashADT);
            Console.WriteLine(sw.Elapsed);

            Console.WriteLine();
            Console.WriteLine("Searching large Hash ADT");
            sw.Restart();
            SearchHashADT(largeHashADT);
            Console.WriteLine(sw.Elapsed);
            #endregion

            Console.ReadKey();


        }
        static void Run()
        {
            //MyList mylist = new MyList();
            //ClubMember cm1 = new ClubMember(1, "Pelle", "Hansen", 24);
            //ClubMember cm2 = new ClubMember(2, "Peter", "Christensen", 21);
            //ClubMember cm3 = new ClubMember(3, "Elias", "Ehlers", 30);
            //ClubMember cm4 = new ClubMember(4, "Johannes", "Erlandsen", 20);
            //ClubMember cm5 = new ClubMember(5, "Mr.", "Coolguy", 19);
            //ClubMember cm6 = new ClubMember(5, "Mr.", "Niceguy", 18);
            //ClubMember cm7 = new ClubMember(5, "Mr.", "Swag", 23);

            //mylist.Insert(cm1);
            //mylist.Insert(cm2);
            //mylist.Insert(cm3);
            //mylist.Insert(cm4);

            //Console.WriteLine("Exercise 1: Insert without index");
            //Console.WriteLine(mylist.ToString());

            //Console.WriteLine("Search for object at a given index");
            //Console.WriteLine(mylist.Search(5).ToString());

            //mylist.Delete();

            //Console.WriteLine();
            //Console.WriteLine("Delete first element in the list");
            //Console.WriteLine(mylist.ToString());

            //Console.WriteLine("Insert at a given index");
            //mylist.Insert(cm4, 0);
            //mylist.Insert(cm5, 3);
            //mylist.Insert(cm6);
            //mylist.Insert(cm7);
            //Console.WriteLine(mylist.ToString());

            //mylist.Delete(0);

            //Console.WriteLine();
            //Console.WriteLine("Delete at a given index");
            //Console.WriteLine(mylist.ToString());

            ////Console.WriteLine();
            ////Console.WriteLine("Sorting by NR");
            ////mylist.SortByID();
            ////Console.WriteLine(mylist.ToString());




            //Console.WriteLine();
            //Console.WriteLine("Does the list contain cm3?");
            //if (mylist.Contains(cm3) == true)
            //{
            //    Console.WriteLine("True");
            //}
            //else
            //{
            //    Console.WriteLine("False");
            //}

            //Console.WriteLine();
            //Console.WriteLine("Get the index of cm5");
            //Console.WriteLine(mylist.IndexOf(cm5));


            //Console.ReadKey();



        }
        public static void SearchLinear(IComparable[] arr)
        {
            Random rnd = new Random();

            ClubMember cm1 = (ClubMember)arr[rnd.Next(0, arr.Length)];
            ClubMember cm2 = (ClubMember)arr[rnd.Next(0, arr.Length)];
            ClubMember cm3 = (ClubMember)arr[rnd.Next(0, arr.Length)];
            ClubMember[] cmarr = new ClubMember[] { cm1, cm2, cm3 };

            for (int i = 0; i < 1000; i++)
            {
                foreach (var item in cmarr)
                {
                    for (int ii = 0; ii < arr.Length; ii++)
                    {
                        arr[ii].Equals(item);

                    }
                }
            }


        }
        static ClubMember[] InsertionSort(ClubMember[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                int j = i;
                while ((j > 0) && (arr[j].Nr < arr[j - 1].Nr))
                {
                    int k = j - 1;
                    ClubMember temp = arr[k];
                    arr[k] = arr[j];
                    arr[j] = temp;

                    j--;
                }
            }
            return arr;
        }
        public static void SearchBinary(IComparable[] arr)
        {
            Random rnd = new Random(); ClubMember[] clubmemberstofind = new ClubMember[] 
            {
                (ClubMember)arr[rnd.Next(0, arr.Length)],
                (ClubMember)arr[rnd.Next(0, arr.Length)],
                (ClubMember)arr[rnd.Next(0, arr.Length)]
            };
            for (int i = 0; i < 1000; i++)
            {
                foreach (var item in clubmemberstofind)
                {
                    int low = 0;          
                    int high = arr.Length - 1;            
                    int middle = (low + high + 1) / 2;        
                    int location = -1; 
                                   
                    do               
                    {
                        for (int j = 0; j < middle; j++)
                            if (item.Nr == (arr[middle] as ClubMember).Nr)
                            {
                                location = middle;
                            }

                            else if (item.Nr < (arr[middle] as ClubMember).Nr)
                            {
                                high = middle - 1;
                            }
                            else
                            {
                                low = middle + 1;
                                middle = (low + high + 1) / 2;
                            }   
                    }
                    while ((low <= high) && (location == -1));
                    // Console.WriteLine("tofind " + item.ToString() +" "+ arr[location].ToString());    
                }
            }
        }

        static void SearchBST(BinarySearchTree<ClubMember> Tree)
        {
            Random rnd = new Random(); ClubMember[] clubmemberstofind = new ClubMember[]
           {
                CMFactory.GetClubMember(),
                CMFactory.GetClubMember(),
                CMFactory.GetClubMember()
           };
            for (int i = 0; i < 1000; i++)
            {
                foreach (var item in clubmemberstofind)
                {
                    Tree.Find(item);
                }
            }

        }
        static void SearchHashADT(HashADT hash)
        {
            Random rnd = new Random(); ClubMember[] clubmemberstofind = new ClubMember[]
          {
                CMFactory.GetClubMember(),
                CMFactory.GetClubMember(),
                CMFactory.GetClubMember()
          };
            for (int i = 0; i < 1000; i++)
            {
                foreach (var item in clubmemberstofind)
                {
                    if (hash.IndexInUse(hash.GetIndex(item)) == false)
                    {
                        return;
                    }
                    hash.GetElement(hash.Search(item));    
                }
            }
        }
     }

 }

