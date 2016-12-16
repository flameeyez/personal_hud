using Microsoft.Graphics.Canvas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace personal_hud {
    class ViewWeatherCurrentAndForecast : View {
        private ViewWeatherCurrentAndForecast() { }
        public static ViewWeatherCurrentAndForecast Create(CanvasDevice device, int width, int height, int rightPanelWidth) {
            ViewWeatherCurrentAndForecast v = new ViewWeatherCurrentAndForecast();

            int nNumPanels = 7;

            int dayPanelWidth = (width - rightPanelWidth) / nNumPanels;
            int padding = (width - rightPanelWidth - dayPanelWidth * nNumPanels) / (nNumPanels - 1);
            while (padding < 5) {
                dayPanelWidth -= 1;
                padding = (width - rightPanelWidth - dayPanelWidth * nNumPanels) / (nNumPanels - 1);
            }

            int dayPanelHeight = dayPanelWidth;
            v.Width = dayPanelWidth * nNumPanels + padding * (nNumPanels - 1);

            float y = height - dayPanelWidth - Panel._PADDING;

            for (int i = 0; i < nNumPanels; i++) {
                Vector2 position = new Vector2(Panel._PADDING + (dayPanelWidth + padding) * i, y);
                v.Panels.Add(new PanelForecastDay(device, position, dayPanelWidth, dayPanelHeight, i));
            }

            v.Panels.Add(new PanelCurrentWeather(device, new Vector2(Panel._PADDING, Panel._PADDING), v.Width, height - Panel._PADDING * 3 - dayPanelHeight));
            return v;
        }
    }
}
