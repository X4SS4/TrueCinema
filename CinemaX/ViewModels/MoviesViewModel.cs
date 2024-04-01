namespace CinemaX.ViewModels;

using CinemaX.Messager.Messages;
using CinemaX.Messager.Services.Base;
using CinemaX.Tools;
using CinemaX.ViewModels.Base;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text.Json;
using WPF_project_N_000047.Models;

public class MoviesViewModel : ViewModelBase
{
    public static User? User { get; set; } = new User();
    private readonly IMessenger _messenger;
    public ObservableCollection<Film> Films { get; set; } = new ObservableCollection<Film>();
    public ObservableCollection<Film> AllFilms { get; set; } = new ObservableCollection<Film>();

    private string _searchFilm;
    public string SearchFilm
    {
        get => this._searchFilm;
        set => base.PropertyChange(out _searchFilm, value);
    }

    private string _welcomeLabel;
    public string WelcomeLabel
    {
        get => this._welcomeLabel;
        set => base.PropertyChange(out _welcomeLabel, value);
    }

    public MoviesViewModel(IMessenger messenger)
    {
        this._messenger = messenger;
        foreach (var film in LoadFilms())
        {
            AllFilms.Add(film);
            Films.Add(film);
        }
        WelcomeLabel = $"You are welcome, {User?.Name}";
    }
    private IEnumerable<Film> LoadFilms()
    {
        var films = JsonSerializer
            .Deserialize<List<Film>>(File
            .ReadAllText(@".\Assets\Films.json"));

        if (films == null || films.Any() == false)
            return Enumerable.Empty<Film>();
        else
            return films;
    }

    #region Commands

    private MyCommand _logOutCommand;
    public MyCommand LogOutCommand
    {
        get => this._logOutCommand ??= new MyCommand(
            action: () => LogOut(),
            predicate: () => true);
        set => base.PropertyChange(out this._logOutCommand, value);
    }

    private MyCommand _findFilmCommand;
    public MyCommand FindFilmCommand
    {
        get => this._findFilmCommand ??= new MyCommand(
            action: () => Find(),
            predicate: () => true);
        set => base.PropertyChange(out this._findFilmCommand, value);
    }

    private MyCommand _buyFilmCommand;
    public MyCommand BuyFilmCommand
    {
        get => this._buyFilmCommand ??= new MyCommand(
            action: () => Buy(),
            predicate: () => true);
        set => base.PropertyChange(out this._buyFilmCommand, value);
    }

    #endregion

    void LogOut() => this._messenger.Send(new NavigationMessage(typeof(HomeViewModel)));

    void Buy()
    {
        var openFileDialog = new OpenFileDialog();
        this._messenger.Send(new NavigationMessage(typeof(ReceiptViewModel)));
    }

    void Find()
    {
        var findFilms = AllFilms.Where(film => film.FilmName.Contains(SearchFilm));
        Films.Clear();
        foreach (var film in findFilms)
        {
            Films.Add(film);
        }
    }
}