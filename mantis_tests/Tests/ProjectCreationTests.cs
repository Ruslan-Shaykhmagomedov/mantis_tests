using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectCreationTests : AuthTestBase
    {
        [Test]
        public void TestProjectCreation()
        {
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "root"
            };

            List<ProjectData> oldProjects = app.Project.GetProjectList(account); // Get old list of project

            ProjectData newProject = new ProjectData("newProject7");
            app.Project.Create(newProject);

            List<ProjectData> newProjects = app.Project.GetProjectList(account); // Get new list of project
            oldProjects.Add(newProject);
            Assert.AreEqual(oldProjects, newProjects);
        }
    }
}