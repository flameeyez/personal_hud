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
            set {
                _position = value;
                RecalculateLayout();
            }
        }
        protected double _width;
        protected double _height;
        protected CanvasTextLayout _titleTextLayout;
        public List<string> Strings = new List<string>();

        // divider bar
        protected Vector2 _barLeft;
        protected Vector2 _barRight;

        protected Vector2 _titlePosition;
        protected Vector2 _stringsPosition;

        protected Color _backgroundColor;
        protected Rect _backgroundRect;

        protected static float _PADDING = 5.0f;

        public Panel(CanvasDevice device, Vector2 position, double width, double height, string title, Color backgroundColor) {
            _width = width;
            _height = height;
            _backgroundColor = backgroundColor;
            _titleTextLayout = new CanvasTextLayout(device, title, Statics.PressStart2P14NoWrap, 0, 0);

            Position = position;
        }

        protected void RecalculateLayout() {
            _backgroundRect = new Rect(Position.X, Position.Y, _width, _height);
            _titlePosition = new Vector2(Position.X + _PADDING, Position.Y + _PADDING);
            _barLeft = new Vector2(Position.X, _titlePosition.Y + (float)_titleTextLayout.LayoutBounds.Height + _PADDING);
            _barRight = new Vector2(Position.X + (float)_width, _titlePosition.Y + (float)_titleTextLayout.LayoutBounds.Height + _PADDING);
            _stringsPosition = new Vector2(Position.X + _PADDING, _titlePosition.Y + (float)_titleTextLayout.LayoutBounds.Height + _PADDING * 3);
        }

        public abstract void Draw(CanvasAnimatedDrawEventArgs args, bool bMouseOver);
        public abstract void Update(CanvasAnimatedUpdateEventArgs args);

        public bool HitTest(int x, int y) {
            if(Position.X > x) { return false; }
            if(Position.X + _width < x) { return false; }
            if(Position.Y > y) { return false; }
            if(Position.Y + _height < y) { return false; }
            return true;
        }
    }
}
