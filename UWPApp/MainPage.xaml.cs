using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using SharedLibrary.Models;
using SharedLibrary.Services;
using Microsoft.Azure.Devices.Client;
using Windows.Data.Json;
using System.Threading.Tasks;
using System.Text;
using System.Collections.ObjectModel;

namespace UWPApp
{
    public sealed partial class MainPage : Page
    {
        private static readonly string _conn = "HostName=ec-win20-danarv.azure-devices.net;DeviceId=consoleApp;SharedAccessKey=TBEL/rmoCXi04vvrsMhHzgcjuZe4cx2PZGes3BaHEdo=";
        private static readonly DeviceClient deviceClient =
            DeviceClient.CreateFromConnectionString(_conn, TransportType.Mqtt);

        /*
        public static async Task RecieveMessageAsync(DeviceClient deviceClient)
        {
             while (true)
             {
                var payload = await deviceClient.ReceiveAsync();

                if (payload == null)
                {
                    continue;
                }

                //Console.WriteLine($"Message Recieved :{Encoding.UTF8.GetString(payload.GetBytes())}");

                await deviceClient.CompleteAsync(payload);
             }
        }
        */

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void btnMessages_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TemperatureService.SendMessageAsync(deviceClient).GetAwaiter();
            }

            catch { }
            finally
            {
                //lvRecieve.Item.Add();
                //lvRecieve.Text = $"The temperature is {temperatureModel.Temperature}";
            }
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                lvRecieve.Items.Remove(lvRecieve.Items[lvRecieve.SelectedIndex]);
            }
            catch { }
        }
    }
}
