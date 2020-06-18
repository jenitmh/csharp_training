using System.Collections.Generic;
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
            app.Contacts.ContactCheck();

            List<ContactData> oldContacts = app.Contacts.GetContactList();
            ContactData oldData = oldContacts[0];

            app.Contacts.Modify(0, newData);

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts[0].Firstname = newData.Firstname;
            oldContacts[0].Lastname = newData.Lastname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                if (contact.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Firstname + newData.Lastname, contact.Firstname + contact.Lastname);
                }
            }

            app.Auth.Logout();
        }
    }
}
