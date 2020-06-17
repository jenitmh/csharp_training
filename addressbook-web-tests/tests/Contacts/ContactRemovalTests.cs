using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]

        public void ContactRemovalTest()
        {
            app.Contacts.ContactCheck();

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Remove();

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.RemoveAt(0);
            Assert.AreEqual(oldContacts, newContacts);

            app.Auth.Logout();
        }
    }
}
