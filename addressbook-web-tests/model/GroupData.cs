using System;
using System.Linq;
using System.Collections.Generic;
using LinqToDB.Mapping;

namespace WebAddressbookTests
{
    [Table(Name = "group_list")]
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData>
    {
        public GroupData()
        {
        }

        public GroupData(string name)
        {
            Name = name;
        }

        public int CompareTo(GroupData other)
        {
            if (other is null)
            {
                return 1;
            }
            return Name.CompareTo(other.Name);
        }

        public bool Equals(GroupData other)
        {
            if (other is null)
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return Name == other.Name;
        }
        
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override string ToString()
        {
            return "\nname = " + Name + "\nheader = " + Header + "\nfooter = " + Footer;
        }

        public static List<GroupData> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from g in db.Groups select g).ToList();
            }
        }

        [Column(Name = "group_name")]
        public string Name { get; set; }

        [Column(Name = "group_header")]
        public string Header { get; set; } = "";

        [Column(Name = "group_footer")]
        public string Footer { get; set; } = "";

        [Column(Name = "group_id"), PrimaryKey, Identity]
        public string Id { get; set; }

    }
}
