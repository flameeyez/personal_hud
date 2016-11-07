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
    class Panel {
        private Vector2 _position;
        public Vector2 Position {
            get { return _position; }
            set {
                _position = value;
                RecalculateLayout();
            }
        }
        private double _width;
        private double _height;
        private CanvasTextLayout _titleTextLayout;
        public List<string> Strings = new List<string>();

        // divider bar
        private Vector2 _barLeft;
        private Vector2 _barRight;

        private Vector2 _titlePosition;
        private Vector2 _stringsPosition;

        private Color _backgroundColor;
        private Rect _backgroundRect;

        private static float _PADDING = 5.0f;

        public Panel(CanvasDevice device, Vector2 position, double width, double height, string title, Color backgroundColor) {
            _width = width;
            _height = height;
            _backgroundColor = backgroundColor;
            _titleTextLayout = new CanvasTextLayout(device, title, Statics.Arial14NoWrap, 0, 0);

            Position = position;
        }

        private void RecalculateLayout() {
            _backgroundRect = new Rect(Position.X, Position.Y, _width, _height);
            _titlePosition = new Vector2(Position.X + _PADDING, Position.Y + _PADDING);
            _barLeft = new Vector2(Position.X, _titlePosition.Y + (float)_titleTextLayout.LayoutBounds.Height + _PADDING);
            _barRight = new Vector2(Position.X + (float)_width, _titlePosition.Y + (float)_titleTextLayout.LayoutBounds.Height + _PADDING);
            _stringsPosition = new Vector2(Position.X + _PADDING, _titlePosition.Y + (float)_titleTextLayout.LayoutBounds.Height + _PADDING * 3);
        }

        public void Draw(CanvasAnimatedDrawEventArgs args, bool bMouseOver) {
            DrawBackground(args, bMouseOver);
            DrawBorder(args);
            DrawTitle(args);
            DrawStrings(args);
        }

        private void DrawBackground(CanvasAnimatedDrawEventArgs args, bool bMouseOver) {
            args.DrawingSession.FillRectangle(new Rect(Position.X, Position.Y, _width, _height), bMouseOver ? Colors.Green : _backgroundColor);
        }

        private void DrawBorder(CanvasAnimatedDrawEventArgs args) {
            args.DrawingSession.DrawRoundedRectangle(new Rect(Position.X, Position.Y, _width, _height), 1, 1, Colors.White);
        }

        private void DrawTitle(CanvasAnimatedDrawEventArgs args) {
            args.DrawingSession.DrawTextLayout(_titleTextLayout, _titlePosition, Colors.White);
            args.DrawingSession.DrawLine(_barLeft, _barRight, Colors.White);
        }

        private void DrawStrings(CanvasAnimatedDrawEventArgs args) {
            float y = _stringsPosition.Y;
            foreach(string str in Strings) {
                args.DrawingSession.DrawText(str, new Vector2(_stringsPosition.X, y), Colors.White, Statics.Arial12NoWrap);
                y += 20.0f;
            }
        }

        public void Update(CanvasAnimatedUpdateEventArgs args) {

        }

        public bool HitTest(int x, int y) {
            if(Position.X > x) { return false; }
            if(Position.X + _width < x) { return false; }
            if(Position.Y > y) { return false; }
            if(Position.Y + _height < y) { return false; }
            return true;
        }
    }
}
