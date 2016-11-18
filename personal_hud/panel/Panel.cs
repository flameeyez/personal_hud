using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.Text;
using Microsoft.Graphics.Canvas.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI;

namespace personal_hud {
    abstract class Panel {
        protected Vector2 _position;
        public Vector2 Position {
            get { return _position; }
            set { _position = value; }
        }
        protected double _width;
        protected double _height;

        protected Color _backgroundColor;
        protected Rect _backgroundRect;

        protected static float _PADDING = 5.0f;

        public Panel(CanvasDevice device, Vector2 position, double width, double height) {
            _width = width;
            _height = height;
            Position = position;
        }

        protected virtual void RecalculateLayout() {
            _backgroundRect = new Rect(Position.X, Position.Y, _width, _height);
        }

        public abstract void Draw(CanvasAnimatedDrawEventArgs args, bool bMouseOver);
        public abstract void Update(CanvasAnimatedUpdateEventArgs args);

        public bool HitTest(int x, int y) {
            if (Position.X > x) { return false; }
            if (Position.X + _width < x) { return false; }
            if (Position.Y > y) { return false; }
            if (Position.Y + _height < y) { return false; }
            return true;
        }
    }
}
