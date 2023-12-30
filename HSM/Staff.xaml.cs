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
using System.IO;

using OpenFileDialog = Microsoft.Win32.OpenFileDialog;
using System.Security.Cryptography;

namespace HSM
{
    
    public partial class Staff : Window
    {
        public Staff()
        {
            InitializeComponent();
        }
        HSMEntities db = new HSMEntities();
        EMPLOYEE emp = new EMPLOYEE();
        private string selectedGender;
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            ShowStff showStff = new ShowStff();
            this.Hide();
            showStff.Show();
        }
        private byte[] ReadImageFile(string filePath)
        {
            try
            {
                return File.ReadAllBytes(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading image file: {ex.Message}");
                return null;
            }
        }
        private byte[] imageData;
        private void upload_Click(object sender, RoutedEventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files |*.bmp;*.jpg;*.png;*.jpng";
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == true)
            {
                imageData = ReadImageFile(openFileDialog.FileName);

                if (imageData != null)
                {
                    imageup.Source = new BitmapImage(new Uri(openFileDialog.FileName));
                    MessageBox.Show("Image uploaded successfully.");
                }
                else
                {
                    MessageBox.Show("Error uploading image.");
                }
            }
        }

            private void male_MouseDown(object sender, MouseButtonEventArgs e)
        {
            selectedGender = "Male";
        }

