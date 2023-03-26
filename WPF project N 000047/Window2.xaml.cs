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
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        MainWindow? mainWindow;
        private static List<User> users = new();
        static StringBuilder temp_password = new StringBuilder();

        public Window2(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            users.Add(new User
            {
                Login = "Zabil",
                Password = "Zabil123"
            });
            //User temp = new User();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (users.Any( user => user.Login == Login_box.Text && temp_password.ToString() == user.Password))
            {
                var catalog_window = new Window3();
                catalog_window.Show();
                Close();
                mainWindow?.Close();
            }
            Error_Label.Content = "Wrong Login or Password";
            temp_password.Clear();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            mainWindow?.Show();
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            mainWindow?.Show();
        }

        private void Password_box_TextChanged(object sender, TextChangedEventArgs e)
        {

            StringBuilder hide = new StringBuilder();
            foreach (var item in Password_box.Text)
            {
                if (item != '*')
                {
                    temp_password.Append(item);
                    hide.Append('*');
                }
            }
            Password_box.Text = hide.ToString();
        }
    }
}
