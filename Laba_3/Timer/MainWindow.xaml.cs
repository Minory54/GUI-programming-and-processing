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
using System.Xml.Linq;

namespace Timer
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dictionary<string, DateTime> timerList = new Dictionary<string, DateTime>();

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
                timerList.Add(addTimer.newTimerName, addTimer.newTimerDateTime);
                lb_timerList.Items.Add(addTimer.newTimerName);
            }
        }

        private void mi_editTimer_Click(object sender, RoutedEventArgs e)
        {
            if (lb_timerList.SelectedIndex != -1)
            {
                editNameTimer = (string)lb_timerList.SelectedValue;
                editTimerDateTime = timerList[editNameTimer];

                AddTimer addTimer = new AddTimer(editNameTimer, editTimerDateTime);
              
                if (addTimer.ShowDialog() == true)
                {
                    timerList.Remove(lb_timerList.Items[lb_timerList.SelectedIndex].ToString());
                    lb_timerList.Items.Remove(lb_timerList.SelectedItem);

                    lb_timerList.SelectedItem = null;

                    timerList.Add(addTimer.newTimerName, addTimer.newTimerDateTime);
                    lb_timerList.Items.Add(addTimer.newTimerName);
                }
            }

            //timerList.Remove(editNameTimer);

            //if (addTimer.ShowDialog() == true)
            //{
            //    lb_timerList.SelectedItem = addTimer.newTimerName;
            //    timerList.Add(addTimer.newTimerName, addTimer.newTimerDateTime);
            //}
        }

        private void mi_delTimer_Click(object sender, RoutedEventArgs e)
        {
            if (lb_timerList.SelectedIndex != -1)
            {
                timerList.Remove(lb_timerList.Items[lb_timerList.SelectedIndex].ToString());
                lb_timerList.Items.Remove(lb_timerList.SelectedItem);
            }
        }

        private void mi_openFile_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "Document";
            dlg.DefaultExt = ".txt";
            dlg.Filter = "Text documents (.txt)|*.txt";
            dlg.ShowDialog();
            string line;
            System.IO.StreamReader file = new System.IO.StreamReader($"{dlg.FileName}");
            while ((line = file.ReadLine()) != null)
            {
                if (timerList.ContainsKey(line.Split()[0]) == false)
                {
                    timerList.Add(line.Split()[0], Convert.ToDateTime(line.Split()[1] + " " + line.Split()[2]));
                    lb_timerList.Items.Add(line.Split()[0]);
                }
            }
        }

        private void mi_saveFile_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "Document";
            dlg.DefaultExt = ".txt";
            dlg.Filter = "Text documents (.txt)|*.txt";

            string[] lines = new string[lb_timerList.Items.Count];
            for (int i = 0; i < lines.Length; i++)
            {
                lines[i] = lb_timerList.Items[i].ToString();
            }

            if (dlg.ShowDialog() == true)
            {
                using (StreamWriter outputFile = new StreamWriter($"{dlg.FileName}"))
                {
                    foreach (string line in lines)
                        outputFile.WriteLine(line + " " + timerList[line].ToString());
                }
            }
        }

        private void lb_timerList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lb_timerList.SelectedIndex != -1)
            {
                TimeSpan ts = DateTime.Now - timerList[lb_timerList.Items[lb_timerList.SelectedIndex].ToString()];
                MessageBox.Show("Дни:" + (Math.Abs(ts.Days)).ToString() + " Время: " + (Math.Abs(ts.Hours)).ToString() + ":" + (Math.Abs(ts.Minutes)).ToString() + ":" + (Math.Abs(ts.Seconds)).ToString(), "Оставшееся время");
            }
        }
    }
}
