using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
    /// Interaction logic for Stafflock.xaml
    /// </summary>
    public partial class Stafflock : Window
    {
        public Stafflock()
        {
            InitializeComponent();
        }
        HSMEntities db= new HSMEntities();
        

        private void textManager_CoManager_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtManager_CoManager.Focus();
        }
        private void txtManager_CoManager_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((!string.IsNullOrEmpty(txtManager_CoManager.Text)) && txtManager_CoManager.Text.Length > 0)
            {
                textManager_CoManager.Visibility = Visibility.Collapsed;
            }
            else
            {
                textManager_CoManager.Visibility = Visibility.Visible;
            }
        }

        private void textMCPassword_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtMCPassword.Focus();
        }

        private void txtMCPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMCPassword.Password) && txtMCPassword.Password.Length > 0)
            {
                textMCPassword.Visibility = Visibility.Collapsed;
            }
            else
            {
                textMCPassword.Visibility = Visibility.Visible;
            }
        }
        private void textMCID_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtMCID.Focus();
        }

        private void txtMCID_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMCID.Text) && txtMCID.Text.Length > 0)
            {
                textMCID.Visibility = Visibility.Collapsed;
            }
            else
            {
                textMCID.Visibility = Visibility.Visible;
            }
        }
        private void ToStaff_Click(object sender, RoutedEventArgs e)
        {
            string AdminName = txtManager_CoManager.Text;
            string AdminPassword = txtMCPassword.Password;
            string AdminID = txtMCID.Text;

            SHA256 sHA256 = SHA256.Create();
            byte[] b = new byte[AdminPassword.Length];
            for (int i = 0; i < AdminPassword.Length; i++)
            {
                b[i] = (byte)AdminPassword[i];
            }
            var res = sHA256.ComputeHash(b);
            string passHash = "";
            for (int i = 0; i < res.Length; i++)
            {
                passHash += (char)res[i];
            }
            if (AdminID.Equals("#M000"))
                {
                    var employee = db.EMPLOYEEs.FirstOrDefault(E =>
                    E.employee_name.Equals(AdminName) &&
                    E.Password.Equals(passHash) &&
                   E.ID_Employee.Equals("#M000"));
                    if (employee != null)
                    {
                        ShowStff showStff = new ShowStff();
                        this.Hide();
                        showStff.Show();
                    }
                    else
                    {
                        MessageBox.Show("Invalid ID, Make sure ID is correct");
                    }
                }
                else if(AdminID.Equals( "#CM101"))
                {
                    var employee = db.EMPLOYEEs.FirstOrDefault(E =>
                    E.employee_name.Equals(AdminName) &&
                    E.Password.Equals(passHash) &&
                   E.ID_Employee.Equals("#CM101"));
                    if (employee != null)
                    {
                        ShowStff showStff = new ShowStff();
                        this.Hide();
                        showStff.Show();
                    }
                    else
                    {
                        MessageBox.Show("Invalid ID, Make sure ID is correct");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Admin");
                } 
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            HomePage homePage = new HomePage();
            this.Hide();
            homePage.Show();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

      
    }
}
