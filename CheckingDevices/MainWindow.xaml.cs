using CheckingDevices.DataBase;
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

namespace CheckingDevices
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void txtBxSearch_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void exportExcel(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click_exit(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_Grid_Update_Click(object sender, RoutedEventArgs e)
        {

        }

        private void importExcel(object sender, RoutedEventArgs e)
        {

        }

        private void dataGridALLAthlets_LoadingRow(object sender, DataGridRowEventArgs e)
        {

        }

        private void dataGridALLAthlets_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (DeviceContext db = new DeviceContext())
            {
                var device = db.Device.ToList();

                dataGridALLDevice.ItemsSource = device;
                labelTotal.Content = device.Count;
            }   
        }
    }
}
