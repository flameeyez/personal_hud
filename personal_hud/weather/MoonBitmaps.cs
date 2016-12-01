using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personal_hud {
    static class MoonBitmaps {
        public static CanvasBitmap MoonBitmapNew { get; set; }
        public static CanvasBitmap MoonBitmapWaxingCrescent { get; set; }
        public static CanvasBitmap MoonBitmapQuarter { get; set; }
        public static CanvasBitmap MoonBitmapWaxingGibbous { get; set; }
        public static CanvasBitmap MoonBitmapFull { get; set; }
        public static CanvasBitmap MoonBitmapWaningGibbous { get; set; }
        public static CanvasBitmap MoonBitmapLastQuarter { get; set; }
        public static CanvasBitmap MoonBitmapWaningCrescent { get; set; }

        public static Dictionary<MOON_PHASE, CanvasBitmap> MoonPhaseToBitmap = new Dictionary<MOON_PHASE, CanvasBitmap>();

        public async static Task Initialize(CanvasAnimatedControl sender) {
            MoonBitmapNew = await CanvasBitmap.LoadAsync(sender, "images/moon_new.png");
            MoonBitmapWaxingCrescent = await CanvasBitmap.LoadAsync(sender, "images/moon_waxing_crescent.png");
            MoonBitmapQuarter = await CanvasBitmap.LoadAsync(sender, "images/moon_first_quarter.png");
            MoonBitmapWaxingGibbous = await CanvasBitmap.LoadAsync(sender, "images/moon_waxing_gibbous.png");
            MoonBitmapFull = await CanvasBitmap.LoadAsync(sender, "images/moon_full.png");
            MoonBitmapWaningGibbous = await CanvasBitmap.LoadAsync(sender, "images/moon_waning_gibbous.png");
            MoonBitmapLastQuarter = await CanvasBitmap.LoadAsync(sender, "images/moon_last_quarter.png");
            MoonBitmapWaningCrescent = await CanvasBitmap.LoadAsync(sender, "images/moon_waning_crescent.png");

            MoonPhaseToBitmap.Add(MOON_PHASE.NEW, MoonBitmapNew);
            MoonPhaseToBitmap.Add(MOON_PHASE.WAXING_CRESCENT, MoonBitmapWaxingCrescent);
            MoonPhaseToBitmap.Add(MOON_PHASE.QUARTER, MoonBitmapQuarter);
            MoonPhaseToBitmap.Add(MOON_PHASE.WAXING_GIBBOUS, MoonBitmapWaxingGibbous);
            MoonPhaseToBitmap.Add(MOON_PHASE.FULL, MoonBitmapFull);
            MoonPhaseToBitmap.Add(MOON_PHASE.WANING_GIBBOUS, MoonBitmapWaningGibbous);
            MoonPhaseToBitmap.Add(MOON_PHASE.LAST_QUARTER, MoonBitmapLastQuarter);
            MoonPhaseToBitmap.Add(MOON_PHASE.WANING_CRESCENT, MoonBitmapWaningCrescent);
        }
    }
}
