﻿using Microsoft.Graphics.Canvas.UI;
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
using Microsoft.Graphics.Canvas;

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

        AnimatedSprite sun;

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
            sun.Draw(args);
        }

        private void canvasMain_Update(ICanvasAnimatedControl sender, CanvasAnimatedUpdateEventArgs args) {
            sun.Update(args);
        }

        private void canvasMain_CreateResources(CanvasAnimatedControl sender, CanvasCreateResourcesEventArgs args) {
            try {
                currentWeather = CurrentWeather.Refresh();
                currentForecast10Day = Forecast10Day.Refresh();

                Random r = new Random(DateTime.Now.Millisecond);

                byte red = (byte)r.Next(150);
                byte green = (byte)r.Next(150);
                byte blue = (byte)r.Next(150);
                Color color = Color.FromArgb(255, red, green, blue);

                //Panel panelCurrentWeather = new Panel(canvasMain.Device, new Vector2(100, 100), 300, 300, "Current Weather", color);
                //panelCurrentWeather.Strings.Add(currentWeather.ToString());
                //Panels.Add(panelCurrentWeather);

                //int clientwidth = 1920;

                //int width = 400;
                //int height = 200;
                //int padding = 10;

                //int nNumPanelsX = Math.Min(clientwidth / width, 7);
                //int nPanelsWidth = nNumPanelsX * (width + padding);

                //int initialx = (clientwidth - nPanelsWidth) / 2;
                //int x = initialx;
                //int y = 300;

                //int nCurrentPanelX = 0;

                //Panels.Add(new Panel(canvasMain.Device, new Vector2(x, y), width, height, currentForecast10Day.Forecast.SimpleForecast.ForecastDay[0].DateFull, color));
                //x += width + padding; if (++nCurrentPanelX == nNumPanelsX) { x = initialx; y += height + padding; nCurrentPanelX = 0; }
                //Panels.Add(new Panel(canvasMain.Device, new Vector2(x, y), width, height, currentForecast10Day.Forecast.SimpleForecast.ForecastDay[1].DateFull, color));
                //x += width + padding; if(++nCurrentPanelX == nNumPanelsX) { x = initialx; y += height + padding; nCurrentPanelX = 0; }
                //Panels.Add(new Panel(canvasMain.Device, new Vector2(x, y), width, height, currentForecast10Day.Forecast.SimpleForecast.ForecastDay[2].DateFull, color));
                //x += width + padding; if(++nCurrentPanelX == nNumPanelsX) { x = initialx; y += height + padding; nCurrentPanelX = 0; }
                //Panels.Add(new Panel(canvasMain.Device, new Vector2(x, y), width, height, currentForecast10Day.Forecast.SimpleForecast.ForecastDay[3].DateFull, color));
                //x += width + padding; if(++nCurrentPanelX == nNumPanelsX) { x = initialx; y += height + padding; nCurrentPanelX = 0; }
                //Panels.Add(new Panel(canvasMain.Device, new Vector2(x, y), width, height, currentForecast10Day.Forecast.SimpleForecast.ForecastDay[4].DateFull, color));
                //x += width + padding; if(++nCurrentPanelX == nNumPanelsX) { x = initialx; y += height + padding; nCurrentPanelX = 0; }
                //Panels.Add(new Panel(canvasMain.Device, new Vector2(x, y), width, height, currentForecast10Day.Forecast.SimpleForecast.ForecastDay[5].DateFull, color));
                //x += width + padding; if(++nCurrentPanelX == nNumPanelsX) { x = initialx; y += height + padding; nCurrentPanelX = 0; }
                //Panels.Add(new Panel(canvasMain.Device, new Vector2(x, y), width, height, currentForecast10Day.Forecast.SimpleForecast.ForecastDay[6].DateFull, color));
                //x += width + padding; if(++nCurrentPanelX == nNumPanelsX) { x = initialx; y += height + padding; nCurrentPanelX = 0; }
                //Panels.Add(new Panel(canvasMain.Device, new Vector2(x, y), width, height, currentForecast10Day.Forecast.SimpleForecast.ForecastDay[7].DateFull, color));
                //x += width + padding; if(++nCurrentPanelX == nNumPanelsX) { x = initialx; y += height + padding; nCurrentPanelX = 0; }
                //Panels.Add(new Panel(canvasMain.Device, new Vector2(x, y), width, height, currentForecast10Day.Forecast.SimpleForecast.ForecastDay[8].DateFull, color));
                //x += width + padding; if(++nCurrentPanelX == nNumPanelsX) { x = initialx; y += height + padding; nCurrentPanelX = 0; }
                //Panels.Add(new Panel(canvasMain.Device, new Vector2(x, y), width, height, currentForecast10Day.Forecast.SimpleForecast.ForecastDay[9].DateFull, color));
                //x += width + padding; if(++nCurrentPanelX == nNumPanelsX) { x = initialx; y += height + padding; nCurrentPanelX = 0; }
            }
            catch (Exception exception) {
                throw;
            }

            args.TrackAsyncAction(CreateResourcesAsync(sender).AsAsyncAction());
        }

        private async Task CreateResourcesAsync(CanvasAnimatedControl sender) {
            CanvasBitmap bitmapSun = await CanvasBitmap.LoadAsync(sender, "images/sun.png");
            sun = new AnimatedSprite(bitmapSun, new Vector2(200, 200), 256, 256, 16, 200.0);
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
