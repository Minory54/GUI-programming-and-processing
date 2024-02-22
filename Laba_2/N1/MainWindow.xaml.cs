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

namespace N1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        double readDouble (TextBox textBox)
        {
            double doubleNum;
            string tbNum = textBox.Text.Replace('.',',');

            while (!(double.TryParse(tbNum, out doubleNum)))
            {
                MessageBox.Show("Неверно задано число.", "Ошибка!");
                textBox.BorderBrush = Brushes.Red;
                return 0;
            }
            textBox.BorderBrush = Brushes.Green;

            return doubleNum;
        }

        private void btn_sum_Click(object sender, RoutedEventArgs e)
        {
            double firstNumA = readDouble(tb_firstNumA);
            double secondNumB = readDouble(tb_secondNumB);

            double result = firstNumA + secondNumB;

            tb_result.Text = result.ToString();
        }

        private void btn_sub_Click(object sender, RoutedEventArgs e)
        {
            double firstNumA = readDouble(tb_firstNumA);
            double secondNumB = readDouble(tb_secondNumB);

            double result = firstNumA - secondNumB;

            tb_result.Text = result.ToString();
        }

        private void btn_mul_Click(object sender, RoutedEventArgs e)
        {
            double firstNumA = readDouble(tb_firstNumA);
            double secondNumB = readDouble(tb_secondNumB);

            double result = firstNumA * secondNumB;

            tb_result.Text = result.ToString();
        }

        private void btn_div_Click(object sender, RoutedEventArgs e)
        {
            double firstNumA = readDouble(tb_firstNumA);
            double secondNumB = readDouble(tb_secondNumB);

            double result = firstNumA / secondNumB;

            tb_result.Text = result.ToString();
        }
    }
}
