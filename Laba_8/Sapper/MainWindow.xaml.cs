using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml;

namespace Sapper
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly int ButtonSize = 40;

        private readonly int FieldSize = 10;

        private readonly int Mines = 50;

        private readonly BitmapImage MineImg = new BitmapImage(new Uri(@"pack://application:,,,/assets/mine.png",
                                            UriKind.Absolute));
        private readonly BitmapImage FlagImg = new BitmapImage(new Uri(@"pack://application:,,,/assets/flag.png",
                                                                        UriKind.Absolute));

        MineGenerator MineGenerator;

        private int[,] Field;

        public enum SapperImages
        {
            Mine,
            Flag,
            Numbers
        }

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

            Score.Text = "0";

            MineGenerator = new MineGenerator(ref Score);

            MainFrame.Rows = FieldSize;
            MainFrame.Columns = FieldSize;

            MainFrame.Height = MainFrame.Rows * (ButtonSize + 4);
            MainFrame.Width = MainFrame.Columns * (ButtonSize + 4);

            MainFrame.Margin = new Thickness(5);

            ///
            /// Делаем кнопочки во всех ячейках
            ///

            Field = new int[MainFrame.Rows, MainFrame.Columns];

            for (int i = 0; i < FieldSize; i++)
            {
                for (int j = 0; j < FieldSize; j++)
                {
                    Field[i, j] = 0;
                }
            }

            MineGenerator.plantMines(Mines, FieldSize, Field);

            for (int i = 0; i < FieldSize; i++)
            {
                for (int j = 0; j < FieldSize; j++)
                {
                    Button Btn = new Button();
                    Btn.Tag = Field[i, j];
                    Btn.Width = Btn.Height = ButtonSize;
                    Btn.Content = " ";
                    Btn.Margin = new Thickness(2);
                    Btn.PreviewMouseDown += Btn_OnClick;

                    MainFrame.Children.Add(Btn);
                }
            }
        }

        private void Btn_OnClick(object sender, MouseButtonEventArgs e)
        {
            if (sender is Button button)
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    switch ((int)button.Tag)
                    {
                        case 0:
                            button.Background = Brushes.White;
                            break;
                        case 1:
                            button = SetBtnContent(button);
                            break;
                        case 2:
                            button = SetBtnContent(button);
                            break;
                        case 3:
                            button = SetBtnContent(button);
                            break;
                        case 4:
                            button = SetBtnContent(button);
                            break;
                        case 5:
                            button = SetBtnContent(button);
                            break;
                        case 6:
                            button = SetBtnContent(button);
                            break;
                        case 7:
                            button = SetBtnContent(button);
                            break;
                        case 8:
                            button = SetBtnContent(button);
                            break;
                        case 9:
                            button.Content = SetBtnContent((SapperImages)0);
                            break;
                        default:
                            button.Background = Brushes.Red;
                            break;
                    }

                    if ((int)button.Tag != 9)
                    {
                        Score.Text = Convert.ToString(Convert.ToInt32(Score.Text) + 100);
                    }

                    return;
                }
                else if (e.RightButton == MouseButtonState.Pressed)
                {
                    button.Content = SetBtnContent((SapperImages)1);

                    return;
                }
                else if (e.MiddleButton == MouseButtonState.Pressed)
                {
                    return;
                }
            }
        }

        private Button SetBtnContent(Button button)
        {
            Button button1 = button;

            button1.Background = Brushes.White;
            button1.Foreground = Brushes.Red;
            button1.FontSize = 14;

            button.Content = button.Tag.ToString();

            return button1;
        }

        private StackPanel SetBtnContent(SapperImages imageType)
        {
            Image image = new Image();

            switch (imageType)
            {
                case SapperImages.Mine:
                    image.Source = MineImg;
                    break;
                case SapperImages.Flag:
                    image.Source = FlagImg;
                    break;
                default:
                    break;
            }
            image.Stretch = Stretch.Fill;

            StackPanel stackPanel = new StackPanel();
            stackPanel.Margin = new Thickness(1);
            stackPanel.Children.Add(image);

            return stackPanel;
        }
    }
}
