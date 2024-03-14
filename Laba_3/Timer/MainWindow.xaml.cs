using System;
using System.Collections.Generic;
using System.IO;
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

namespace Timer
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dictionary<string, DateTime> timerList = new Dictionary<string, DateTime>();
        DateTime dateTimeSelected = new DateTime();

        public string editNameTimer;
        public DateTime editTimerDateTime;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void mi_addTimer_Click(object sender, RoutedEventArgs e)
        {
            AddTimer addTimer = new AddTimer();
            if (addTimer.ShowDialog() == true) 
            {
                lb_timerList.Items.Add(addTimer.newTimerName);
                timerList.Add(addTimer.newTimerName, addTimer.newTimerDateTime);
            }            
        }

        private void mi_editTimer_Click(object sender, RoutedEventArgs e)
        {
            editNameTimer = (string)lb_timerList.SelectedValue;
            editTimerDateTime = timerList[editNameTimer];
            //timerList.Remove(editNameTimer);

            AddTimer addTimer = new AddTimer();
            if (addTimer.ShowDialog() == true)
            {
                lb_timerList.SelectedItem = addTimer.newTimerName;
                timerList.Add(addTimer.newTimerName, addTimer.newTimerDateTime);
            }
            
        }

        private void mi_delTimer_Click(object sender, RoutedEventArgs e)
        {
            lb_timerList.Items.Remove(lb_timerList.SelectedItem);
        }

        private void mi_openFile_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".txt";
            dlg.Filter = "Text documents (.txt)|*.txt";

            if (dlg.ShowDialog() == true)
            {
                FileStream fs = File.OpenRead(dlg.FileName);
                byte[] array = new byte[fs.Length];
                fs.Read(array, 0, array.Length);
                string textFromFile = System.Text.Encoding.UTF8.GetString(array);
                lb_timerList.Items.Add($"{textFromFile}");
            }
        }

        private void mi_saveFile_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.DefaultExt = ".txt";
            dlg.Filter = "Text documents (.txt)|*.txt";

            string text = Convert.ToString(lb_timerList.Items[0]);

            if (dlg.ShowDialog() == true)
            {
                using (FileStream fstream = new FileStream(dlg.FileName, FileMode.OpenOrCreate))
                {
                    byte[] array = System.Text.Encoding.UTF8.GetBytes(text);
                    fstream.Write(array, 0, array.Length);
                }
            }
        }

        private void lb_timerList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime dateTimeNow = DateTime.Now;            
            TimeSpan ts = dateTimeSelected - dateTimeNow;
            MessageBox.Show("Дни:" + ts.Days + " Время: " + ts.Hours + ":" + ts.Minutes + ":" + ts.Seconds, "Оставшееся время");           
        }
    }
}
