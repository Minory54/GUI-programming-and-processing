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

namespace N3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            lb_planets.Items.Add("Меркурий");
            lb_planets.Items.Add("Венера");
            lb_planets.Items.Add("Сатурн");

        }

        private void lb_planets_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            l_namePlanet.Content = lb_planets.SelectedValue as string;        
            switch (lb_planets.SelectedIndex)
            {
                case 0:
                    {
                        l_descriptionPlanet.Text = "Наименьшая планета Солнечной системы и самая близкая к Солнцу.";
                        break;
                    }
                case 1:
                    {
                        l_descriptionPlanet.Text = "Третий по яркости объект на небе Земли после Солнца и Луны.";
                        break;
                    }
                case 2:
                    {
                        l_descriptionPlanet.Text = "Шестая планета по удалённости от Солнца и вторая по размерам планета в Солнечной системе после Юпитера..";
                        break;
                    }
            }
        }
    }
}
