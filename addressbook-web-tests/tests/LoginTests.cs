using System;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]
    public class LoginTests : TestBase
    {

        [Test]
        public void LoginWithValidCredentials()
        {
            app.Auth.Logout();

            AccountData acc = new AccountData("admin", "secret");
            app.Auth.Login(acc);

            Assert.IsTrue(app.Auth.IsLoggedIn(acc));
        }

        [Test]
        public void LoginWithInvalidCredentials()
        {
            app.Auth.Logout();

            AccountData acc = new AccountData("admin", "wrongpass");
            app.Auth.Login(acc);

            Assert.IsFalse(app.Auth.IsLoggedIn(acc));
        }

    }
}
