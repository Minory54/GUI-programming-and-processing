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
            dateTime = dateTime.AddSeconds(-1);           
        }

        private void mi_addTimer_Click(object sender, RoutedEventArgs e)
        {
            AddTimer addTimer = new AddTimer();
            if (addTimer.ShowDialog() == true) 
            {
                foreach (var timer in addTimer.timerList) 
                {
                    lb_timerList.Items.Add($" \"{timer.Key}\": {timer.Value}");                   
                }
            }            
        }

        private void mi_editTimer_Click(object sender, RoutedEventArgs e)
        {
            
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
                lb_timerList.Items.Add($"{ textFromFile}");
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

        }
    }
}
