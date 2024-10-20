
using System.Threading.Tasks;
using System.Windows;


namespace WevilTimer_Desctop
{

    public partial class PreloaderWindow : Window
    {
        public PreloaderWindow()
        {
            InitializeComponent();
            //Здесь далее стоит расположить какую-нибудь проверку обновлений и подгрузку ресурсов
            LoadMainWindowAsync();
        }

        private async void LoadMainWindowAsync()
        {
            await Task.Delay(2000); 
            MainWindow.MainWindow mainWindow = new MainWindow.MainWindow();
            mainWindow.Show();
            this.Close(); 
        }
    }
}
