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
using System.Data.SQLite; 


namespace N1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        DBEntities db = new DBEntities();

        public MainWindow()
        {
            InitializeComponent();
        }

        public void UpdateTable() 
        { 
            try 
            {
                //var students = from s in db.Students
                //               select new
                //               { id = s.id, FirstName = s.FirstName};

                //dg_Jurnal.ItemsSource = students.ToList();

                var jurnal = from j in db.Journals
                             join stud in db.Students on j.id_Student equals stud.id
                             select new
                               { id = j.id, StudentFIO = stud.FirstName + " " + stud.Surname + " " + stud.LastName, Physics = j.Physics, Math = j.Math};

                dg_Jurnal.ItemsSource = jurnal.ToList();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dg_Jurnal_Loaded(object sender, RoutedEventArgs e)
        {
            
           

            UpdateTable();
        }

    }
}
