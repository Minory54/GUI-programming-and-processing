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
using System.Windows.Shapes;

namespace N1
{
    /// <summary>
    /// Логика взаимодействия для EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        DBEntities db = new DBEntities();
        public int id_selectedJournal;

        public EditWindow()
        {
            InitializeComponent();          
        }

        public void EditData()
        {
            if (tb_FirstName.Text == "" || tb_Surname.Text == "" || tb_MiddleName.Text == "")
            {
                MessageBox.Show("Введите ФИО полностью!");
                return;
            }
            if (tb_Physic.Text == "" || tb_Math.Text == "")
            {
                MessageBox.Show("Поля с оценками не могут быть пустыми");
                return;
            }
            try
            {
                Journal journal = db.Journals.Where(j => j.id == id_selectedJournal).FirstOrDefault();
                Student student = db.Students.Where(j => j.id == journal.id_Student).FirstOrDefault();

                student.FirstName = tb_FirstName.Text;
                student.Surname = tb_Surname.Text;
                student.MiddleName = tb_MiddleName.Text;
                journal.Math = Convert.ToInt32(tb_Math.Text);
                journal.Physics = Convert.ToInt32(tb_Physic.Text);

                db.SaveChanges();

                MessageBox.Show("Изменение прошло успешно!");
                this.DialogResult = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            EditData();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Journal journal = db.Journals.Where(j => j.id == id_selectedJournal).FirstOrDefault();
            Student student = db.Students.Where(j => j.id == journal.id_Student).FirstOrDefault();

            tb_FirstName.Text = student.FirstName;
            tb_Surname.Text = student.Surname;
            tb_MiddleName.Text = student.MiddleName;
            tb_Math.Text = journal.Math.ToString();
            tb_Physic.Text = journal.Physics.ToString();
        }
    }
}
