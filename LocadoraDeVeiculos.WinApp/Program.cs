using Serilog;

namespace LocadoraDeVeiculos.WinApp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {

            Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.Debug()
                    .WriteTo.Seq("http://localhost:5341")
                    .CreateLogger();

            ApplicationConfiguration.Initialize();
            Application.Run(new TelaPrincipalForm());
        }
    }
}