using CycoPath.Models;
using System;

namespace CycoPath.DAL
{
    interface IWeatherGateway
    {
        Weather getParkWeather(String coordinates);
    }
}
