using Cinema;
using System;
using System.Collections.Generic;
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
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        MainWindow mainWindow;
        StringBuilder temp_for_login = new StringBuilder();
        User newUser = new User();
        public Window1(MainWindow mainWindow)
        {
            InitializeComponent();
            this.DataContext = this;
            this.mainWindow = mainWindow;
        }

        

        string SBeditor(string stringToRead)
        {
            foreach (var item in stringToRead) this.temp_for_login.Append(item);
            return this.temp_for_login.ToString() == null ? string.Empty : this.temp_for_login.ToString();
        }


        private void SUPsave_Click(object sender, RoutedEventArgs e)
        {
            if (this.newUser.Name == name_TB.Text
                && this.newUser.Surname == surname_TB.Text
                && this.newUser.Login == login_TB.Text
                && this.newUser.Password == password_TB.Text
                && this.newUser.Card_number == cardNumber_TB.Text
                && this.newUser.Mobile_number == mobileNumber_TB.Text)
            {
                MainWindow.users.Add(this.newUser);
                var json = JsonSerializer.Serialize(MainWindow.users);
                File.WriteAllText(@".\Assets\Users.json", json);
                var Loginwindow = new Window2(mainWindow);

                mainWindow.Hide();
                Loginwindow.Show();
                Close();
            }
        }

        private void SUPback_Click(object sender, RoutedEventArgs e)
        {
            this.mainWindow.Show();
            Close();
        }


        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.mainWindow.Show();
        }


        /*------------------------TextBox EVENTS------------------------*/
        private void name_TB__TextChanged(object sender, TextChangedEventArgs e)
        {
            this.newUser.Name = string.Empty;
        }     
        private void name_TB_GotFocus(object sender, RoutedEventArgs e)
        {
            name_TB.Text = string.Empty;
        }
        private void nameTB_LostFocus(object sender, RoutedEventArgs e)
        {
            this.newUser.Name = name_TB.Text;
            if (!string.IsNullOrEmpty(newUser.Name))
            {
                message_label.Foreground = Brushes.Green;
                message_label.Content = "Input Name is ok";
                return;
            }
            name_TB.Text = string.Empty;
            this.newUser.Name = string.Empty;
            message_label.Foreground = Brushes.Red;
            message_label.Content = "Input Name doesn`t match";
        }
        private void surname_TB_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.newUser.Surname = string.Empty;
        }
        private void surname_TB_GotFocus(object sender, RoutedEventArgs e)
        {
            surname_TB.Text = string.Empty;
        }
        private void surname_TB_LostFocus(object sender, RoutedEventArgs e)
        {
            this.newUser.Surname = surname_TB.Text;
            if (!string.IsNullOrEmpty(newUser.Surname))
            {
                message_label.Foreground = Brushes.Green;
                message_label.Content = "Input Surname is ok";
                return;
            }
            surname_TB.Text = string.Empty;
            this.newUser.Surname = string.Empty;
            message_label.Foreground = Brushes.Red;
            message_label.Content = "Input Surname doesn`t match";
        }
        private void login_TB_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.newUser.Login= string.Empty;
        }
        private void login_TB_GotFocus(object sender, RoutedEventArgs e)
        {
            login_TB.Text = string.Empty;
        }
        private void login_TB_LostFocus(object sender, RoutedEventArgs e)
        {
            this.newUser.Login = login_TB.Text;
            if (!string.IsNullOrEmpty(this.newUser.Login) && !MainWindow.users.Any(users => users.Login == newUser.Login))
            {

                message_label.Foreground = Brushes.Green;
                message_label.Content = "Input Login is ok";
                return;
            }
            login_TB.Text = string.Empty;
            this.newUser.Login = string.Empty;
            message_label.Foreground = Brushes.Red;
            message_label.Content = "Input Login doesn`t match";
        }
        private void password_TB_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.newUser.Password = string.Empty;
        }
        private void password_TB_GotFocus(object sender, RoutedEventArgs e)
        {
            password_TB.Text = string.Empty;
        }
        private void password_TB_LostFocus(object sender, RoutedEventArgs e)
        {
            this.newUser.Password = password_TB.Text;
            if (!string.IsNullOrEmpty(this.newUser.Password))
            {
                message_label.Foreground = Brushes.Green;
                message_label.Content = "Input password is ok";
                return;
            }
            password_TB.Text = string.Empty;
            this.newUser.Password = string.Empty;
            message_label.Foreground = Brushes.Red;
            message_label.Content = "Input password doesn`t match";
        }
        private void cardNumber_TB_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.newUser.Card_number = string.Empty;
        }
        private void cardNumber_TB_GotFocus(object sender, RoutedEventArgs e)
        {
            cardNumber_TB.Text = string.Empty;

        }
        private void cardNumber_TB_LostFocus(object sender, RoutedEventArgs e)
        {
            this.newUser.Card_number = cardNumber_TB.Text;
            if (!string.IsNullOrEmpty(this.newUser.Card_number))
            {
                message_label.Foreground = Brushes.Green;
                message_label.Content = "Input card number is ok";
                return;
            }
            cardNumber_TB.Text = string.Empty;
            this.newUser.Card_number = string.Empty;
            message_label.Foreground = Brushes.Red;
            message_label.Content = "Input card number doesn`t match";
        }
        private void mobileNumber_TB_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.newUser.Mobile_number= string.Empty;
        }
        private void mobileNumber_TB_GotFocus(object sender, RoutedEventArgs e)
        {
            mobileNumber_TB.Text = string.Empty;

        }
        private void mobileNumber_TB_LostFocus(object sender, RoutedEventArgs e)
        {
            this.newUser.Mobile_number = mobileNumber_TB.Text;
            if (!string.IsNullOrEmpty(this.newUser.Mobile_number))
            {
                message_label.Foreground = Brushes.Green;
                message_label.Content = "Input mobile number is ok";
                return;
            }
            mobileNumber_TB.Text = string.Empty;
            this.newUser.Mobile_number = string.Empty;
            message_label.Foreground = Brushes.Red;
            message_label.Content = "Input mobile number doesn`t match";
        }
    }
}
