using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MantisBT_tests
{
    public class APIHelper : HelperBase
    {
        public APIHelper(ApplicationManager manager): base(manager) { }

        public void CreateNewIssue(AccountData account,ProjectData project, IssueData issueData)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.IssueData issue = new Mantis.IssueData();
            issue.summary = issueData.Summary;
            issue.description = issueData.Description;
            issue.category = issueData.Categori;
            issue.project = new Mantis.ObjectRef();
            issue.project.id = project.Id;
            client.mc_issue_add(account.Username, account.Password, issue);
        }

        public List<ProjectData> GetAllProject(AccountData account)
        {
            List<ProjectData> projects = new List<ProjectData>();

            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData[] projectMantis = client.mc_projects_get_user_accessible(account.Username, account.Password);
            foreach(Mantis.ProjectData projectM in projectMantis)
            {
                projects.Add(new ProjectData()
                {
                    Name = projectM.name,
                    Title = projectM.description,
                    Id = projectM.id
                });
            }
            return projects;
        }

        public void ProjectAdd(AccountData account, ProjectData project)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData project1 = new Mantis.ProjectData()
            {
                name = project.Name
            };
            client.mc_project_add(account.Username, account.Password, project1);
        }
    }
}
