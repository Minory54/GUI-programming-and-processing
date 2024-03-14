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

        public AddTimer()
        {
            InitializeComponent(); 
            
            MainWindow mainWindow = new MainWindow();
            if (mainWindow.editNameTimer != null )
            {
                tb_timerName.Text = mainWindow.editNameTimer.ToString();
                tb_timerHour.Text = mainWindow.editTimerDateTime.Hour.ToString();
                tb_timerMinute.Text = mainWindow.editTimerDateTime.Minute.ToString();
                tb_timerSecond.Text = mainWindow.editTimerDateTime.Second.ToString();
            }
        }

        private void bt_cancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void bt_addTimer_Click(object sender, RoutedEventArgs e)
        {           
            DateTime? selectDate = cal_timerCalendar.SelectedDate;
            newTimerName = tb_timerName.Text;
            newTimerDateTime = new DateTime(selectDate.Value.Year, selectDate.Value.Month, selectDate.Value.Day, Convert.ToInt32(tb_timerHour.Text), Convert.ToInt32(tb_timerMinute.Text), Convert.ToInt32(tb_timerSecond.Text));
            this.DialogResult = true;
        }
    }
}
