using Microsoft.Graphics.Canvas.UI;
using Microsoft.Graphics.Canvas.UI.Xaml;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace personal_hud
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private string strJsonUrlRedmond = "http://api.wunderground.com/api/023422a3f5a8324b/conditions/q/WA/Redmond.json";
        private string strTempResponse = "{  \"response\": {  \"version\":\"0.1\",  \"termsofService\":\"http://www.wunderground.com/weather/api/d/terms.html\",  \"features\": {  \"conditions\": 1  }	}  ,	\"current_observation\": {		\"image\": {		\"url\":\"http://icons.wxug.com/graphics/wu2/logo_130x80.png\",		\"title\":\"Weather Underground\",		\"link\":\"http://www.wunderground.com\"		},		\"display_location\": {		\"full\":\"Redmond, WA\",		\"city\":\"Redmond\",		\"state\":\"WA\",		\"state_name\":\"Washington\",		\"country\":\"US\",		\"country_iso3166\":\"US\",		\"zip\":\"98052\",		\"magic\":\"1\",		\"wmo\":\"99999\",		\"latitude\":\"47.68000031\",		\"longitude\":\"-122.12000275\",		\"elevation\":\"33.2\"		},		\"observation_location\": {		\"full\":\"Education Hill, Redmond, Washington\",		\"city\":\"Education Hill, Redmond\",		\"state\":\"Washington\",		\"country\":\"US\",		\"country_iso3166\":\"US\",		\"latitude\":\"47.686687\",		\"longitude\":\"-122.105721\",		\"elevation\":\"416 ft\"		},		\"estimated\": {		},		\"station_id\":\"KWAREDMO124\",		\"observation_time\":\"Last Updated on October 31, 3:05 PM PDT\",		\"observation_time_rfc822\":\"Mon, 31 Oct 2016 15:05:14 -0700\",		\"observation_epoch\":\"1477951514\",		\"local_time_rfc822\":\"Mon, 31 Oct 2016 15:49:03 -0700\",		\"local_epoch\":\"1477954143\",		\"local_tz_short\":\"PDT\",		\"local_tz_long\":\"America/Los_Angeles\",		\"local_tz_offset\":\"-0700\",		\"weather\":\"Overcast\",		\"temperature_string\":\"52.3 F (11.3 C)\",		\"temp_f\":52.3,		\"temp_c\":11.3,		\"relative_humidity\":\"97%\",		\"wind_string\":\"From the NNW at 1.9 MPH Gusting to 6.2 MPH\",		\"wind_dir\":\"NNW\",		\"wind_degrees\":345,		\"wind_mph\":1.9,		\"wind_gust_mph\":\"6.2\",		\"wind_kph\":3.1,		\"wind_gust_kph\":\"10.0\",		\"pressure_mb\":\"1010\",		\"pressure_in\":\"29.82\",		\"pressure_trend\":\"+\",		\"dewpoint_string\":\"52 F (11 C)\",		\"dewpoint_f\":52,		\"dewpoint_c\":11,		\"heat_index_string\":\"NA\",		\"heat_index_f\":\"NA\",		\"heat_index_c\":\"NA\",		\"windchill_string\":\"NA\",		\"windchill_f\":\"NA\",		\"windchill_c\":\"NA\",		\"feelslike_string\":\"52.3 F (11.3 C)\",		\"feelslike_f\":\"52.3\",		\"feelslike_c\":\"11.3\",		\"visibility_mi\":\"10.0\",		\"visibility_km\":\"16.1\",		\"solarradiation\":\"--\",		\"UV\":\"1\",\"precip_1hr_string\":\"-999.00 in ( 0 mm)\",		\"precip_1hr_in\":\"-999.00\",		\"precip_1hr_metric\":\" 0\",		\"precip_today_string\":\"0.57 in (14 mm)\",		\"precip_today_in\":\"0.57\",		\"precip_today_metric\":\"14\",		\"icon\":\"cloudy\",		\"icon_url\":\"http://icons.wxug.com/i/c/k/cloudy.gif\",		\"forecast_url\":\"http://www.wunderground.com/US/WA/Redmond.html\",		\"history_url\":\"http://www.wunderground.com/weatherstation/WXDailyHistory.asp?ID=KWAREDMO124\",		\"ob_url\":\"http://www.wunderground.com/cgi-bin/findweather/getForecast?query=47.686687,-122.105721\",		\"nowcast\":\"\"	}}";
        WeatherData data;
        List<Panel> Panels = new List<Panel>();

        int x = 0;
        int y = 0;

        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void canvasMain_Draw(ICanvasAnimatedControl sender, CanvasAnimatedDrawEventArgs args) {
            foreach(Panel panel in Panels) {
                panel.Draw(args, panel.HitTest(x, y));
            }
            
            args.DrawingSession.DrawText(x.ToString() + ", " + y.ToString(), new Vector2(1500, 10), Colors.White);
        }

        private void canvasMain_Update(ICanvasAnimatedControl sender, CanvasAnimatedUpdateEventArgs args) {

        }

        private void canvasMain_CreateResources(CanvasAnimatedControl sender, CanvasCreateResourcesEventArgs args) {
            dynamic stuff = JsonConvert.DeserializeObject(strTempResponse);

            data = new WeatherData();
            data.DisplayLocationFull = stuff.current_observation.display_location.full;
            data.DisplayLocationCity = stuff.current_observation.display_location.city;
            data.DisplayLocationStateAbbr = stuff.current_observation.display_location.state;
            data.DisplayLocationStateFull = stuff.current_observation.display_location.state_name;
            data.DisplayLocationCountry = stuff.current_observation.display_location.country;
            data.DisplayLocationZip = stuff.current_observation.display_location.zip;
            data.DisplayLocationLatitude = stuff.current_observation.display_location.latitude;
            data.DisplayLocationLongitude = stuff.current_observation.display_location.longitude;
            data.DisplayLocationElevation = stuff.current_observation.display_location.elevation;

            data.ObservationLocationFull = stuff.current_observation.observation_location.full;
            data.ObservationLocationCity = stuff.current_observation.observation_location.city;
            data.ObservationLocationLatitude = stuff.current_observation.observation_location.latitude;
            data.ObservationLocationLongitude = stuff.current_observation.observation_location.longitude;
            data.ObservationLocationElevation = stuff.current_observation.observation_location.elevation;

            data.ObservationTime = stuff.current_observation.observation_time;
            data.Weather = stuff.current_observation.weather;
            data.TemperatureFull = stuff.current_observation.temperature_string;
            data.TemperatureFahrenheit = stuff.current_observation.temp_f;
            data.TemperatureCelsius = stuff.current_observation.temp_c;
            data.RelativeHumidity = stuff.current_observation.relative_humidity;
            data.WindFull = stuff.current_observation.wind_string;
            data.WindDirection = stuff.current_observation.wind_dir;
            data.WindDegrees = stuff.current_observation.wind_degrees;
            data.WindMPH = stuff.current_observation.wind_mph;
            data.WindGustMPH = stuff.current_observation.wind_gust_mph;
            data.WindKPH = stuff.current_observation.wind_kph;
            data.WindGustKPH = stuff.current_observation.wind_gust_kph;
            data.PressureMB = stuff.current_observation.pressure_mb;
            data.PressureInches = stuff.current_observation.pressure_in;
            data.DewpointFull = stuff.current_observation.dewpoint_string;
            data.DewpointFahrenheit = stuff.current_observation.dewpoint_f;
            data.DewpointCelsius = stuff.current_observation.dewpoint_c;
            data.HeatIndexFull = stuff.current_observation.heat_index_string;
            data.HeatIndexFahrenheit = stuff.current_observation.heat_index_f;
            data.HeatIndexCelsius = stuff.current_observation.heat_index_c;
            data.WindchillFull = stuff.current_observation.windchill_string;
            data.WindchillFahrenheit = stuff.current_observation.windchill_f;
            data.WindchillCelsius = stuff.current_observation.windchill_c;
            data.FeelsLikeFull = stuff.current_observation.feelslike_string;
            data.FeelsLikeFahrenheit = stuff.current_observation.feelslike_f;
            data.FeelsLikeCelsius = stuff.current_observation.feelslike_c;
            data.VisibilityMiles = stuff.current_observation.visibility_mi;
            data.VisibilityKilometers = stuff.current_observation.visibility_km;
            data.UVIndex = stuff.current_observation.uv;
            data.PrecipitationOneHourFull = stuff.current_observation.precip_1hr_string;
            data.PrecipitationOneHourInches = stuff.current_observation.precip_1hr_in;
            data.PrecipitationOneHourMetric = stuff.current_observation.precip_1hr_metric;
            data.PrecipitationTodayFull = stuff.current_observation.precip_today_string;
            data.PrecipitationTodayInches = stuff.current_observation.precip_today_in;
            data.PrecipitationTodayMetric = stuff.current_observation.precip_today_metric;
            data.WeatherIconString = stuff.current_observation.icon;
            data.WeatherIconURL = stuff.current_observation.icon_url;
            data.ForecastURL = stuff.current_observation.forecast_url;
            data.HistoryURL = stuff.current_observation.history_url;

            Panel p1 = new Panel(canvasMain.Device, new Vector2(100, 100), 500, 300, "Test panel 1", Colors.Blue);
            p1.Strings.Add("test string 1");
            p1.Strings.Add("test string 2");
            Panels.Add(p1);

            Panel p2 = new Panel(canvasMain.Device, new Vector2(500, 500), 300, 200, "Test panel 2", Colors.Red);
            p2.Strings.Add("test string 3");
            p2.Strings.Add("test string 4");
            Panels.Add(p2);
        }

        private void canvasMain_PointerMoved(object sender, PointerRoutedEventArgs e) {
            PointerPoint p = e.GetCurrentPoint(canvasMain);
            x = (int)p.Position.X;
            y = (int)p.Position.Y;
        }

        private void canvasMain_PointerPressed(object sender, PointerRoutedEventArgs e) {

        }

        private void canvasMain_PointerReleased(object sender, PointerRoutedEventArgs e) {

        }
    }
}
