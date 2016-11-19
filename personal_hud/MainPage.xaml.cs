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
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page {
        List<Panel> Panels = new List<Panel>();
        List<AnimatedSprite> AnimatedSprites = new List<AnimatedSprite>();

        int mouseX = 0;
        int mouseY = 0;

        public MainPage() {
            this.InitializeComponent();
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.FullScreen;
        }

        private void canvasMain_Draw(ICanvasAnimatedControl sender, CanvasAnimatedDrawEventArgs args) {
            for (int i = Panels.Count - 1; i >= 0; i--) {
                Panels[i].Draw(args, Panels[i].HitTest(mouseX, mouseY));
            }

            args.DrawingSession.DrawText(mouseX.ToString() + ", " + mouseY.ToString(), new Vector2(1500, 10), Colors.White);

            //foreach (AnimatedSprite animatedSprite in AnimatedSprites) {
            //    animatedSprite.Draw(args);
            //}
        }

        private void canvasMain_Update(ICanvasAnimatedControl sender, CanvasAnimatedUpdateEventArgs args) {
            foreach (Panel panel in Panels) {
                panel.Update(args);
            }
        }

        private void canvasMain_CreateResources(CanvasAnimatedControl sender, CanvasCreateResourcesEventArgs args) {
            args.TrackAsyncAction(CreateResourcesAsync(sender).AsAsyncAction());
        }

        private async Task CreateResourcesAsync(CanvasAnimatedControl sender) {
            Weather.CanvasBitmapSun = await CanvasBitmap.LoadAsync(sender, "images/sun.png");
            Weather.CanvasBitmapCloud = await CanvasBitmap.LoadAsync(sender, "images/cloud.png");
            Weather.CanvasBitmapRain = await CanvasBitmap.LoadAsync(sender, "images/rain.png");
            Weather.CanvasBitmapChanceRain = await CanvasBitmap.LoadAsync(sender, "images/chancerain.png");
            Weather.CanvasBitmapLightning = await CanvasBitmap.LoadAsync(sender, "images/lightning.png");
            Weather.CanvasBitmapPartlyCloudy = await CanvasBitmap.LoadAsync(sender, "images/partly_cloudy.png");
            Weather.CanvasBitmapSnow = await CanvasBitmap.LoadAsync(sender, "images/snow.png");
            Weather.CanvasBitmapChanceSnow = await CanvasBitmap.LoadAsync(sender, "images/chancesnow.png");

            Weather.WeatherTypeToBitmap.Add("chancerain", Weather.CanvasBitmapChanceRain);
            Weather.WeatherTypeToBitmap.Add("partlycloudy", Weather.CanvasBitmapPartlyCloudy);
            Weather.WeatherTypeToBitmap.Add("cloudy", Weather.CanvasBitmapCloud);
            Weather.WeatherTypeToBitmap.Add("rain", Weather.CanvasBitmapRain);
            Weather.WeatherTypeToBitmap.Add("tstorms", Weather.CanvasBitmapLightning);
            Weather.WeatherTypeToBitmap.Add("clear", Weather.CanvasBitmapSun);
            Weather.WeatherTypeToBitmap.Add("snow", Weather.CanvasBitmapSnow);
            Weather.WeatherTypeToBitmap.Add("chancesnow", Weather.CanvasBitmapChanceSnow);

            Random r = new Random(DateTime.Now.Millisecond);

            AnimatedSprites.Add(new AnimatedSprite(Weather.CanvasBitmapSun, new Vector2(1000, 0), 64, 64, 16, 150 + r.Next(100)));
            AnimatedSprites.Add(new AnimatedSprite(Weather.CanvasBitmapCloud, new Vector2(1000, 64), 64, 64, 16, 150 + r.Next(100)));
            AnimatedSprites.Add(new AnimatedSprite(Weather.CanvasBitmapRain, new Vector2(1000, 128), 64, 64, 16, 150 + r.Next(100)));
            AnimatedSprites.Add(new AnimatedSprite(Weather.CanvasBitmapChanceRain, new Vector2(1000, 192), 64, 64, 16, 150 + r.Next(100)));
            AnimatedSprites.Add(new AnimatedSprite(Weather.CanvasBitmapLightning, new Vector2(1256, 256), 64, 64, 16, 150 + r.Next(100)));
            AnimatedSprites.Add(new AnimatedSprite(Weather.CanvasBitmapPartlyCloudy, new Vector2(1256, 320), 64, 64, 16, 150 + r.Next(100)));
            AnimatedSprites.Add(new AnimatedSprite(Weather.CanvasBitmapSnow, new Vector2(1512, 384), 64, 64, 16, 150 + r.Next(100)));

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

            Forecast10Day initialForecastData = Forecast10Day.Refresh();
            for (int i = 0; i < nNumPanels; i++) {
                Vector2 position = new Vector2(Panel._PADDING + (panelWidth + padding) * i, y);
                TxtForecastDay txtForecastDay = initialForecastData.Forecast.Txt_Forecast.ForecastDay[i];
                SimpleForecastDay simpleForecastDay = initialForecastData.Forecast.SimpleForecast.ForecastDay[i];
                Panels.Add(new PanelForecastDay(sender.Device, position, panelWidth, panelHeight, txtForecastDay, simpleForecastDay));
            }

            // create current snapshot panel
            Panels.Add(new PanelCurrentWeather(sender.Device, new Vector2(Panel._PADDING, Panel._PADDING), clientWidth, clientHeight - Panel._PADDING * 3 - panelHeight));
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
