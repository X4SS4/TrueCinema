namespace CinemaX.ViewModels;

using CinemaX.Messager.Messages;
using CinemaX.Messager.Services.Base;
using CinemaX.Tools;
using CinemaX.ViewModels.Base;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using WPF_project_N_000047.Models;

public class HomeViewModel : ViewModelBase {
    public static List<User> users = JsonSerializer.Deserialize<List<User>>(File.ReadAllText(@".\Assets\Users.json")) ?? new List<User>();
    private readonly IMessenger messenger;

    
    #region Commands

    private MyCommand _signUpCommand;
    public MyCommand SignUpCommand
    {
        get => this._signUpCommand ??= new MyCommand(
            action: () => RegistrationUser(),
            predicate: () => true);
        set => base.PropertyChange(out this._signUpCommand, value);
    }

    private MyCommand _signInCommand;
    public MyCommand SignInCommand
    {
        get => this._signInCommand ??= new MyCommand(
            action: () => LoginUser(),
            predicate: () => true);
        set => base.PropertyChange(out this._signInCommand, value);
    }

    #endregion

    public HomeViewModel(IMessenger messenger)
    {
        this.messenger = messenger;
    }

    void LoginUser()
    {
        this.messenger.Send(new NavigationMessage(typeof(LoginViewModel)));
    }

    void RegistrationUser()
    {
        this.messenger.Send(new NavigationMessage(typeof(RegistrationViewModel)));
    }
}