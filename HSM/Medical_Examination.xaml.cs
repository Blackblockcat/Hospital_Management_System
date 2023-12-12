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
    /// Interaction logic for Medical_Examination.xaml
    /// </summary>
    public partial class Medical_Examination : Window
    {
        public Medical_Examination()
        {
            InitializeComponent();
        }

        private void Pap_Smear_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Saved !" +"\n "+
                "We Wish a patient be Well");
        }

      

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            HomePage page = new HomePage();
            this.Hide();
            page.Show();
        }
    }
}
