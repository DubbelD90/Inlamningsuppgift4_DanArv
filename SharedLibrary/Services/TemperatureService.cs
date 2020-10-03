using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Devices.Client;
using MAD = Microsoft.Azure.Devices;
using Newtonsoft.Json;
using SharedLibrary.Models;
using Windows.UI.Xaml.Controls;

namespace SharedLibrary.Services
{
    public class TemperatureService
    {
        public static readonly Random rnd = new Random();

        public static async Task SendMessageAsync(DeviceClient deviceClient)
        {
            while (true)
            {
                
                var data = new TemperatureModel
                {
                    Temperature = rnd.Next(10, 30),
                    Humidity = rnd.Next(30, 60)
                };
                
                
                var json = JsonConvert.SerializeObject(data);

                var payload = new Message(Encoding.UTF8.GetBytes(json));
                await deviceClient.SendEventAsync(payload);


                break;
            }
            
         
        }
    }
}
