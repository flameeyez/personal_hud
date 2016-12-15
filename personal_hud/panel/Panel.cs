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

        private double _lastRefreshMilliseconds;
        protected DateTime DataSourceLastUpdated = DateTime.MinValue;

        public static float _PADDING = 5.0f;

        public Panel(CanvasDevice device, Vector2 position, double width, double height) {
            _device = device;
            _width = width;
            _height = height;
            Position = position;
            _lastRefreshMilliseconds = 0.0;
        }

        protected virtual void RecalculateLayout() {
            _backgroundRect = new Rect(Position.X, Position.Y, _width, _height);
        }

        public virtual void Draw(CanvasAnimatedDrawEventArgs args, Point mouseCoordinates) {
            DrawBackground(args, mouseCoordinates);
            DrawBorder(args);
        }
        public virtual void Update(CanvasAnimatedUpdateEventArgs args) {
            _lastRefreshMilliseconds += args.Timing.ElapsedTime.TotalMilliseconds;
            if(_lastRefreshMilliseconds >= Statics._panelRefreshThresholdMilliseconds) {
                _lastRefreshMilliseconds = 0.0;
                RefreshData();
            }
        }

        public abstract void RefreshData();

        protected void DrawBackground(CanvasAnimatedDrawEventArgs args, Point mouseCoordinates) {
            args.DrawingSession.FillRectangle(_backgroundRect, HitTest(mouseCoordinates) ? Colors.Green : _backgroundColor);
        }

        protected void DrawBorder(CanvasAnimatedDrawEventArgs args) {
            args.DrawingSession.DrawRoundedRectangle(new Rect(Position.X, Position.Y, _width, _height), 1, 1, Colors.White);
        }

        public bool HitTest(Point p) {
            if (PanelBoundaryLeft > p.X) { return false; }
            if (PanelBoundaryRight < p.X) { return false; }
            if (PanelBoundaryTop > p.Y) { return false; }
            if (PanelBoundaryBottom < p.Y) { return false; }
            return true;
        }
    }
}
