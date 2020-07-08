using System;
using System.Linq;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        private List<ContactData> contactCache = null;

        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }

        public void AddContactToGroup(ContactData contact, GroupData group)
        {
            manager.Navigator.GoToHomePage();
            ClearGroupFilter();
            SelectContact(contact.Id);
            SelectGroupToAdd(group.Name);
            CommitAddingContactToGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }

        public void CheckContactInGroup()
        {
            ContactData contact = ContactData.GetAll()[0];
            GroupData group = GroupData.GetAll()[0];
            List<GroupData> List = contact.GetGroups();

            if (List.Count() == 0)
            {
                AddContactToGroup(contact, group);
            };
        }

        public void CheckContactOutOfGroup()
        {
            ContactData c = new ContactData(TestBase.GenerateRandomString(5), TestBase.GenerateRandomString(5));

            ContactData contact = ContactData.GetAll()[0];
            List<GroupData> groupsList = GroupData.GetAll();
            List<GroupData> contactGroupsList = contact.GetGroups();

            groupsList.Sort();
            contactGroupsList.Sort();

            if (groupsList.SequenceEqual(contactGroupsList))
            {
                Create(c);
            }
        }

        public void ClearGroupFilter()
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText("[all]");
        }

        public void CommitAddingContactToGroup()
        {
            driver.FindElement(By.Name("add")).Click();
        }

        public void CommitRemovingContactFromGroup()
        {
            driver.FindElement(By.Name("remove")).Click();
        }

        public ContactHelper ContactCheck()
        {
            manager.Navigator.GoToHomePage();
            if (driver.Url == manager.Navigator.baseURL && !IsElementPresent(By.Name("selected[]")))
            {
                ContactData contact = new ContactData("Name", "Lastname");
                Create(contact);
            }
            return this;
        }

        public ContactHelper Create(ContactData contact)
        {
            InitContactCreation();
            FillContactForm(contact);
            SubmitContactCreation();
            ReturnToHomePage();
            return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("lastname"), contact.Lastname);
            Type(By.Name("middlename"), contact.Middlename);
            return this;
        }

        public ContactData GetContactInformationFromContactPage(int index)
        {
            manager.Navigator.GoToHomePage();
            driver.FindElement(By.XPath("(//img[@alt='Details'])[" + (index + 1) + "]")).Click();
            string allData = driver.FindElement(By.Id("content")).Text;

            return new ContactData(null, null)
            {
                AllData = allData
            };
        }

        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification(index);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");

            string email1 = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            return new ContactData(firstName, lastName)
            {
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                Email1 = email1,
                Email2 = email2,
                Email3 = email3
            };
        }

        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.GoToHomePage();

            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allEmail = cells[4].Text;
            string allPhones = cells[5].Text;

            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllPhones = allPhones,
                AllEmail = allEmail
            };
        }

        public List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                manager.Navigator.GoToHomePage();
                ICollection<IWebElement> elements = driver.FindElements(By.Name("entry"));

                foreach (IWebElement element in elements)
                {
                    IList<IWebElement> cells = element.FindElements(By.TagName("td"));
                    contactCache.Add(new ContactData(cells[2].Text, cells[1].Text)
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    });
                }
            }

            return new List<ContactData>(contactCache);
        }

        public ContactHelper InitContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public ContactHelper InitContactModification(int index)
        {
            driver.FindElement(By.XPath("(//img[@alt='Edit'])[" + (index + 1) + "]")).Click();
            return this;
        }

        public ContactHelper Modify(int index, ContactData newData)
        {
            manager.Navigator.GoToHomePage();

            InitContactModification(index);
            FillContactForm(newData);
            SubmitContactModification();
            ReturnToHomePage();
            return this;
        }

        public ContactHelper Remove()
        {
            manager.Navigator.GoToHomePage();

            SelectContact();
            RemoveContact();
            return this;
        }

        public ContactHelper Remove(ContactData contact)
        {
            manager.Navigator.GoToHomePage();

            SelectContact(contact.Id);
            RemoveContact();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(d => d.FindElements(By.Id("search_count")).Count > 0);
            return this;
        }

        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            contactCache = null;
            return this;
        }

        public void RemoveContactFromGroup(GroupData group, ContactData contact)
        {
            manager.Navigator.GoToHomePage();
            SelectGroupFromRemove(group.Id);
            SelectContact(contact.Id);
            CommitRemovingContactFromGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }

        public ContactHelper ReturnToHomePage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
            return this;
        }

        public void SelectGroupFromRemove(string Id)
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByValue(Id);
        }

        public ContactHelper SelectContact()
        {
            driver.FindElement(By.Name("selected[]")).Click();
            return this;
        }

        public ContactHelper SelectContact(string id)
        {
            driver.FindElement(By.Id(id)).Click();
            return this;
        }

        public void SelectGroupToAdd(string name)
        {
            new SelectElement(driver.FindElement(By.Name("to_group"))).SelectByText(name);
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            contactCache = null;
            return this;
        }
    }
}
