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
using static System.Net.Mime.MediaTypeNames;

namespace N4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            int[] year = {2021, 2022, 2023, 2024};           
            string[] month = { "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь" };

            for (int j = 0; j < year.Length; j++)
            {
                cmb_year.Items.Add(year[j]);
            }

            for (int i = 0; i < month.Length; i++)
            {
                cmb_month.Items.Add(month[i]);
            }
        }

        int fillingCmbDays (int year, int indexMonth)
        {
            int daysCount = 0;

            switch (indexMonth)
            {
                case 0: //Январь
                    daysCount = 31; 
                    break;
                case 1: //Февраль
                    if (year % 4 == 0)
                    {
                        daysCount = 29;
                    } else
                    {
                        daysCount = 28;
                    }                    
                    break;
                case 2: //Март
                    daysCount = 31; 
                    break;
                case 3: //Апрель
                    daysCount = 30; 
                    break;
                case 4: //Май
                    daysCount = 31;
                    break;
                case 5: //Июнь
                    daysCount = 30;
                    break;
                case 6: //Июль
                    daysCount = 31;
                    break;
                case 7: //Август
                    daysCount = 31;
                    break;
                case 8: //Сентябрь
                    daysCount = 30;
                    break;
                case 9: //Октябрь
                    daysCount = 31;
                    break;
                case 10: //Ноябрь
                    daysCount = 30;
                    break;
                case 11: //Декабрь
                    daysCount = 31;
                    break;
            }

            fillingDaysCount (daysCount);
            return daysCount;
        }

        void fillingDaysCount( int daysCount)
        {
            for (int i = 1; i <= daysCount; i++)
            {
                cmb_day.Items.Add(i);
            }
        }

        private void cmb_day_DropDownOpened(object sender, EventArgs e)
        {
            int year = Convert.ToInt32(cmb_year.SelectedValue);
            int indexMonth = cmb_month.SelectedIndex;
            cmb_day.Items.Clear();


            if (cmb_year.SelectedItem != null & cmb_month.SelectedItem != null) 
            {
                fillingCmbDays(year, indexMonth);
            }
        }

        private void cmb_day_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int year = Convert.ToInt32(cmb_year.SelectedValue);
            int indexMonth = cmb_month.SelectedIndex;
            int day = Convert.ToInt32(cmb_day.SelectedValue);

            int yearPassed = DateTime.Now.Year - year;
            int monthPassed = DateTime.Now.Month - indexMonth-1;
            int dayPassed = DateTime.Now.Day - day;

            if (yearPassed > 0 )

            if (cmb_year.SelectedItem != null & cmb_month.SelectedItem != null & cmb_month.SelectedItem != null)
            {
                MessageBox.Show($"Прошло {yearPassed} года, {monthPassed} месяцев и {dayPassed} дней");
            }
            
        }

        private void cmb_year_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cmb_month_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        
    }
}
