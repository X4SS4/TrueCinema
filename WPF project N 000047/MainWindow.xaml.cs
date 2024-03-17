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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_project_N_000047
{

    public partial class MainWindow : Window
    {
        
        public static List<User> users = JsonSerializer.Deserialize<List<User>>(File.ReadAllText(@".\Assets\Users.json")) ?? new List<User>();

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        /*--------------------Mouse Enter/Leave EVENTS--------------------*/

        private void Sign_in_MouseEnter(object sender, MouseEventArgs e)
        {
            this.Sign_in.Foreground = Brushes.Black;
        }

        private void Sign_up_MouseEnter(object sender, MouseEventArgs e)
        {
            this.Sign_up.Foreground = Brushes.Black;
        }

        private void Sign_in_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Sign_in.Foreground = Brushes.Yellow;
        }

        private void Sign_up_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Sign_up.Foreground = Brushes.Yellow;
        }


        /*------------------------------------Click EVENTS------------------------------------*/
        private void Sign_in_Click(object sender, RoutedEventArgs e)
        {
            var windowSIN = new Window2(this);
            windowSIN.Show();
            Hide();
        }

        private void Sign_up_Click(object sender, RoutedEventArgs e)
        {
            var windowSUP = new Window1(this);
            windowSUP.Show();
            Hide();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
    }
}
