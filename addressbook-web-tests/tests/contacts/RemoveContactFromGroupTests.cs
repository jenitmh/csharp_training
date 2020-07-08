using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    class RemoveContactFromGroupTests : AuthTestBase
    {
        [Test]
        public void RemoveContactFromGroupTest()
        {
            app.Contacts.CheckContactInGroup();

            ContactData contact = ContactData.GetAll()[0];
            List<GroupData> oldList = contact.GetGroups();
            GroupData group = oldList[0];

            app.Contacts.RemoveContactFromGroup(group, contact);

            List<GroupData> newList = contact.GetGroups();
            oldList.Remove(group);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);

        }
    }
}
