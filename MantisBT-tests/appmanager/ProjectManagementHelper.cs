using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace MantisBT_tests
{
    public class ProjectManagementHelper :HelperBase
    {
        public ProjectManagementHelper(ApplicationManager manager) : base(manager)
        {
        }

        public ProjectManagementHelper Create(ProjectData project)
        {
            manager.ManagementMenu.GoToManagementPage();
            manager.ManagementMenu.GoToManagementProjectPage();
            InitNewProjectCreation();
            FillProjectForm(project);
            SubmitProjectCreation();
            ReturnToManagementProjectPage();
            return this;
        }

        public bool CheckDuplicateName(List<ProjectData> oldProjects, ProjectData project)
        {
            
            foreach (ProjectData oldProject in oldProjects)
            {
               if (oldProject.Name.Equals(project.Name))
                  {
                       return true;
                  }
            }
            return false;
        }

        public ProjectManagementHelper InitNewProjectCreation()
        {
            driver.FindElement(By.XPath("//button[text()='Создать новый проект']")).Click();
            return this;
        }

        public ProjectManagementHelper FillProjectForm(ProjectData project)
        {
            Type(By.Name("name"), project.Name);
            Type(By.Name("description"), project.Title);
            return this;
        }

        public ProjectManagementHelper SubmitProjectCreation()
        {
            driver.FindElement(By.XPath("//input[@value='Добавить проект']")).Click();
            projectCache = null;
            return this;
        }

        public ProjectManagementHelper ReturnToManagementProjectPage()
        {
            driver.FindElement(By.XPath("//a[text()='Продолжить']")).Click();
            return this;
        }

        public ProjectManagementHelper Remove(int p)
        {
            manager.ManagementMenu.GoToManagementPage();
            manager.ManagementMenu.GoToManagementProjectPage();
            SelectProject(p);
            RemoveProject();
            RemoveProject();
            return this;
        }

        public bool ProjectCheck()
        {
            manager.ManagementMenu.GoToManagementPage();
            manager.ManagementMenu.GoToManagementProjectPage();
            return IsElementPresent(By.XPath("//h4[text()='			Проекты		']/../..//tbody/tr"));
        }

        public ProjectManagementHelper SelectProject(int index)
        {
            driver.FindElement(By.XPath("//h4[text()='			Проекты		']/../..//tbody/tr/td/a["+ index+ "]")).Click();
            return this;
        }

        public ProjectManagementHelper RemoveProject()
        {
            driver.FindElement(By.XPath("//input[@value='Удалить проект']")).Click();
            projectCache = null;
            return this;
        }

        public int GetProjectCount()
        {
            return driver.FindElements(By.XPath("//h4[text()='			Проекты		']/../..//tbody/tr")).Count;
        }

        private List<ProjectData> projectCache = null;

        public List<ProjectData> GetProjectList()
        {
            if (projectCache == null)
            {
                manager.ManagementMenu.GoToManagementPage();
                manager.ManagementMenu.GoToManagementProjectPage();
                projectCache = new List<ProjectData>();
                ICollection<IWebElement> elements = driver.FindElements(By.XPath("//h4[text()='			Проекты		']/../..//tbody/tr"));
                foreach (IWebElement element in elements)
                {
                    IList<IWebElement> cells = element.FindElements(By.TagName("td"));
                    projectCache.Add(new ProjectData()
                    {
                        Name = cells[0].Text,
                        Title = cells[4].Text
                    });
                }
            }
            return new List<ProjectData>(projectCache);
        }
    }
}