        private void female_MouseDown(object sender, MouseButtonEventArgs e)
        {
            selectedGender = "Female";
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

        private void save_Click(object sender, RoutedEventArgs e)
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
                ValidateJob();
                ValidateSalary();
                ValidateImage();
                ValidatePassword();



                // If all validations pass, save the Employee and navigate to Show Staff Page
                db.EMPLOYEEs.Add(emp);
                db.SaveChanges();
                MessageBox.Show("Employee was Successfully added to the system.","Information", MessageBoxButton.OK, MessageBoxImage.Information); ;
                ShowStff showStff = new ShowStff();
                this.Hide();
                showStff.Show();

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
        private void ValidateImage()
        {
            try
            {
                if (imageup != null)
                {
                    emp.Image = imageData;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error uploading image: {ex.Message}");

            }
        }
        private void ValidateName()
        {
            if (!IsAllLetters(empName.textbox.Text))
            {
                throw new ArgumentException("Invalid Name. Please enter a name containing only letters.");
            }
            else if (empName.textbox.Text.Length < 3)
            {
                throw new ArgumentException("Invalid Name. Name is too short.");
            }
            else if (empName.textbox.Text.Length > 20)
            {
                throw new ArgumentException("Invalid Name. Name is too Long.");
            }
            else
            {
                emp.employee_name = ConvertToTitleCase(empName.textbox.Text);
            }
        }

        private void ValidateID()
        {
            if (empID.textbox.Text.Trim().Length < 5)
            {
                throw new ArgumentException("Invalid ID. ID must be at least 5 characters long.");
            }

            if (empID.textbox.Text[0] != '#')
            {
                throw new ArgumentException("Invalid ID. The first character must be '#'.");
            }

            char secondChar = empID.textbox.Text.Length > 1 ? empID.textbox.Text[1] : ' ';
            char thirdChar = empID.textbox.Text.Length > 2 ? empID.textbox.Text[2] : ' ';

            if (!char.IsLetter(secondChar) || !char.IsLetterOrDigit(thirdChar))
            {
                throw new ArgumentException("Invalid ID. The second character must be a letter, and the third character must be a letter or a digit.");
            }




            int numericStartIndex = 3;
            string numericPart = empID.textbox.Text.Substring(numericStartIndex);

            if ((numericPart.Length < 2 || numericPart.Length > 4) || !numericPart.All(char.IsDigit))
            {
                throw new ArgumentException("Invalid ID. The numeric part should be 3 or 4 digits.");
            }

            emp.ID_Employee = empID.textbox.Text;
        }



        private void ValidateAge()
        {
            if (empAGE.textbox.Text.Length < 1)
            {
                throw new ArgumentException("Invalid Age. Age is less than 1.");
            }
            else if (empAGE.textbox.Text.Length > 3)
            {
                throw new ArgumentException("Invalid Age. Age is more than 3.");
            }
            else if (Convert.ToInt32(empAGE.textbox.Text) > 115)
            {
                throw new ArgumentException("Invalid Age. The entered age is greater than 115 years, which is not valid.");
            }
            emp.Age = Convert.ToInt32(empAGE.textbox.Text);
        }

        private void ValidateCity()
        {
            if (!IsAllLetters(empCity.textbox.Text))
            {
                throw new ArgumentException("Invalid City. Please enter a city containing only letters.");
            }
            else if (empCity.textbox.Text.Length < 2)
            {
                throw new ArgumentException("Invalid City. The entered City is less than 2 letters, which is not valid.");
            }
            else if (empCity.textbox.Text.Length > 20)
            {
                throw new ArgumentException("Invalid city name. The city name should not exceed 20 letters.");
            }
            emp.Town = empCity.textbox.Text;
        }

        private void ValidateAddress()
        {
            if (empAddress.textbox.Text.Length < 6)
            {
                throw new ArgumentException("Invalid Address. The address should have at least 6 characters.");
            }
            emp.Address = empAddress.textbox.Text;
        }

        private void ValidatePhoneNumber()
        {
            if (!IsValidPhoneNumberFormat(empPhone.textbox.Text))
            {
                throw new ArgumentException("Invalid phone number. Please enter a valid phone number in the format 'xxx-xxx-xxxx' or 'xxxxxxxxxx'.");
            }
            emp.Phone = empPhone.textbox.Text;
        }

        private void ValidateGender()
        {
            if (selectedGender == null)
            {
                throw new ArgumentException("Please select a gender.");
            }
            emp.Gender = selectedGender;
        }
        private void ValidateJob()
        {


            // Check if the jobString contains only letters
            if (!IsAllLetters(empJob.textbox.Text))
            {
                throw new ArgumentException("Invalid Job. Job should contain only letters.");
            }

            // List of valid hospital jobs
            List<string> validHospitalJobs = new List<string>
{
    "Doctor",
    "Nurse",
    "Surgeon",
    "Administrator",
    "Pharmacist",
    "Technician",
    "Radiologist",
    "Therapist",
    "Receptionist",
    "Anesthesiologist",
    "Cardiologist",
    "Dentist",
    "Orthopedic Surgeon",
    "Pediatrician",
    "Psychiatrist",
    "Oncologist",
    "Gynecologist",
    "Urologist",
    "Neurologist",
    "Ophthalmologist",
    "Dermatologist",
    "Gastroenterologist",
    "Endocrinologist",
    "ENT Specialist",
    "Physical Therapist",
    "Occupational Therapist",
    "Speech Therapist",
    "Radiology Technician",
    "Lab Technician",
    "Pharmacy Technician",
    "Medical Assistant",
    "Surgical Technologist",
    "Emergency Medical Technician (EMT)",
    "Paramedic",
    "Clinical Research Coordinator",
    "Health Information Technician",
    "Medical Coder",
    "Medical Biller",
    "Hospital Administrator",
    "Medical Receptionist",
    "Patient Care Coordinator",
    "Patient Advocate",
    "Pharmacy Manager",
    "Pharmaceutical Sales Representative",
    "Medical Equipment Technician",
    "Biomedical Engineer",
    "Hospital IT Specialist",
    "Hospital Security Officer",
    "Hospital Housekeeper",
    "Nutritionist",
    "Dietitian",
    "Hospital Chaplain",
    "Medical Librarian",
    "Hospital Volunteer Coordinator",
    "Health Educator",
    "Hospital Social Worker",
    "Patient Transporter",
    "Medical Interpreter",
    "Hospital Finance Analyst",
    "Hospital HR Manager",
    "Hospital Marketing Specialist",
    "Ambulance Driver",
    "Hospital Manager",
    "Co-Manager",
};


            // Check if the jobString is a valid hospital job
            if (!validHospitalJobs.Contains(empJob.textbox.Text.Trim(), StringComparer.OrdinalIgnoreCase))
            {
                throw new ArgumentException("Invalid Job. Please enter a valid hospital job.");
            }

            // Assign the validated jobString to your employee object or use it as needed
            emp.Job = empJob.textbox.Text.Trim();
        }
        private void ValidateSalary()
        {
            if (empSalary.textbox.Text.Trim().Length<4)
            {
                throw new ArgumentException("Invalid Salary. Salary must contain at least 4 Digits.");
            }
            else if (empSalary.textbox.Text.Trim().Length > 5)
            {
                throw new ArgumentException("Invalid Salary. Salary is more than 5 Digits.");
            }
            else if (!string.IsNullOrEmpty(empSalary.textbox.Text) && empSalary.textbox.Text.Any(char.IsLetter))
            {
                throw new ArgumentException("Invalid Salary. Please enter a Salary without any letters.");
            }
            emp.Salary = Convert.ToDouble(empSalary.textbox.Text.Trim());
        }
        private void ValidatePassword()
        {
            if (passwordEmp.Password.Length < 5)
            {
                throw new ArgumentException("Password is too short, try something stronger");
            }
            HashSet<char> pass = new HashSet<char>();
            foreach(char ch in passwordEmp.Password)
            {
                pass.Add(ch);
            }
            if (pass.Count <3)
            {
                throw new ArgumentException("Try Using Different charcters");
            }
            SHA256 sHA256 = SHA256.Create();
            byte[] b = new byte[passwordEmp.Password.Length];
            for (int i = 0; i < passwordEmp.Password.Length; i++)
            {
                b[i] = (byte)passwordEmp.Password[i];
            }
            var res = sHA256.ComputeHash(b);
            string passHash = "";
            for (int i = 0; i < res.Length; i++)
            {
                passHash += (char)res[i];
            }
            emp.Password =passHash;

        }



        private void password_MouseDown(object sender, MouseButtonEventArgs e)
        {
            passwordEmp.Focus();
        }

        private void passwordEmp_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(passwordEmp.Password) && passwordEmp.Password.Length > 0)
            {
                password.Visibility = Visibility.Collapsed;
            }
            else
            {
                password.Visibility = Visibility.Visible;
            }
        }
    }
}
