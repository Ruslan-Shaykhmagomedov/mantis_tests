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
            List<ProjectData> oldProjects = app.Project.GetProjectList(); // Get old list of project

            ProjectData newProject = new ProjectData("newProject");
            app.Project.Create(newProject);

            List<ProjectData> newProjects = app.Project.GetProjectList(); // Get new list of project
            oldProjects.Add(newProject);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);
        }
    }
}