using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.Text;
using Microsoft.Graphics.Canvas.UI.Xaml;
using personal_hud.forecast;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI;

namespace personal_hud {
    class PanelForecastDay : Panel {
        private AnimatedSprite _sprite;
        private Rect _spriteRect;

        private CanvasTextLayout _weekdayStringTextLayout;
        private Vector2 _weekdayStringPosition;
        private CanvasTextLayout _monthDayStringTextLayout;
        private Vector2 _monthDayStringPosition;
        private CanvasTextLayout _temperatureHighTextLayout;
        private Vector2 _temperatureHighPosition;
        private CanvasTextLayout _temperatureLowTextLayout;
        private Vector2 _temperatureLowPosition;

        private Vector2 _barLeft;
        private Vector2 _barRight;

        // breaking panel up into third-scale grid
        private float X0 { get { return Position.X; } }
        private float X1 { get { return Position.X + (float)_width / 3; } }
        private float X2 { get { return Position.X + (float)_width * 2 / 3; } }
        private float Y0 { get { return Position.Y; } }
        private float Y1 { get { return Position.Y + (float)_height / 3; } }
        private float Y2 { get { return Position.Y + (float)_height * 2 / 3; } }
        private double _widthThird { get { return _width / 3; } }
        private double _heightThird { get { return _height / 3; } }

        public PanelForecastDay(CanvasDevice device, Vector2 position, double width, double height, TxtForecastDay txtForecastDay, SimpleForecastDay simpleForecastDay) : base(device, position, width, height) {
            _backgroundColor = Color.FromArgb(255, 0, 0, 128);

            _weekdayStringTextLayout = new CanvasTextLayout(device, simpleForecastDay.Date.Weekday, Fonts.PressStart2P14NoWrap, 0, 0);
            _weekdayStringPosition = new Vector2(position.X + _PADDING, position.Y + _PADDING);

            _monthDayStringTextLayout = new CanvasTextLayout(device, simpleForecastDay.Date.Month + "/" + simpleForecastDay.Date.Day, Fonts.PressStart2P14NoWrap, 0, 0);
            float x = Position.X + (float)_width - _PADDING - (float)_monthDayStringTextLayout.LayoutBounds.Width;
            _monthDayStringPosition = new Vector2(x, position.Y + _PADDING);

            _barLeft = new Vector2(Position.X, _weekdayStringPosition.Y + (float)_weekdayStringTextLayout.LayoutBounds.Height + _PADDING);
            _barRight = new Vector2(Position.X + (float)_width, _weekdayStringPosition.Y + (float)_weekdayStringTextLayout.LayoutBounds.Height + _PADDING);

            _temperatureHighTextLayout = new CanvasTextLayout(device, "H:" + simpleForecastDay.High.Fahrenheit + "°", Fonts.PressStart2P12NoWrap, 0, 0);
            float y = position.Y + (float)height - _PADDING - (float)_temperatureHighTextLayout.LayoutBounds.Height;
            _temperatureHighPosition = new Vector2(position.X + _PADDING, y);

            _temperatureLowTextLayout = new CanvasTextLayout(device, "L:" + simpleForecastDay.Low.Fahrenheit + "°", Fonts.PressStart2P12NoWrap, 0, 0);
            x = Position.X + (float)_width - _PADDING - (float)_temperatureLowTextLayout.LayoutBounds.Width;
            y = position.Y + (float)_height - _PADDING - (float)_temperatureLowTextLayout.LayoutBounds.Height;
            _temperatureLowPosition = new Vector2(x, y);

            // set sprite
            _spriteRect = new Rect(X1, Y1, _widthThird, _heightThird);
            CanvasBitmap bitmap = null;
            if (Weather.WeatherTypeToBitmap.TryGetValue(simpleForecastDay.Icon, out bitmap)) {
                // consider caching and cloning
                _sprite = new AnimatedSprite(bitmap, new Vector2(X1, Y1), _widthThird, _heightThird);
            }

            RecalculateLayout();
        }

        public override void Draw(CanvasAnimatedDrawEventArgs args, bool bMouseOver) {
            base.Draw(args, bMouseOver);
            DrawTextLayouts(args);
            DrawBar(args);
            DrawBitmap(args);
        }

        private void DrawBar(CanvasAnimatedDrawEventArgs args) {
            args.DrawingSession.DrawLine(_barLeft, _barRight, Colors.White);
        }

        private void DrawTextLayouts(CanvasAnimatedDrawEventArgs args) {
            if (_weekdayStringTextLayout != null) { args.DrawingSession.DrawTextLayout(_weekdayStringTextLayout, _weekdayStringPosition, Colors.White); }
            if (_monthDayStringTextLayout != null) { args.DrawingSession.DrawTextLayout(_monthDayStringTextLayout, _monthDayStringPosition, Colors.White); }
            if (_temperatureHighTextLayout != null) { args.DrawingSession.DrawTextLayout(_temperatureHighTextLayout, _temperatureHighPosition, Colors.White); }
            if (_temperatureLowTextLayout != null) { args.DrawingSession.DrawTextLayout(_temperatureLowTextLayout, _temperatureLowPosition, Colors.White); }
        }

        private void DrawBitmap(CanvasAnimatedDrawEventArgs args) {
            if (_sprite != null) { _sprite.Draw(args); }
        }

        public override void Update(CanvasAnimatedUpdateEventArgs args) {
            if (_sprite != null) { _sprite.Update(args); }
        }
    }
}
