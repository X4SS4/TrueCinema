using CinemaX.Messager.Messages;
using CinemaX.Messager.Services.Base;
using CinemaX.Tools;
using CinemaX.ViewModels.Base;
using CinemaX.Views;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Windows.Input;
using WPF_project_N_000047.Models;

namespace CinemaX.ViewModels;
public class RegistrationViewModel : ViewModelBase
{
    private readonly IMessenger messenger;
    private User _newUser = new User();
    public User NewUser
    {
        get => this._newUser;
        set => base.PropertyChange(out _newUser, value);
    }
    private string _errorLog = string.Empty;
    public string ErrorLog
    {
        get => this._errorLog;
        set => PropertyChange(out _errorLog, value);
    }
    private StringBuilder temporarySBForLogin = new StringBuilder();

    public RegistrationViewModel(IMessenger messenger)
    {
        this.messenger = messenger;
    }

    #region Commands

    private MyCommand _saveUserCommand;
    public MyCommand SaveUserCommand
    {
        get => this._saveUserCommand ??= new MyCommand(
            action: () => Save(),
            predicate: () => true);
        set => base.PropertyChange(out this._saveUserCommand, value);
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

    void Save()
    {
        var properties = this._newUser.GetType().GetProperties();
        foreach (var property in properties)
        {
            var value = property.GetValue(this._newUser);
            if (string.IsNullOrEmpty((string)value))
            {
                ErrorLog = $"Input {property.Name} doesn`t match";
                return;
            }
        }
        HomeViewModel.users.Add(this._newUser);
        var json = JsonSerializer.Serialize(HomeViewModel.users);
        File.WriteAllText(@".\Assets\Users.json", json);
        this.messenger.Send(new NavigationMessage(typeof(HomeViewModel)));
    }

    void Back()
    {
        this.messenger.Send(new NavigationMessage(typeof(HomeViewModel)));
    }
}