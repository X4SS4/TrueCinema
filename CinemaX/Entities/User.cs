namespace WPF_project_N_000047.Models;

using System.Linq;

public class User
{
    private string? name;
    private string? surname;
    private string? login;
    private string? card_number;
    private string? password;
    private string? mobile_number;
    public string Name
    {
        get => name;
        set
        {
            if (value.All(character => char.IsLetter(character) && value.Length > 1)) name = value;
        }
    }
    public string Surname
    {
        get => surname;
        set
        {
            if (value.All(character => char.IsLetter(character))) surname = value;
        }
    }
    public string Login
    {
        get => login;
        set
        {
            if (value.All(character => char.IsLetterOrDigit(character))) login = value;
        }
    }
    public string Card_number
    {
        get => card_number;
        set
        {
            if (value.All(character => char.IsDigit(character)) && value.Length == 16) card_number = value;
        }
    }
    public string Password
    {
        get => password;
        set
        {
            if (value.Any(character => char.IsDigit(character))
                && value.Any(character => char.IsUpper(character))
                && value.Any(character => char.IsLower(character))
                && value.All(character => char.IsLetterOrDigit(character))
                && value.Length >= 8) password = value;
        }
    }
    public string Mobile_number
    {
        get => mobile_number;
        set
        {
            if (value.All(character => char.IsDigit(character)) && value.Length == 9) mobile_number = value;
        }
    }
}
