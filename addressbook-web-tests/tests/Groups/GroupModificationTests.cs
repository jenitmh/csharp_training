using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : TestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("Group Modifided")
            {
                Header = null,
                Footer = null
            };
            app.Groups.Modify(1, newData);
            app.Auth.Logout();
        }
    }
}
