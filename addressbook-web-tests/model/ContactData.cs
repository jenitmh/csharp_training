namespace WebAddressbookTests
{
    public class ContactData
    {

        public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Middlename { get; set; }

        public string Nickname { get; set; }

        //public string Groupname { get; set; }

    }
}
