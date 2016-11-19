using Microsoft.Graphics.Canvas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personal_hud {
    static class Weather {
        public static CanvasBitmap CanvasBitmapSun { get; set; }
        public static CanvasBitmap CanvasBitmapCloud { get; set; }
        public static CanvasBitmap CanvasBitmapRain { get; set; }
        public static CanvasBitmap CanvasBitmapChanceRain { get; set; }
        public static CanvasBitmap CanvasBitmapLightning { get; set; }
        public static CanvasBitmap CanvasBitmapPartlyCloudy { get; set; }
        public static CanvasBitmap CanvasBitmapSnow { get; set; }
        public static CanvasBitmap CanvasBitmapChanceSnow { get; set; }

        public static Dictionary<string, CanvasBitmap> WeatherTypeToBitmap = new Dictionary<string, CanvasBitmap>();

        static Weather() {
            //WeatherTypeToBitmap.Add(WEATHER_TYPE.SUNNY, CanvasBitmapSun);
            //WeatherTypeToBitmap.Add(WEATHER_TYPE.CLOUDY, CanvasBitmapCloud);
            
            //WeatherTypeToBitmap.Add(WEATHER_TYPE.SNOW, CanvasBitmapSnow);
        }
    }
}
