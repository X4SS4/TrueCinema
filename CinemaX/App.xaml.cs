namespace CinemaX;

using CinemaX.ViewModels.Base;
using CinemaX.ViewModels;
using System.Windows;
using SimpleInjector;
using CinemaX.Messager.Services.Base;
using CinemaX.Messager.Services;

public partial class App : Application {
    public static Container ServiceContainer { get; set; } = new Container();

    protected override void OnStartup(StartupEventArgs e) {
        base.OnStartup(e);

        ConfigureContainer();

        StartWindow<HomeViewModel>();
    }

    private void ConfigureContainer() {
        ServiceContainer.RegisterSingleton<IMessenger, Messenger>();

        ServiceContainer.RegisterSingleton<HomeViewModel>();
        ServiceContainer.RegisterSingleton<MainViewModel>();
        ServiceContainer.RegisterSingleton<LoginViewModel>();
        ServiceContainer.RegisterSingleton<MoviesViewModel>();
        ServiceContainer.RegisterSingleton<ReceiptViewModel>();
        ServiceContainer.RegisterSingleton<RegistrationViewModel>();

        ServiceContainer.Verify();
    }

    private void StartWindow<T>() where T : ViewModelBase {
        var startView = new MainWindow();

        var startViewModel = ServiceContainer.GetInstance<MainViewModel>();
        startViewModel.ActiveViewModel = ServiceContainer.GetInstance<T>();
        startView.DataContext = startViewModel;

        startView.ShowDialog();
    }
}