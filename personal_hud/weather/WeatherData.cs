using Microsoft.Graphics.Canvas.UI.Xaml;
using Newtonsoft.Json;
using personal_hud.current_weather;
using personal_hud.forecast;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace personal_hud {
    class WeatherData {
        public Forecast10Day Forecast { get; set; }
        public CurrentWeather Current { get; set; }

        public async void Refresh() {
            Forecast10Day f = await Forecast10Day.Refresh();
            if (f != null) { Forecast = f; }

            CurrentWeather c = await CurrentWeather.Refresh();
            if (c != null) { Current = c; }
        }

        public static async Task<WeatherData> Create() {
            WeatherData w = new WeatherData();
            w.Forecast = await Forecast10Day.Refresh();
            w.Current = await CurrentWeather.Refresh();
            return w;
        }

        public async Task Update(CanvasAnimatedUpdateEventArgs args) {
            Forecast = await Forecast10Day.Refresh();
            Current = await CurrentWeather.Refresh();
        }
    }
}
