namespace Condez_SIS_v3
{
    internal static class Program
    {
        public static string ConnectionString = @"Server=DESKTOP-G6J8QFP\SQLEXPRESS01;Database=DaveDB;Trusted_Connection=True;TrustServerCertificate=True;";
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}