using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_project_N_000047
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           
        }

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
    }
}
