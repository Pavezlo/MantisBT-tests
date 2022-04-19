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
            if (!app.ProjectManagement.ProjectCheck())
            {
                ProjectData project = new ProjectData()
                {
                    Name = "hhhh",
                    Title = "prprpr"
                };
                app.ProjectManagement.Create(project);
            }
            List<ProjectData> oldProject = app.ProjectManagement.GetProjectList();
            app.ProjectManagement.Remove(1);
            Assert.AreEqual(oldProject.Count - 1, app.ProjectManagement.GetProjectCount());
            List<ProjectData> newProject = app.ProjectManagement.GetProjectList();
            oldProject.RemoveAt(0);
            Assert.AreEqual(oldProject, newProject);
        }
    }
}
