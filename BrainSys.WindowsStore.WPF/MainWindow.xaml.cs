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

namespace BrainSys.WindowsStore.WPF
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

        private async void GetInfoButton_Click(object sender, RoutedEventArgs e)
        {
            WindowsStoreApiConnector conn = new WindowsStoreApiConnector
                (this.ValueTenantId.Text, this.ValueClientId.Text, this.ValueClientSecret.Text);

            var request = new AppAcquisitionsRequest(this.ValueAppId.Text);
            request.StartDate = new DateTime(2015, 01, 01);
            request.OrderBy.Add(OrderBy.Date);
            request.Top = 10;
            var response = await conn.GetAppAcquisitionsAsync(request);
        }
    }
}