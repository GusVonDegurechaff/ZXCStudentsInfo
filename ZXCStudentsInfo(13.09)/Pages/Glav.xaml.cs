using Microsoft.EntityFrameworkCore;
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
    /// Логика взаимодействия для Glav.xaml
    /// </summary>
    public partial class Glav : Page
    {
        public List<Students> students = new List<Students>();
        public Glav()
        {
            using (ApplicationContext zxc = new ApplicationContext())
            {
                students = zxc.Students.Include(s => s.Specialnosts)
                    .ToList();
            }
            InitializeComponent();
            dtgUsers.ItemsSource = students;

        }

        private void btnRedactStudents_Click(object sender, RoutedEventArgs e)
        {
            var studentForRedact = (Students)dtgUsers.SelectedItem;
            NavigationService.Navigate(new RedactStudent(studentForRedact));
        }

        private void btnDeleteStudents_Click(object sender, RoutedEventArgs e)
        {
            List<Students> studentsForRemoving = dtgUsers.SelectedItems.Cast<Students>().ToList();
            if (studentsForRemoving.Count > 0)
            {
                foreach (Students user in studentsForRemoving)
                {
                    using (ApplicationContext zxc = new ApplicationContext())
                    {
                        zxc.Students.Remove(user);
                        zxc.SaveChanges();
                    }
                }
                using (ApplicationContext zxc = new ApplicationContext())
                {
                    dtgUsers.ItemsSource = zxc.Students.ToList();
                }
                MessageBox.Show($"Выбранные пользователи({studentsForRemoving.Count}) удалены");
            }
            else
            {
                MessageBox.Show("Вы не выбрали ни одного пользователя");
            }
        }

        private void btnCreateStudents_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddStudents());
        }
    }
}
