using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personal_hud {
    class WeatherData {
        public string DisplayLocationFull { get; set; }
        public string DisplayLocationCity { get; set; }
        public string DisplayLocationStateAbbr { get; set; }
        public string DisplayLocationStateFull { get; set; }
        public string DisplayLocationCountry { get; set; }
        public string DisplayLocationZip { get; set; }
        public string DisplayLocationLatitude { get; set; }
        public string DisplayLocationLongitude { get; set; }
        public string DisplayLocationElevation { get; set; }

        public string ObservationLocationFull { get; set; }
        public string ObservationLocationCity { get; set; }
        public string ObservationLocationLatitude { get; set; }
        public string ObservationLocationLongitude { get; set; }
        public string ObservationLocationElevation { get; set; }

        public string ObservationTime { get; set; }
        public string Weather { get; set; }
        public string TemperatureFull { get; set; }
        public string TemperatureFahrenheit { get; set; }
        public string TemperatureCelsius { get; set; }
        public string RelativeHumidity { get; set; }
        public string WindFull { get; set; }
        public string WindDirection { get; set; }
        public string WindDegrees { get; set; }
        public string WindMPH { get; set; }
        public string WindGustMPH { get; set; }
        public string WindKPH { get; set; }
        public string WindGustKPH { get; set; }
        public string PressureMB { get; set; }
        public string PressureInches { get; set; }
        public string DewpointFull { get; set; }
        public string DewpointFahrenheit { get; set; }
        public string DewpointCelsius { get; set; }
        public string HeatIndexFull { get; set; }
        public string HeatIndexFahrenheit { get; set; }
        public string HeatIndexCelsius { get; set; }
        public string WindchillFull { get; set; }
        public string WindchillFahrenheit { get; set; }
        public string WindchillCelsius { get; set; }
        public string FeelsLikeFull { get; set; }
        public string FeelsLikeFahrenheit { get; set; }
        public string FeelsLikeCelsius { get; set; }
        public string VisibilityMiles { get; set; }
        public string VisibilityKilometers { get; set; }
        public string UVIndex { get; set; }
        public string PrecipitationOneHourFull { get; set; }
        public string PrecipitationOneHourInches { get; set; }
        public string PrecipitationOneHourMetric { get; set; }
        public string PrecipitationTodayFull { get; set; }
        public string PrecipitationTodayInches { get; set; }
        public string PrecipitationTodayMetric { get; set; }
        public string WeatherIconString { get; set; }
        public string WeatherIconURL { get; set; }
        public string ForecastURL { get; set; }
        public string HistoryURL { get; set; }

        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            sb.Append("Display location full: " + DisplayLocationFull + "\r\n");
            sb.Append("Display location city: " + DisplayLocationCity + "\r\n");
            sb.Append("Display location state abbr: " + DisplayLocationStateAbbr + "\r\n");
            sb.Append("Display location state full: " + DisplayLocationStateFull + "\r\n");
            sb.Append("Display location country: " + DisplayLocationCountry + "\r\n");
            sb.Append("Display location zip: " + DisplayLocationZip + "\r\n");
            sb.Append("Display location latitude: " + DisplayLocationLatitude + "\r\n");
            sb.Append("Display location longitude: " + DisplayLocationLongitude + "\r\n");
            sb.Append("Display location elevation: " + DisplayLocationElevation + "\r\n");

            sb.Append("Observation location full: " + ObservationLocationFull + "\r\n");
            sb.Append("Observation location city: " + ObservationLocationCity + "\r\n");
            sb.Append("Observation location latitude: " + ObservationLocationLatitude + "\r\n");
            sb.Append("Observation location longitude: " + ObservationLocationLongitude + "\r\n");
            sb.Append("Observation location elevation: " + ObservationLocationElevation + "\r\n");

            sb.Append("Observation location elevation: " + ObservationTime + "\r\n");
            sb.Append("Observation location elevation: " + Weather + "\r\n");
            sb.Append("Observation location elevation: " + TemperatureFull + "\r\n");
            sb.Append("Observation location elevation: " + TemperatureFahrenheit + "\r\n");
            sb.Append("Observation location elevation: " + TemperatureCelsius + "\r\n");
            sb.Append("Observation location elevation: " + RelativeHumidity + "\r\n");
            sb.Append("Observation location elevation: " + WindFull + "\r\n");
            sb.Append("Observation location elevation: " + WindDirection + "\r\n");
            sb.Append("Observation location elevation: " + WindDegrees + "\r\n");
            sb.Append("Observation location elevation: " + WindMPH + "\r\n");
            sb.Append("Observation location elevation: " + WindGustMPH + "\r\n");
            sb.Append("Observation location elevation: " + WindKPH + "\r\n");
            sb.Append("Observation location elevation: " + WindGustKPH + "\r\n");
            sb.Append("Observation location elevation: " + PressureMB + "\r\n");
            sb.Append("Observation location elevation: " + PressureInches + "\r\n");
            sb.Append("Observation location elevation: " + DewpointFull + "\r\n");
            sb.Append("Observation location elevation: " + DewpointFahrenheit + "\r\n");
            sb.Append("Observation location elevation: " + DewpointCelsius + "\r\n");
            sb.Append("Observation location elevation: " + HeatIndexFull + "\r\n");
            sb.Append("Observation location elevation: " + HeatIndexFahrenheit + "\r\n");
            sb.Append("Observation location elevation: " + HeatIndexCelsius + "\r\n");
            sb.Append("Observation location elevation: " + WindchillFull + "\r\n");
            sb.Append("Observation location elevation: " + WindchillFahrenheit + "\r\n");
            sb.Append("Observation location elevation: " + WindchillCelsius + "\r\n");
            sb.Append("Observation location elevation: " + FeelsLikeFull + "\r\n");
            sb.Append("Observation location elevation: " + FeelsLikeFahrenheit + "\r\n");
            sb.Append("Observation location elevation: " + FeelsLikeCelsius + "\r\n");
            sb.Append("Observation location elevation: " + VisibilityMiles + "\r\n");
            sb.Append("Observation location elevation: " + VisibilityKilometers + "\r\n");
            sb.Append("Observation location elevation: " + UVIndex + "\r\n");
            sb.Append("Observation location elevation: " + PrecipitationOneHourFull + "\r\n");
            sb.Append("Observation location elevation: " + PrecipitationOneHourInches + "\r\n");
            sb.Append("Observation location elevation: " + PrecipitationOneHourMetric + "\r\n");
            sb.Append("Observation location elevation: " + PrecipitationTodayFull + "\r\n");
            sb.Append("Observation location elevation: " + PrecipitationTodayInches + "\r\n");
            sb.Append("Observation location elevation: " + PrecipitationTodayMetric + "\r\n");
            sb.Append("Observation location elevation: " + WeatherIconString + "\r\n");
            sb.Append("Observation location elevation: " + WeatherIconURL + "\r\n");
            sb.Append("Observation location elevation: " + ForecastURL + "\r\n");
            sb.Append("Observation location elevation: " + HistoryURL + "\r\n");

            return sb.ToString();
        }
    }
}
