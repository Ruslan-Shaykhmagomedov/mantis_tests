using Org.BouncyCastle.Asn1.Cms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class APIHelper : HelperBase
    {

        public APIHelper (ApplicationManager manager) : base (manager)
        {
        }

        public void CreateNewIssue(AccountData account,ProjectData project, IssueData issueData) // method for system call
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient(); // create new object for soap call 
            Mantis.IssueData issue = new Mantis.IssueData();
            issue.project = new Mantis.ObjectRef();

            issue.summary = issueData.Summary; // required filed
            issue.description = issueData.Description; // required filed
            issue.category = issueData.Category; // required filed
            issue.project.id = project.Id; // required filed


            client.mc_issue_add(account.Name, account.Password, issue);

        }
    }
}
