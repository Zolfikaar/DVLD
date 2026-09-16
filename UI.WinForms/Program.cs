using System;
using Application.Services;
using DependencyInjection;

namespace UI.WinForms
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

            PersonService personService = ServiceBootstrapper.CreatePersonService();

            System.Windows.Forms.Application.Run(new MainForm(personService));

    
        }
    }
}
