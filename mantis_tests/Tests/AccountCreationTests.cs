using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using NUnit.Framework;

namespace mantis_tests 
{
    [TestFixture]
    public class AccountCreationTests : TestBase
    {
        [TestFixtureSetUp]
        public void SetUpConfig()
        {
            app.Ftp.BackUpFile("/config_defaults_inc.php");
            using (Stream localFile = File.Open("C://Users//Ruslan//source//repos//mantis_tests//mantis_tests//config_defaults_inc.php", FileMode.Open))
            app.Ftp.Upload("/config_defaults_inc.php", localFile);
        }

        [Test]
        public void TestAccountRegistration()
        {
            AccountData account = new AccountData()
            {
                Name = "mantis",
                Password = "mantis",
                Email = "mantis@localhost.localdomain",
            };

            List<AccountData> accounts = app.Admin.GetAllAccounts();
            AccountData existingAccount = accounts.Find(x => x.Name == account.Name);

            if(existingAccount != null)
            {
                app.Admin.DeleteAccount(existingAccount);
            }
            
            app.Registration.Register(account);
        }
        [TestFixtureTearDown]
        public void RestoreConfig()
        {
            app.Ftp.RestoreBackUpFile("/config_defaults_inc.php");

        }
    }
}
