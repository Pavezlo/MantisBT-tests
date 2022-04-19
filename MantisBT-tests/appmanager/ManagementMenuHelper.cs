using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace MantisBT_tests
{
    public class ManagementMenuHelper :HelperBase
    {
        private string baseURL;

        public ManagementMenuHelper(ApplicationManager manager, string baseURL) :base(manager)
        {
            this.baseURL = baseURL;
        }

        public void GoToHomePage()
        {
            if (driver.Url == baseURL + "/my_view_page.php"
                && IsElementPresent(By.XPath("//a[text()='Назначенные мне, нерешенные']")))
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL);
        }

        public void GoToManagementPage()
        {
            if(driver.Url == baseURL + "/manage_overview_page.php"
                && IsElementPresent(By.XPath("//h4[text()='			О сайте		']")))
            {
                return;
            }
            driver.FindElement(By.XPath("//i[@class='fa fa-gears menu-icon']/..")).Click();
        }

        public void GoToManagementProjectPage()
        {
            if (driver.Url == baseURL + "/manage_proj_page.php"
                && IsElementPresent(By.XPath("//button[text()='Создать новый проект']")))
            {
                return;
            }
            driver.FindElement(By.XPath("//a[text()='Управление проектами']")).Click();
        }
    }
}
