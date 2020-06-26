using System;
using System.Text.RegularExpressions;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmail;
        private string allData;

        public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Middlename { get; set; }

        public string Nickname { get; set; }

        public string Id { get; set; }

        //public string Groupname { get; set; }

        public string Address { get; set; }

        public string HomePhone { get; set; }

        public string MobilePhone { get; set; }

        public string WorkPhone { get; set; }

        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }

        public string Email1 { get; set; }

        public string Email2 { get; set; }

        public string Email3 { get; set; }

        public string AllEmail
        {
            get
            {
                if (allEmail != null)
                {
                    return allEmail;
                }
                else
                {
                    return Email1 + "\r\n" + Email2 + "\r\n" + Email3.Trim();
                }
            }
            set
            {
                allEmail = value;
            }
        }

        public string AllData
        {
            get
            {
                if (allData != null)
                {
                    return CleanUpData(allData);
                }
                else
                {
                    return CleanUpData(Firstname)
                        + CleanUpData(Lastname)
                        + CleanUpData(Address)
                        + CleanUpData(HomePhone)
                        + CleanUpData(MobilePhone)
                        + CleanUpData(WorkPhone)
                        + CleanUpData(Email1)
                        + CleanUpData(Email2)
                        + CleanUpData(Email3).Trim();
                }
            }
            set
            {
                allData = value;
            }
        }

        public string CleanUpData(string arg)
        {
            if (arg == null || arg == "")
            {
                return "";
            }
            return Regex.Replace(arg, @"[ -()HMW:\n\r]", "");
        }

        public string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone, "[ -()]", "") + "\r\n";
        }

        public int CompareTo(ContactData other)
        {
            if (other is null)
            {
                return 1;
            }
            if (Lastname == other.Lastname)
            {
                return Firstname.CompareTo(other.Firstname);
            }

            return Lastname.CompareTo(other.Lastname);
        }

        public bool Equals(ContactData other)
        {
            if (other is null)
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return (Firstname == other.Firstname) && (Lastname == other.Lastname);
        }

        public override int GetHashCode()
        {
            return Firstname.GetHashCode() ^ Lastname.GetHashCode();
        }

        public override string ToString()
        {
            return "Firstname = " + Firstname + "\nLastname = " + Lastname;
        }
    }
}
