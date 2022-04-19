using NUnit.Framework;
using System.Collections.Generic;

namespace MantisBT_tests

{
    [TestFixture]
    public class ProjectRemovalTests : AuthTestBase
    {    
        [Test]
        public void ProjectRemovalTest()
        {
            ProjectData project = new ProjectData()
            {
                Name = "hhhh",
                Title = "prprpr"
            };
            AccountData account = new AccountData("administrator", "root");
            List<ProjectData> oldProject = app.API.GetAllProject(account);
            if (app.API.GetAllProject(account).Count == 0)
            {
                app.API.ProjectAdd(account, project);
                oldProject = app.API.GetAllProject(account);
            }
            app.ProjectManagement.Remove(1);
            Assert.AreEqual(oldProject.Count - 1, app.API.GetAllProject(account).Count);
            List<ProjectData> newProject = app.API.GetAllProject(account);
            oldProject.RemoveAt(0);
            Assert.AreEqual(oldProject, newProject);
        }
    }
}
