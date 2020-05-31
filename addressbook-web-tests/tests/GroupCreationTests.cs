using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {

        [Test]
        public void GroupCreationTest()
        {
            GroupData group = new GroupData("Group 1")
            {
                Header = "Field 1",
                Footer = "Field 2"
            };
            app.Groups.Create(group);
            app.Auth.Logout();
        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData group = new GroupData("Group 1")
            {
                Header = "Field 1",
                Footer = "Field 2"
            };
            app.Groups.Create(group);
            app.Auth.Logout();
        }

    }
}
