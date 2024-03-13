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

namespace Timer
{
    /// <summary>
    /// Логика взаимодействия для AddTimer.xaml
    /// </summary>
    public partial class AddTimer : Window
    {      
        public Dictionary<string, DateTime> timerList;

        public AddTimer()
        {
            InitializeComponent();  
            
            timerList = new Dictionary<string, DateTime>();
        }

        private void bt_cancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void bt_addTimer_Click(object sender, RoutedEventArgs e)
        {           
            DateTime? selectDate = cal_timerCalendar.SelectedDate;
            timerList.Add(tb_timerName.Text, new DateTime(selectDate.Value.Year, selectDate.Value.Month, selectDate.Value.Day, Convert.ToInt32(tb_timerHour.Text), Convert.ToInt32(tb_timerMinute.Text), Convert.ToInt32(tb_timerSecond.Text)));
            this.DialogResult = true;
        }
    }
}
