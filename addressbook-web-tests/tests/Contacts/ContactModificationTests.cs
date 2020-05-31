using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : TestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newData = new ContactData("Ivan", "Ivanov")
            {
                Middlename = "Ivanovich",
                Nickname = ""
            };
            app.Contacts.Modify(1, newData);
            app.Auth.Logout();
        }
    }
}
