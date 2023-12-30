using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for ShowStff.xaml
    /// </summary>
    public partial class ShowStff : Window
    {
        public ShowStff()
        {
            InitializeComponent();
            ShowStaff();
        }
        HSMEntities db=new HSMEntities();

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            HomePage homePage = new HomePage();
            this.Hide();
            homePage.Show();
        }

        private bool IsMaximize = false;

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                if (IsMaximize)
                {
                    this.WindowState = WindowState.Normal;
                    this.Width = 1300;
                    this.Height = 700;

                    IsMaximize = false;
                }
                else
                {
                    this.WindowState = WindowState.Maximized;

                    IsMaximize = true;
                }
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            
            Staff staff = new Staff();
            this.Hide();
            staff.Show();
        }
        private void ShowStaff()
        {
            var item = db.EMPLOYEEs.ToList();
            membersDataGrid.ItemsSource = item;
        }
        private void textBoxFilter_TextChanged()
        {
            var item = db.EMPLOYEEs.ToList();
            var search = from serch in item
                         where serch.employee_name.Contains(EmpName.textbox.Text)
                         select serch;
            membersDataGrid.ItemsSource = search;

        }
        private EMPLOYEE selectedMember;
 

        private void refresh_MouseDown(object sender, MouseButtonEventArgs e)
        {
            EmpName.textbox.Clear();
            ShowStaff();
        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            textBoxFilter_TextChanged();

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (selectedMember != null)
            {
                var memberToDelete = db.EMPLOYEEs.Find(selectedMember.ID_Employee);
                if (memberToDelete != null)
                {
                    db.EMPLOYEEs.Remove(memberToDelete);
                    db.SaveChanges();
                    membersDataGrid.ItemsSource = db.EMPLOYEEs.ToList();
                }
            }
        }

        private void membersDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (membersDataGrid.SelectedItem != null)
            {
                selectedMember = (EMPLOYEE)membersDataGrid.SelectedItem;
            }
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
        private void ViewPhoto_Click(object sender, MouseButtonEventArgs e)
        {
            if (selectedMember != null)
            {
                if (selectedMember != null)
                {
                    // Assuming Photo is the property in EMPLOYEE class which contains binary photo data
                    byte[] photoData = selectedMember.Image;

                    if (photoData != null && photoData.Length > 0)
                    {
                        // Convert the binary data to a BitmapImage
                        BitmapImage bitmapImage = ConvertToBitmapImage(photoData);

                        // Display the image in a new window
                        Window imageWindow = new Window
                        {
                            
                            Content = new Image { Source = bitmapImage, Stretch = Stretch.Fill }
                        };

                        imageWindow.Show();
                    }
                }
            }
        }

        private BitmapImage ConvertToBitmapImage(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0)
                return null;


            BitmapImage image = new BitmapImage();
            using (MemoryStream stream = new MemoryStream(imageData))
            {
                stream.Position = 0;
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.StreamSource = stream;
                image.EndInit();
            }
            return image;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UpdateEmployee u=new UpdateEmployee();
            this.Hide();
            u.Show();
        }
    }


}
