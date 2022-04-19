using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace MantisBT_tests
{
    public class ApplicationManager
    {

        protected string baseURL;

        private static ThreadLocal <ApplicationManager> applicationManager = new ThreadLocal<ApplicationManager>();

        #region Constructures
        private ApplicationManager()
        {
            driver = new ChromeDriver();
            baseURL = "http://localhost/mantisbt-2.25.3/login_page.php";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            loginHelper = new LoginHelper(this);
            managementMenuHelper = new ManagementMenuHelper(this, baseURL);
            projectManagementHelper = new ProjectManagementHelper(this);
        }
        #endregion

        public static ApplicationManager GetInstance()
        {
            if (!applicationManager.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.ManagermentMenu.GoToHomePage();
                applicationManager.Value = newInstance;                
            }
            return applicationManager.Value;
        }

        //Деструктор
        ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        #region Driver
        protected IWebDriver driver;
        public IWebDriver Driver
        {
            get
            {
                return driver;
            }
        }
        #endregion

        #region Auth
        protected LoginHelper loginHelper;
        public LoginHelper Auth
        {
            get
            {
                return loginHelper;
            }
        }
        #endregion

        #region ManagermentMenu
        protected ManagementMenuHelper managementMenuHelper;
        public ManagementMenuHelper ManagermentMenu
        {
            get
            {
                return managementMenuHelper;
            }
        }
        #endregion

        #region Project
        protected ProjectManagementHelper projectManagementHelper;
        public ProjectManagementHelper ProjectManagement
        {
            get
            {
                return projectManagementHelper;
            }
        }
        #endregion
    }
}
