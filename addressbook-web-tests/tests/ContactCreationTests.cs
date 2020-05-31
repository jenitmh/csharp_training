using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {

        [Test]
        public void ContactCreationTest()
        {
            app.Navigator.GoToHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Contacts.InitContactCreation();
            ContactData contact = new ContactData("Иван", "Иванов")
            {
                Middlename = "Иванович",
                Nickname = ""
            };
            app.Contacts.FillContactForm(contact);
            app.Contacts.SubmitContactCreation();
            app.Navigator.ReturnToHomePage();
            app.Auth.Logout();
        }
    }
}
