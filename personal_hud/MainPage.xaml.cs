using Microsoft.Graphics.Canvas.UI;
using Microsoft.Graphics.Canvas.UI.Xaml;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

using personal_hud.current_weather;
using personal_hud.forecast;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace personal_hud {
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page {
        List<Panel> Panels = new List<Panel>();
        CurrentWeather currentWeather;
        Forecast10Day currentForecast10Day;
        Panel currentPanel;

        int mouseX = 0;
        int mouseY = 0;
        int currentPanelOffsetX = 0;
        int currentPanelOffsetY = 0;

        public MainPage() {
            this.InitializeComponent();
        }

        private async void canvasMain_Draw(ICanvasAnimatedControl sender, CanvasAnimatedDrawEventArgs args) {
            for (int i = Panels.Count - 1; i >= 0; i--) {
                Panels[i].Draw(args, Panels[i].HitTest(mouseX, mouseY));
            }

            args.DrawingSession.DrawText(mouseX.ToString() + ", " + mouseY.ToString(), new Vector2(1500, 10), Colors.White);
        }

        private void canvasMain_Update(ICanvasAnimatedControl sender, CanvasAnimatedUpdateEventArgs args) {

        }

        private void canvasMain_CreateResources(CanvasAnimatedControl sender, CanvasCreateResourcesEventArgs args) {
            try {
                currentWeather = CurrentWeather.Refresh();
                currentForecast10Day = Forecast10Day.Refresh();

                int nStringIndex = 1;
                Random r = new Random(DateTime.Now.Millisecond);

                byte red = (byte)r.Next(150);
                byte green = (byte)r.Next(150);
                byte blue = (byte)r.Next(150);
                Color color = Color.FromArgb(255, red, green, blue);

                Panel panelCurrentWeather = new Panel(canvasMain.Device, new Vector2(100, 100), 300, 300, "Current Weather", color);
                panelCurrentWeather.Strings.Add(currentWeather.ToString());
                Panels.Add(panelCurrentWeather);

                int x = 100;
                int y = 500;
                int width = 200;
                int height = 300;
                int padding = 10;

                Panel panelForecastDay0 = new Panel(canvasMain.Device, new Vector2(x, y), width, height, "Forecast Day 0", color);
                panelForecastDay0.Strings.Add(currentForecast10Day.Forecast.SimpleForecast.ForecastDay[0].ToString());
                Panels.Add(panelForecastDay0);
                x += width + padding;

                Panel panelForecastDay1 = new Panel(canvasMain.Device, new Vector2(x, y), width, height, "Forecast Day 1", color);
                panelForecastDay1.Strings.Add(currentForecast10Day.Forecast.SimpleForecast.ForecastDay[1].ToString());
                Panels.Add(panelForecastDay1);
                x += width + padding;

                Panel panelForecastDay2 = new Panel(canvasMain.Device, new Vector2(x, y), width, height, "Forecast Day 2", color);
                panelForecastDay2.Strings.Add(currentForecast10Day.Forecast.SimpleForecast.ForecastDay[2].ToString());
                Panels.Add(panelForecastDay2);
                x += width + padding;

                Panel panelForecastDay3 = new Panel(canvasMain.Device, new Vector2(x, y), width, height, "Forecast Day 3", color);
                panelForecastDay3.Strings.Add(currentForecast10Day.Forecast.SimpleForecast.ForecastDay[3].ToString());
                Panels.Add(panelForecastDay3);
                x += width + padding;

                Panel panelForecastDay4 = new Panel(canvasMain.Device, new Vector2(x, y), width, height, "Forecast Day 4", color);
                panelForecastDay4.Strings.Add(currentForecast10Day.Forecast.SimpleForecast.ForecastDay[4].ToString());
                Panels.Add(panelForecastDay4);
                x += width + padding;

                Panel panelForecastDay5 = new Panel(canvasMain.Device, new Vector2(x, y), width, height, "Forecast Day 5", color);
                panelForecastDay5.Strings.Add(currentForecast10Day.Forecast.SimpleForecast.ForecastDay[5].ToString());
                Panels.Add(panelForecastDay5);
                x += width + padding;

                Panel panelForecastDay6 = new Panel(canvasMain.Device, new Vector2(x, y), width, height, "Forecast Day 6", color);
                panelForecastDay6.Strings.Add(currentForecast10Day.Forecast.SimpleForecast.ForecastDay[6].ToString());
                Panels.Add(panelForecastDay6);
                x += width + padding;
            }
            catch (Exception exception) {
                throw;
            }
        }

        private void canvasMain_PointerMoved(object sender, PointerRoutedEventArgs e) {
            PointerPoint p = e.GetCurrentPoint(canvasMain);
            mouseX = (int)p.Position.X;
            mouseY = (int)p.Position.Y;

            if (currentPanel != null) {
                currentPanel.Position = new Vector2(mouseX - currentPanelOffsetX, mouseY - currentPanelOffsetY);
            }
        }

        private void canvasMain_PointerPressed(object sender, PointerRoutedEventArgs e) {
            PointerPoint p = e.GetCurrentPoint(canvasMain);
            int x = (int)p.Position.X;
            int y = (int)p.Position.Y;

            for (int i = 0; i < Panels.Count; i++) {
                if (Panels[i].HitTest(x, y)) {
                    currentPanel = Panels[i];
                    currentPanelOffsetX = mouseX - (int)currentPanel.Position.X;
                    currentPanelOffsetY = mouseY - (int)currentPanel.Position.Y;

                    Panels.RemoveAt(i);
                    Panels.Insert(0, currentPanel);
                    return;
                }
            }
        }

        private void canvasMain_PointerReleased(object sender, PointerRoutedEventArgs e) {
            currentPanel = null;
        }
    }
}
