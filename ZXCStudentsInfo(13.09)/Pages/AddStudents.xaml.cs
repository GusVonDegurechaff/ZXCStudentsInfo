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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ZXCStudentsInfo.Classes;

namespace ZXCStudentsInfo.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddStudents.xaml
    /// </summary>
    public partial class AddStudents : Page
    {
        public AddStudents()
        {
            InitializeComponent();

            using (var db = new ApplicationContext())
            {
                cmbSpecialnost.ItemsSource = db.Specialnosts.ToList();
                cmbSpecialnost.SelectedValuePath = "Id";
                cmbSpecialnost.DisplayMemberPath = "Name";
            }
        }

        private void btnSavechanges_Click(object sender, RoutedEventArgs e)
        {
            string studName = txtNameUser.Text;
            int studAge = Convert.ToInt32(txtAgeUser.Text);
            int studKyrs = Convert.ToInt32(txtKyrsUser.Text);
            string studDateBrithDay = txtDateBrtithDayUser.Text;
            string studNumbGroup = txtNumberGroupUser.Text;
            int studStipendiya = Convert.ToInt32(txtStipendiyaUser.Text);
            int studYearPostypleniya = Convert.ToInt32(txtYearPostypleniyaUser.Text);
            Specialnost SpecId = (Specialnost)cmbSpecialnost.SelectedItem;

            using (ApplicationContext context = new ApplicationContext())
            {
            //    string studSpecialnostName = cmbSpecialnost.SelectedItem?.ToString() ?? "";

            //    var specialnost = context.Specialnosts.FirstOrDefault(s => s.Name == studSpecialnostName);

            //    if (specialnost == null)
            //    {
            //        MessageBox.Show("Специальность не найдена.");
            //        return;
            //    }

                Students students = new Students(studName, studAge, studKyrs,SpecId.Id, studDateBrithDay, studNumbGroup, studStipendiya, studYearPostypleniya);

                context.Students.Add(students);
                context.SaveChanges();
                MessageBox.Show("Студент добавлен");
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Glav());
        }
    }
}
