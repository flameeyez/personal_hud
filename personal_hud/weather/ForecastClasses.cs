using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }

    public class Forecast {
        public TxtForecast Txt_Forecast { get; set; }
        public SimpleForecast SimpleForecast { get; set; }
    }

    public class Forecast10Day {
        public Response Response { get; set; }
        public Forecast Forecast { get; set; }

        private static string strTempResponse = "{\"response\":{\"version\":\"0.1\",\"termsofService\":\"http://www.wunderground.com/weather/api/d/terms.html\",\"features\":{\"forecast10day\":1}},\"forecast\":{\"txt_forecast\":{\"date\":\"10:46PMPST\",\"forecastday\":[{\"period\":0,\"icon\":\"chancesnow\",\"icon_url\":\"http://icons.wxug.com/i/c/k/chancerain.gif\",\"title\":\"Friday\",\"fcttext\":\"Chanceofshowers.Lowsovernightinthemid40s.\",\"fcttext_metric\":\"Chanceofshowers.Low7C.\",\"pop\":\"60\"},{\"period\":1,\"icon\":\"nt_chancerain\",\"icon_url\":\"http://icons.wxug.com/i/c/k/nt_chancerain.gif\",\"title\":\"FridayNight\",\"fcttext\":\"Overcastwithrainshowersattimes.Low44F.WindsESEat10to15mph.Chanceofrain60%.\",\"fcttext_metric\":\"Cloudywithoccasionalrainshowers.Low7C.WindsESEat15to25km/h.Chanceofrain60%.\",\"pop\":\"60\"},{\"period\":2,\"icon\":\"chancerain\",\"icon_url\":\"http://icons.wxug.com/i/c/k/chancerain.gif\",\"title\":\"Saturday\",\"fcttext\":\"Showersinthemorning,thenpartlycloudyintheafternoon.Highnear55F.WindsESEat5to10mph.Chanceofrain40%.\",\"fcttext_metric\":\"Showersinthemorning,thenpartlycloudyintheafternoon.High13C.WindsESEat10to15km/h.Chanceofrain40%.\",\"pop\":\"40\"},{\"period\":3,\"icon\":\"nt_chancerain\",\"icon_url\":\"http://icons.wxug.com/i/c/k/nt_chancerain.gif\",\"title\":\"SaturdayNight\",\"fcttext\":\"Overcastwithrainshowersattimes.Low47F.WindsESEat5to10mph.Chanceofrain50%.\",\"fcttext_metric\":\"Considerablecloudinesswithoccasionalrainshowers.Low9C.WindsESEat10to15km/h.Chanceofrain50%.\",\"pop\":\"50\"},{\"period\":4,\"icon\":\"chancerain\",\"icon_url\":\"http://icons.wxug.com/i/c/k/chancerain.gif\",\"title\":\"Sunday\",\"fcttext\":\"Cloudywithshowers.High54F.WindsSSEat5to10mph.Chanceofrain60%.\",\"fcttext_metric\":\"Considerablecloudinesswithoccasionalrainshowers.High12C.WindsSSEat10to15km/h.Chanceofrain60%.\",\"pop\":\"60\"},{\"period\":5,\"icon\":\"nt_chancerain\",\"icon_url\":\"http://icons.wxug.com/i/c/k/nt_chancerain.gif\",\"title\":\"SundayNight\",\"fcttext\":\"Cloudywithshowers.Lownear45F.WindsSat5to10mph.Chanceofrain40%.\",\"fcttext_metric\":\"Cloudywithshowers.Low8C.WindsSat10to15km/h.Chanceofrain40%.\",\"pop\":\"40\"},{\"period\":6,\"icon\":\"partlycloudy\",\"icon_url\":\"http://icons.wxug.com/i/c/k/partlycloudy.gif\",\"title\":\"Monday\",\"fcttext\":\"Cloudyskiesearly,thenpartlycloudyintheafternoon.High51F.WindsSat5to10mph.\",\"fcttext_metric\":\"Cloudyearlywithpartialsunshineexpectedlate.High11C.WindsSat10to15km/h.\",\"pop\":\"20\"},{\"period\":7,\"icon\":\"nt_chancerain\",\"icon_url\":\"http://icons.wxug.com/i/c/k/nt_chancerain.gif\",\"title\":\"MondayNight\",\"fcttext\":\"Partlycloudyskiesearlyfollowedbyincreasingcloudswithshowersdevelopinglateratnight.Low43F.WindsSEat5to10mph.Chanceofrain40%.\",\"fcttext_metric\":\"Partlycloudyskiesearlyfollowedbyincreasingcloudswithshowersdevelopinglateratnight.Low7C.WindsSEat10to15km/h.Chanceofrain40%.\",\"pop\":\"40\"},{\"period\":8,\"icon\":\"rain\",\"icon_url\":\"http://icons.wxug.com/i/c/k/rain.gif\",\"title\":\"Tuesday\",\"fcttext\":\"Periodsofrain.High49F.WindsSSEat5to10mph.Chanceofrain90%.Rainfallaroundaquarterofaninch.\",\"fcttext_metric\":\"Occasionalrain.Highnear10C.WindsSSEat10to15km/h.Chanceofrain90%.Rainfallnear6mm.\",\"pop\":\"90\"},{\"period\":9,\"icon\":\"nt_chancerain\",\"icon_url\":\"http://icons.wxug.com/i/c/k/nt_chancerain.gif\",\"title\":\"TuesdayNight\",\"fcttext\":\"Steadylightrainintheevening.Showerscontinuinglate.Low42F.Windslightandvariable.Chanceofrain60%.\",\"fcttext_metric\":\"Lightrainearly...thenremainingcloudywithshowerslate.Low6C.Windslightandvariable.Chanceofrain60%.\",\"pop\":\"60\"},{\"period\":10,\"icon\":\"chancerain\",\"icon_url\":\"http://icons.wxug.com/i/c/k/chancerain.gif\",\"title\":\"Wednesday\",\"fcttext\":\"Cloudywithperiodsoflightrain.High49F.WindsSSEat5to10mph.Chanceofrain80%.\",\"fcttext_metric\":\"Cloudywithoccasionallightrain.Highnear10C.WindsSSEat10to15km/h.Chanceofrain80%.\",\"pop\":\"80\"},{\"period\":11,\"icon\":\"nt_chancerain\",\"icon_url\":\"http://icons.wxug.com/i/c/k/nt_chancerain.gif\",\"title\":\"WednesdayNight\",\"fcttext\":\"Cloudywithshowers.Low42F.WindsSEat5to10mph.Chanceofrain60%.\",\"fcttext_metric\":\"Cloudywithoccasionalrainshowers.Low6C.WindsSEat10to15km/h.Chanceofrain60%.\",\"pop\":\"60\"},{\"period\":12,\"icon\":\"chancerain\",\"icon_url\":\"http://icons.wxug.com/i/c/k/chancerain.gif\",\"title\":\"Thursday\",\"fcttext\":\"Cloudywithoccasionalrainshowers.High48F.WindsSSEat5to10mph.Chanceofrain60%.\",\"fcttext_metric\":\"Overcastwithrainshowersattimes.High9C.WindsSSEat10to15km/h.Chanceofrain60%.\",\"pop\":\"60\"},{\"period\":13,\"icon\":\"nt_chancerain\",\"icon_url\":\"http://icons.wxug.com/i/c/k/nt_chancerain.gif\",\"title\":\"ThursdayNight\",\"fcttext\":\"Cloudywithafewshowers.Low41F.WindsSEat5to10mph.Chanceofrain30%.\",\"fcttext_metric\":\"Cloudywithafewshowers.Lownear5C.Windslightandvariable.Chanceofrain40%.\",\"pop\":\"30\"},{\"period\":14,\"icon\":\"chancerain\",\"icon_url\":\"http://icons.wxug.com/i/c/k/chancerain.gif\",\"title\":\"Friday\",\"fcttext\":\"Cloudywithshowers.High49F.WindsSSEat5to10mph.Chanceofrain40%.\",\"fcttext_metric\":\"Cloudywithoccasionalrainshowers.High9C.WindsSSEat10to15km/h.Chanceofrain40%.\",\"pop\":\"40\"},{\"period\":15,\"icon\":\"nt_chancerain\",\"icon_url\":\"http://icons.wxug.com/i/c/k/nt_chancerain.gif\",\"title\":\"FridayNight\",\"fcttext\":\"Cloudywithoccasionalrainshowers.Low42F.WindsSEat5to10mph.Chanceofrain60%.\",\"fcttext_metric\":\"Cloudywithshowers.Low6C.WindsSEat10to15km/h.Chanceofrain60%.\",\"pop\":\"60\"},{\"period\":16,\"icon\":\"chancerain\",\"icon_url\":\"http://icons.wxug.com/i/c/k/chancerain.gif\",\"title\":\"Saturday\",\"fcttext\":\"Cloudywithoccasionalrainshowers.High48F.WindsSEat5to10mph.Chanceofrain60%.\",\"fcttext_metric\":\"Overcastwithrainshowersattimes.High9C.WindsSEat10to15km/h.Chanceofrain60%.\",\"pop\":\"60\"},{\"period\":17,\"icon\":\"nt_chancerain\",\"icon_url\":\"http://icons.wxug.com/i/c/k/nt_chancerain.gif\",\"title\":\"SaturdayNight\",\"fcttext\":\"Cloudywithshowers.Low41F.WindsSSEat5to10mph.Chanceofrain60%.\",\"fcttext_metric\":\"Cloudywithshowers.Low6C.WindsSSEat10to15km/h.Chanceofrain60%.\",\"pop\":\"60\"},{\"period\":18,\"icon\":\"chancerain\",\"icon_url\":\"http://icons.wxug.com/i/c/k/chancerain.gif\",\"title\":\"Sunday\",\"fcttext\":\"Considerablecloudinesswithoccasionalrainshowers.High47F.WindsSSEat5to10mph.Chanceofrain60%.\",\"fcttext_metric\":\"Overcastwithrainshowersattimes.High8C.WindsSSEat10to15km/h.Chanceofrain60%.\",\"pop\":\"60\"},{\"period\":19,\"icon\":\"nt_chancerain\",\"icon_url\":\"http://icons.wxug.com/i/c/k/nt_chancerain.gif\",\"title\":\"SundayNight\",\"fcttext\":\"Cloudywithoccasionalrainshowers.Low41F.Windslightandvariable.Chanceofrain60%.\",\"fcttext_metric\":\"Cloudywithshowers.Lownear5C.Windslightandvariable.Chanceofrain60%.\",\"pop\":\"60\"}]},\"simpleforecast\":{\"forecastday\":[{\"date\":{\"epoch\":\"1479524400\",\"pretty\":\"7:00PMPSTonNovember18,2016\",\"day\":18,\"month\":11,\"year\":2016,\"yday\":322,\"hour\":19,\"min\":\"00\",\"sec\":0,\"isdst\":\"0\",\"monthname\":\"November\",\"monthname_short\":\"Nov\",\"weekday_short\":\"Fri\",\"weekday\":\"Friday\",\"ampm\":\"PM\",\"tz_short\":\"PST\",\"tz_long\":\"America/Los_Angeles\"},\"period\":1,\"high\":{\"fahrenheit\":\"54\",\"celsius\":\"12\"},\"low\":{\"fahrenheit\":\"44\",\"celsius\":\"7\"},\"conditions\":\"ChanceofRain\",\"icon\":\"chancesnow\",\"icon_url\":\"http://icons.wxug.com/i/c/k/chancerain.gif\",\"skyicon\":\"\",\"pop\":60,\"qpf_allday\":{\"in\":0.07,\"mm\":2},\"qpf_day\":{\"in\":null,\"mm\":null},\"qpf_night\":{\"in\":0.08,\"mm\":2},\"snow_allday\":{\"in\":0.0,\"cm\":0.0},\"snow_day\":{\"in\":null,\"cm\":null},\"snow_night\":{\"in\":0.0,\"cm\":0.0},\"maxwind\":{\"mph\":15,\"kph\":24,\"dir\":\"SE\",\"degrees\":0},\"avewind\":{\"mph\":3,\"kph\":4,\"dir\":\"SE\",\"degrees\":0},\"avehumidity\":58,\"maxhumidity\":0,\"minhumidity\":0},{\"date\":{\"epoch\":\"1479610800\",\"pretty\":\"7:00PMPSTonNovember19,2016\",\"day\":19,\"month\":11,\"year\":2016,\"yday\":323,\"hour\":19,\"min\":\"00\",\"sec\":0,\"isdst\":\"0\",\"monthname\":\"November\",\"monthname_short\":\"Nov\",\"weekday_short\":\"Sat\",\"weekday\":\"Saturday\",\"ampm\":\"PM\",\"tz_short\":\"PST\",\"tz_long\":\"America/Los_Angeles\"},\"period\":2,\"high\":{\"fahrenheit\":\"55\",\"celsius\":\"13\"},\"low\":{\"fahrenheit\":\"47\",\"celsius\":\"8\"},\"conditions\":\"ChanceofRain\",\"icon\":\"snow\",\"icon_url\":\"http://icons.wxug.com/i/c/k/chancerain.gif\",\"skyicon\":\"\",\"pop\":40,\"qpf_allday\":{\"in\":0.14,\"mm\":4},\"qpf_day\":{\"in\":0.03,\"mm\":1},\"qpf_night\":{\"in\":0.11,\"mm\":3},\"snow_allday\":{\"in\":0.0,\"cm\":0.0},\"snow_day\":{\"in\":0.0,\"cm\":0.0},\"snow_night\":{\"in\":0.0,\"cm\":0.0},\"maxwind\":{\"mph\":10,\"kph\":16,\"dir\":\"ESE\",\"degrees\":112},\"avewind\":{\"mph\":7,\"kph\":11,\"dir\":\"ESE\",\"degrees\":112},\"avehumidity\":66,\"maxhumidity\":0,\"minhumidity\":0},{\"date\":{\"epoch\":\"1479697200\",\"pretty\":\"7:00PMPSTonNovember20,2016\",\"day\":20,\"month\":11,\"year\":2016,\"yday\":324,\"hour\":19,\"min\":\"00\",\"sec\":0,\"isdst\":\"0\",\"monthname\":\"November\",\"monthname_short\":\"Nov\",\"weekday_short\":\"Sun\",\"weekday\":\"Sunday\",\"ampm\":\"PM\",\"tz_short\":\"PST\",\"tz_long\":\"America/Los_Angeles\"},\"period\":3,\"high\":{\"fahrenheit\":\"54\",\"celsius\":\"12\"},\"low\":{\"fahrenheit\":\"45\",\"celsius\":\"7\"},\"conditions\":\"ChanceofRain\",\"icon\":\"clear\",\"icon_url\":\"http://icons.wxug.com/i/c/k/chancerain.gif\",\"skyicon\":\"\",\"pop\":60,\"qpf_allday\":{\"in\":0.15,\"mm\":4},\"qpf_day\":{\"in\":0.11,\"mm\":3},\"qpf_night\":{\"in\":0.04,\"mm\":1},\"snow_allday\":{\"in\":0.0,\"cm\":0.0},\"snow_day\":{\"in\":0.0,\"cm\":0.0},\"snow_night\":{\"in\":0.0,\"cm\":0.0},\"maxwind\":{\"mph\":10,\"kph\":16,\"dir\":\"SSE\",\"degrees\":154},\"avewind\":{\"mph\":9,\"kph\":14,\"dir\":\"SSE\",\"degrees\":154},\"avehumidity\":75,\"maxhumidity\":0,\"minhumidity\":0},{\"date\":{\"epoch\":\"1479783600\",\"pretty\":\"7:00PMPSTonNovember21,2016\",\"day\":21,\"month\":11,\"year\":2016,\"yday\":325,\"hour\":19,\"min\":\"00\",\"sec\":0,\"isdst\":\"0\",\"monthname\":\"November\",\"monthname_short\":\"Nov\",\"weekday_short\":\"Mon\",\"weekday\":\"Monday\",\"ampm\":\"PM\",\"tz_short\":\"PST\",\"tz_long\":\"America/Los_Angeles\"},\"period\":4,\"high\":{\"fahrenheit\":\"51\",\"celsius\":\"11\"},\"low\":{\"fahrenheit\":\"43\",\"celsius\":\"6\"},\"conditions\":\"PartlyCloudy\",\"icon\":\"partlycloudy\",\"icon_url\":\"http://icons.wxug.com/i/c/k/partlycloudy.gif\",\"skyicon\":\"\",\"pop\":20,\"qpf_allday\":{\"in\":0.05,\"mm\":1},\"qpf_day\":{\"in\":0.00,\"mm\":0},\"qpf_night\":{\"in\":0.05,\"mm\":1},\"snow_allday\":{\"in\":0.0,\"cm\":0.0},\"snow_day\":{\"in\":0.0,\"cm\":0.0},\"snow_night\":{\"in\":0.0,\"cm\":0.0},\"maxwind\":{\"mph\":10,\"kph\":16,\"dir\":\"S\",\"degrees\":182},\"avewind\":{\"mph\":8,\"kph\":13,\"dir\":\"S\",\"degrees\":182},\"avehumidity\":80,\"maxhumidity\":0,\"minhumidity\":0},{\"date\":{\"epoch\":\"1479870000\",\"pretty\":\"7:00PMPSTonNovember22,2016\",\"day\":22,\"month\":11,\"year\":2016,\"yday\":326,\"hour\":19,\"min\":\"00\",\"sec\":0,\"isdst\":\"0\",\"monthname\":\"November\",\"monthname_short\":\"Nov\",\"weekday_short\":\"Tue\",\"weekday\":\"Tuesday\",\"ampm\":\"PM\",\"tz_short\":\"PST\",\"tz_long\":\"America/Los_Angeles\"},\"period\":5,\"high\":{\"fahrenheit\":\"49\",\"celsius\":\"9\"},\"low\":{\"fahrenheit\":\"42\",\"celsius\":\"6\"},\"conditions\":\"Rain\",\"icon\":\"rain\",\"icon_url\":\"http://icons.wxug.com/i/c/k/rain.gif\",\"skyicon\":\"\",\"pop\":90,\"qpf_allday\":{\"in\":0.38,\"mm\":10},\"qpf_day\":{\"in\":0.28,\"mm\":7},\"qpf_night\":{\"in\":0.09,\"mm\":2},\"snow_allday\":{\"in\":0.0,\"cm\":0.0},\"snow_day\":{\"in\":0.0,\"cm\":0.0},\"snow_night\":{\"in\":0.0,\"cm\":0.0},\"maxwind\":{\"mph\":10,\"kph\":16,\"dir\":\"SSE\",\"degrees\":150},\"avewind\":{\"mph\":9,\"kph\":14,\"dir\":\"SSE\",\"degrees\":150},\"avehumidity\":79,\"maxhumidity\":0,\"minhumidity\":0},{\"date\":{\"epoch\":\"1479956400\",\"pretty\":\"7:00PMPSTonNovember23,2016\",\"day\":23,\"month\":11,\"year\":2016,\"yday\":327,\"hour\":19,\"min\":\"00\",\"sec\":0,\"isdst\":\"0\",\"monthname\":\"November\",\"monthname_short\":\"Nov\",\"weekday_short\":\"Wed\",\"weekday\":\"Wednesday\",\"ampm\":\"PM\",\"tz_short\":\"PST\",\"tz_long\":\"America/Los_Angeles\"},\"period\":6,\"high\":{\"fahrenheit\":\"49\",\"celsius\":\"9\"},\"low\":{\"fahrenheit\":\"42\",\"celsius\":\"6\"},\"conditions\":\"ChanceofRain\",\"icon\":\"tstorms\",\"icon_url\":\"http://icons.wxug.com/i/c/k/chancerain.gif\",\"skyicon\":\"\",\"pop\":80,\"qpf_allday\":{\"in\":0.54,\"mm\":14},\"qpf_day\":{\"in\":0.17,\"mm\":4},\"qpf_night\":{\"in\":0.37,\"mm\":9},\"snow_allday\":{\"in\":0.0,\"cm\":0.0},\"snow_day\":{\"in\":0.0,\"cm\":0.0},\"snow_night\":{\"in\":0.0,\"cm\":0.0},\"maxwind\":{\"mph\":10,\"kph\":16,\"dir\":\"SSE\",\"degrees\":166},\"avewind\":{\"mph\":9,\"kph\":14,\"dir\":\"SSE\",\"degrees\":166},\"avehumidity\":79,\"maxhumidity\":0,\"minhumidity\":0},{\"date\":{\"epoch\":\"1480042800\",\"pretty\":\"7:00PMPSTonNovember24,2016\",\"day\":24,\"month\":11,\"year\":2016,\"yday\":328,\"hour\":19,\"min\":\"00\",\"sec\":0,\"isdst\":\"0\",\"monthname\":\"November\",\"monthname_short\":\"Nov\",\"weekday_short\":\"Thu\",\"weekday\":\"Thursday\",\"ampm\":\"PM\",\"tz_short\":\"PST\",\"tz_long\":\"America/Los_Angeles\"},\"period\":7,\"high\":{\"fahrenheit\":\"48\",\"celsius\":\"9\"},\"low\":{\"fahrenheit\":\"41\",\"celsius\":\"5\"},\"conditions\":\"ChanceofRain\",\"icon\":\"chancerain\",\"icon_url\":\"http://icons.wxug.com/i/c/k/chancerain.gif\",\"skyicon\":\"\",\"pop\":60,\"qpf_allday\":{\"in\":0.44,\"mm\":11},\"qpf_day\":{\"in\":0.40,\"mm\":10},\"qpf_night\":{\"in\":0.04,\"mm\":1},\"snow_allday\":{\"in\":0.0,\"cm\":0.0},\"snow_day\":{\"in\":0.0,\"cm\":0.0},\"snow_night\":{\"in\":0.0,\"cm\":0.0},\"maxwind\":{\"mph\":10,\"kph\":16,\"dir\":\"SSE\",\"degrees\":156},\"avewind\":{\"mph\":9,\"kph\":14,\"dir\":\"SSE\",\"degrees\":156},\"avehumidity\":77,\"maxhumidity\":0,\"minhumidity\":0},{\"date\":{\"epoch\":\"1480129200\",\"pretty\":\"7:00PMPSTonNovember25,2016\",\"day\":25,\"month\":11,\"year\":2016,\"yday\":329,\"hour\":19,\"min\":\"00\",\"sec\":0,\"isdst\":\"0\",\"monthname\":\"November\",\"monthname_short\":\"Nov\",\"weekday_short\":\"Fri\",\"weekday\":\"Friday\",\"ampm\":\"PM\",\"tz_short\":\"PST\",\"tz_long\":\"America/Los_Angeles\"},\"period\":8,\"high\":{\"fahrenheit\":\"49\",\"celsius\":\"9\"},\"low\":{\"fahrenheit\":\"42\",\"celsius\":\"6\"},\"conditions\":\"ChanceofRain\",\"icon\":\"chancerain\",\"icon_url\":\"http://icons.wxug.com/i/c/k/chancerain.gif\",\"skyicon\":\"\",\"pop\":40,\"qpf_allday\":{\"in\":0.16,\"mm\":4},\"qpf_day\":{\"in\":0.03,\"mm\":1},\"qpf_night\":{\"in\":0.13,\"mm\":3},\"snow_allday\":{\"in\":0.0,\"cm\":0.0},\"snow_day\":{\"in\":0.0,\"cm\":0.0},\"snow_night\":{\"in\":0.0,\"cm\":0.0},\"maxwind\":{\"mph\":10,\"kph\":16,\"dir\":\"SSE\",\"degrees\":162},\"avewind\":{\"mph\":7,\"kph\":11,\"dir\":\"SSE\",\"degrees\":162},\"avehumidity\":76,\"maxhumidity\":0,\"minhumidity\":0},{\"date\":{\"epoch\":\"1480215600\",\"pretty\":\"7:00PMPSTonNovember26,2016\",\"day\":26,\"month\":11,\"year\":2016,\"yday\":330,\"hour\":19,\"min\":\"00\",\"sec\":0,\"isdst\":\"0\",\"monthname\":\"November\",\"monthname_short\":\"Nov\",\"weekday_short\":\"Sat\",\"weekday\":\"Saturday\",\"ampm\":\"PM\",\"tz_short\":\"PST\",\"tz_long\":\"America/Los_Angeles\"},\"period\":9,\"high\":{\"fahrenheit\":\"48\",\"celsius\":\"9\"},\"low\":{\"fahrenheit\":\"41\",\"celsius\":\"5\"},\"conditions\":\"ChanceofRain\",\"icon\":\"chancerain\",\"icon_url\":\"http://icons.wxug.com/i/c/k/chancerain.gif\",\"skyicon\":\"\",\"pop\":60,\"qpf_allday\":{\"in\":0.23,\"mm\":6},\"qpf_day\":{\"in\":0.14,\"mm\":4},\"qpf_night\":{\"in\":0.09,\"mm\":2},\"snow_allday\":{\"in\":0.0,\"cm\":0.0},\"snow_day\":{\"in\":0.0,\"cm\":0.0},\"snow_night\":{\"in\":0.0,\"cm\":0.0},\"maxwind\":{\"mph\":10,\"kph\":16,\"dir\":\"SE\",\"degrees\":142},\"avewind\":{\"mph\":8,\"kph\":13,\"dir\":\"SE\",\"degrees\":142},\"avehumidity\":78,\"maxhumidity\":0,\"minhumidity\":0},{\"date\":{\"epoch\":\"1480302000\",\"pretty\":\"7:00PMPSTonNovember27,2016\",\"day\":27,\"month\":11,\"year\":2016,\"yday\":331,\"hour\":19,\"min\":\"00\",\"sec\":0,\"isdst\":\"0\",\"monthname\":\"November\",\"monthname_short\":\"Nov\",\"weekday_short\":\"Sun\",\"weekday\":\"Sunday\",\"ampm\":\"PM\",\"tz_short\":\"PST\",\"tz_long\":\"America/Los_Angeles\"},\"period\":10,\"high\":{\"fahrenheit\":\"47\",\"celsius\":\"8\"},\"low\":{\"fahrenheit\":\"41\",\"celsius\":\"5\"},\"conditions\":\"ChanceofRain\",\"icon\":\"chancerain\",\"icon_url\":\"http://icons.wxug.com/i/c/k/chancerain.gif\",\"skyicon\":\"\",\"pop\":60,\"qpf_allday\":{\"in\":0.25,\"mm\":6},\"qpf_day\":{\"in\":0.09,\"mm\":2},\"qpf_night\":{\"in\":0.15,\"mm\":4},\"snow_allday\":{\"in\":0.0,\"cm\":0.0},\"snow_day\":{\"in\":0.0,\"cm\":0.0},\"snow_night\":{\"in\":0.0,\"cm\":0.0},\"maxwind\":{\"mph\":10,\"kph\":16,\"dir\":\"SSE\",\"degrees\":163},\"avewind\":{\"mph\":8,\"kph\":13,\"dir\":\"SSE\",\"degrees\":163},\"avehumidity\":83,\"maxhumidity\":0,\"minhumidity\":0}]}}}";
        public static Forecast10Day Refresh() {
            return JsonConvert.DeserializeObject<Forecast10Day>(strTempResponse);
        }
    }
}
