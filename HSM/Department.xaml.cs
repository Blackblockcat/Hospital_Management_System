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
    /// Interaction logic for Department.xaml
    /// </summary>
    public partial class Department : Window
    {
        public Department()
        {
            InitializeComponent();
        }

        private void Pediatrics_Click(object sender, RoutedEventArgs e)
        {
            registration r=new registration();
            this.Hide();
            r.Show();
        }

        private void Emergency_Click(object sender, RoutedEventArgs e)
        {
            registration r = new registration();
            this.Hide();
            r.Show();
        }

        private void Cardiology_Click(object sender, RoutedEventArgs e)
        {
            registration r = new registration();
            this.Hide();
            r.Show();
        }

        private void Gastroenterology_Click(object sender, RoutedEventArgs e)
        {
            registration r = new registration();
            this.Hide();
            r.Show();
        }

        private void Gynecology_Click(object sender, RoutedEventArgs e)
        {
            registration r = new registration();
            this.Hide();
            r.Show();
        }

        private void Hematology_Click(object sender, RoutedEventArgs e)
        {
            registration r = new registration();
            this.Hide();
            r.Show();
        }

        private void Oncology_Click(object sender, RoutedEventArgs e)
        {
            registration r = new registration();
            this.Hide();
            r.Show();
        }

        private void Ophthalmology_Click(object sender, RoutedEventArgs e)
        {
            registration r = new registration();
            this.Hide();
            r.Show();
        }

        private void Neurology_Click(object sender, RoutedEventArgs e)
        {
            registration r = new registration();
            this.Hide();
            r.Show();
        }

        private void Orthopedic_Click(object sender, RoutedEventArgs e)
        {
            registration r = new registration();
            this.Hide();
            r.Show();
        }

        private void Urology_Click(object sender, RoutedEventArgs e)
        {
            registration r = new registration();
            this.Hide();
            r.Show();
        }

        private void Dental_Click(object sender, RoutedEventArgs e)
        {
            registration r = new registration();
            this.Hide();
            r.Show();
        }

        private void Nutrition_and_Dietetics_Click(object sender, RoutedEventArgs e)
        {
            registration r = new registration();
            this.Hide();
            r.Show();
        }

        private void Respiratory_Therapy_Click(object sender, RoutedEventArgs e)
        {
            registration r = new registration();
            this.Hide();
            r.Show();
        }

        private void ENT_Click(object sender, RoutedEventArgs e)
        {
            registration r = new registration();
            this.Hide();
            r.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            HomePage page = new HomePage();
            this.Hide();
            page.Show();
        }
    }
}
