using Microsoft.Extensions.Configuration;
using ShabatGuest.DAL;
using ShabatGuest.Forms;

namespace ShabatGuest
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            var config = new ConfigurationBuilder()
                .AddUserSecrets<DBconnections>()
                .Build();
            string Conn = config["connectionstring"];
            DBconnections dBconnections = new DBconnections(Conn);           
            Application.Run(new LogIn(dBconnections));
        }
    }
}