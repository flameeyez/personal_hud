using Microsoft.Graphics.Canvas;
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
    }
}
