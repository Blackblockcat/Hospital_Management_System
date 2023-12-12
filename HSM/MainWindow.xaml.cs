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

namespace HSM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=HSMBase;Integrated Security=True;Trust Server Certificate=True");
        
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
         
            SqlDataAdapter adapter=new SqlDataAdapter("select employee_name,ID_Employee from EMPLOYEE where employee_name='" + txtUserName.Text + "'and ID_Employee='" + txtUserID.Password + "'", con);
            DataTable dataTable = new DataTable();
             adapter.Fill(dataTable);
            /*
             * John Doe #M000
             * Michael Johnson #CM101
             * Emma Brown   #R204
             * Aiden Clark  #R223
             * Amelia Parker #R245
             * Noah Martinez #R299
             * Stella Nelson #R305
             */
           
            if (dataTable.Rows.Count > 0 && ((txtUserName.Text == "John Doe" && txtUserID.Password == "#M000") || (txtUserName.Text == "Michael Johnson" && txtUserID.Password == "#CM101") || (txtUserName.Text == "Emma Brown" && txtUserID.Password == "#R204")
    || (txtUserName.Text == "Aiden Clark" && txtUserID.Password == "#R223") || (txtUserName.Text == "Amelia Parker" && txtUserID.Password == "#R245")
    || (txtUserName.Text == "Noah Martinez" && txtUserID.Password == "#R299") || (txtUserName.Text == "Stella Nelson" && txtUserID.Password == "#R305")))
            {
                 HomePage p=new HomePage();
                this.Hide();
                p.Show();
               
            }
            else
            {

                MessageBox.Show("!Invaild");
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
