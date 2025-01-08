using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using WewilTimer.ViewModels;
using WewilTimer.Views;

namespace WewilTimer
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                var mainView = new MainView();
                var mainViewModel = new MainViewModel(mainView);
                mainView.DataContext = mainViewModel;

                desktop.MainWindow = new MainWindow
                {
                    Content = mainView
                };
            }
            else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
            {
                var mainView = new MainView();
                var mainViewModel = new MainViewModel(mainView);
                mainView.DataContext = mainViewModel;

                singleViewPlatform.MainView = mainView;
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}