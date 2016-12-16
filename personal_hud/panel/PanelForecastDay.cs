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
        private int _dayIndex;

        private PanelString _weekday;
        private PanelString _monthDay;
        private PanelString _temperatureHigh;
        private PanelString _temperatureLow;

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

        public PanelForecastDay(CanvasDevice device, Vector2 position, double width, double height, int dayIndex) : base(device, position, width, height) {
            _backgroundColor = Color.FromArgb(255, 0, 0, 128);
            _dayIndex = dayIndex;
            RefreshData();
        }

        public override void RefreshData() {
            if (WeatherData.LastUpdate > DataSourceLastUpdated) {
                DataSourceLastUpdated = WeatherData.LastUpdate;

                byte red = (byte)Statics.r.Next(200);
                byte green = (byte)Statics.r.Next(200);
                byte blue = (byte)Statics.r.Next(200);
                _backgroundColor = Color.FromArgb(255, red, green, blue);

                SimpleForecastDay simpleForecastDay = WeatherData.Forecast.Forecast.SimpleForecast.ForecastDay[_dayIndex];
                TxtForecastDay txtForecastDay = WeatherData.Forecast.Forecast.Txt_Forecast.ForecastDay[_dayIndex];

                _weekday = new PanelString(_device, simpleForecastDay.Date.Weekday, Fonts.PressStart2P14NoWrap);
                _weekday.Position = new Vector2(Position.X + _PADDING, Position.Y + _PADDING);

                _monthDay = new PanelString(_device, simpleForecastDay.Date.Month + "/" + simpleForecastDay.Date.Day, Fonts.PressStart2P14NoWrap);
                float x = Position.X + (float)_width - _PADDING - (float)_monthDay.Width;
                _monthDay.Position = new Vector2(x, Position.Y + _PADDING);

                _barLeft = new Vector2(Position.X, _weekday.Position.Y + (float)_weekday.Height + _PADDING);
                _barRight = new Vector2(Position.X + (float)_width, _weekday.Position.Y + (float)_weekday.Height + _PADDING);

                _temperatureHigh = new PanelString(_device, "H:" + simpleForecastDay.High.Fahrenheit + "°", Fonts.PressStart2P12NoWrap);
                float y = Position.Y + (float)_height - _PADDING - (float)_temperatureHigh.Height;
                _temperatureHigh.Position = new Vector2(Position.X + _PADDING, y);

                _temperatureLow = new PanelString(_device, "L:" + simpleForecastDay.Low.Fahrenheit + "°", Fonts.PressStart2P12NoWrap);
                x = Position.X + (float)_width - _PADDING - (float)_temperatureLow.Width;
                y = Position.Y + (float)_height - _PADDING - (float)_temperatureLow.Height;
                _temperatureLow.Position = new Vector2(x, y);

                // set sprite
                _spriteRect = new Rect(X1, Y1, _widthThird, _heightThird);
                CanvasBitmap bitmap = null;
                if (WeatherBitmaps.WeatherTypeToBitmap.TryGetValue(simpleForecastDay.Icon, out bitmap)) {
                    // consider caching and cloning
                    _sprite = new AnimatedSprite(bitmap, new Vector2(X1, Y1), _widthThird, _heightThird);
                }

                RecalculateLayout();
            }
        }

        public override void Draw(CanvasAnimatedDrawEventArgs args, Point mouseCoordinates) {
            base.Draw(args, mouseCoordinates);
            DrawTextLayouts(args);
            DrawBar(args);
            DrawBitmap(args);
        }

        private void DrawBar(CanvasAnimatedDrawEventArgs args) {
            args.DrawingSession.DrawLine(_barLeft, _barRight, Colors.White);
        }

        private void DrawTextLayouts(CanvasAnimatedDrawEventArgs args) {
            _weekday.Draw(args);
            _monthDay.Draw(args);
            _temperatureHigh.Draw(args);
            _temperatureLow.Draw(args);
        }

        private void DrawBitmap(CanvasAnimatedDrawEventArgs args) {
            if (_sprite != null) { _sprite.Draw(args); }
        }

        public override void Update(CanvasAnimatedUpdateEventArgs args) {
            base.Update(args);
            if (_sprite != null) { _sprite.Update(args); }
        }
    }
}
