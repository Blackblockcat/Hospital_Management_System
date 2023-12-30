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
        HSMEntities db= new HSMEntities();
        APPOINTMENT app = new APPOINTMENT();
        static int Capacity = 10;
        private void HandleDepartment(int dep_ID)
        {

            var checkout = db.APPOINTMENTs.Count(check => check.ID_Dep == dep_ID && check.p_turn == false);

            if (checkout < Capacity)
            {
               app.p_turn = false;
               app.ID_Dep = dep_ID;
                app.ID_Patient = 123456789;  // Assign an existing patient ID to M.ID_Patient before adding
                app.app_date = new DateTime(2022, 6, 8);

                db.APPOINTMENTs.Add(app);
                db.SaveChanges();
                registrationDepartment r = new registrationDepartment();
                Hide();
                r.Show();
            }


        }
        private void Pediatrics_Click(object sender, RoutedEventArgs e)
        {
            HandleDepartment(5);

        }

        private void Emergency_Click(object sender, RoutedEventArgs e)
        {
            HandleDepartment(1);
        }

        private void Cardiology_Click(object sender, RoutedEventArgs e)
        {
            HandleDepartment(2);

        }

        private void Gastroenterology_Click(object sender, RoutedEventArgs e)
        {
            HandleDepartment(4);

        }

        private void Gynecology_Click(object sender, RoutedEventArgs e)
        {
            HandleDepartment(6);

        }

        private void Hematology_Click(object sender, RoutedEventArgs e)
        {
            HandleDepartment(7);

        }

        private void Oncology_Click(object sender, RoutedEventArgs e)
        {
            HandleDepartment(8);

        }

        private void Ophthalmology_Click(object sender, RoutedEventArgs e)
        {
            HandleDepartment(10);

        }

        private void Neurology_Click(object sender, RoutedEventArgs e)
        {
            HandleDepartment(9);

        }

        private void Orthopedic_Click(object sender, RoutedEventArgs e)
        {
            HandleDepartment(11);

        }

        private void Urology_Click(object sender, RoutedEventArgs e)
        {
            HandleDepartment(12);

        }

        private void Dental_Click(object sender, RoutedEventArgs e)
        {
            HandleDepartment(13);

        }

        private void Nutrition_and_Dietetics_Click(object sender, RoutedEventArgs e)
        {
            HandleDepartment(15);

        }

        private void Respiratory_Therapy_Click(object sender, RoutedEventArgs e)
        {
            HandleDepartment(14);

        }

        private void ENT_Click(object sender, RoutedEventArgs e)
        {
            HandleDepartment(3);
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            HomePage page = new HomePage();
            this.Hide();
            page.Show();
        }
    }
}
