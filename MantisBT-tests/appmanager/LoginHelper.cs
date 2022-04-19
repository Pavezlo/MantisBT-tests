using OpenQA.Selenium;
using System;

namespace MantisBT_tests
{
    public class LoginHelper :HelperBase
    { 
        public LoginHelper(ApplicationManager manager) : base(manager)
        {
        }

        public void Login(AccountData account)
        {
            if (IsLoggedIn())
            {
                if (IsLoggedIn(account))
                {
                    return;
                }
                LogOut();
            }
            Type(By.Name("username"), account.Username);
            driver.FindElement(By.XPath("//input[@type='submit']")).Click();
            Type(By.Name("password"), account.Password);
            driver.FindElement(By.XPath("//input[@type='submit']")).Click();
        }

        public bool IsLoggedIn(AccountData account)
        {
            return IsLoggedIn()
                && GetLoggetUserName() == account.Username;
        }

        public string GetLoggetUserName()
        {
            return driver.FindElement(By.CssSelector("span.user-info")).Text;
        }

        public bool IsLoggedIn()
        {
            return IsElementPresent(By.XPath("//a[text()=' Выход']"));
        }

        public void LogOut()
        {
            if (IsLoggedIn()) 
            { 
                driver.FindElement(By.CssSelector("a.dropdown-toggle")).Click();
                driver.FindElement(By.XPath("//a[text()=' Выход']")).Click();
            }
            driver.FindElement(By.Name("username"));
        }
    }
}
