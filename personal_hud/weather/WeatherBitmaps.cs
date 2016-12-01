using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personal_hud {
    static class WeatherBitmaps {
        public static CanvasBitmap CanvasBitmapSun { get; set; }
        public static CanvasBitmap CanvasBitmapCloud { get; set; }
        public static CanvasBitmap CanvasBitmapRain { get; set; }
        public static CanvasBitmap CanvasBitmapChanceRain { get; set; }
        public static CanvasBitmap CanvasBitmapLightning { get; set; }
        public static CanvasBitmap CanvasBitmapPartlyCloudy { get; set; }
        public static CanvasBitmap CanvasBitmapSnow { get; set; }
        public static CanvasBitmap CanvasBitmapChanceSnow { get; set; }

        public static Dictionary<string, CanvasBitmap> WeatherTypeToBitmap = new Dictionary<string, CanvasBitmap>();

        public async static Task Initialize(CanvasAnimatedControl sender) {
            CanvasBitmapSun = await CanvasBitmap.LoadAsync(sender, "images/sun.png");
            CanvasBitmapCloud = await CanvasBitmap.LoadAsync(sender, "images/cloud.png");
            CanvasBitmapRain = await CanvasBitmap.LoadAsync(sender, "images/rain.png");
            CanvasBitmapChanceRain = await CanvasBitmap.LoadAsync(sender, "images/chancerain.png");
            CanvasBitmapLightning = await CanvasBitmap.LoadAsync(sender, "images/lightning.png");
            CanvasBitmapPartlyCloudy = await CanvasBitmap.LoadAsync(sender, "images/partly_cloudy.png");
            CanvasBitmapSnow = await CanvasBitmap.LoadAsync(sender, "images/snow.png");
            CanvasBitmapChanceSnow = await CanvasBitmap.LoadAsync(sender, "images/chancesnow.png");

            WeatherTypeToBitmap.Add("chancerain", CanvasBitmapChanceRain);
            WeatherTypeToBitmap.Add("partlycloudy", CanvasBitmapPartlyCloudy);
            WeatherTypeToBitmap.Add("cloudy", CanvasBitmapCloud);
            WeatherTypeToBitmap.Add("mostlycloudy", CanvasBitmapCloud);
            WeatherTypeToBitmap.Add("rain", CanvasBitmapRain);
            WeatherTypeToBitmap.Add("tstorms", CanvasBitmapLightning);
            WeatherTypeToBitmap.Add("clear", CanvasBitmapSun);
            WeatherTypeToBitmap.Add("snow", CanvasBitmapSnow);
            WeatherTypeToBitmap.Add("chancesnow", CanvasBitmapChanceSnow);
        }
    }
}
