using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    [TestFixture]
    public class AddNewIssueTest : TestBase
    {
        [Test]
        public void AddNewIssue()
        {
            ProjectData project = new ProjectData()
            {
                Id = "1"
            };
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "root",
            };
            IssueData issueData = new IssueData()
            {
                Summary = "some short text",
                Description = "some long text",
                Category = "General"
            };
            app.API.CreateNewIssue(account,project, issueData);

        }
    }
}
