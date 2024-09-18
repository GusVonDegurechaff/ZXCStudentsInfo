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
    /// Логика взаимодействия для RedactStudent.xaml
    /// </summary>
    public partial class RedactStudent : Page
    {
        private Students _student { get; set; }
        public RedactStudent(Students students)
        {
            this._student = students;
            InitializeComponent();
            txtNameUser.Text = students.FIO;
            txtAgeUser.Text = Convert.ToString(students.Age);
            txtKyrsUser.Text = Convert.ToString(students.Kyrs);
            using (var db = new ApplicationContext())
            {
                cmbSpecialnost.ItemsSource = db.Specialnosts.ToList();
                cmbSpecialnost.SelectedValuePath = "Id";
                cmbSpecialnost.DisplayMemberPath = "Name";

            }
            cmbSpecialnost.SelectedIndex = _student.SpecialnostId-1;
            txtDateBrtithDayUser.Text = students.DateBrithDay;
            txtNumberGroupUser.Text = students.NumberGroup;
            txtStipendiyaUser.Text = Convert.ToString(students.Stipendiya);
            txtYearPostypleniyaUser.Text = Convert.ToString(students.YearPostypleniya);
        }

        private void btnBackRedact_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Glav());
        }

        private void btnSaveRedact_Click(object sender, RoutedEventArgs e)
        {
            _student.FIO = txtNameUser.Text;
            _student.Age = Convert.ToInt32(txtAgeUser.Text);
            _student.Kyrs = Convert.ToInt32(txtKyrsUser.Text);
         
            _student.Specialnosts = cmbSpecialnost.SelectedItem as Specialnost;
            _student.DateBrithDay = txtDateBrtithDayUser.Text;
            _student.NumberGroup = txtNumberGroupUser.Text;
            _student.Stipendiya = Convert.ToInt32(txtStipendiyaUser.Text);
            _student.YearPostypleniya = Convert.ToInt32(txtYearPostypleniyaUser.Text);
            using (ApplicationContext zxc = new ApplicationContext())
            {
                zxc.Students.Update(_student);
                zxc.SaveChanges();
            }
            MessageBox.Show("Пользователь изменён");
        }
    }
}
