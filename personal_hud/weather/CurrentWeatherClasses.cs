using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace personal_hud.current_weather {
    public class Features {
        public int Conditions { get; set; }
    }

    public class Response {
        public string Version { get; set; }
        public string TermsOfService { get; set; }
        public Features Features { get; set; }
    }

    public class Image {
        public string URL { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
    }

    public class DisplayLocation {
        public string Full { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string State_Name { get; set; }
        public string Country { get; set; }
        public string Country_ISO3166 { get; set; }
        public string Zip { get; set; }
        public string Magic { get; set; }
        public string WMO { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Elevation { get; set; }
    }

    public class ObservationLocation {
        public string Full { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Country_ISO3166 { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Elevation { get; set; }
    }

    public class Estimated {
    }

    public class CurrentObservation {
        public Image Image { get; set; }
        public DisplayLocation Display_Location { get; set; }
        public ObservationLocation Observation_Location { get; set; }
        public Estimated Estimated { get; set; }
        public string Station_ID { get; set; }
        public string Observation_Time { get; set; }
        public string Observation_Time_RFC822 { get; set; }
        public string Observation_Epoch { get; set; }
        public string Local_Time_RFC822 { get; set; }
        public string Local_Epoch { get; set; }
        public string Local_TZ_Short { get; set; }
        public string Local_TZ_Long { get; set; }
        public string Local_TZ_Offset { get; set; }
        public string Weather { get; set; }
        public string Temperature_String { get; set; }
        public double Temp_F { get; set; }
        public double Temp_C { get; set; }
        public string Relative_Humidity { get; set; }
        public string Wind_String { get; set; }
        public string Wind_Dir { get; set; }
        public int Wind_Degrees { get; set; }
        public double Wind_MPH { get; set; }
        public string Wind_Gust_MPH { get; set; }
        public double Wind_KPH { get; set; }
        public string Wind_Gust_KPH { get; set; }
        public string Pressure_MB { get; set; }
        public string Pressure_In { get; set; }
        public string Pressure_Trend { get; set; }
        public string Dewpoint_String { get; set; }
        public int Dewpoint_F { get; set; }
        public int Dewpoint_C { get; set; }
        public string Heat_Index_String { get; set; }
        public string Heat_Index_F { get; set; }
        public string Heat_Index_C { get; set; }
        public string Windchill_String { get; set; }
        public string Windchill_F { get; set; }
        public string Windchill_C { get; set; }
        public string FeelsLike_String { get; set; }
        public string FeelsLike_F { get; set; }
        public string FeelsLike_C { get; set; }
        public string Visibility_Mi { get; set; }
        public string Visibility_Km { get; set; }
        public string SolarRadiation { get; set; }
        public string UV { get; set; }
        public string Precip_1hr_String { get; set; }
        public string Precip_1hr_In { get; set; }
        public string Precip_1hr_Metric { get; set; }
        public string Precip_Today_String { get; set; }
        public string Precip_Today_In { get; set; }
        public string Precip_Today_Metric { get; set; }
        public string Icon { get; set; }
        public string Icon_URL { get; set; }
        public string Forecast_URL { get; set; }
        public string History_URL { get; set; }
        public string Ob_URL { get; set; }
        public string Nowcast { get; set; }

        public bool IsValid { get { return Image != null && Display_Location != null && Observation_Location != null; } }
    }

    public class CurrentWeather {
        public Response Response { get; set; }
        public CurrentObservation Current_Observation { get; set; }

        public static async Task<CurrentWeather> Refresh() {
            try {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync("http://api.wunderground.com/api/023422a3f5a8324b/conditions/q/WA/Redmond.json");
                if (response.IsSuccessStatusCode) {
                    CurrentWeather c = JsonConvert.DeserializeObject<CurrentWeather>(response.Content.ReadAsStringAsync().Result);
                    c.Current_Observation.Observation_Time = c.Current_Observation.Observation_Time.Replace("LANG.kLang.DateTime.", string.Empty);
                    return c;
                }
                else {
                    return null;
                }
            }
            catch {
                return null;
            }
        }

        public bool IsValid { get { return Current_Observation != null && Current_Observation.IsValid; } }
    }
}