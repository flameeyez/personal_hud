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

        private static string strTempResponse = "{\"response\":{\"version\":\"0.1\",\"termsofService\":\"http://www.wunderground.com/weather/api/d/terms.html\",\"features\":{\"forecast10day\":1}},\"forecast\":{\"txt_forecast\":{\"date\":\"7:09PMPST\",\"forecastday\":[{\"period\":0,\"icon\":\"rain\",\"icon_url\":\"http://icons.wxug.com/i/c/k/rain.gif\",\"title\":\"Monday\",\"fcttext\":\"Periodsofrainlate.Lowsovernightinthemid40s.\",\"fcttext_metric\":\"Raindevelopinglate.Low7C.\",\"pop\":\"90\"},{\"period\":1,\"icon\":\"nt_rain\",\"icon_url\":\"http://icons.wxug.com/i/c/k/nt_rain.gif\",\"title\":\"MondayNight\",\"fcttext\":\"Cloudywithraindevelopingaftermidnight.Low46F.Windslightandvariable.Chanceofrain90%.Rainfallnearaquarterofaninch.\",\"fcttext_metric\":\"Cloudywithraindevelopingaftermidnight.Low7C.Windslightandvariable.Chanceofrain100%.Rainfallaround12mm.\",\"pop\":\"90\"},{\"period\":2,\"icon\":\"tstorms\",\"icon_url\":\"http://icons.wxug.com/i/c/k/tstorms.gif\",\"title\":\"Tuesday\",\"fcttext\":\"Rainshowersinthemorningwiththunderstormsdevelopingintheafternoon.High52F.WindsSSWat10to15mph.Chanceofrain80%.\",\"fcttext_metric\":\"Variablecloudswithscatteredthunderstorms.High11C.WindsSSWat15to25km/h.Chanceofrain60%.\",\"pop\":\"80\"},{\"period\":3,\"icon\":\"nt_tstorms\",\"icon_url\":\"http://icons.wxug.com/i/c/k/nt_tstorms.gif\",\"title\":\"TuesdayNight\",\"fcttext\":\"Thunderstormsintheevening,mainlycloudyovernightwithafewshowers.Low41F.Windslightandvariable.Chanceofrain80%.\",\"fcttext_metric\":\"Cloudywithshowers.Lownear5C.Windslightandvariable.Chanceofrain60%.\",\"pop\":\"80\"},{\"period\":4,\"icon\":\"chancerain\",\"icon_url\":\"http://icons.wxug.com/i/c/k/chancerain.gif\",\"title\":\"Wednesday\",\"fcttext\":\"Considerablecloudiness.Occasionalrainshowersintheafternoon.High48F.Windslightandvariable.Chanceofrain50%.\",\"fcttext_metric\":\"Cloudyinthemorning,thenoffandonrainshowersduringtheafternoonhours.High9C.WindsSSEat10to15km/h.Chanceofrain50%.\",\"pop\":\"50\"},{\"period\":5,\"icon\":\"nt_partlycloudy\",\"icon_url\":\"http://icons.wxug.com/i/c/k/nt_partlycloudy.gif\",\"title\":\"WednesdayNight\",\"fcttext\":\"Mostlycloudyskiesearly,thenpartlycloudyaftermidnight.Slightchanceofarainshower.Low39F.Windslightandvariable.\",\"fcttext_metric\":\"Mostlycloudyskiesearlywillbecomepartlycloudylate.Slightchanceofarainshower.Low4C.Windslightandvariable.\",\"pop\":\"20\"},{\"period\":6,\"icon\":\"chancerain\",\"icon_url\":\"http://icons.wxug.com/i/c/k/chancerain.gif\",\"title\":\"Thursday\",\"fcttext\":\"Partlycloudyearlyfollowedbyincreasingcloudswithshowersdevelopinglaterintheday.High49F.Windslightandvariable.Chanceofrain40%.\",\"fcttext_metric\":\"Partlycloudyinthemorning.Increasingcloudswithperiodsofshowerslaterintheday.High9C.Windslightandvariable.Chanceofrain40%.\",\"pop\":\"40\"},{\"period\":7,\"icon\":\"nt_clear\",\"icon_url\":\"http://icons.wxug.com/i/c/k/nt_clear.gif\",\"title\":\"ThursdayNight\",\"fcttext\":\"Mostlyclearskies.Low38F.Windslightandvariable.\",\"fcttext_metric\":\"Mainlyclearskies.Low3C.Windslightandvariable.\",\"pop\":\"10\"},{\"period\":8,\"icon\":\"cloudy\",\"icon_url\":\"http://icons.wxug.com/i/c/k/cloudy.gif\",\"title\":\"Friday\",\"fcttext\":\"Cloudyskies.High52F.WindsEat5to10mph.\",\"fcttext_metric\":\"Cloudy.High11C.WindsEat10to15km/h.\",\"pop\":\"0\"},{\"period\":9,\"icon\":\"nt_chancerain\",\"icon_url\":\"http://icons.wxug.com/i/c/k/nt_chancerain.gif\",\"title\":\"FridayNight\",\"fcttext\":\"Cloudywithoccasionalshowerslateatnight.Low44F.WindsEat5to10mph.Chanceofrain60%.\",\"fcttext_metric\":\"Cloudyintheevening,thenoffandonrainshowersaftermidnight.Low7C.WindsEat10to15km/h.Chanceofrain60%.\",\"pop\":\"60\"},{\"period\":10,\"icon\":\"chancerain\",\"icon_url\":\"http://icons.wxug.com/i/c/k/chancerain.gif\",\"title\":\"Saturday\",\"fcttext\":\"Cloudyskiesearly.Afewshowersdevelopinglaterintheday.Higharound55F.WindsESEat5to10mph.Chanceofrain30%.\",\"fcttext_metric\":\"Cloudyskieswithafewshowerslaterintheday.High13C.WindsESEat10to15km/h.Chanceofrain30%.\",\"pop\":\"30\"},{\"period\":11,\"icon\":\"nt_chancerain\",\"icon_url\":\"http://icons.wxug.com/i/c/k/nt_chancerain.gif\",\"title\":\"SaturdayNight\",\"fcttext\":\"Considerablecloudiness.Occasionalrainshowerslateratnight.Lownear45F.WindsESEat5to10mph.Chanceofrain40%.\",\"fcttext_metric\":\"Cloudyintheevening,thenoffandonrainshowersaftermidnight.Low7C.WindsESEat10to15km/h.Chanceofrain40%.\",\"pop\":\"40\"},{\"period\":12,\"icon\":\"chancerain\",\"icon_url\":\"http://icons.wxug.com/i/c/k/chancerain.gif\",\"title\":\"Sunday\",\"fcttext\":\"Showersearlybecomingasteadylightrainlaterintheday.High54F.WindsSEat5to10mph.Chanceofrain80%.\",\"fcttext_metric\":\"Rainshowersinthemorningbecomingasteadylightrainintheafternoon.High12C.WindsSEat10to15km/h.Chanceofrain80%.\",\"pop\":\"80\"},{\"period\":13,\"icon\":\"nt_chancerain\",\"icon_url\":\"http://icons.wxug.com/i/c/k/nt_chancerain.gif\",\"title\":\"SundayNight\",\"fcttext\":\"Considerablecloudinesswithoccasionalrainshowers.Low46F.Windslightandvariable.Chanceofrain60%.\",\"fcttext_metric\":\"Overcastwithrainshowersattimes.Low8C.Windslightandvariable.Chanceofrain60%.\",\"pop\":\"60\"},{\"period\":14,\"icon\":\"chancerain\",\"icon_url\":\"http://icons.wxug.com/i/c/k/chancerain.gif\",\"title\":\"Monday\",\"fcttext\":\"Cloudywithshowers.High53F.WindsSSEat5to10mph.Chanceofrain50%.\",\"fcttext_metric\":\"Cloudywithshowers.High12C.WindsSSEat10to15km/h.Chanceofrain50%.\",\"pop\":\"50\"},{\"period\":15,\"icon\":\"nt_chancerain\",\"icon_url\":\"http://icons.wxug.com/i/c/k/nt_chancerain.gif\",\"title\":\"MondayNight\",\"fcttext\":\"Cloudywithshowers.Low46F.WindsSSEat5to10mph.Chanceofrain60%.\",\"fcttext_metric\":\"Cloudywithoccasionalrainshowers.Low8C.Windslightandvariable.Chanceofrain60%.\",\"pop\":\"60\"},{\"period\":16,\"icon\":\"chancerain\",\"icon_url\":\"http://icons.wxug.com/i/c/k/chancerain.gif\",\"title\":\"Tuesday\",\"fcttext\":\"Overcastwithrainshowersattimes.High52F.WindsSSEat5to10mph.Chanceofrain60%.\",\"fcttext_metric\":\"Cloudywithoccasionalrainshowers.High11C.WindsSSEat10to15km/h.Chanceofrain60%.\",\"pop\":\"60\"},{\"period\":17,\"icon\":\"nt_mostlycloudy\",\"icon_url\":\"http://icons.wxug.com/i/c/k/nt_mostlycloudy.gif\",\"title\":\"TuesdayNight\",\"fcttext\":\"Mostlycloudyskies.Lowaround45F.WindsSEat5to10mph.\",\"fcttext_metric\":\"Mainlycloudy.Low7C.WindsSEat10to15km/h.\",\"pop\":\"20\"},{\"period\":18,\"icon\":\"chancerain\",\"icon_url\":\"http://icons.wxug.com/i/c/k/chancerain.gif\",\"title\":\"Wednesday\",\"fcttext\":\"Overcastwithrainshowersattimes.Highnear50F.WindsSSEat5to10mph.Chanceofrain50%.\",\"fcttext_metric\":\"Overcastwithrainshowersattimes.Highnear10C.WindsSSEat10to15km/h.Chanceofrain50%.\",\"pop\":\"50\"},{\"period\":19,\"icon\":\"nt_chancerain\",\"icon_url\":\"http://icons.wxug.com/i/c/k/nt_chancerain.gif\",\"title\":\"WednesdayNight\",\"fcttext\":\"Considerablecloudiness.Occasionalrainshowerslateratnight.Low44F.Windslightandvariable.Chanceofrain40%.\",\"fcttext_metric\":\"Considerablecloudiness.Occasionalrainshowerslateratnight.Low7C.Windslightandvariable.Chanceofrain40%.\",\"pop\":\"40\"}]},\"simpleforecast\":{\"forecastday\":[{\"date\":{\"epoch\":\"1479178800\",\"pretty\":\"7:00PMPSTonNovember14,2016\",\"day\":14,\"month\":11,\"year\":2016,\"yday\":318,\"hour\":19,\"min\":\"00\",\"sec\":0,\"isdst\":\"0\",\"monthname\":\"November\",\"monthname_short\":\"Nov\",\"weekday_short\":\"Mon\",\"weekday\":\"Monday\",\"ampm\":\"PM\",\"tz_short\":\"PST\",\"tz_long\":\"America/Los_Angeles\"},\"period\":1,\"high\":{\"fahrenheit\":\"51\",\"celsius\":\"10\"},\"low\":{\"fahrenheit\":\"46\",\"celsius\":\"8\"},\"conditions\":\"Rain\",\"icon\":\"rain\",\"icon_url\":\"http://icons.wxug.com/i/c/k/rain.gif\",\"skyicon\":\"\",\"pop\":90,\"qpf_allday\":{\"in\":0.32,\"mm\":8},\"qpf_day\":{\"in\":null,\"mm\":null},\"qpf_night\":{\"in\":0.32,\"mm\":8},\"snow_allday\":{\"in\":0.0,\"cm\":0.0},\"snow_day\":{\"in\":null,\"cm\":null},\"snow_night\":{\"in\":0.0,\"cm\":0.0},\"maxwind\":{\"mph\":6,\"kph\":9,\"dir\":\"\",\"degrees\":0},\"avewind\":{\"mph\":1,\"kph\":1,\"dir\":\"NNW\",\"degrees\":330},\"avehumidity\":84,\"maxhumidity\":0,\"minhumidity\":0},{\"date\":{\"epoch\":\"1479265200\",\"pretty\":\"7:00PMPSTonNovember15,2016\",\"day\":15,\"month\":11,\"year\":2016,\"yday\":319,\"hour\":19,\"min\":\"00\",\"sec\":0,\"isdst\":\"0\",\"monthname\":\"November\",\"monthname_short\":\"Nov\",\"weekday_short\":\"Tue\",\"weekday\":\"Tuesday\",\"ampm\":\"PM\",\"tz_short\":\"PST\",\"tz_long\":\"America/Los_Angeles\"},\"period\":2,\"high\":{\"fahrenheit\":\"52\",\"celsius\":\"11\"},\"low\":{\"fahrenheit\":\"41\",\"celsius\":\"5\"},\"conditions\":\"Thunderstorm\",\"icon\":\"tstorms\",\"icon_url\":\"http://icons.wxug.com/i/c/k/tstorms.gif\",\"skyicon\":\"\",\"pop\":80,\"qpf_allday\":{\"in\":0.20,\"mm\":5},\"qpf_day\":{\"in\":0.15,\"mm\":4},\"qpf_night\":{\"in\":0.05,\"mm\":1},\"snow_allday\":{\"in\":0.0,\"cm\":0.0},\"snow_day\":{\"in\":0.0,\"cm\":0.0},\"snow_night\":{\"in\":0.0,\"cm\":0.0},\"maxwind\":{\"mph\":15,\"kph\":24,\"dir\":\"SSW\",\"degrees\":201},\"avewind\":{\"mph\":12,\"kph\":19,\"dir\":\"SSW\",\"degrees\":201},\"avehumidity\":80,\"maxhumidity\":0,\"minhumidity\":0},{\"date\":{\"epoch\":\"1479351600\",\"pretty\":\"7:00PMPSTonNovember16,2016\",\"day\":16,\"month\":11,\"year\":2016,\"yday\":320,\"hour\":19,\"min\":\"00\",\"sec\":0,\"isdst\":\"0\",\"monthname\":\"November\",\"monthname_short\":\"Nov\",\"weekday_short\":\"Wed\",\"weekday\":\"Wednesday\",\"ampm\":\"PM\",\"tz_short\":\"PST\",\"tz_long\":\"America/Los_Angeles\"},\"period\":3,\"high\":{\"fahrenheit\":\"48\",\"celsius\":\"9\"},\"low\":{\"fahrenheit\":\"39\",\"celsius\":\"4\"},\"conditions\":\"ChanceofRain\",\"icon\":\"chancerain\",\"icon_url\":\"http://icons.wxug.com/i/c/k/chancerain.gif\",\"skyicon\":\"\",\"pop\":50,\"qpf_allday\":{\"in\":0.06,\"mm\":2},\"qpf_day\":{\"in\":0.06,\"mm\":2},\"qpf_night\":{\"in\":0.00,\"mm\":0},\"snow_allday\":{\"in\":0.0,\"cm\":0.0},\"snow_day\":{\"in\":0.0,\"cm\":0.0},\"snow_night\":{\"in\":0.0,\"cm\":0.0},\"maxwind\":{\"mph\":10,\"kph\":16,\"dir\":\"SSE\",\"degrees\":160},\"avewind\":{\"mph\":5,\"kph\":8,\"dir\":\"SSE\",\"degrees\":160},\"avehumidity\":81,\"maxhumidity\":0,\"minhumidity\":0},{\"date\":{\"epoch\":\"1479438000\",\"pretty\":\"7:00PMPSTonNovember17,2016\",\"day\":17,\"month\":11,\"year\":2016,\"yday\":321,\"hour\":19,\"min\":\"00\",\"sec\":0,\"isdst\":\"0\",\"monthname\":\"November\",\"monthname_short\":\"Nov\",\"weekday_short\":\"Thu\",\"weekday\":\"Thursday\",\"ampm\":\"PM\",\"tz_short\":\"PST\",\"tz_long\":\"America/Los_Angeles\"},\"period\":4,\"high\":{\"fahrenheit\":\"49\",\"celsius\":\"9\"},\"low\":{\"fahrenheit\":\"38\",\"celsius\":\"3\"},\"conditions\":\"ChanceofRain\",\"icon\":\"chancerain\",\"icon_url\":\"http://icons.wxug.com/i/c/k/chancerain.gif\",\"skyicon\":\"\",\"pop\":40,\"qpf_allday\":{\"in\":0.02,\"mm\":1},\"qpf_day\":{\"in\":0.02,\"mm\":1},\"qpf_night\":{\"in\":0.00,\"mm\":0},\"snow_allday\":{\"in\":0.0,\"cm\":0.0},\"snow_day\":{\"in\":0.0,\"cm\":0.0},\"snow_night\":{\"in\":0.0,\"cm\":0.0},\"maxwind\":{\"mph\":5,\"kph\":8,\"dir\":\"SE\",\"degrees\":145},\"avewind\":{\"mph\":4,\"kph\":6,\"dir\":\"SE\",\"degrees\":145},\"avehumidity\":79,\"maxhumidity\":0,\"minhumidity\":0},{\"date\":{\"epoch\":\"1479524400\",\"pretty\":\"7:00PMPSTonNovember18,2016\",\"day\":18,\"month\":11,\"year\":2016,\"yday\":322,\"hour\":19,\"min\":\"00\",\"sec\":0,\"isdst\":\"0\",\"monthname\":\"November\",\"monthname_short\":\"Nov\",\"weekday_short\":\"Fri\",\"weekday\":\"Friday\",\"ampm\":\"PM\",\"tz_short\":\"PST\",\"tz_long\":\"America/Los_Angeles\"},\"period\":5,\"high\":{\"fahrenheit\":\"52\",\"celsius\":\"11\"},\"low\":{\"fahrenheit\":\"44\",\"celsius\":\"7\"},\"conditions\":\"Overcast\",\"icon\":\"cloudy\",\"icon_url\":\"http://icons.wxug.com/i/c/k/cloudy.gif\",\"skyicon\":\"\",\"pop\":0,\"qpf_allday\":{\"in\":0.07,\"mm\":2},\"qpf_day\":{\"in\":0.00,\"mm\":0},\"qpf_night\":{\"in\":0.07,\"mm\":2},\"snow_allday\":{\"in\":0.0,\"cm\":0.0},\"snow_day\":{\"in\":0.0,\"cm\":0.0},\"snow_night\":{\"in\":0.0,\"cm\":0.0},\"maxwind\":{\"mph\":10,\"kph\":16,\"dir\":\"E\",\"degrees\":92},\"avewind\":{\"mph\":8,\"kph\":13,\"dir\":\"E\",\"degrees\":92},\"avehumidity\":58,\"maxhumidity\":0,\"minhumidity\":0},{\"date\":{\"epoch\":\"1479610800\",\"pretty\":\"7:00PMPSTonNovember19,2016\",\"day\":19,\"month\":11,\"year\":2016,\"yday\":323,\"hour\":19,\"min\":\"00\",\"sec\":0,\"isdst\":\"0\",\"monthname\":\"November\",\"monthname_short\":\"Nov\",\"weekday_short\":\"Sat\",\"weekday\":\"Saturday\",\"ampm\":\"PM\",\"tz_short\":\"PST\",\"tz_long\":\"America/Los_Angeles\"},\"period\":6,\"high\":{\"fahrenheit\":\"55\",\"celsius\":\"13\"},\"low\":{\"fahrenheit\":\"45\",\"celsius\":\"7\"},\"conditions\":\"ChanceofRain\",\"icon\":\"chancerain\",\"icon_url\":\"http://icons.wxug.com/i/c/k/chancerain.gif\",\"skyicon\":\"\",\"pop\":30,\"qpf_allday\":{\"in\":0.07,\"mm\":2},\"qpf_day\":{\"in\":0.02,\"mm\":1},\"qpf_night\":{\"in\":0.06,\"mm\":2},\"snow_allday\":{\"in\":0.0,\"cm\":0.0},\"snow_day\":{\"in\":0.0,\"cm\":0.0},\"snow_night\":{\"in\":0.0,\"cm\":0.0},\"maxwind\":{\"mph\":10,\"kph\":16,\"dir\":\"ESE\",\"degrees\":115},\"avewind\":{\"mph\":7,\"kph\":11,\"dir\":\"ESE\",\"degrees\":115},\"avehumidity\":64,\"maxhumidity\":0,\"minhumidity\":0},{\"date\":{\"epoch\":\"1479697200\",\"pretty\":\"7:00PMPSTonNovember20,2016\",\"day\":20,\"month\":11,\"year\":2016,\"yday\":324,\"hour\":19,\"min\":\"00\",\"sec\":0,\"isdst\":\"0\",\"monthname\":\"November\",\"monthname_short\":\"Nov\",\"weekday_short\":\"Sun\",\"weekday\":\"Sunday\",\"ampm\":\"PM\",\"tz_short\":\"PST\",\"tz_long\":\"America/Los_Angeles\"},\"period\":7,\"high\":{\"fahrenheit\":\"54\",\"celsius\":\"12\"},\"low\":{\"fahrenheit\":\"46\",\"celsius\":\"8\"},\"conditions\":\"ChanceofRain\",\"icon\":\"chancerain\",\"icon_url\":\"http://icons.wxug.com/i/c/k/chancerain.gif\",\"skyicon\":\"\",\"pop\":80,\"qpf_allday\":{\"in\":0.27,\"mm\":7},\"qpf_day\":{\"in\":0.19,\"mm\":5},\"qpf_night\":{\"in\":0.07,\"mm\":2},\"snow_allday\":{\"in\":0.0,\"cm\":0.0},\"snow_day\":{\"in\":0.0,\"cm\":0.0},\"snow_night\":{\"in\":0.0,\"cm\":0.0},\"maxwind\":{\"mph\":10,\"kph\":16,\"dir\":\"SE\",\"degrees\":134},\"avewind\":{\"mph\":7,\"kph\":11,\"dir\":\"SE\",\"degrees\":134},\"avehumidity\":77,\"maxhumidity\":0,\"minhumidity\":0},{\"date\":{\"epoch\":\"1479783600\",\"pretty\":\"7:00PMPSTonNovember21,2016\",\"day\":21,\"month\":11,\"year\":2016,\"yday\":325,\"hour\":19,\"min\":\"00\",\"sec\":0,\"isdst\":\"0\",\"monthname\":\"November\",\"monthname_short\":\"Nov\",\"weekday_short\":\"Mon\",\"weekday\":\"Monday\",\"ampm\":\"PM\",\"tz_short\":\"PST\",\"tz_long\":\"America/Los_Angeles\"},\"period\":8,\"high\":{\"fahrenheit\":\"53\",\"celsius\":\"12\"},\"low\":{\"fahrenheit\":\"46\",\"celsius\":\"8\"},\"conditions\":\"ChanceofRain\",\"icon\":\"chancerain\",\"icon_url\":\"http://icons.wxug.com/i/c/k/chancerain.gif\",\"skyicon\":\"\",\"pop\":50,\"qpf_allday\":{\"in\":0.27,\"mm\":7},\"qpf_day\":{\"in\":0.07,\"mm\":2},\"qpf_night\":{\"in\":0.21,\"mm\":5},\"snow_allday\":{\"in\":0.0,\"cm\":0.0},\"snow_day\":{\"in\":0.0,\"cm\":0.0},\"snow_night\":{\"in\":0.0,\"cm\":0.0},\"maxwind\":{\"mph\":10,\"kph\":16,\"dir\":\"SSE\",\"degrees\":159},\"avewind\":{\"mph\":7,\"kph\":11,\"dir\":\"SSE\",\"degrees\":159},\"avehumidity\":81,\"maxhumidity\":0,\"minhumidity\":0},{\"date\":{\"epoch\":\"1479870000\",\"pretty\":\"7:00PMPSTonNovember22,2016\",\"day\":22,\"month\":11,\"year\":2016,\"yday\":326,\"hour\":19,\"min\":\"00\",\"sec\":0,\"isdst\":\"0\",\"monthname\":\"November\",\"monthname_short\":\"Nov\",\"weekday_short\":\"Tue\",\"weekday\":\"Tuesday\",\"ampm\":\"PM\",\"tz_short\":\"PST\",\"tz_long\":\"America/Los_Angeles\"},\"period\":9,\"high\":{\"fahrenheit\":\"52\",\"celsius\":\"11\"},\"low\":{\"fahrenheit\":\"45\",\"celsius\":\"7\"},\"conditions\":\"ChanceofRain\",\"icon\":\"chancerain\",\"icon_url\":\"http://icons.wxug.com/i/c/k/chancerain.gif\",\"skyicon\":\"\",\"pop\":60,\"qpf_allday\":{\"in\":0.07,\"mm\":2},\"qpf_day\":{\"in\":0.07,\"mm\":2},\"qpf_night\":{\"in\":0.00,\"mm\":0},\"snow_allday\":{\"in\":0.0,\"cm\":0.0},\"snow_day\":{\"in\":0.0,\"cm\":0.0},\"snow_night\":{\"in\":0.0,\"cm\":0.0},\"maxwind\":{\"mph\":10,\"kph\":16,\"dir\":\"SSE\",\"degrees\":162},\"avewind\":{\"mph\":9,\"kph\":14,\"dir\":\"SSE\",\"degrees\":162},\"avehumidity\":77,\"maxhumidity\":0,\"minhumidity\":0},{\"date\":{\"epoch\":\"1479956400\",\"pretty\":\"7:00PMPSTonNovember23,2016\",\"day\":23,\"month\":11,\"year\":2016,\"yday\":327,\"hour\":19,\"min\":\"00\",\"sec\":0,\"isdst\":\"0\",\"monthname\":\"November\",\"monthname_short\":\"Nov\",\"weekday_short\":\"Wed\",\"weekday\":\"Wednesday\",\"ampm\":\"PM\",\"tz_short\":\"PST\",\"tz_long\":\"America/Los_Angeles\"},\"period\":10,\"high\":{\"fahrenheit\":\"50\",\"celsius\":\"10\"},\"low\":{\"fahrenheit\":\"44\",\"celsius\":\"7\"},\"conditions\":\"ChanceofRain\",\"icon\":\"chancerain\",\"icon_url\":\"http://icons.wxug.com/i/c/k/chancerain.gif\",\"skyicon\":\"\",\"pop\":50,\"qpf_allday\":{\"in\":0.06,\"mm\":2},\"qpf_day\":{\"in\":0.05,\"mm\":1},\"qpf_night\":{\"in\":0.01,\"mm\":0},\"snow_allday\":{\"in\":0.0,\"cm\":0.0},\"snow_day\":{\"in\":0.0,\"cm\":0.0},\"snow_night\":{\"in\":0.0,\"cm\":0.0},\"maxwind\":{\"mph\":10,\"kph\":16,\"dir\":\"SSE\",\"degrees\":156},\"avewind\":{\"mph\":7,\"kph\":11,\"dir\":\"SSE\",\"degrees\":156},\"avehumidity\":78,\"maxhumidity\":0,\"minhumidity\":0}]}}}";
        public static Forecast10Day Refresh() {
            return JsonConvert.DeserializeObject<Forecast10Day>(strTempResponse);
        }
    }
}
