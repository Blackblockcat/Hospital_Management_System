using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace HSM
{
    public partial class Medical_Examination : Window
    {
        private const int Capacity = 6;
        private  HSMEntities db = new HSMEntities();
        private  MEDICAL_EXAMINATIONS M = new MEDICAL_EXAMINATIONS();

        public Medical_Examination()
        {
            InitializeComponent();
        }

        private void HandleMedicalExamination(int meType)
        {
            
                var checkout = db.MEDICAL_EXAMINATIONS.Count(check => check.MeType == meType && check.P_OUT == 0);
            if (checkout < Capacity)
                {
                    M.P_OUT = 0;
                    M.MeType = meType;
                    M.ID_Patient = 123456789;  // Assign an existing patient ID to M.ID_Patient before adding
                    M.ME_DATE = new DateTime(2022, 6, 8);

                    db.MEDICAL_EXAMINATIONS.Add(M);
                    db.SaveChanges();

                    registration r = new registration();
                    Hide();
                    r.Show();
                }
                else
            {
                
               
                MessageBox.Show("Capicty is High right now");
            }
            
            
        }

        private void BloodCell_Click(object sender, RoutedEventArgs e)
        {
            HandleMedicalExamination(1);
        }

        private void X_ray_Click(object sender, RoutedEventArgs e)
        {
            HandleMedicalExamination(2);
        }

        private void Ultrasound_Click(object sender, RoutedEventArgs e)
        {
            HandleMedicalExamination(3);
        }

        private void MRI_Scan_Click(object sender, RoutedEventArgs e)
        {
            HandleMedicalExamination(4);
        }

        private void EKG_Click(object sender, RoutedEventArgs e)
        {
            HandleMedicalExamination(5);
        }

        private void Colonoscopy_Click(object sender, RoutedEventArgs e)
        {
            HandleMedicalExamination(6);
        }

        private void Pap_Smear_Click(object sender, RoutedEventArgs e)
        {
            HandleMedicalExamination(7);
        }

        private void Bone_Density_Scan_Click(object sender, RoutedEventArgs e)
        {
            HandleMedicalExamination(8);
        }

        private void CT_Scan_Click(object sender, RoutedEventArgs e)
        {
            HandleMedicalExamination(9);
        }

        private void Dental_Check_up_Click(object sender, RoutedEventArgs e)
        {
            HandleMedicalExamination(10);
        }

        private void Allergy_Test_Click(object sender, RoutedEventArgs e)
        {
            HandleMedicalExamination(11);
        }

        private void Endoscopy_Click(object sender, RoutedEventArgs e)
        {
            HandleMedicalExamination(12);
        }

        private void Pulmonary_Function_Test_Click(object sender, RoutedEventArgs e)
        {
            HandleMedicalExamination(13);
        }

        private void Eye_Exam_Click(object sender, RoutedEventArgs e)
        {
            HandleMedicalExamination(14);
        }

        private void Cardiac_Stress_Test_Click(object sender, RoutedEventArgs e)
        {
            HandleMedicalExamination(15);
        }

        private void Pregnancy_Ultrasound_Click(object sender, RoutedEventArgs e)
        {
            HandleMedicalExamination(16);
        }

        private void DEXA_Scan_Click(object sender, RoutedEventArgs e)
        {
            HandleMedicalExamination(17);
        }

        private void Spirometry_Click(object sender, RoutedEventArgs e)
        {
            HandleMedicalExamination(18);
        }

        private void Dermatological_Exam_Click(object sender, RoutedEventArgs e)
        {
            HandleMedicalExamination(19);
        }

        private void Colon_Cancer_Screening_Click(object sender, RoutedEventArgs e)
        {
            HandleMedicalExamination(20);
        }

        private void Hearing_Test_Click(object sender, RoutedEventArgs e)
        {
            HandleMedicalExamination(21);
        }

        private void cancel1_Click(object sender, RoutedEventArgs e)
        {
            HomePage homePage = new HomePage();
            Hide();
            homePage.Show();
        }
    }
}
