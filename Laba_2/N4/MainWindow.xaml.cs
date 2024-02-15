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

            int[] year = {2019, 2020, 2021, 2022, 2023};
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

        void fillingCmbDays() 
        {
            int year = Convert.ToInt32(cmb_year.SelectedValue);
            int indexMonth = cmb_month.SelectedIndex + 1;
            cmb_day.Items.Clear();


            if (cmb_year.SelectedItem != null & cmb_month.SelectedItem != null)
            {
                fillingdaysCountInMonth(daysCountInMonth(year, indexMonth));
                cmb_day.IsEnabled = true;
            }
        }

        int daysCountInMonth(int selectedYear, int indexMonth)
        {
            int daysCountInMonth = 0;

            switch (indexMonth)
            {
                case 1: //Январь
                    daysCountInMonth = 31; 
                    break;
                case 2: //Февраль
                    if (selectedYear % 4 == 0)
                    {
                        daysCountInMonth = 29;
                    } else
                    {
                        daysCountInMonth = 28;
                    }                    
                    break;
                case 3: //Март
                    daysCountInMonth = 31; 
                    break;
                case 4: //Апрель
                    daysCountInMonth = 30; 
                    break;
                case 5: //Май
                    daysCountInMonth = 31;
                    break;
                case 6: //Июнь
                    daysCountInMonth = 30;
                    break;
                case 7: //Июль
                    daysCountInMonth = 31;
                    break;
                case 8: //Август
                    daysCountInMonth = 31;
                    break;
                case 9: //Сентябрь
                    daysCountInMonth = 30;
                    break;
                case 10: //Октябрь
                    daysCountInMonth = 31;
                    break;
                case 11: //Ноябрь
                    daysCountInMonth = 30;
                    break;
                case 12: //Декабрь
                    daysCountInMonth = 31;
                    break;
            }
            return daysCountInMonth;
        }

        void fillingdaysCountInMonth(int daysCountInMonth)
        {
            for (int i = 1; i <= daysCountInMonth; i++)
            {
                cmb_day.Items.Add(i);
            }
        }

        void pastTime ()
        {
            int selectedYear = Convert.ToInt32(cmb_year.SelectedValue);
            int selectedIndexMonth = cmb_month.SelectedIndex + 1;
            int selectedDay = Convert.ToInt32(cmb_day.SelectedValue);


            //int dayPassed = Math.Abs(DateTime.Now.Day - day);          
            //int monthPassed = Math.Abs(DateTime.Now.Month - indexMonth;
            //int yearPassed = DateTime.Now.Year - year;

            int dayPassed = 0;
            int monthPassed = 0;
            int yearPassed = 0;


            if (DateTime.Now.Day - selectedDay < 0)
            {
                dayPassed = daysCountInMonth(selectedYear, selectedIndexMonth) + DateTime.Now.Day - selectedDay;
                monthPassed = DateTime.Now.Month - selectedIndexMonth - 1;
            }
            else
            {
                dayPassed = DateTime.Now.Day - selectedDay;
                monthPassed = DateTime.Now.Month - selectedIndexMonth;
            }

            if (DateTime.Now.Month - selectedIndexMonth < 0 || daysCountInMonth(selectedYear, monthPassed) + monthPassed < 0)
            {
                monthPassed = 12 + DateTime.Now.Month - selectedIndexMonth;
                yearPassed = DateTime.Now.Year - selectedYear - 1;
            }
            else
            {
                monthPassed = DateTime.Now.Month - selectedIndexMonth;
                yearPassed = DateTime.Now.Year - selectedYear;
            }


            if (cmb_year.SelectedItem != null & cmb_month.SelectedItem != null & cmb_day.SelectedItem != null)
            {
                MessageBox.Show($"Прошло {yearPassed} года, {monthPassed} месяцев и {dayPassed} дней");
            }
        }

        private void cmb_day_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            pastTime();
        }

        private void cmb_year_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            fillingCmbDays();
        }

        private void cmb_month_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            fillingCmbDays();
        }
    }
}
