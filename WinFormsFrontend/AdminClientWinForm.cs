namespace WinFormsFrontend
{
    internal static class AdminClientWinForm
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new AdminFormLogin());
        }
    }
}