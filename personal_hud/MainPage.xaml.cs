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
using Microsoft.Graphics.Canvas;
using Windows.UI.ViewManagement;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace personal_hud {
    public static class Debug {
        public static object Lock = new object();
    }
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page {
        List<Panel> Panels = new List<Panel>();
        List<AnimatedSprite> AnimatedSprites = new List<AnimatedSprite>();
        WeatherData weatherData;
        private double _weatherDataLastUpdatedMilliseconds;
        private static readonly double _weatherDataUpdateThreshold = 360000;

        // debug
        PanelCurrentWeather pcw;

        int mouseX = 0;
        int mouseY = 0;

        public MainPage() {
            this.InitializeComponent();
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.FullScreen;
        }

        private void canvasMain_Draw(ICanvasAnimatedControl sender, CanvasAnimatedDrawEventArgs args) {
            for (int i = Panels.Count - 1; i >= 0; i--) {
                Panels[i].Draw(args, false); // Panels[i].HitTest(mouseX, mouseY));
            }

            //args.DrawingSession.DrawText(mouseX.ToString() + ", " + mouseY.ToString(), new Vector2(1500, 10), Colors.White);

            args.DrawingSession.DrawText(((int)_weatherDataLastUpdatedMilliseconds).ToString(), new Vector2(1500, 10), Colors.White);
            args.DrawingSession.DrawText(_weatherDataUpdateThreshold.ToString(), new Vector2(1500, 30), Colors.White);

            //foreach (AnimatedSprite animatedSprite in AnimatedSprites) {
            //    animatedSprite.Draw(args);
            //}
        }

        private async void canvasMain_Update(ICanvasAnimatedControl sender, CanvasAnimatedUpdateEventArgs args) {
            foreach (Panel panel in Panels) {
                panel.Update(args);
            }

            _weatherDataLastUpdatedMilliseconds += args.Timing.ElapsedTime.TotalMilliseconds;

            if (_weatherDataLastUpdatedMilliseconds >= _weatherDataUpdateThreshold) {
                _weatherDataLastUpdatedMilliseconds = 0;
                await weatherData.Update(args);

                lock (Debug.Lock) {
                    pcw.DebugStrings.Add(DateTime.Now.ToString("hh:mm.ss") + ": " + weatherData.Current.Current_Observation.Observation_Time);
                }

                foreach (Panel panel in Panels) {
                    panel.RefreshWeatherDataObjects(weatherData);
                }
            }
        }

        private void canvasMain_CreateResources(CanvasAnimatedControl sender, CanvasCreateResourcesEventArgs args) {
            args.TrackAsyncAction(CreateResourcesAsync(sender).AsAsyncAction());
        }

        private async Task CreateResourcesAsync(CanvasAnimatedControl sender) {
            WeatherBitmaps.CanvasBitmapSun = await CanvasBitmap.LoadAsync(sender, "images/sun.png");
            WeatherBitmaps.CanvasBitmapCloud = await CanvasBitmap.LoadAsync(sender, "images/cloud.png");
            WeatherBitmaps.CanvasBitmapRain = await CanvasBitmap.LoadAsync(sender, "images/rain.png");
            WeatherBitmaps.CanvasBitmapChanceRain = await CanvasBitmap.LoadAsync(sender, "images/chancerain.png");
            WeatherBitmaps.CanvasBitmapLightning = await CanvasBitmap.LoadAsync(sender, "images/lightning.png");
            WeatherBitmaps.CanvasBitmapPartlyCloudy = await CanvasBitmap.LoadAsync(sender, "images/partly_cloudy.png");
            WeatherBitmaps.CanvasBitmapSnow = await CanvasBitmap.LoadAsync(sender, "images/snow.png");
            WeatherBitmaps.CanvasBitmapChanceSnow = await CanvasBitmap.LoadAsync(sender, "images/chancesnow.png");

            WeatherBitmaps.WeatherTypeToBitmap.Add("chancerain", WeatherBitmaps.CanvasBitmapChanceRain);
            WeatherBitmaps.WeatherTypeToBitmap.Add("partlycloudy", WeatherBitmaps.CanvasBitmapPartlyCloudy);
            WeatherBitmaps.WeatherTypeToBitmap.Add("cloudy", WeatherBitmaps.CanvasBitmapCloud);
            WeatherBitmaps.WeatherTypeToBitmap.Add("mostlycloudy", WeatherBitmaps.CanvasBitmapCloud);
            WeatherBitmaps.WeatherTypeToBitmap.Add("rain", WeatherBitmaps.CanvasBitmapRain);
            WeatherBitmaps.WeatherTypeToBitmap.Add("tstorms", WeatherBitmaps.CanvasBitmapLightning);
            WeatherBitmaps.WeatherTypeToBitmap.Add("clear", WeatherBitmaps.CanvasBitmapSun);
            WeatherBitmaps.WeatherTypeToBitmap.Add("snow", WeatherBitmaps.CanvasBitmapSnow);
            WeatherBitmaps.WeatherTypeToBitmap.Add("chancesnow", WeatherBitmaps.CanvasBitmapChanceSnow);

            Random r = new Random(DateTime.Now.Millisecond);

            AnimatedSprites.Add(new AnimatedSprite(WeatherBitmaps.CanvasBitmapSun, new Vector2(1000, 0), 64, 64, 16, 150 + r.Next(100)));
            AnimatedSprites.Add(new AnimatedSprite(WeatherBitmaps.CanvasBitmapCloud, new Vector2(1000, 64), 64, 64, 16, 150 + r.Next(100)));
            AnimatedSprites.Add(new AnimatedSprite(WeatherBitmaps.CanvasBitmapRain, new Vector2(1000, 128), 64, 64, 16, 150 + r.Next(100)));
            AnimatedSprites.Add(new AnimatedSprite(WeatherBitmaps.CanvasBitmapChanceRain, new Vector2(1000, 192), 64, 64, 16, 150 + r.Next(100)));
            AnimatedSprites.Add(new AnimatedSprite(WeatherBitmaps.CanvasBitmapLightning, new Vector2(1256, 256), 64, 64, 16, 150 + r.Next(100)));
            AnimatedSprites.Add(new AnimatedSprite(WeatherBitmaps.CanvasBitmapPartlyCloudy, new Vector2(1256, 320), 64, 64, 16, 150 + r.Next(100)));
            AnimatedSprites.Add(new AnimatedSprite(WeatherBitmaps.CanvasBitmapSnow, new Vector2(1512, 384), 64, 64, 16, 150 + r.Next(100)));

            // calculate panel dimensions based on client bounds
            int clientWidth = 1920 - (int)Panel._PADDING * 2;
            int clientHeight = 1080;
            int nNumPanels = 7;

            int panelWidth = clientWidth / nNumPanels;
            int padding = (clientWidth - panelWidth * nNumPanels) / (nNumPanels - 1);
            while (padding < 5) {
                panelWidth -= 1;
                padding = (clientWidth - panelWidth * nNumPanels) / (nNumPanels - 1);
            }

            clientWidth = panelWidth * nNumPanels + padding * (nNumPanels - 1);
            int panelHeight = panelWidth;

            float y = clientHeight - panelWidth - Panel._PADDING;

            weatherData = await WeatherData.Create();

            for (int i = 0; i < nNumPanels; i++) {
                Vector2 position = new Vector2(Panel._PADDING + (panelWidth + padding) * i, y);
                Panels.Add(new PanelForecastDay(sender.Device, position, panelWidth, panelHeight, weatherData, i));
            }

            // create current snapshot panel
            pcw = new PanelCurrentWeather(sender.Device, new Vector2(Panel._PADDING, Panel._PADDING), clientWidth, clientHeight - Panel._PADDING * 3 - panelHeight, weatherData);
            Panels.Add(pcw);
        }

        private void canvasMain_PointerMoved(object sender, PointerRoutedEventArgs e) {
            PointerPoint p = e.GetCurrentPoint(canvasMain);
            mouseX = (int)p.Position.X;
            mouseY = (int)p.Position.Y;
        }

        private void canvasMain_PointerPressed(object sender, PointerRoutedEventArgs e) {
            PointerPoint p = e.GetCurrentPoint(canvasMain);
            int x = (int)p.Position.X;
            int y = (int)p.Position.Y;
        }

        private void canvasMain_PointerReleased(object sender, PointerRoutedEventArgs e) {

        }
    }
}
