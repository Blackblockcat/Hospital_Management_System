using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
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
    /// Interaction logic for Patient.xaml
    /// </summary>
    public partial class Patient : Window
    {
        public Patient()
        {
            InitializeComponent();
        }
        HSMEntities db=new HSMEntities(); 
        MEDICAL_EXAMINATIONS m=new MEDICAL_EXAMINATIONS();
        BILL b=new BILL();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            HomePage homePage = new HomePage();
            this.Hide();
            homePage.Show();
        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            var check = db.PATIENTs.FirstOrDefault(EE => EE.name_patient.Equals(name.textbox.Text.ToString()) && EE.ID_Patient.ToString().Equals(ID.textbox.Text.ToString()));
            if (check != null)
            {


                ID_TextChanged();
            }
            else
            {
                MessageBox.Show("invalid, Try again");
            }
        }

        private void Name_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void id(object sender, TextChangedEventArgs e)
        {

        }
        private PATIENT selectedMember;

        private void membersDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (membersDataGrid.SelectedItem != null)
            {
                selectedMember = (PATIENT)membersDataGrid.SelectedItem;
            }

        }
        private bool IsMaximize = false;
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                if (IsMaximize)
                {
                    this.WindowState = WindowState.Normal;
                    this.Width = 1300;
                    this.Height = 700;

                    IsMaximize = false;
                }
                else
                {
                    this.WindowState = WindowState.Maximized;

                    IsMaximize = true;
                }
            }
        }

        private void Border_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {

        }

        private void Name_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void Border_MouseLeftButtonDown_2(object sender, MouseButtonEventArgs e)
        {

        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        


        

       
        private void ID_TextChanged()
        {
            var patients = db.PATIENTs.ToList();
            var appointments = db.APPOINTMENTs.ToList();
            var idPatient = ID.textbox.Text;
            var patientName = name.textbox.Text;
            var patches = from p in patients
                          where p.ID_Patient.ToString() == idPatient.ToString()
                          && p.name_patient.ToString() ==patientName.ToString()
                          select p;
           


                membersDataGrid.ItemsSource = patches;

                var idDep = (from app in db.APPOINTMENTs.ToList()
                             where app.ID_Patient.ToString() == idPatient.ToString()
                             select app.ID_Dep).ToList();

                var nameDep = (from dep in db.DEPARTMENTs.ToList()
                               where idDep.Contains(dep.ID_Dep)
                               select dep).ToList();

                Department.ItemsSource = nameDep.Select(depName => new { DepartmentName = depName.NAME_DEP });

                var idMed = (from app in db.MEDICAL_EXAMINATIONS.ToList()
                             where app.ID_Patient.ToString() == idPatient.ToString()
                             select app.MeType).ToList();

                var nameMed = (from medType in db.MEDICAL_EXAMINATIONS_TYPE.ToList()
                               where idMed.Contains(medType.ID)
                               select medType).ToList();

                Medical.ItemsSource = nameMed.Select(medName => new { MedicalTypeName = medName.ME_TYPE });

        }

        private void Update1_Click(object sender, RoutedEventArgs e)
        {
            UpdatePatient u=new UpdatePatient();
            this.Hide();
            u.Show();

        }

 
    }
}

