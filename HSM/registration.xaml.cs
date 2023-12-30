using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
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
using System.Globalization;
using System.Text.RegularExpressions;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;
using System.Data;
using System.Data.Entity;
using System.Runtime.Remoting.Contexts;

namespace HSM
{

    public partial class registration : Window
    {
        public registration()
        {
            InitializeComponent();

            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;

        }
        HSMEntities db = new HSMEntities();
        PATIENT p = new PATIENT();
        MEDICAL_EXAMINATIONS m = new MEDICAL_EXAMINATIONS();

        private string selectedGender;
        private DateTime selectedDate;


        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
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
        static string ConvertToTitleCase(string input)
        {
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            return textInfo.ToTitleCase(input.ToLower());
        }


        // Function to check if the phone number has a valid format
        static bool IsValidPhoneNumberFormat(string phoneNumber)
        {
            string pattern = @"^(\d{3}-\d{3}-\d{4}|\d{10})$";
            return Regex.IsMatch(phoneNumber, pattern);
        }
        private void cancel_Click(object sender, RoutedEventArgs e)
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

        private void SAVE_Click_1(object sender, RoutedEventArgs e)
        {

            try
            {
                ValidateName();
                ValidateID();
                ValidateAge();
                ValidateCity();
                ValidateAddress();
                ValidatePhoneNumber();
                ValidateGender();
                ValidateDate();




                // If all validations pass, save the patient and navigate to HomePage
                db.PATIENTs.Add(p);
                db.SaveChanges();
                add_ID_To_Examination();

            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException != null && ex.InnerException.InnerException != null)
                {
                    MessageBox.Show($"An error occurred while updating entries: {ex.InnerException.InnerException.Message}");
                }
                else
                {
                    MessageBox.Show($"An error occurred while updating entries: {ex.Message}");
                }
            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder errorMessages = new StringBuilder();
                foreach (var error in ex.EntityValidationErrors)
                {
                    foreach (var validationError in error.ValidationErrors)
                    {
                        errorMessages.AppendLine($"{validationError.PropertyName}: {validationError.ErrorMessage}");
                    }
                }

                MessageBox.Show($"An error occurred while saving data: {errorMessages.ToString()}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}");
            }
        }

        private void ValidateName()
        {
            if (!IsAllLetters(patientName.textbox.Text))
            {
                throw new ArgumentException("Invalid Name. Please enter a name containing only letters.");
            }
            else if (patientName.textbox.Text.Length < 3)
            {
                throw new ArgumentException("Invalid Name. Name is too short.");
            }
            else if (patientName.textbox.Text.Length > 20)
            {
                throw new ArgumentException("Invalid Name. Name is too Long.");
            }
            p.name_patient = patientName.textbox.Text;
        }

        private void ValidateID()
        {
            if (patientID.textbox.Text.Length < 9)
            {
                throw new ArgumentException("Invalid ID. ID is less than 9 Digits.");
            }
            else if (patientID.textbox.Text.Length > 9)
            {
                throw new ArgumentException("Invalid ID. ID is more than 9 Digits.");
            }
            else if (!string.IsNullOrEmpty(patientID.textbox.Text) && patientID.textbox.Text.Any(char.IsLetter))
            {
                throw new ArgumentException("Invalid ID. Please enter an ID without any letters.");
            }
            p.ID_Patient = Convert.ToInt32(patientID.textbox.Text);
        }

        private void ValidateAge()
        {
            if (AGE.textbox.Text.Length < 1)
            {
                throw new ArgumentException("Invalid Age. Age is less than 1.");
            }
            else if (AGE.textbox.Text.Length > 3)
            {
                throw new ArgumentException("Invalid Age. Age is more than 3.");
            }
            else if (Convert.ToInt32(AGE.textbox.Text) > 115)
            {
                throw new ArgumentException("Invalid Age. The entered age is greater than 115 years, which is not valid.");
            }
            p.Age = Convert.ToInt32(AGE.textbox.Text);
        }

        private void ValidateCity()
        {
            if (!IsAllLetters(CITY.textbox.Text))
            {
                throw new ArgumentException("Invalid City. Please enter a city containing only letters.");
            }
            else if (CITY.textbox.Text.Length < 2)
            {
                throw new ArgumentException("Invalid City. The entered City is less than 2 letters, which is not valid.");
            }
            else if (CITY.textbox.Text.Length > 20)
            {
                throw new ArgumentException("Invalid city name. The city name should not exceed 20 letters.");
            }
            p.Town = CITY.textbox.Text;
        }

        private void ValidateAddress()
        {
            if (ADDRESS.textbox.Text.Length < 6)
            {
                throw new ArgumentException("Invalid Address. The address should have at least 6 characters.");
            }
            p.AddressS = ADDRESS.textbox.Text;
        }

        private void ValidatePhoneNumber()
        {
            if (!IsValidPhoneNumberFormat(PhoneNumber.textbox.Text))
            {
                throw new ArgumentException("Invalid phone number. Please enter a valid phone number in the format 'xxx-xxx-xxxx' or 'xxxxxxxxxx'.");
            }
            p.PHONE = PhoneNumber.textbox.Text;
        }

        private void ValidateGender()
        {
            if (selectedGender == null)
            {
                throw new ArgumentException("Please select a gender.");
            }
            p.Gender = selectedGender;
        }

        private void male_MouseDown(object sender, MouseButtonEventArgs e)
        {
            selectedGender = "Male";
        }

        private void female_MouseDown(object sender, MouseButtonEventArgs e)
        {
            selectedGender = "Female";
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
               
                // Save changes to the database
                db.SaveChanges();
            }
        }

        private void date_Click(object sender, RoutedEventArgs e)
        {

            selectedDate = datePicker.SelectedDate ?? DateTime.MinValue;
        }

        private void add_ID_To_Examination()
        {
            var lastEntity = db.MEDICAL_EXAMINATIONS.OrderByDescending(h => h.ME_ID).FirstOrDefault();

            if (lastEntity != null)
            {
                // Update the specific column
                lastEntity.ID_Patient = Convert.ToInt32(patientID.textbox.Text); // Update to the desired value

                // Save changes to the database
                db.SaveChanges();
            }
            MessageBox.Show("Patient added to the examination successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            HomePage homePage = new HomePage();
            this.Hide();
            homePage.Show();
        }

       

        private void LOGIN_Click(object sender, RoutedEventArgs e)
        {
            Login1 login1 = new Login1();
            this.Hide();
            login1.Show();  
        }
    }
}
