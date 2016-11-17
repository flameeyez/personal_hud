using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;

namespace personal_hud {
    class Sprite {
        protected CanvasBitmap _canvasBitmap;
        public Vector2 Position { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }

        public Sprite(CanvasBitmap canvasBitmap, Vector2 position, double width, double height) {
            _canvasBitmap = canvasBitmap;
            Position = position;
            Width = width;
            Height = height;
        }

        public virtual void Draw(CanvasAnimatedDrawEventArgs args) {
            args.DrawingSession.DrawImage(_canvasBitmap, new Rect(Position.X, Position.Y, Width, Height));
        }

        public virtual void Update(CanvasAnimatedUpdateEventArgs args) {

        }
    }
}
