using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {

        [Test]
        public void GroupRemovalTest()
        {
            app.Groups.GroupCheck();
            app.Groups.Remove(1);
            app.Auth.Logout();
        }
    }
}
