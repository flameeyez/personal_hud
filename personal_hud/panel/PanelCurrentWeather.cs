using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.Text;
using Microsoft.Graphics.Canvas.UI.Xaml;
using personal_hud.current_weather;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI;

namespace personal_hud {
    class PanelCurrentWeather : Panel {
        private PanelString _title;
        private PanelString _lastUpdated;

        // top divider bar
        protected Vector2 _barLeft;
        protected Vector2 _barRight;
        // bottom divider bar
        private Vector2 _bottomBarLeft;
        private Vector2 _bottomBarRight;

        private Vector2 timeStringPosition;

        public PanelCurrentWeather(CanvasDevice device, Vector2 position, double width, double height)
            : base(device, position, width, height) {
            _backgroundColor = Color.FromArgb(255, 0, 0, 128);
            RefreshData();
        }

        public override void RefreshData() {
            if(WeatherData.LastUpdate > DataSourceLastUpdated) {
                DataSourceLastUpdated = WeatherData.LastUpdate;

                byte red = (byte)Statics.r.Next(200);
                byte green = (byte)Statics.r.Next(200);
                byte blue = (byte)Statics.r.Next(200);
                _backgroundColor = Color.FromArgb(255, red, green, blue);

                _title = new PanelString(_device, WeatherData.Current.Current_Observation.Display_Location.Full, Fonts.PressStart2P14NoWrap);
                _lastUpdated = new PanelString(_device, WeatherData.Current.Current_Observation.Observation_Time, Fonts.PressStart2P12NoWrap);
                RecalculateLayout();
            }
        }

        protected override void RecalculateLayout() {
            base.RecalculateLayout();
            _title.Position = new Vector2(Position.X + _PADDING, Position.Y + _PADDING);

            if (_title != null) {
                _barLeft = new Vector2(PanelBoundaryLeft, _title.Position.Y + (float)_title.Height + _PADDING);
                _barRight = new Vector2(PanelBoundaryRight, _title.Position.Y + (float)_title.Height + _PADDING);
            }

            CanvasTextLayout tempLayout = new CanvasTextLayout(_device, DateTime.Now.ToString("hh:mm.ss tt"), Fonts.PressStart2P12NoWrap, 0, 0);
            double layoutWidth = tempLayout.LayoutBounds.Width;
            double layoutHeight = tempLayout.LayoutBounds.Height;

            _lastUpdated.Position = new Vector2(PanelBoundaryLeft + _PADDING, PanelBoundaryBottom - _PADDING - (float)layoutHeight);
            timeStringPosition = new Vector2(PanelBoundaryRight - _PADDING - (float)layoutWidth, PanelBoundaryBottom - _PADDING - (float)layoutHeight);
            _bottomBarLeft = new Vector2(PanelBoundaryLeft, timeStringPosition.Y - _PADDING);
            _bottomBarRight = new Vector2(PanelBoundaryRight, timeStringPosition.Y - _PADDING);
        }

        public override void Draw(CanvasAnimatedDrawEventArgs args, Point mouseCoordinates) {
            DrawBackground(args, mouseCoordinates);
            DrawBorder(args);
            DrawTitle(args);
            DrawBars(args);
            DrawCurrentTime(args);
            DrawStrings(args);

            float y = _barRight.Y + _PADDING;
            args.DrawingSession.DrawText("Current temperature: " + WeatherData.Current.Current_Observation.Temperature_String, new Vector2(PanelBoundaryLeft + _PADDING, y), Colors.White, Fonts.PressStart2P12NoWrap);
            y += 20;
            args.DrawingSession.DrawText("Feels like: " + WeatherData.Current.Current_Observation.FeelsLike_String, new Vector2(PanelBoundaryLeft + _PADDING, y), Colors.White, Fonts.PressStart2P12NoWrap);
            y += 20;
            args.DrawingSession.DrawText("Relative humidity: " + WeatherData.Current.Current_Observation.Relative_Humidity, new Vector2(PanelBoundaryLeft + _PADDING, y), Colors.White, Fonts.PressStart2P12NoWrap);
            y += 20;
            args.DrawingSession.DrawText("Conditions: " + WeatherData.Current.Current_Observation.Icon, new Vector2(PanelBoundaryLeft + _PADDING, y), Colors.White, Fonts.PressStart2P12NoWrap);
            y += 20;
            args.DrawingSession.DrawText("Wind: " + WeatherData.Current.Current_Observation.Wind_String, new Vector2(PanelBoundaryLeft + _PADDING, y), Colors.White, Fonts.PressStart2P12NoWrap);
            y += 20;
            args.DrawingSession.DrawText("Precipitation (last hour): " + WeatherData.Current.Current_Observation.Precip_1hr_In + " in", new Vector2(PanelBoundaryLeft + _PADDING, y), Colors.White, Fonts.PressStart2P12NoWrap);
            y += 20;
            args.DrawingSession.DrawText("Precipitation (day): " + WeatherData.Current.Current_Observation.Precip_Today_In + " in", new Vector2(PanelBoundaryLeft + _PADDING, y), Colors.White, Fonts.PressStart2P12NoWrap);
            y += 20;
            args.DrawingSession.DrawText("Time since last data check: " + WeatherData.TimeSinceLastDataCheck, new Vector2(PanelBoundaryLeft + _PADDING, y), Colors.White, Fonts.PressStart2P12NoWrap);
            y += 20;
            args.DrawingSession.DrawText("Time until next data check: " + WeatherData.TimeUntilNextDataCheck, new Vector2(PanelBoundaryLeft + _PADDING, y), Colors.White, Fonts.PressStart2P12NoWrap);
        }

        public override void Update(CanvasAnimatedUpdateEventArgs args) {
            base.Update(args);
        }

        private void DrawStrings(CanvasAnimatedDrawEventArgs args) {
            _lastUpdated.Draw(args);
        }

        private void DrawBars(CanvasAnimatedDrawEventArgs args) {
            args.DrawingSession.DrawLine(_barLeft, _barRight, Colors.White);
            args.DrawingSession.DrawLine(_bottomBarLeft, _bottomBarRight, Colors.White);
        }

        private void DrawCurrentTime(CanvasAnimatedDrawEventArgs args) {
            args.DrawingSession.DrawText(DateTime.Now.ToString("hh:mm.ss tt"), timeStringPosition, Colors.White, Fonts.PressStart2P12NoWrap);
        }

        private void DrawTitle(CanvasAnimatedDrawEventArgs args) {
            _title.Draw(args);
        }
    }
}
