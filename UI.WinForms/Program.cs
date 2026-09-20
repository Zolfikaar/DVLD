using System;
using System.Windows.Forms;
using Application.DTOs;
using Application.Services;
using DependencyInjection;
using UI.WinForms.Forms.User;

namespace UI.WinForms
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

            PersonService personService = ServiceBootstrapper.CreatePersonService();
            UserService userService = ServiceBootstrapper.CreateUserService();
            ApplicationTypeService applicationTypeService = ServiceBootstrapper.CreateApplicationTypeService();
            TestTypeService testTypeService = ServiceBootstrapper.CreateTestTypeService();

            while (true)
            {
                UserDto loggedInUser;
                using (LoginForm loginForm = new LoginForm(userService))
                {
                    if (loginForm.ShowDialog() != DialogResult.OK || loginForm.LoggedInUser == null)
                        return;

                    loggedInUser = loginForm.LoggedInUser;
                }

                CurrentUserSession.SignIn(loggedInUser);

                using (MainForm mainForm = new MainForm(personService, userService, applicationTypeService, testTypeService))
                {
                    System.Windows.Forms.Application.Run(mainForm);
                    CurrentUserSession.SignOut();

                    if (!mainForm.IsLogout)
                        return;
                }
            }
        }
    }
}
