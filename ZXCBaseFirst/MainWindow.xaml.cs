using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
namespace ZXCBaseFirst
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Student> students = new List<Student>();
        public MainWindow()
        {
            InitializeComponent();
            using (ZXCInfStudentsContext zxc = new ZXCInfStudentsContext()) 
            {
                students = zxc.Students.ToList();
                dtgUsers.ItemsSource = zxc.Students.Include(t => t.Specialnost).ToList();
            
            }
        }
    }
}