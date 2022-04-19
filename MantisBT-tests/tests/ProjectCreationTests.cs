using System.Collections.Generic;
using NUnit.Framework;

namespace MantisBT_tests
{
    [TestFixture]
    public class ProjectCreationTests : AuthTestBase
    {        
        [Test]
        public void ProjectCreationTest()
        {
            ProjectData project = new ProjectData()
            {
                Name = "bbb" + GenerateRandomString(10),
                Title = "вот такой здесь текст"
            };
            AccountData account = new AccountData("administrator", "root");
            List<ProjectData> oldProjects = app.API.GetAllProject(account);
            Assert.False(app.ProjectManagement.CheckDuplicateName(oldProjects, project));
            app.ProjectManagement.Create(project);
            Assert.AreEqual(oldProjects.Count + 1, app.API.GetAllProject(account).Count);

            List<ProjectData> newGroups = app.API.GetAllProject(account);
            oldProjects.Add(project);
            oldProjects.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldProjects, newGroups);
        }
    }
}
