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
        protected CanvasDevice _device;

        protected Vector2 _position;
        public Vector2 Position {
            get { return _position; }
            set { _position = value; }
        }

        protected float PanelBoundaryTop { get { return Position.Y; } }
        protected float PanelBoundaryBottom { get { return Position.Y + (float)_height; } }
        protected float PanelBoundaryLeft { get { return Position.X; } }
        protected float PanelBoundaryRight { get { return Position.X + (float)_width; } }

        protected double _width;
        protected double _height;

        protected Color _backgroundColor;
        protected Rect _backgroundRect;

        public static float _PADDING = 5.0f;

        public Panel(CanvasDevice device, Vector2 position, double width, double height) {
            _device = device;
            _width = width;
            _height = height;
            Position = position;
        }

        protected virtual void RecalculateLayout() {
            _backgroundRect = new Rect(Position.X, Position.Y, _width, _height);
        }

        public virtual void Draw(CanvasAnimatedDrawEventArgs args, bool bMouseOver) {
            DrawBackground(args, bMouseOver);
            DrawBorder(args);
        }
        public abstract void Update(CanvasAnimatedUpdateEventArgs args);
        public abstract void RefreshWeatherDataObjects(WeatherData weatherData);

        protected void DrawBackground(CanvasAnimatedDrawEventArgs args, bool bMouseOver) {
            args.DrawingSession.FillRectangle(_backgroundRect, bMouseOver ? Colors.Green : _backgroundColor);
        }

        protected void DrawBorder(CanvasAnimatedDrawEventArgs args) {
            args.DrawingSession.DrawRoundedRectangle(new Rect(Position.X, Position.Y, _width, _height), 1, 1, Colors.White);
        }

        public bool HitTest(int x, int y) {
            if (PanelBoundaryLeft > x) { return false; }
            if (PanelBoundaryRight < x) { return false; }
            if (PanelBoundaryTop > y) { return false; }
            if (PanelBoundaryBottom < y) { return false; }
            return true;
        }
    }
}
