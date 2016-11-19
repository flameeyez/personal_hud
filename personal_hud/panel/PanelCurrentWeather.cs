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
        private CurrentWeather _currentWeatherData;

        private CanvasTextLayout _titleTextLayout;
        private Vector2 _titlePosition;

        // divider bar
        protected Vector2 _barLeft;
        protected Vector2 _barRight;

        private Vector2 timeStringPosition;

        public PanelCurrentWeather(CanvasDevice device, Vector2 position, double width, double height)
            : base(device, position, width, height) {

            RefreshWeatherData();
            _backgroundColor = Color.FromArgb(255, 0, 0, 128);
            _titleTextLayout = new CanvasTextLayout(device, _currentWeatherData.Current_Observation.Display_Location.Full, Fonts.PressStart2P14NoWrap, 0, 0);
            RecalculateLayout();
        }

        protected override void RecalculateLayout() {
            base.RecalculateLayout();
            _titlePosition = new Vector2(Position.X + _PADDING, Position.Y + _PADDING);

            if(_titleTextLayout != null) {
                _barLeft = new Vector2(Position.X, _titlePosition.Y + (float)_titleTextLayout.LayoutBounds.Height + _PADDING);
                _barRight = new Vector2(Position.X + (float)_width, _titlePosition.Y + (float)_titleTextLayout.LayoutBounds.Height + _PADDING);
            }

            timeStringPosition = new Vector2(Position.X + _PADDING, _barLeft.Y + _PADDING);
        }

        public override void Draw(CanvasAnimatedDrawEventArgs args, bool bMouseOver) {
            DrawBackground(args, bMouseOver);
            DrawBorder(args);
            DrawTitle(args);
            DrawCurrentTime(args);
        }

        public override void Update(CanvasAnimatedUpdateEventArgs args) {

        }

        private void DrawCurrentTime(CanvasAnimatedDrawEventArgs args) {
            args.DrawingSession.DrawText(DateTime.Now.ToString("hh:mm.ss tt"), timeStringPosition, Colors.White);
        }


        private void DrawTitle(CanvasAnimatedDrawEventArgs args) {
            args.DrawingSession.DrawTextLayout(_titleTextLayout, _titlePosition, Colors.White);
            args.DrawingSession.DrawLine(_barLeft, _barRight, Colors.White);
        }

        public void RefreshWeatherData() {
            _currentWeatherData = CurrentWeather.Refresh();
        }
    }
}
