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

namespace Sapper
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly int ButtonSize = 25;

        public MainWindow()
        {
            InitializeGame();
        }

        private void InitializeGame()
        {
            InitializeComponent();

            ///
            /// Заполнение грида ячейками по заданным параметрам
            ///

            MainFrame.Rows = 10;
            MainFrame.Columns = 10;

            MainFrame.Height = MainFrame.Rows * (ButtonSize + 4);
            MainFrame.Width = MainFrame.Columns * (ButtonSize + 4);

            MainFrame.Margin = new Thickness(5);

            ///
            /// Делаем кнопочки во всех ячейках
            ///

            for (int i = 0; i < MainFrame.Rows * MainFrame.Columns; i++)
            {
                Button Btn = new Button();

                Btn.Tag = i;
                Btn.Width = Btn.Height = ButtonSize;
                Btn.Content = " ";
                Btn.Margin = new Thickness(2);
                Btn.PreviewMouseDown += Btn_OnClick;

                MainFrame.Children.Add(Btn);
            }
        }

        /// 
        /// AppLogic part. Init all events, prop and etc.
        /// 

        private void Btn_OnClick(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {

                return;
            }
            else if (e.RightButton == MouseButtonState.Pressed)
            {

                return;
            }
            else if (e.MiddleButton == MouseButtonState.Pressed)
            {

                return;
            }
        }



    }
}
