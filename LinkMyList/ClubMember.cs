using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkMyList
{
    class ClubMember : IComparable
    {
        public int Nr { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"Member {Nr} Name: {Fname} {Lname} Age: {Age}";
        }

        public int CompareTo(object obj)
        {
            if (this.Nr < (obj as ClubMember).Nr )
            {
                return -1;
            }
            if (this.Nr > (obj as ClubMember).Nr)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public ClubMember(int Nr, string Fname, string Lname, int Age)
        {
            this.Nr = Nr;
            this.Fname = Fname;
            this.Lname = Lname;
            this.Age = Age;
        }
        public ClubMember()
        { }

        public override bool Equals(object obj)
        {
            if (this.GetHashCode() == obj.GetHashCode())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return Nr.GetHashCode() + Fname.GetHashCode() + Lname.GetHashCode() + Age.GetHashCode();
        }
    }
}
