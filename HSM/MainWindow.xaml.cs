using System;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Navigation;
using Azure;
using Microsoft.Data.SqlClient;
using System.Security.Cryptography;

namespace HSM
{
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
      
        HSMEntities db= new HSMEntities();
        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }
        private void textUserName_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtUserName.Focus();
        }

        private void txtUserName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if((! string.IsNullOrEmpty(txtUserName.Text))&& txtUserName.Text.Length>0)
            {
                textUserName.Visibility = Visibility.Collapsed;
            }
            else
            {
                textUserName.Visibility = Visibility.Visible;
            }
        }

        private void textUserID_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtUserID.Focus();
        }

        private void txtUserID_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUserID.Password) && txtUserID.Password.Length > 0)
            {
                textUserID.Visibility = Visibility.Collapsed;
            }
            else
            {
                textUserID.Visibility = Visibility.Visible;
            }
        } 
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            string userName = txtUserName.Text;
            string userPassword = txtUserID.Password;
            SHA256 sHA256 = SHA256.Create();
            byte[] b=new byte[userPassword.Length];
            for (int i = 0; i < userPassword.Length; i++)
            {
                b[i] = (byte)userPassword[i];
            }
            var res=sHA256.ComputeHash(b);
            string passHash = "";
            for (int i = 0; i < res.Length; i++)
            {
                passHash += (char)res[i];
            }
       
            var user = db.EMPLOYEEs.FirstOrDefault(E => E.employee_name.Equals(userName) && E.Password.Equals(passHash));
            if (user != null)
            {
               
                HomePage homePage = new HomePage();
                this.Hide();
                homePage.Show();
            }
            else
            {
                MessageBox.Show("Sorry Invalid");
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
            Application.Current.Shutdown();
        }
    }
}
