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
                var journal = from j in db.Journals
                             join stud in db.Students on j.id_Student equals stud.id
                             select new
                               { id = j.id, StudentFIO = stud.FirstName + " " + stud.Surname + " " + stud.LastName, Physics = j.Physics, Math = j.Math};

                dg_Journal.ItemsSource = journal.ToList();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dg_Journal_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateTable();
        }

        private void btn_del_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить информацию о студенте?", "Подтверждение удаления", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            { 
                try 
                {                   
                    var ci = new DataGridCellInfo(dg_Journal.SelectedItem, dg_Journal.Columns[0]);
                    var id_journal = Convert.ToInt32((ci.Column.GetCellContent(ci.Item) as TextBlock).Text);

                    Journal journal = db.Journals.Where(j => j.id == id_journal).FirstOrDefault();
                    db.Journals.Remove(journal);
                    db.SaveChanges();
                    UpdateTable();

                    MessageBox.Show("Удаление прошло успешно!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            AddWindow addWindow = new AddWindow();
            addWindow.ShowDialog();

        }

        private void btn_edit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Update_Click(object sender, RoutedEventArgs e)
        {
            UpdateTable();
        }
    }
}
