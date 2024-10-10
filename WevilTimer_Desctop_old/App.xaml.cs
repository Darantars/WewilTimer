using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace WevilTimer_Desctop
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override async void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            PreloaderWindow preloaderWindow = new PreloaderWindow();
            MainWindow mainWindow = new MainWindow();

            preloaderWindow.Show();

            await Task.Delay(2500);

            preloaderWindow.Close();


            mainWindow.Show();
            this.MainWindow = mainWindow;
        }
    }
}