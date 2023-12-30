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
    /// Interaction logic for Login1.xaml
    /// </summary>
    public partial class Login1 : Window
    {
        // Examination
        public Login1()
        {
            InitializeComponent();
        }
        HSMEntities db=new HSMEntities();
        Medical_Examination m=new Medical_Examination();
        PATIENT P = new PATIENT();
        private DateTime selectedDate;
        private void PatientID_MouseDown(object sender, MouseButtonEventArgs e)
        {
            PatientID1.Focus();
        }

        private void PatientID1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(PatientID1.Text) && PatientID1.Text.Length > 0)
            {
                PatientID.Visibility = Visibility.Collapsed;
            }
            else
            {
                PatientID.Visibility = Visibility.Visible;
            }

        }

        private void PatientName_MouseDown(object sender, MouseButtonEventArgs e)
        {
            PatientName1.Focus();
        }

        private void PatientName1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(PatientName1.Text) && PatientName1.Text.Length > 0)
            {
               PatientName .Visibility = Visibility.Collapsed;
            }
            else
            {
                PatientName.Visibility = Visibility.Visible;
            }

        }

        

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            var lastRow = db.MEDICAL_EXAMINATIONS.OrderByDescending(h => h.ME_ID).FirstOrDefault();


            if (lastRow != null)
            {
                // Delete the last added row
                db.MEDICAL_EXAMINATIONS.Remove(lastRow);
                db.SaveChanges();
            }
            HomePage page = new HomePage();
            this.Hide();
            page.Show();
        }

        private void Login(object sender, RoutedEventArgs e)
        {

            try
            {
                if (!string.IsNullOrEmpty(PatientID1.Text) && PatientID1.Text.Any(char.IsLetter))
                {
                    throw new ArgumentException("Invalid ID. Please enter an ID without any letters.");
                }

                string patientname = PatientName1.Text;
                int patinetid = Convert.ToInt32(PatientID1.Text);
                var checkPatient = db.PATIENTs.FirstOrDefault(A => A.name_patient.Equals(patientname) && A.ID_Patient == patinetid);

                if (checkPatient != null)
                {
                    var lastEntity = db.MEDICAL_EXAMINATIONS.OrderByDescending(h => h.ME_ID).FirstOrDefault();

                    if (lastEntity != null)
                    {
                        // Update the specific column
                        lastEntity.ID_Patient = patinetid; // Update to the desired value
                        ValidateDate();
                        // Save changes to the database
                        db.MEDICAL_EXAMINATIONS.Add(lastEntity);
                        db.SaveChanges();
                    }
                    MessageBox.Show("Patient added to the examination successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    HomePage homePage = new HomePage();
                    this.Hide();
                    homePage.Show();
                }
                else
                {
                    MessageBox.Show("Patient isn't Registered in the System");
                }
            }
            catch
            {
                MessageBox.Show("Invalid please Make sure You Entered the Info Correctly");
            }
            
            
        }
        private void ValidateDate()

        {
         


            var lastEntity = db.MEDICAL_EXAMINATIONS.OrderByDescending(h => h.ME_ID).FirstOrDefault();

            if (lastEntity != null)
            {
                DateTime currentDate = DateTime.Now;
                if (selectedDate < currentDate.Date)
                {
                    throw new ArgumentException("Invalid date. Please select a date that is today or in the future.");
                }
                // Update the specific column
                lastEntity.ME_DATE = datePicker.SelectedDate ?? DateTime.MinValue; // Update to the desired value
            }
        }
        private void date_Click(object sender, RoutedEventArgs e)
        {
            selectedDate = datePicker.SelectedDate ?? DateTime.MinValue;

        }
    }
}
