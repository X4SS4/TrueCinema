namespace CinemaX.ViewModels;

using CinemaX.Tools;
using CinemaX.ViewModels.Base;
using WPF_project_N_000047.Models;

public class ReceiptViewModel : ViewModelBase
{
    public static Film? Buyedfilm { get; set; }
    public User? ReceiptUser { get; set; }

    private MyCommand? _loadCommand;
    public MyCommand LoadCommand
    {
        get => this._loadCommand ??= new MyCommand(
            action: () => LoadUserProps(),
            predicate: () => true);
        set => base.PropertyChange(out this._loadCommand, value);
    }

    void LoadUserProps() => ReceiptUser = MoviesViewModel.User;
}
