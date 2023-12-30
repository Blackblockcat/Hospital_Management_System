using LiveCharts.Wpf;
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
    /// Interaction logic for BILL.xaml
    /// </summary>
    public partial class BILL : Window
    {   HSMEntities db=new HSMEntities();   
        public BILL()
        {
            InitializeComponent();
        }

        private void print1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("print");
        }

        private void backtohome_MouseDown(object sender, MouseButtonEventArgs e)
        {
            HomePage homePage = new HomePage();
            this.Hide();
            homePage.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = int.Parse(ID.Text);
                int appiont = 0 , medical =0;

                    //ASSIGN PATEINT_NAME
                    PATIENT P = db.PATIENTs.FirstOrDefault(n => n.ID_Patient == id);

                    name.Text = P.name_patient;

                    //assaign Medical_examination
                    //get_ID_TYPE
                    var get_ID = from h in db.MEDICAL_EXAMINATIONS
                                 where h.ID_Patient == id
                                 select h.MeType;
                    var get_ID_TYPE = get_ID.FirstOrDefault();

                    string get_NAME_ME = "NULL";
                    double get_me_price = 0.0;

                    //int get_me_id = 0;
                    if (get_ID != null)
                    {
                    //  get_me_id
                    medical = 1;
                        var NAME_ME = from g in db.MEDICAL_EXAMINATIONS_TYPE
                                      where g.ID == get_ID_TYPE
                                      select g.ME_TYPE;
                        get_NAME_ME = NAME_ME.FirstOrDefault();
                        var me_price = from x in db.MEDICAL_EXAMINATIONS_TYPE
                                       where x.ID == get_ID_TYPE
                                       select x.ME_PRICE;
                        get_me_price = (double)me_price.FirstOrDefault();
                    var pOut = from med in db.MEDICAL_EXAMINATIONS.ToList()
                               where med.ID_Patient == id
                               select med;


                    var assign2 = pOut.FirstOrDefault();

                    assign2.P_OUT = 1;

                }



                    // asseign appointments
                    //get_appoint_id
                    var appoint_id = from o in db.APPOINTMENTs
                                     where o.ID_Patient == id
                                     select o.Appointment_id;
                    var get_appoint_id = appoint_id.FirstOrDefault();


                    string get_NAME_DEP = "NULL";
                    double get_Price_Dep = 0.0;

                    if (appoint_id != null)
                    { //get_id_DEP 
                    appiont = 1;
                        var get_id = from d in db.APPOINTMENTs
                                     where d.ID_Patient == id
                                     select d.ID_Dep;
                        var get_id_DEP = get_id.FirstOrDefault();


                        //get_NAME_DEP
                        var NAME_DEP = from B in db.DEPARTMENTs
                                       where B.ID_Dep == get_id_DEP
                                       select B.NAME_DEP;

                        get_NAME_DEP = NAME_DEP.FirstOrDefault();




                        //get_depart_id
                        var depart_id = from a in db.APPOINTMENTs
                                        where a.ID_Patient == id
                                        select a.ID_Dep;
                        var get_depart_id = depart_id.FirstOrDefault();



                        //get_Price_Dep

                        var depart_price = from k in db.DEPARTMENTs
                                           where get_depart_id == k.ID_Dep
                                           select k.Price_Dep;
                        get_Price_Dep = depart_price.FirstOrDefault();


                    var pTurn = from app in db.APPOINTMENTs.ToList()
                                where app.ID_Patient == id
                                select app;
                    var assign = pTurn.FirstOrDefault();
                    assign.p_turn = true;

                }





                    //assain TOTAL PRICE
                    var total_price = (double)get_Price_Dep + (double)get_me_price;

                    //ASSAIGN DATAGRID
                    var query = new[] { new { APPOINTMENTS = get_NAME_DEP, APPOIN_PRICE = get_Price_Dep, MEDICALEXAMINATION = get_NAME_ME, ME_PRICE = get_me_price } };
                    membersDataGrid.ItemsSource = query.ToList();


                    //NEW BILL
                    
                    db.BILLs.Add(new BILL { ME_Price = (double)get_me_price, Appointment_id = get_appoint_id, Appointment_Price = get_Price_Dep, ID_Patient = id, Pay_Method = "vesa", Payment = true });
                    db.SaveChanges();
                    TOTAL_PRICE.textbox.Text = total_price.ToString();
                
              
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
            catch 
            {
                MessageBox.Show("Patient didn't Sign Up");
            }
        
        }

     
    }
}
