using Cinema;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
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
        StringBuilder temp_password = new StringBuilder();

        public Window2(MainWindow mainWindow)
        {
            InitializeComponent();
            this.DataContext = this;
            mainWindow.Hide();
            this.mainWindow = mainWindow;
            MainWindow.users.Add(new User { Name = "Zabil", Login = "Xassa", Password = "Zabil123" });
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

        private void Back_Button_Click_1(object sender, RoutedEventArgs e)
        {
            mainWindow?.Show();
            this.Close();
        }

        private void Login_Button_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.users.Any(user => user.Login == Login_box.Text && temp_password.ToString() == user.Password))
            {
                User? temp_user = new();

                foreach (var item in MainWindow.users) 
                    if (item.Login == Login_box.Text && temp_password.ToString() == item.Password)
                        temp_user = item;
                
                var catalog_window = new Window3(temp_user, mainWindow);
                temp_password.Clear();
                catalog_window.Show();
                mainWindow?.Hide();
                mainWindow = null;
                Close();
            }
            Error_Label.Content = "Wrong Login or Password";
            temp_password.Clear();
        }
    }
}
