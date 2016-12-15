using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace personal_hud.forecast {
    public class Features {
        public int Forecast10Day { get; set; }
    }

    public class Response {
        public string Version { get; set; }
        public string TermsOfService { get; set; }
        public Features Features { get; set; }
    }

    public class TxtForecastDay {
        public int Period { get; set; }
        public string Icon { get; set; }
        public string Icon_URL { get; set; }
        public string Title { get; set; }
        public string FCTText { get; set; }
        public string FCTText_Metric { get; set; }
        public string Pop { get; set; }
    }

    public class TxtForecast {
        public string Date { get; set; }
        public List<TxtForecastDay> ForecastDay { get; set; }

        public bool IsValid { get { return ForecastDay != null && ForecastDay.Count > 0; } }
    }

    public class Date {
        public string Epoch { get; set; }
        public string Pretty { get; set; }
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int YDay { get; set; }
        public int Hour { get; set; }
        public string Min { get; set; }
        public int Sec { get; set; }
        public string IsDST { get; set; }
        public string MonthName { get; set; }
        public string MonthName_Short { get; set; }
        public string Weekday_Short { get; set; }
        public string Weekday { get; set; }
        public string AMPM { get; set; }
        public string TZ_Short { get; set; }
        public string TZ_Long { get; set; }
    }

    public class High {
        public string Fahrenheit { get; set; }
        public string Celsius { get; set; }
    }

    public class Low {
        public string Fahrenheit { get; set; }
        public string Celsius { get; set; }
    }

    public class QpfAllday {
        public double @in { get; set; }
        public int mm { get; set; }
    }

    public class QpfDay {
        public double? @in { get; set; }
        public int? mm { get; set; }
    }

    public class QpfNight {
        public double @in { get; set; }
        public int mm { get; set; }
    }

    public class SnowAllday {
        public double @in { get; set; }
        public double cm { get; set; }
    }

    public class SnowDay {
        public double? @in { get; set; }
        public double? cm { get; set; }
    }

    public class SnowNight {
        public double @in { get; set; }
        public double cm { get; set; }
    }

    public class MaxWind {
        public int MPH { get; set; }
        public int KPH { get; set; }
        public string Dir { get; set; }
        public int Degrees { get; set; }
    }

    public class AveWind {
        public int MPH { get; set; }
        public int KPH { get; set; }
        public string Dir { get; set; }
        public int Degrees { get; set; }
    }

    public class SimpleForecastDay {
        public Date Date { get; set; }
        public int Period { get; set; }
        public High High { get; set; }
        public Low Low { get; set; }
        public string Conditions { get; set; }
        public string Icon { get; set; }
        public string Icon_URL { get; set; }
        public string SkyIcon { get; set; }
        public int Pop { get; set; }
        public QpfAllday QPF_AllDay { get; set; }
        public QpfDay QPF_Day { get; set; }
        public QpfNight QPF_Night { get; set; }
        public SnowAllday Snow_AllDay { get; set; }
        public SnowDay Snow_Day { get; set; }
        public SnowNight Snow_Night { get; set; }
        public MaxWind MaxWind { get; set; }
        public AveWind AveWind { get; set; }
        public int AveHumidity { get; set; }
        public int MaxHumidity { get; set; }
        public int MinHumidity { get; set; }

        public string DateFull { get { return Date.Weekday + ", " + Date.MonthName + " " + Date.Day + ", " + Date.Year; } }
        public string HighFull { get { return High.Fahrenheit + (char)176; } }

        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            sb.Append(DateFull);
            return sb.ToString();
        }
    }

    public class SimpleForecast {
        public List<SimpleForecastDay> ForecastDay { get; set; }

        public bool IsValid { get { return ForecastDay != null && ForecastDay.Count > 0; } }
    }

    public class Forecast {
        public TxtForecast Txt_Forecast { get; set; }
        public SimpleForecast SimpleForecast { get; set; }

        public bool IsValid { get { return Txt_Forecast != null && SimpleForecast != null && Txt_Forecast.IsValid && SimpleForecast.IsValid; } }
    }

    public class Forecast10Day {
        public Response Response { get; set; }
        public Forecast Forecast { get; set; }

        public static async Task<Forecast10Day> Refresh() {
            try {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync("http://api.wunderground.com/api/023422a3f5a8324b/forecast10day/q/WA/Redmond.json");
                if (response.IsSuccessStatusCode) {
                    return JsonConvert.DeserializeObject<Forecast10Day>(response.Content.ReadAsStringAsync().Result);
                }
                else {
                    return null;
                }
            }
            catch {
                return null;
            }
        }

        public bool IsValid { get { return Forecast != null && Forecast.IsValid; } }
    }
}
