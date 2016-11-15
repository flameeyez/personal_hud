using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }

    public class CurrentWeather {
        public Response Response { get; set; }
        public CurrentObservation Current_Observation { get; set; }

        private static string strTempResponse = "{\"response\":{\"version\":\"0.1\",\"termsofService\":\"http://www.wunderground.com/weather/api/d/terms.html\",\"features\":{\"conditions\":1}},\"current_observation\":{\"image\":{\"url\":\"http://icons.wxug.com/graphics/wu2/logo_130x80.png\",\"title\":\"WeatherUnderground\",\"link\":\"http://www.wunderground.com\"},\"display_location\":{\"full\":\"Redmond,WA\",\"city\":\"Redmond\",\"state\":\"WA\",\"state_name\":\"Washington\",\"country\":\"US\",\"country_iso3166\":\"US\",\"zip\":\"98052\",\"magic\":\"1\",\"wmo\":\"99999\",\"latitude\":\"47.68000031\",\"longitude\":\"-122.12000275\",\"elevation\":\"33.2\"},\"observation_location\":{\"full\":\"EducationHill,Redmond,Washington\",\"city\":\"EducationHill,Redmond\",\"state\":\"Washington\",\"country\":\"US\",\"country_iso3166\":\"US\",\"latitude\":\"47.686687\",\"longitude\":\"-122.105721\",\"elevation\":\"416ft\"},\"estimated\":{},\"station_id\":\"KWAREDMO124\",\"observation_time\":\"LastUpdatedonOctober31,3:05PMPDT\",\"observation_time_rfc822\":\"Mon,31Oct201615:05:14-0700\",\"observation_epoch\":\"1477951514\",\"local_time_rfc822\":\"Mon,31Oct201615:49:03-0700\",\"local_epoch\":\"1477954143\",\"local_tz_short\":\"PDT\",\"local_tz_long\":\"America/Los_Angeles\",\"local_tz_offset\":\"-0700\",\"weather\":\"Overcast\",\"temperature_string\":\"52.3F(11.3C)\",\"temp_f\":52.3,\"temp_c\":11.3,\"relative_humidity\":\"97%\",\"wind_string\":\"FromtheNNWat1.9MPHGustingto6.2MPH\",\"wind_dir\":\"NNW\",\"wind_degrees\":345,\"wind_mph\":1.9,\"wind_gust_mph\":\"6.2\",\"wind_kph\":3.1,\"wind_gust_kph\":\"10.0\",\"pressure_mb\":\"1010\",\"pressure_in\":\"29.82\",\"pressure_trend\":\"+\",\"dewpoint_string\":\"52F(11C)\",\"dewpoint_f\":52,\"dewpoint_c\":11,\"heat_index_string\":\"NA\",\"heat_index_f\":\"NA\",\"heat_index_c\":\"NA\",\"windchill_string\":\"NA\",\"windchill_f\":\"NA\",\"windchill_c\":\"NA\",\"feelslike_string\":\"52.3F(11.3C)\",\"feelslike_f\":\"52.3\",\"feelslike_c\":\"11.3\",\"visibility_mi\":\"10.0\",\"visibility_km\":\"16.1\",\"solarradiation\":\"--\",\"UV\":\"1\",\"precip_1hr_string\":\"-999.00in(0mm)\",\"precip_1hr_in\":\"-999.00\",\"precip_1hr_metric\":\"0\",\"precip_today_string\":\"0.57in(14mm)\",\"precip_today_in\":\"0.57\",\"precip_today_metric\":\"14\",\"icon\":\"cloudy\",\"icon_url\":\"http://icons.wxug.com/i/c/k/cloudy.gif\",\"forecast_url\":\"http://www.wunderground.com/US/WA/Redmond.html\",\"history_url\":\"http://www.wunderground.com/weatherstation/WXDailyHistory.asp?ID=KWAREDMO124\",\"ob_url\":\"http://www.wunderground.com/cgi-bin/findweather/getForecast?query=47.686687,-122.105721\",\"nowcast\":\"\"}}";
        public static CurrentWeather Refresh() {
            return JsonConvert.DeserializeObject<CurrentWeather>(strTempResponse);
        }

        public override string ToString() {
            return Current_Observation.Observation_Location.City;
        }
    }
}