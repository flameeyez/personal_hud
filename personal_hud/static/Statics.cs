using Microsoft.Graphics.Canvas.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Input;

namespace personal_hud {
    static class Statics {
        public static CanvasTextFormat PressStart2P12Wrap;
        public static CanvasTextFormat PressStart2P12NoWrap;

        public static CanvasTextFormat PressStart2P14Wrap;
        public static CanvasTextFormat PressStart2P14NoWrap;

        public static PointerPoint MouseCoordinates;

        static Statics() {
            PressStart2P12Wrap = new CanvasTextFormat();
            PressStart2P12Wrap.FontFamily = "Press Start 2P";
            PressStart2P12Wrap.FontSize = 12;
            PressStart2P12Wrap.WordWrapping = CanvasWordWrapping.Wrap;

            PressStart2P12NoWrap = new CanvasTextFormat();
            PressStart2P12NoWrap.FontFamily = "Press Start 2P";
            PressStart2P12NoWrap.FontSize = 12;
            PressStart2P12NoWrap.WordWrapping = CanvasWordWrapping.NoWrap;

            PressStart2P14Wrap = new CanvasTextFormat();
            PressStart2P14Wrap.FontFamily = "Press Start 2P";
            PressStart2P14Wrap.FontSize = 14;
            PressStart2P14Wrap.WordWrapping = CanvasWordWrapping.Wrap;

            PressStart2P14NoWrap = new CanvasTextFormat();
            PressStart2P14NoWrap.FontFamily = "Press Start 2P";
            PressStart2P14NoWrap.FontSize = 14;
            PressStart2P14NoWrap.WordWrapping = CanvasWordWrapping.NoWrap;
        }
    }
}
