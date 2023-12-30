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
    /// Interaction logic for Pharmacy.xaml
    /// </summary>
    public partial class Pharmacy : Window
    {
        public Pharmacy()
        {
            InitializeComponent();
            show_PharmacyList();
        }
        private List<PHARMACY> ls { get; set; }
        HSMEntities db = new HSMEntities();
        private void show_PharmacyList()
        {
            var item = db.PHARMACies.ToList();
            ls = item as List<PHARMACY>;
            DataContext = ls;
        }
        double price = 0.0;
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selected_item = search.Text;

                var item = db.PHARMACies.ToList();
                var codeMedicine = (from p in item
                                    where p.MEDICENE_name.ToLower().Equals(selected_item.ToLower())
                                    select p.Medicine_Code).FirstOrDefault();
                // var codeMedicine = db.PHARMACies.FirstOrDefault(p=>p.MEDICENE_name.ToLower().Equals(selected_item.ToLower()));
                var checkPatient = db.PATIENTs.FirstOrDefault(P => P.name_patient.Equals(Pname.textbox.Text) && P.ID_Patient.ToString().Equals(userid.textbox.Text));
                if (checkPatient != null)
                {
                    


                        if (codeMedicine != 0)
                        {


                            int idPatient = Convert.ToInt32(userid.textbox.Text);
                            db.Pharmacy_Bill.Add(new Pharmacy_Bill
                            {

                                ID_Patient = idPatient,
                                Medicine_Code = codeMedicine
                            });
                            db.SaveChanges();



                            var result = from p in item
                                         where p.MEDICENE_name.ToLower().Equals(selected_item.ToLower())
                                         select p;

                            membersDataGrid.Items.Add(result);
                            search.Clear();

                            // select price to calculate Total sum
                            var pricaMedicine = from p in item
                                                where p.MEDICENE_name.ToLower().Equals(selected_item.ToLower())
                                                select p.Price;
                            double selectPrice = (double)pricaMedicine.FirstOrDefault();
                            price += selectPrice;
                            TotalPrice.Text = price.ToString();

                        }
                        else
                        {
                            MessageBox.Show("You didn't Add Any Medicine");
                        }
                    }
                else
                {
                    MessageBox.Show("Patient doesn't exist");
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

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            HomePage homePage = new HomePage();
            this.Hide();
            homePage.Show();
        }

        
    }
}
