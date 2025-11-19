using NUnit.Framework;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Xml.Linq;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectRemovalTests : AuthTestBase
    {
        [Test]
        public void TestProjectRemoval()
        {
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "root"
            };

            ProjectData projectToRemove = new ProjectData("Test Project for Removal"); // Check, if there is 1 project

            List<ProjectData> oldProjects = app.Project.GetProjectList(account); // Get list of projects

            if (oldProjects.Count == 0) // If there is no projects, create new one 
            {
                //app.Project.Create(projectToRemove);
                //oldProjects = app.Project.GetProjectList(account);
                Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
                Mantis.ProjectData projectData = new Mantis.ProjectData();
                projectData.name = "projectToRemove";

                client.mc_project_add("administrator", "root", projectData);
            }

            app.Project.Remove(projectToRemove); // delete project

            List<ProjectData> newProjects = app.Project.GetProjectList(account); // Get new list of projects

            
            Assert.That(newProjects.Count, Is.EqualTo(oldProjects.Count - 1)); // Check diff between new and old list
        }
    }
}