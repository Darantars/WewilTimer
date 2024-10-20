using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WevilTimer_Desctop.MainModels.Mvvm;

namespace WevilTimer_Desctop.MainWindow
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }

    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand ExpandCommand { get; }
        public ICommand CollapseCommand { get; }
        public ICommand CloseCommand { get; }

        public MainViewModel()
        {
            ExpandCommand = new RelayCommand(Expand);
            CollapseCommand = new RelayCommand(Collapse);
            CloseCommand = new RelayCommand(Close);
        }

        private void Expand(object parameter)
        {
            if (parameter is System.Windows.Window window)
            {
                if (window.WindowState != WindowState.Maximized)
                {
                    window.WindowState = WindowState.Maximized;
                }
                else
                {
                    window.WindowState = WindowState.Normal;
                }
            }
        }

        private void Collapse(object parameter)
        {
            if (parameter is System.Windows.Window window)
            {
                window.WindowState = WindowState.Minimized;
            }
        }

        private void Close(object parameter)
        {
            Console.WriteLine("Close action triggered");
            if (parameter is System.Windows.Window window)
            {
                window.Close();
            }
        }
    }

}
