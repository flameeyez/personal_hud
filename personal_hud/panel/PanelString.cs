using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.Text;
using Microsoft.Graphics.Canvas.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;

namespace personal_hud {
    class PanelString {
        private CanvasTextLayout _textLayout;
        public Vector2 Position { get; set; }

        public double Width { get { return _textLayout.LayoutBounds.Width; } }
        public double Height { get { return _textLayout.LayoutBounds.Height; } }

        public PanelString(CanvasDevice device, string text, CanvasTextFormat format) {
            _textLayout = new CanvasTextLayout(device, text, format, 0, 0);
        }

        public void Draw(CanvasAnimatedDrawEventArgs args) {
            args.DrawingSession.DrawTextLayout(_textLayout, Position, Colors.White);
        }
    }
}
