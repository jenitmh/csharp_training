using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newData = new ContactData("Ivan", "Ivanov")
            {
                Middlename = null,
                Nickname = null
            };
            app.Contacts.Modify(1, newData);
            app.Auth.Logout();
        }
    }
}
