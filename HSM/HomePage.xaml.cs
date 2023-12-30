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

 

        private void logout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow p= new MainWindow();
            this.Hide();
            p.Show();
        }

        private void appointment_Click(object sender, RoutedEventArgs e)
        {
            Department p = new Department();
            this.Hide();
            p.Show();
        }

        private void examination_Click(object sender, RoutedEventArgs e)
        {
            Medical_Examination p = new Medical_Examination();
            this.Hide();
            p.Show();
        }

        private void patient_Click(object sender, RoutedEventArgs e)
        {
            Patient p = new Patient();
            this.Hide();
            p.Show();
        }

        private void staff_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                Console.Beep();
            }
            this.Hide();
            Stafflock stafflock = new Stafflock();
            stafflock.Show();
           
        }

        private void payment_Click(object sender, RoutedEventArgs e)
        {
            BILL bILL = new BILL();
            this.Hide();
            bILL.Show();
        }

        private void pharmacy_Click(object sender, RoutedEventArgs e)
        {
            Pharmacy p= new Pharmacy();
            this.Hide(); p.Show();
        }
    }
}
