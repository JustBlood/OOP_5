using System;
using System.ComponentModel;
using System.Threading;
using System.Windows;
using System.Windows.Threading;
using Controllers;
using MeasuringDevice;

namespace FifthPractice
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainViewModel ViewModel { get; set; }
        DispatcherTimer Timer { get; set; }
        public MainWindow()
        {
            InitializeComponent();

            ViewModel = new MainViewModel();

            startMeasurementsButton.Visibility = Visibility.Hidden;
            stopMeasurementsButton.Visibility = Visibility.Hidden;
            getMetric.Visibility = Visibility.Hidden;
            getImperial.Visibility = Visibility.Hidden;
            getRecent.Visibility = Visibility.Hidden;
            Timer = new DispatcherTimer();
            Timer.Tick += OnTick;
            Timer.Interval = new TimeSpan(0, 0, 0, 1);
            Timer.Start();
        }

        private void OnTick(object sender, EventArgs e)
        {
            data.Items.Refresh();
            
        }

        private void CreateController_Click(object sender, RoutedEventArgs e)
        {
            Units unitsToUse;
            DeviceType selectedDeviceType;
            if (deviceUnits.SelectedItem == null
                || deviceType.SelectedItem == null)
            {
                MessageBox.Show("Введитетип девайса и его систему измерения.");
                return;
            }
            if (!Enum.TryParse(deviceUnits.SelectedItem?.ToString(), out unitsToUse)
                || !Enum.TryParse(deviceType.SelectedItem?.ToString(), out selectedDeviceType))
            {
                MessageBox.Show("Невозможно создать контроллер.");
                return;
            }
            ViewModel.Controller = DeviceController.CreateController(selectedDeviceType, unitsToUse);
            startMeasurementsButton.Visibility = Visibility.Visible;
            stopMeasurementsButton.Visibility = Visibility.Visible;
            getMetric.Visibility = Visibility.Visible;
            getImperial.Visibility = Visibility.Visible;
            getRecent.Visibility = Visibility.Visible;
        }

        private void startMeasurementsButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.Controller.StartDevice();
            
            data.ItemsSource = ViewModel.Controller.Device.GetRawData();
            //var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(2) };
            //timer.Start();
            //timer.Tick += (sender, args) =>
            //{
            //    data.UpdateLayout();
            //};
        }

        private void stopMeasurementsButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.Controller.StopDevice();
            ViewModel.Measurements = ViewModel.Controller.Device.GetRawData();
        }

        private void getMetric_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBox.Show(ViewModel.Controller.TakeMeasurement(Units.Metric).ToString());
            } catch (Exception ex) { MessageBox.Show(ex.Message); }
                
        }

        private void getImperial_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBox.Show(ViewModel.Controller.TakeMeasurement(Units.Imperial).ToString());
            } catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void getRecent_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBox.Show(ViewModel.Controller.TakeMeasurement().ToString());
            } catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
