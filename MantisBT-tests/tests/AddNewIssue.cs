using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MantisBT_tests
{
    [TestFixture]
    public class AddNewIssueTests : TestBase
    {
        [Test]
        public void AddNewIssue()
        {
            AccountData account = new AccountData()
            {
                Username = "administrator",
                Password = "root"
            };
            ProjectData project = new ProjectData() {
                Id = "15"
            };

            IssueData issue = new IssueData()
            {
                Summary = "some short text",
                Description = "some ong text",
                Categori = "General"
            };

            app.API.CreateNewIssue(account, project, issue);
        }
    }
}
