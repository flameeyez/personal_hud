using Microsoft.Graphics.Canvas.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Input;

namespace personal_hud {
    static class Statics {
        public static CanvasTextFormat Arial12Wrap;
        public static CanvasTextFormat Arial12NoWrap;

        public static CanvasTextFormat Arial14Wrap;
        public static CanvasTextFormat Arial14NoWrap;

        public static PointerPoint MouseCoordinates;

        static Statics() {
            Arial12Wrap = new CanvasTextFormat();
            Arial12Wrap.FontFamily = "Arial";
            Arial12Wrap.FontSize = 12;
            Arial12Wrap.WordWrapping = CanvasWordWrapping.Wrap;

            Arial12NoWrap = new CanvasTextFormat();
            Arial12NoWrap.FontFamily = "Arial";
            Arial12NoWrap.FontSize = 12;
            Arial12NoWrap.WordWrapping = CanvasWordWrapping.NoWrap;

            Arial14Wrap = new CanvasTextFormat();
            Arial14Wrap.FontFamily = "Arial";
            Arial14Wrap.FontSize = 14;
            Arial14Wrap.WordWrapping = CanvasWordWrapping.Wrap;

            Arial14NoWrap = new CanvasTextFormat();
            Arial14NoWrap.FontFamily = "Arial";
            Arial14NoWrap.FontSize = 14;
            Arial14NoWrap.WordWrapping = CanvasWordWrapping.NoWrap;
        }
    }
}
