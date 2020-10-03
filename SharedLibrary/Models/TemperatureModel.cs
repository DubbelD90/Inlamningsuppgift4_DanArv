using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Devices;
using SharedLibrary.Services;

namespace SharedLibrary.Models
{
    public class TemperatureModel
    {
        public double Temperature { get; set; }
        public double Humidity { get; set; }
    }
}
