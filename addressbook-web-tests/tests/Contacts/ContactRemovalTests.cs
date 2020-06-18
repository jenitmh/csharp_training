using System.Collections.Generic;
using NUnit.Framework;

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

            ContactData toBeRemoved = oldContacts[0];
            oldContacts.RemoveAt(0);
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
            };

            app.Auth.Logout();
        }
    }
}
