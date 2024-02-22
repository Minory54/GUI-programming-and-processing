using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace N5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        System.Windows.Threading.DispatcherTimer Timer;
        DateTime dateTime = new DateTime();

        int time_count = 0;

        public MainWindow()
        {
            InitializeComponent();

            Timer = new System.Windows.Threading.DispatcherTimer();
            Timer.Tick += new EventHandler(dispatcherTimer_Tick);
            Timer.Interval = new TimeSpan(0, 0, 1);
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e) //Обновляет Label
        {
            dateTime = dateTime.AddSeconds(1);
            lb_timer.Content = $"{dateTime.ToString("HH:mm:ss")}";
        }

        private void btn_start_Click(object sender, RoutedEventArgs e)
        {
            Timer.Start();
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            time_count += 1;

            if (cb_format.IsChecked == true)
            {
                lb_time.Items.Add($"Время {time_count}: {dateTime.ToString("HH:mm:ss")}");
            }
            else 
            { 
                lb_time.Items.Add($"Время {time_count}: {dateTime.Second} сек");
            }                     
        }

        private void btn_stop_Click(object sender, RoutedEventArgs e)
        {
            Timer.Stop();
            dateTime = new DateTime();
            time_count = 0;
            lb_timer.Content = $"{dateTime.ToString("HH:mm:ss")}";
        }
    }
}
