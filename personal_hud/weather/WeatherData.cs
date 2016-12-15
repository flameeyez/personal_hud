using Microsoft.Graphics.Canvas.UI.Xaml;
using Newtonsoft.Json;
using personal_hud.current_weather;
using personal_hud.forecast;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace personal_hud {
    static class WeatherData {
        private static double _weatherDataLastRefreshMilliseconds;
        private static string Updates = string.Empty;
        // this is the last time the SOURCE (wunderground) updated its data; it won't necessarily change with each Refresh() call
        public static DateTime LastUpdate;

        public static Forecast10Day Forecast { get; set; }
        public static CurrentWeather Current { get; set; }

        public static async void Refresh() {
            Forecast10Day f = await Forecast10Day.Refresh();
            if (f != null) { Forecast = f; }
            CurrentWeather c = await CurrentWeather.Refresh();
            if (c != null) { Current = c; }
        }

        public static async Task Create() {
            Forecast = await Forecast10Day.Refresh();
            Current = await CurrentWeather.Refresh();
            LastUpdate = DateTime.Parse(Current.Current_Observation.Observation_Time_RFC822);
        }

        public static async Task Update(CanvasAnimatedUpdateEventArgs args) {
            _weatherDataLastRefreshMilliseconds += args.Timing.ElapsedTime.TotalMilliseconds;

            if (_weatherDataLastRefreshMilliseconds >= Statics._weatherDataRefreshThreshold) {
                _weatherDataLastRefreshMilliseconds = 0;

                Forecast10Day f = await Forecast10Day.Refresh();
                CurrentWeather c = await CurrentWeather.Refresh();

                // bail if refreshing fails for whatever reason (bad HTTP call, exception during deserialization, etc.)
                // try again at next refresh
                // TODO: investigate why JSON deserializer occasionally returns null values; add debug info to WeatherData
                if (!f.IsValid) { return; }
                if (!c.IsValid) { return; }

                Forecast = f;
                Current = c;
                LastUpdate = DateTime.Parse(Current.Current_Observation.Observation_Time_RFC822);
                lock (Debug.Lock) { Updates += Current.Current_Observation.Observation_Time + "\r\n"; }
            }
        }

        public static string DebugString {
            get {
                string str = string.Empty;
                lock (Debug.Lock) { str = Updates + "\r\n" + ((int)_weatherDataLastRefreshMilliseconds).ToString() + "\r\n" + Statics._weatherDataRefreshThreshold.ToString(); }
                return str;
            }
        }
    }
}
