using Newtonsoft.Json;
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
using System.IO;
using System.Xml.Linq;

namespace project6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Student> students;
        public MainWindow()
        {
            InitializeComponent();
            Data.List(students);
            list.ItemsSource = students;


        }

        private void btnsearch_Click(object sender, RoutedEventArgs e)
        {          
            list.ItemsSource = null;
            list.ItemsSource = Data.ToSearch(students, txtsearch.Text); 
        }
        
        private void btnadd_Click(object sender, RoutedEventArgs e)
        {
            students = new List<Student>();
            Data.ToAdd(students,txtname.Text);
            txtname.Clear();
            list.ItemsSource = null;
            list.ItemsSource = students;

        }
    }

   
}