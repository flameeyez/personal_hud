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
    enum VIEW {
        CURRENT_WEATHER_AND_FORECAST
    }

    public static class Debug {
        public static object Lock = new object();
    }

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page {
        Dictionary<VIEW, View> Views = new Dictionary<VIEW, View>();
        View viewCurrent;
        PanelViews PanelViews;
        List<AnimatedSprite> AnimatedSprites = new List<AnimatedSprite>();
        Point mouseCoordinates = new Point(0.0, 0.0);

        public MainPage() {
            this.InitializeComponent();
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.FullScreen;
        }

        private void canvasMain_Draw(ICanvasAnimatedControl sender, CanvasAnimatedDrawEventArgs args) {
            if(viewCurrent != null) {
                viewCurrent.Draw(args, mouseCoordinates);
            }

            PanelViews.Draw(args, mouseCoordinates);

            foreach (AnimatedSprite animatedSprite in AnimatedSprites) {
                animatedSprite.Draw(args);
            }
        }

        private async void canvasMain_Update(ICanvasAnimatedControl sender, CanvasAnimatedUpdateEventArgs args) {
            foreach (AnimatedSprite animatedSprite in AnimatedSprites) {
                animatedSprite.Update(args);
            }

            await WeatherData.Update(args);

            if (viewCurrent != null) {
                viewCurrent.Update(args);
            }
        }

        private void canvasMain_CreateResources(CanvasAnimatedControl sender, CanvasCreateResourcesEventArgs args) {
            args.TrackAsyncAction(CreateResourcesAsync(sender).AsAsyncAction());
        }

        private async Task CreateResourcesAsync(CanvasAnimatedControl sender) {
            await MoonBitmaps.Initialize(sender);
            await WeatherBitmaps.Initialize(sender);
            await WeatherData.Create();
            MOON_PHASE phase = Moon.GetCurrentPhase();

            Random r = new Random(DateTime.Now.Millisecond);

            int clientWidth = 1920 - (int)Panel._PADDING * 2;
            int clientHeight = 1080 - (int)Panel._PADDING * 2;
            int rightPanelWidth = 300;

            ViewWeatherCurrentAndForecast vwcf = ViewWeatherCurrentAndForecast.Create(sender.Device, clientWidth, clientHeight, rightPanelWidth);
            Views.Add(VIEW.CURRENT_WEATHER_AND_FORECAST, vwcf);
            viewCurrent = Views[VIEW.CURRENT_WEATHER_AND_FORECAST];

            PanelViews = new PanelViews(sender.Device, new Vector2((float)vwcf.Width + Panel._PADDING * 2, Panel._PADDING), rightPanelWidth, clientHeight - Panel._PADDING * 2);
        }

        private void canvasMain_PointerMoved(object sender, PointerRoutedEventArgs e) {
            mouseCoordinates = e.GetCurrentPoint(canvasMain).Position;
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

//AnimatedSprites.Add(new AnimatedSprite(MoonBitmaps.MoonBitmapFull, new Vector2(200, 200), 64, 64, 32));
//AnimatedSprites.Add(new AnimatedSprite(WeatherBitmaps.CanvasBitmapSun, new Vector2(1000, 0), 64, 64, 16, 150 + r.Next(100)));
//AnimatedSprites.Add(new AnimatedSprite(WeatherBitmaps.CanvasBitmapCloud, new Vector2(1000, 64), 64, 64, 16, 150 + r.Next(100)));
//AnimatedSprites.Add(new AnimatedSprite(WeatherBitmaps.CanvasBitmapRain, new Vector2(1000, 128), 64, 64, 16, 150 + r.Next(100)));
//AnimatedSprites.Add(new AnimatedSprite(WeatherBitmaps.CanvasBitmapChanceRain, new Vector2(1000, 192), 64, 64, 16, 150 + r.Next(100)));
//AnimatedSprites.Add(new AnimatedSprite(WeatherBitmaps.CanvasBitmapLightning, new Vector2(1256, 256), 64, 64, 16, 150 + r.Next(100)));
//AnimatedSprites.Add(new AnimatedSprite(WeatherBitmaps.CanvasBitmapPartlyCloudy, new Vector2(1256, 320), 64, 64, 16, 150 + r.Next(100)));
//AnimatedSprites.Add(new AnimatedSprite(WeatherBitmaps.CanvasBitmapSnow, new Vector2(1512, 384), 64, 64, 16, 150 + r.Next(100)));
//
//args.DrawingSession.DrawText(mouseX.ToString() + ", " + mouseY.ToString(), new Vector2(1500, 10), Colors.White);
//args.DrawingSession.DrawImage(MoonBitmaps.MoonBitmapNew, new Rect(100, 100, 64, 64));
//args.DrawingSession.DrawImage(MoonBitmaps.MoonBitmapWaxingCrescent, new Rect(164, 100, 64, 64));
//args.DrawingSession.DrawImage(MoonBitmaps.MoonBitmapQuarter, new Rect(228, 100, 64, 64));
//args.DrawingSession.DrawImage(MoonBitmaps.MoonBitmapWaxingGibbous, new Rect(296, 100, 64, 64));
//args.DrawingSession.DrawImage(MoonBitmaps.MoonBitmapFull, new Rect(100, 164, 64, 64));
//args.DrawingSession.DrawImage(MoonBitmaps.MoonBitmapWaningGibbous, new Rect(164, 164, 64, 64));
//args.DrawingSession.DrawImage(MoonBitmaps.MoonBitmapLastQuarter, new Rect(228, 164, 64, 64));
//args.DrawingSession.DrawImage(MoonBitmaps.MoonBitmapWaningCrescent, new Rect(296, 164, 64, 64));