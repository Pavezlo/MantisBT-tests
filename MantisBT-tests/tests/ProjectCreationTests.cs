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
                Name = "bbb",
                Title = "вот такой здесь текст"
            };
            List<ProjectData> oldProjects = app.ProjectManagement.GetProjectList();
            project.Name = app.ProjectManagement.CheckDuplicateName(oldProjects, project);
            app.ProjectManagement.Create(project);
            Assert.AreEqual(oldProjects.Count + 1, app.ProjectManagement.GetProjectCount());

            List<ProjectData> newGroups = app.ProjectManagement.GetProjectList();
            oldProjects.Add(project);
            oldProjects.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldProjects, newGroups);
        }
    }
}
