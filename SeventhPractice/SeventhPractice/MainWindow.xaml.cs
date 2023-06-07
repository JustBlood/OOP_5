using SixthPractice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

namespace SeventhPractice
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        private Dictionary<TrafficLightState, Border[]> lightToBorder = new Dictionary<TrafficLightState, Border[]>();
        private Dictionary<Border, Color> borderColor = new Dictionary<Border, Color>();
        private TrafficLight trafficLight;

        public void On_ColorChanged(object sender, ColorChangedArgs args)
        {
            TrafficLightState prevColor = args.Color - 1;
            if (args.Color == 0) { prevColor = TrafficLightState.Yellow; }
            resetColors(lightToBorder[prevColor]);
            foreach (var border in lightToBorder[args.Color])
            {
                border.Background = new SolidColorBrush(borderColor[border]);
            }
        }

        private void resetColors(params Border[] borderLights)
        {
            foreach (var border in borderLights)
            {
                border.Background = new SolidColorBrush(Colors.Black);
            }
        }

        public MainWindow()
        {
            InitializeComponent();

            red.Background = new SolidColorBrush(Colors.Black);
            yellow.Background = new SolidColorBrush(Colors.Black);
            green.Background = new SolidColorBrush(Colors.Black);
            lightToBorder[TrafficLightState.Red] = new Border[] { red };
            lightToBorder[TrafficLightState.Green] = new Border[] { green };
            lightToBorder[TrafficLightState.RedYellow] = new Border[] { red, yellow };
            lightToBorder[TrafficLightState.Yellow] = new Border[] { yellow };
            borderColor[red] = Colors.Red;
            borderColor[green] = Color.FromArgb(100, 77, 181, 74);
            borderColor[yellow] = Colors.Yellow;
            trafficLight = new TrafficLight();
            trafficLight.ColorChanged += On_ColorChanged;

            new ThirdTask().Show();
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            trafficLight.Start();
        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            trafficLight.Stop();
        }
    }
}
