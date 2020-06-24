using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactInformationTests : AuthTestBase
    {

        [Test]
        public void ContactInformationFromTableTest()
        {
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(0);
            ContactData fromTable = app.Contacts.GetContactInformationFromTable(0);

            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
            Assert.AreEqual(fromTable.AllEmail, fromForm.AllEmail);
        }

        [Test]
        public void ContactInformationFromContactPageTest()
        {
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(0);
            ContactData fromPage = app.Contacts.GetContactInformationFromContactPage(0);

            Assert.AreEqual(fromForm.AllData, fromPage.AllData);
        }
    }
}
