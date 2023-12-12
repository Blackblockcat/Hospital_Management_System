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

namespace HSM
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Window
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow p= new MainWindow();
            this.Hide();
            p.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            Department p= new Department();
            this.Hide();
            p.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Medical_Examination p= new Medical_Examination();
            this.Hide();
            p.Show();
        }
    }
}
