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
        // this is the last time the SOURCE (wunderground) updated its data; it won't necessarily change with each Refresh() call
        public static DateTime LastUpdate;
        public static string TimeSinceLastDataCheck { get; set; }
        public static string TimeUntilNextDataCheck { get; set; }
        public static string DebugString { get; set; }

        private static double _weatherDataLastRefreshMilliseconds = 0.0;

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

            int seconds = (int)(_weatherDataLastRefreshMilliseconds / 1000) % 60;
            int minutes = (int)((_weatherDataLastRefreshMilliseconds / (1000 * 60)) % 60);
            int hours = (int)((_weatherDataLastRefreshMilliseconds / (1000 * 60 * 60)) % 24);
            string strSeconds = seconds < 10 ? "0" + seconds.ToString() : seconds.ToString();
            string strMinutes = minutes < 10 ? "0" + minutes.ToString() : minutes.ToString();
            string strHours = hours.ToString();
            TimeSinceLastDataCheck = strHours + ":" + strMinutes + "." + strSeconds;

            double millisecondsToNextDataCheck = Statics._weatherDataRefreshThreshold - _weatherDataLastRefreshMilliseconds + 1000;
            if(millisecondsToNextDataCheck < 0) { millisecondsToNextDataCheck = 0; }
            int secondsRemaining = (int)(millisecondsToNextDataCheck / 1000) % 60;
            int minutesRemaining = (int)((millisecondsToNextDataCheck / (1000 * 60)) % 60);
            int hoursRemaining = (int)((millisecondsToNextDataCheck / (1000 * 60 * 60)) % 24);
            string strSecondsRemaining = secondsRemaining < 10 ? "0" + secondsRemaining.ToString() : secondsRemaining.ToString();
            string strMinutesRemaining = minutesRemaining < 10 ? "0" + minutesRemaining.ToString() : minutesRemaining.ToString();
            string strHoursRemaining = hoursRemaining.ToString();
            TimeUntilNextDataCheck = strHoursRemaining + ":" + strMinutesRemaining + "." + strSecondsRemaining;

            if (_weatherDataLastRefreshMilliseconds >= Statics._weatherDataRefreshThreshold) {
                _weatherDataLastRefreshMilliseconds = 0;

                Forecast10Day f = await Forecast10Day.Refresh();
                CurrentWeather c = await CurrentWeather.Refresh();

                // bail if refreshing fails for whatever reason (bad HTTP call, exception during deserialization, etc.)
                // try again at next refresh
                // TODO: investigate why JSON deserializer occasionally returns null values; add debug info to WeatherData
                if (f == null || !f.IsValid) { return; }
                if (c == null || !c.IsValid) { return; }

                Forecast = f;
                Current = c;
                LastUpdate = DateTime.Parse(Current.Current_Observation.Observation_Time_RFC822);
                lock (Debug.Lock) { DebugString = DateTime.Now.ToString() + ": " + Current.Current_Observation.Observation_Time + "\r\n"; }
            }
        }
    }
}
