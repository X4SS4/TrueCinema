using Cinema;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPF_project_N_000047
{
    public partial class Window3 : Window
    {
        public ObservableCollection<Film> Films { get; set; } = new ObservableCollection<Film>();
        public ObservableCollection<Film> AllFilms { get; set; } = new ObservableCollection<Film>();
        MainWindow? mainWindow;
        User user;
        public Window3(User user, MainWindow mainWindow)
        {
            InitializeComponent();
            this.DataContext = this;
            foreach (var film in LoadFilms())
            {
                AllFilms.Add(film);
                Films.Add(film);
            }
            Message_Label.Content = $"You are welcome, {user.Name}";
            this.user = user;
            this.mainWindow = mainWindow;
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

        private void ButtonBuyF1_Click(object sender, RoutedEventArgs e)
        {
            //if(this.Seance)

            var film = FilmsLV.SelectedIndex;
            var bill = new Window4(this, film, user);
            bill.Show();
        }

        private void Log_out_button_Click(object sender, RoutedEventArgs e)
        {
            mainWindow?.Show();
            Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            mainWindow?.Show();
        }
    }
}
