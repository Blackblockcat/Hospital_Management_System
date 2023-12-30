using MaterialDesignColors;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
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

    public partial class UpdatePatient : Window
    {
        HSMEntities db = new HSMEntities();
        PATIENT p = new PATIENT();

        public UpdatePatient()
        {
            InitializeComponent();
        }
        List<PATIENT> ls = new List<PATIENT>();
        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            Patient s = new Patient();
            this.Hide();
            s.Show();
        }
        static bool IsAllLetters(string input)
        {
            foreach (var part in input.Split(' '))
            {
                if (!string.IsNullOrEmpty(part) && !part.All(char.IsLetter))
                {
                    return false;
                }
            }
            return true;
        }
        private void save_Click(object sender, RoutedEventArgs e)
        {
          
                try
                {
                    int patientId = Convert.ToInt32(PatientId.textbox.Text);
                    PATIENT NEWIMP = db.PATIENTs.Where(s => s.ID_Patient == patientId).SingleOrDefault();

                    // Validate Age
                    if (int.TryParse(PatientAge.textbox.Text, out int age))
                    {
                        if (age < 1 || age > 120)
                        {
                            MessageBox.Show("Age must be between 1 and 120.");
                            return;
                        }
                        NEWIMP.Age = age;
                    }
                    else
                    {
                        MessageBox.Show("Invalid input for Age. Please enter a valid integer.");
                        return;
                    }

                    // Validate Phone
                    string phone = PatientPhone.textbox.Text; // Remove separators for validation
                    if (phone.Length != 10 || !phone.All(char.IsDigit))
                    {
                        MessageBox.Show("Invalid phone number. Please enter a valid 10-digit number.");
                        return;
                    }
                    NEWIMP.PHONE = PatientPhone.textbox.Text;

                    // Validate Address
                    if (PatientAddress.textbox.Text.Trim().Length < 5 || PatientAddress.textbox.Text.Trim().Length > 15)
                    {
                        MessageBox.Show("Invalid Address. Address should be between 5 and 15 characters.");
                        return;
                    }
                    NEWIMP.AddressS = PatientAddress.textbox.Text;

                    // Validate City
                    string city = PatientCity.textbox.Text.ToString();
                    if (city.Length < 3 || city.Length > 20 && !IsAllLetters(city))
                    {
                throw new ArgumentException("Invalid City. The entered City is less than 2 letters or may have none chars values, which is not valid.");

                }
                NEWIMP.Town = city;

                    db.SaveChanges();
                    MessageBox.Show("Saved!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An unexpected error occurred: {ex.Message}");
                }
            

      
       
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }

        }

        private void Modify_Click(object sender, RoutedEventArgs e)
        {
            int pp = Convert.ToInt32(PatientId.textbox.Text);
            var item = from s in db.PATIENTs.ToList()
                       where s.ID_Patient == pp&&
                       s.name_patient == PatientName.textbox.Text
                       select s;
            ls = item.ToList();
            if (ls.Count > 0)
            {
                foreach (var s in ls)
                {
                    PatientAge.textbox.Text = s.Age.ToString();


                    PatientPhone.textbox.Text = s.PHONE.ToString();
                    PatientAddress.textbox.Text = s.AddressS.ToString();
                    PatientCity.textbox.Text = s.Town.ToString();
                }
            }
            else
            {
                MessageBox.Show("Patient not found. Please check the ID and name.");
            }

            

        }
    }
}
