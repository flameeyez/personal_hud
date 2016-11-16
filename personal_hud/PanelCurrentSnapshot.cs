using Microsoft.Graphics.Canvas;
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
    class PanelCurrentSnapshot : Panel {
        public PanelCurrentSnapshot(CanvasDevice device, Vector2 position, double width, double height, string title, Color backgroundColor)
            : base(device, position, width, height, title, backgroundColor) { }

        public override void Draw(CanvasAnimatedDrawEventArgs args, bool bMouseOver) {

        }

        public override void Update(CanvasAnimatedUpdateEventArgs args) {
            throw new NotImplementedException();
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
                args.DrawingSession.DrawText(str, new Vector2(_stringsPosition.X, y), Colors.White, Statics.PressStart2P12NoWrap);
                y += 20.0f;
            }
        }
    }
}
