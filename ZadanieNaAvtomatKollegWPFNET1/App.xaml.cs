using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;

namespace ZadanieNaAvtomatKollegWPFNET1
{
    public partial class App : Application
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        public App()
        {
            // Конфигурация DI
            ServiceProvider = DependencyInjection.ConfigureServices();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Получаем экземпляр главного окна через DI
            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }
    }
}