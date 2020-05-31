using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {

        [Test]
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData("Иван", "Иванов")
            {
                Middlename = "Иванович",
                Nickname = ""
            };
            app.Contacts.Create(contact);
            app.Auth.Logout();
        }

        [Test]
        public void EmptyContactCreationTest()
        {
            ContactData contact = new ContactData("", "")
            {
                Middlename = "",
                Nickname = ""
            };
            app.Contacts.Create(contact);
            app.Auth.Logout();
        }

    }
}
