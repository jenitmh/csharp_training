using OpenQA.Selenium;

namespace WebAddressbookTests
{
    public class NavigationHelper : HelperBase
    {
        public readonly string baseURL;

        public NavigationHelper(ApplicationManager manager, string baseURL) : base(manager)
        {
            this.baseURL = baseURL;
        }

        public void GoToHomePage()
        {
            if (driver.Url == baseURL && IsElementPresent(By.Name("searchform")))
            {
                return;
            }

            driver.Navigate().GoToUrl(baseURL);
        }

        public void GoToGroupsPage()
        {
            if (driver.Url == baseURL + "group.php" && IsElementPresent(By.Name("new")))
            {
                return;
            }

            driver.FindElement(By.LinkText("groups")).Click();
        }
    }
}
