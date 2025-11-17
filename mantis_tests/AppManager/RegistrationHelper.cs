using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Text.RegularExpressions;

namespace mantis_tests
{
    public class RegistrationHelper : HelperBase
    {
        public RegistrationHelper(ApplicationManager manager) : base(manager)
        {
        }

        public void Register(AccountData account) // Function for registration new user with accountData
        {
            OpenMainPage();
            OpenRegistrationForm();
            FillRegistrationForm(account);
            SubmitRegistration();
            String url = GetConfirmationUrl(account);
            FillPasswordForm(url, account);
            SubmitPasswordForm();
        }

        private void SubmitPasswordForm()
        {
            driver.FindElement(By.CssSelector("input.button")).Click();
        }

        private void FillPasswordForm(string url, AccountData account)
        {
            driver.Url = url;
            driver.FindElement(By.Name("password")).SendKeys(account.Password);
            driver.FindElement(By.Name("password_confirm")).SendKeys(account.Password);
        }

        private string GetConfirmationUrl(AccountData account)
        {
            String message = manager.Mail.GetLastMail(account);
            Match match = Regex.Match(message, @"http://\S*");
            return match.Value;
        }

        private void OpenRegistrationForm() // Click on the Registration button
        {
            driver.FindElements(By.CssSelector("span.bracket-link"))[0].Click();
        }

        private void SubmitRegistration() // Click on submit button for registration
        {
            driver.FindElement(By.CssSelector("input.button")).Click();
        }

        private void FillRegistrationForm(AccountData account)  // Fill registration form with accountData
        {
            driver.FindElement(By.Name("username")).SendKeys(account.Name); // Fill Name 
            driver.FindElement(By.Name("email")).SendKeys(account.Email); // Fill Email
        }

        private void OpenMainPage() // Open main page 
        {
            manager.Driver.Url = "http://localhost/mantisbt-2.27.1/manage_user_page.php";
        }
    }
}
