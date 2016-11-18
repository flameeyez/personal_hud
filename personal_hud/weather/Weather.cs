using Microsoft.Graphics.Canvas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personal_hud {
    enum WEATHER_TYPE {
        SUNNY,
        CLOUDY,
        RAINY,
        STORMY,
        PARTLY_CLOUDY,
        SNOW
    }

    static class Weather {
        public static CanvasBitmap CanvasBitmapSun { get; set; }
        public static CanvasBitmap CanvasBitmapCloud { get; set; }
        public static CanvasBitmap CanvasBitmapRain { get; set; }
        public static CanvasBitmap CanvasBitmapLightning { get; set; }
        public static CanvasBitmap CanvasBitmapPartlyCloudy { get; set; }
        public static CanvasBitmap CanvasBitmapSnow { get; set; }

        public static Dictionary<WEATHER_TYPE, CanvasBitmap> WeatherTypeToBitmap = new Dictionary<WEATHER_TYPE, CanvasBitmap>();

        static Weather() {
            WeatherTypeToBitmap.Add(WEATHER_TYPE.SUNNY, CanvasBitmapSun);
            WeatherTypeToBitmap.Add(WEATHER_TYPE.CLOUDY, CanvasBitmapCloud);
            WeatherTypeToBitmap.Add(WEATHER_TYPE.RAINY, CanvasBitmapRain);
            WeatherTypeToBitmap.Add(WEATHER_TYPE.STORMY, CanvasBitmapLightning);
            WeatherTypeToBitmap.Add(WEATHER_TYPE.PARTLY_CLOUDY, CanvasBitmapPartlyCloudy);
            WeatherTypeToBitmap.Add(WEATHER_TYPE.SNOW, CanvasBitmapSnow);
        }
    }
}
