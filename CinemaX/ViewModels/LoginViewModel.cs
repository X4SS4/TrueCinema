namespace CinemaX.ViewModels;

using CinemaX.Messager.Messages;
using CinemaX.Messager.Services.Base;
using CinemaX.Tools;
using CinemaX.ViewModels.Base;
using System.Linq;

public class LoginViewModel : ViewModelBase
{
    private readonly IMessenger _messenger;
    private string _userLogin;

    public string UserLogin
    {
        get => this._userLogin;
        set => base.PropertyChange(out _userLogin, value);
    }

    private string _userPassword;

    public string UserPassword
    {
        get => this._userPassword;
        set => base.PropertyChange(out _userPassword, value);
    }

    public LoginViewModel(IMessenger messenger)
    {
        this._messenger = messenger;
    }

    #region Commands

    private MyCommand _loginCommand;
    public MyCommand LoginCommand
    {
        get => this._loginCommand ??= new MyCommand(
            action: () => Login(),
            predicate: () => true);
        set => base.PropertyChange(out this._loginCommand, value);
    }

    private MyCommand _backCommand;
    public MyCommand BackCommand
    {
        get => this._backCommand ??= new MyCommand(
            action: () => Back(),
            predicate: () => true);
        set => base.PropertyChange(out this._backCommand, value);
    }

    #endregion

    void Login()
    {
        if (HomeViewModel.users.Any(user => user.Login == UserLogin && UserPassword == user.Password))
        {
            MoviesViewModel.User = HomeViewModel.users.FirstOrDefault(user => user.Login == UserLogin && UserPassword == user.Password);
            this._messenger.Send(new NavigationMessage(typeof(MoviesViewModel)));
        }
    }

    void Back()
    {
        this._messenger.Send(new NavigationMessage(typeof(HomeViewModel)));
    }
}
