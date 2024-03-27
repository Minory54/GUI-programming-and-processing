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
    /// Логика взаимодействия для AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        DBEntities db = new DBEntities();

        public AddWindow()
        {
            InitializeComponent();
        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            AddJournal();
           
        }

        public void AddJournal()
        {
            if (tb_FirstName.Text == "" || tb_Surname.Text == "" || tb_LastName.Text == "")
            {
                MessageBox.Show("Введите ФИО полностью!");
                return;
            }
            if (Convert.ToInt32(tb_Physic.Text) < 0 || Convert.ToInt32(tb_Physic.Text) > 5 || Convert.ToInt32(tb_Physic.Text)%10 != 0)
            {
                MessageBox.Show("Некоректная оценка!");
                return;
            }
            if (Convert.ToInt32(tb_Math.Text) < 0 || Convert.ToInt32(tb_Math.Text) > 5 || Convert.ToInt32(tb_Math.Text) % 10 != 0)
            {
                MessageBox.Show("Некоректная оценка!");
                return;
            }
            try 
            { 
                Student student = new Student()
                {
                    FirstName = Convert.ToString(tb_FirstName.Text),
                    Surname = Convert.ToString(tb_Surname.Text),
                    LastName = Convert.ToString(tb_LastName.Text),
                };

                student = db.Students.Add(student);
                db.SaveChanges();

                var stud = (from s in db.Students
                           orderby s.id descending
                           select new
                           { id = s.id }).First();

                Journal journal = new Journal()
                { 
                    id_Student = stud.id,
                    Physics = Convert.ToInt32(tb_Physic.Text),
                    Math = Convert.ToInt32(tb_Math.Text),
                };

                journal = db.Journals.Add(journal);
                db.SaveChanges();

                MessageBox.Show("Добавление прошло успешно!");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
    }
}
