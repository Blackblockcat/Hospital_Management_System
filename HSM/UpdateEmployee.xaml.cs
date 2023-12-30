using MaterialDesignColors;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Mapping;
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
    /// <summary>
    /// Interaction logic for UpdateEmployee.xaml
    /// </summary>
    public partial class UpdateEmployee : Window
    {
        HSMEntities db = new HSMEntities();
        EMPLOYEE EM = new EMPLOYEE();
        
        public UpdateEmployee()
        {
            InitializeComponent();
        }
        // List<EMPLOYEE> ls = new List<EMPLOYEE>();
        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            ShowStff s = new ShowStff();
            this.Hide();
            s.Show();
        }
        private void save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                EMPLOYEE NEWIMP = db.EMPLOYEEs.SingleOrDefault(s => s.ID_Employee.ToString() == empID.textbox.Text.ToString());

                if (NEWIMP != null)
                {
                    // Validate Age
                    if (int.TryParse(empAGE.textbox.Text, out int age))
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

                    // Validate City
                    if (!IsAllLetters(empCity.textbox.Text) || empCity.textbox.Text.Length > 12 || empCity.textbox.Text.Length < 3 || !char.IsUpper(empCity.textbox.Text.First()))
                    {
                        MessageBox.Show("Invalid City.  start with an uppercase letter, and be at most 12 characters.");
                        return;
                    }

                    // Validate Phone
                    string phone = empPhone.textbox.Text; // Remove separators for validation
                    if (!IsValidPhoneNumberFormat(phone))
                    {
                        MessageBox.Show("Invalid phone number. Please enter a valid 10-digit number.");
                        return;
                    }
                    NEWIMP.Phone = empPhone.textbox.Text;

                    // Validate Address
                    if (empAddress.textbox.Text.Trim().Length < 3 || empAddress.textbox.Text.Trim().Length > 15)
                    {
                        MessageBox.Show("Invalid Address. Address should be between 3 and 15 characters.");
                        return;
                    }
                    NEWIMP.Address = empAddress.textbox.Text;

                    // Validate Salary
                    if (empSalary.textbox.Text.Trim().Length > 5)
                    {
                        MessageBox.Show("Invalid Salary. Salary should not be more than 5 digits.");
                        return;
                    }

                    NEWIMP.Salary = Convert.ToDouble(empSalary.textbox.Text.Trim());

                    db.SaveChanges();
                    MessageBox.Show("Saved!");
                }
                else
                {
                    MessageBox.Show("Employee not found. Please check the ID.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}");
            }
        }
        //try
        //{   

        //    ValidatePhoneNumber();
        //    ValidateAddress();
        //    ValidateCity();
        //    ValidateAge();
        //    ValidateSalary();
        //    db.SaveChanges();
        //    MessageBox.Show("accepted");
        //}
        //catch (DbUpdateException ex)
        //{
        //    if (ex.InnerException != null && ex.InnerException.InnerException != null)
        //    {
        //        MessageBox.Show($"An error occurred while updating entries: {ex.InnerException.InnerException.Message}");
        //    }
        //    else
        //    {
        //        MessageBox.Show($"An error occurred while updating entries: {ex.Message}");
        //    }
        //}
        //catch (DbEntityValidationException ex)
        //{
        //    StringBuilder errorMessages = new StringBuilder();
        //    foreach (var error in ex.EntityValidationErrors)
        //    {
        //        foreach (var validationError in error.ValidationErrors)
        //        {
        //            errorMessages.AppendLine($"{validationError.PropertyName}: {validationError.ErrorMessage}");
        //        }
        //    }

        //    MessageBox.Show($"An error occurred while saving data: {errorMessages.ToString()}");
        //}

        //catch (Exception ex)
        //{
        //    MessageBox.Show($"An unexpected error occurred: {ex.Message}");
        //}


    



        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void Modify_Click(object sender, RoutedEventArgs e)
        {
            var item = db.EMPLOYEEs.FirstOrDefault(E => E.ID_Employee.Equals(empID.textbox.Text));
            try
            {
                
              //  MessageBox.Show(item.ID_Employee.ToString());
                if (item == null)
                {
                    MessageBox.Show("error");
                }
                else
                {
                    empAGE.textbox.Text = item.Age.ToString();
                    empSalary.textbox.Text = item.Salary.ToString();
                    empPhone.textbox.Text = item.Phone.ToString();
                    empAddress.textbox.Text = item.Address.ToString();
                    empCity.textbox.Text = item.Town.ToString();
                    
                }
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
        static string ConvertToTitleCase(string input)
        {
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            return textInfo.ToTitleCase(input.ToLower());
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
        // Function to check if the phone number has a valid format
        static bool IsValidPhoneNumberFormat(string phoneNumber)
        {
            string pattern = @"^(\d{3}-\d{3}-\d{4}|\d{10})$";
            return Regex.IsMatch(phoneNumber, pattern);
        }
        private void ValidatePhoneNumber()
        {
            if (!IsValidPhoneNumberFormat(empPhone.textbox.Text))
            {
                throw new ArgumentException("Invalid phone number. Please enter a valid phone number in the format 'xxx-xxx-xxxx' or 'xxxxxxxxxx'.");
            }
            EM.Phone=empPhone.textbox.Text;

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
            EM.Age = Convert.ToInt32(empAGE.textbox.Text);
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
            EM.Town = empCity.textbox.Text;
        }

        private void ValidateAddress()
        {
            if (empAddress.textbox.Text.Length < 6)
            {
                throw new ArgumentException("Invalid Address. The address should have at least 6 characters.");
            }
            EM.Address = empAddress.textbox.Text;
        }
        private void ValidateSalary()
        {
            if (empSalary.textbox.Text.Trim().Length < 4)
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
            EM.Salary = Convert.ToDouble(empSalary.textbox.Text.Trim());
        }
    }
}
