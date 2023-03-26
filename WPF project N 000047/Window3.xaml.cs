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
    public partial class Window3 : Window
    {
        MainWindow? mainWindow;
        public Window3(User user, MainWindow mainWindow)
        {
            InitializeComponent();
            Message_Label.Content = $"You are welcome, {user.Name}";
            this.mainWindow = mainWindow;
        }

        private void ButtonBuyF1_Click(object sender, RoutedEventArgs e)
        {
            var test4 = new Window4();
            test4.Show();
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
