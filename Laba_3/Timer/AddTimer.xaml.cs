using System;
using System.Collections.Generic;
using System.Data;
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

namespace Timer
{
    /// <summary>
    /// Логика взаимодействия для AddTimer.xaml
    /// </summary>
    public partial class AddTimer : Window
    {
        public string newTimerName;
        public DateTime newTimerDateTime;

        public AddTimer(string _editNameTimer, DateTime _editTimerDateTime)
        {
            InitializeComponent();

            tb_timerName.Text = _editNameTimer.ToString();
            tb_timerHour.Text = _editTimerDateTime.Hour.ToString();
            tb_timerMinute.Text = _editTimerDateTime.Minute.ToString();
            tb_timerSecond.Text = _editTimerDateTime.Second.ToString();
            cal_timerCalendar.SelectedDate = _editTimerDateTime;
        }

        public AddTimer()
        {
            InitializeComponent();      
        }

        private void bt_cancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void bt_addTimer_Click(object sender, RoutedEventArgs e)
        {           
            //DateTime? selectDate = cal_timerCalendar.SelectedDate;
            newTimerName = tb_timerName.Text;
            newTimerDateTime = cal_timerCalendar.SelectedDate.Value;
            newTimerDateTime = newTimerDateTime.AddHours(Convert.ToInt32(tb_timerHour.Text));
            newTimerDateTime = newTimerDateTime.AddMinutes(Convert.ToInt32(tb_timerMinute.Text));
            newTimerDateTime = newTimerDateTime.AddSeconds(Convert.ToInt32(tb_timerSecond.Text));
            //newTimerDateTime = new DateTime(selectDate.Value.Year, selectDate.Value.Month, selectDate.Value.Day, Convert.ToInt32(tb_timerHour.Text), Convert.ToInt32(tb_timerMinute.Text), Convert.ToInt32(tb_timerSecond.Text));
            this.DialogResult = true;
        }

        private void tb_timerHour_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tb_timerHour.Text != "" && Convert.ToInt32(tb_timerHour.Text) >= 24)
            {
                tb_timerHour.Text = "23";
            }
        }

        private void tb_timerMinute_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tb_timerMinute.Text != "" && Convert.ToInt32(tb_timerMinute.Text) >= 60)
            {
                tb_timerMinute.Text = "59";
            }
        }

        private void tb_timerSecond_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tb_timerSecond.Text != "" && Convert.ToInt32(tb_timerSecond.Text) >= 60)
            {
                tb_timerSecond.Text = "59";
            }
        }
    }
}
