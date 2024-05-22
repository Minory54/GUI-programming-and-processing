using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
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
        private int ButtonSize = 40;

        private int Mines = 50;
        private int FieldSizeX = 10;
        private int FieldSizeY = 10;

        private int WinScore;

        private readonly BitmapImage MineImg = new BitmapImage(new Uri(@"pack://application:,,,/assets/mine.png",
                                            UriKind.Absolute));
        private readonly BitmapImage FlagImg = new BitmapImage(new Uri(@"pack://application:,,,/assets/flag.png",
                                                                        UriKind.Absolute));

        MineGenerator MineGenerator;

        MediaPlayer Correct = new MediaPlayer();
        MediaPlayer Explode = new MediaPlayer();

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
            Correct.Open(new Uri("pack://siteoforigin:,,,/assets/correct.mp3"));
            Explode.Open(new Uri("pack://siteoforigin:,,,/assets/explode.mp3"));
            Explode.Volume = 0.01f;
        }

        private void InitializeGame()
        {
            InitializeComponent();

            WinScore = (FieldSizeX * FieldSizeY * 100) - (Mines * 100);

            Score.Text = "0";
            MineGenerator = new MineGenerator();

            MainFrame.Rows = FieldSizeX;
            MainFrame.Columns = FieldSizeY;

            MainFrame.Height = MainFrame.Rows * (ButtonSize + 4);
            MainFrame.Width = MainFrame.Columns * (ButtonSize + 4);

            MainFrame.Margin = new Thickness(5);

            Field = new int[MainFrame.Rows, MainFrame.Columns];

            for (int i = 0; i < FieldSizeX; i++)
            {
                for (int j = 0; j < FieldSizeY; j++)
                {
                    Field[i, j] = 0;
                }
            }

            MineGenerator.plantMines(Mines, FieldSizeX, FieldSizeY, Field);

            MainFrame.Children.Clear();

            for (int i = 0; i < FieldSizeX; i++)
            {
                for (int j = 0; j < FieldSizeY; j++)
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

        private void btn_StartOwnGame(object sender, EventArgs e)
        {
            try
            {
                Mines = Convert.ToInt32(OwnMines.Text);
                FieldSizeX = Convert.ToInt32(OwnX.Text);
                FieldSizeY = Convert.ToInt32(OwnY.Text);

                if (Mines == 0 || FieldSizeX == 0 || FieldSizeY == 0)
                {
                    MessageBox.Show("Ошибка ввода данных", "Ситуация...");
                    Mines = 50; FieldSizeX = 10; FieldSizeY = 10;
                }
            }
            catch
            {
                MessageBox.Show("Ошибка ввода данных", "Ситуация...");
            }
            InitializeGame();
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
                        Correct.Play();
                        Correct.Position = TimeSpan.Zero;

                        Score.Text = Convert.ToString(Convert.ToInt32(Score.Text) + 100);

                        if (Convert.ToInt32(Score.Text) == WinScore)
                        {
                            MessageBox.Show($"Вы победили!!!!!!! Красивая игра!!!!!!!!\nТвой счёт: {Score.Text}");
                            //вот сюда запись в бд
                        }

                        
                    }
                    else
                    {
                        Explode.Play();
                        Explode.Position = TimeSpan.Zero;

                        MessageBox.Show("Не знаю, попробуй в солдатиков поиграть, " +
                                        $"а не в сапёра, там не нужно столько мозгов\nТвой счёт: {Score.Text}");
                        Score.Text = "0";
                        InitializeGame();

                        //вот сюда запись в бд
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
