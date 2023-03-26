using Cinema;
using System;
using System.Collections.Generic;
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

namespace WPF_project_N_000047
{
    /// <summary>
    /// Interaction logic for Window4.xaml
    /// </summary>
    public partial class Window4 : Window
    {
        Film? film;
        User? user;
        public Window4(object film, User user)
        {
            InitializeComponent();
            this.DataContext = this;
            this.film = (Film?)film;
            this.user = user;
            NameTB.Text = user.Name;
            SurnameTB.Text = user.Surname;
            TimeTB.Text = this.film.seanses[1];
            PaidTB.Text = this.film.price.ToString();
            RoomTB.Text = this.film.filmName;
        }

        
    }
}
