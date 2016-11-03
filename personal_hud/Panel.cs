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
            _position = position;
            _width = width;
            _height = height;
            _titleTextLayout = new CanvasTextLayout(device, title, Statics.Arial14NoWrap, 0, 0);

            _titlePosition = new Vector2(_position.X + _PADDING, _position.Y + _PADDING);
            _barLeft = new Vector2(position.X, _titlePosition.Y + (float)_titleTextLayout.LayoutBounds.Height + _PADDING);
            _barRight = new Vector2(position.X + (float)width, _titlePosition.Y + (float)_titleTextLayout.LayoutBounds.Height + _PADDING);
            _stringsPosition = new Vector2(_position.X + _PADDING, _titlePosition.Y + (float)_titleTextLayout.LayoutBounds.Height + _PADDING * 3);

            _backgroundRect = new Rect(_position.X, _position.Y, _width, _height);
            _backgroundColor = backgroundColor;
        }

        public void Draw(CanvasAnimatedDrawEventArgs args, bool bMouseOver) {
            DrawBackground(args, bMouseOver);
            DrawBorder(args);
            DrawTitle(args);
            DrawStrings(args);
        }

        private void DrawBackground(CanvasAnimatedDrawEventArgs args, bool bMouseOver) {
            args.DrawingSession.FillRectangle(_backgroundRect, bMouseOver ? Colors.Green : _backgroundColor);
        }

        private void DrawBorder(CanvasAnimatedDrawEventArgs args) {
            args.DrawingSession.DrawRoundedRectangle(_backgroundRect, 1, 1, Colors.White);
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
            if(_position.X > x) { return false; }
            if(_position.X + _width < x) { return false; }
            if(_position.Y > y) { return false; }
            if(_position.Y + _height < y) { return false; }
            return true;
        }
    }
}
