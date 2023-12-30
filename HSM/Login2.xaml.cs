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
    /// Interaction logic for Login2.xaml
    /// </summary>
    public partial class Login2 : Window
    {
        public Login2()
        {
            InitializeComponent();
        }
        HSMEntities db = new HSMEntities();
       APPOINTMENT app = new APPOINTMENT();
        PATIENT P = new PATIENT();
        private DateTime selectedDate;
        private void ValidateDate()

        {

            var lastEntity = db.APPOINTMENTs.OrderByDescending(h => h.Appointment_id).FirstOrDefault();

            if (lastEntity != null)
            {
                // Update the specific column
                DateTime currentDate = DateTime.Now;
                if (selectedDate < currentDate.Date)
                {
                    throw new ArgumentException("Invalid date. Please select a date that is today or in the future.");
                }
                lastEntity.app_date = datePicker.SelectedDate ?? DateTime.MinValue; // Update to the desired value

                // Save changes to the database
                db.SaveChanges();
            }
        }
        private void date_Click(object sender, RoutedEventArgs e)
        {
            selectedDate = datePicker.SelectedDate ?? DateTime.MinValue;
        }

        private void Login_Click(object sender, RoutedEventArgs e)
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
                    var lastEntity = db.APPOINTMENTs.OrderByDescending(h => h.Appointment_id).FirstOrDefault();

                    if (lastEntity != null)
                    {
                        // Update the specific column
                        lastEntity.ID_Patient = patinetid; // Update to the desired value
                        ValidateDate();
                        // Save changes to the database
                        db.SaveChanges();
                    }
                    MessageBox.Show("Patient added to the Appointment successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
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

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            var lastRow = db.APPOINTMENTs.OrderByDescending(h => h.Appointment_id).FirstOrDefault();


            if (lastRow != null)
            {
                // Delete the last added row
                db.APPOINTMENTs.Remove(lastRow);
                db.SaveChanges();
            }
            HomePage page = new HomePage();
            this.Hide();
            page.Show();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
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
                PatientName.Visibility = Visibility.Collapsed;
            }
            else
            {
                PatientName.Visibility = Visibility.Visible;
            }
        }

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
    }
}
