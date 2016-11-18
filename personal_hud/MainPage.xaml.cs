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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace personal_hud {
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page {
        List<Panel> Panels = new List<Panel>();
        AnimatedSprite sun;

        int mouseX = 0;
        int mouseY = 0;

        public MainPage() {
            this.InitializeComponent();
        }

        private void canvasMain_Draw(ICanvasAnimatedControl sender, CanvasAnimatedDrawEventArgs args) {
            for(int i = Panels.Count - 1; i >= 0; i--) {
                Panels[i].Draw(args, Panels[i].HitTest(mouseX, mouseY));
            }

            args.DrawingSession.DrawText(mouseX.ToString() + ", " + mouseY.ToString(), new Vector2(1500, 10), Colors.White);
            sun.Draw(args);
        }

        private void canvasMain_Update(ICanvasAnimatedControl sender, CanvasAnimatedUpdateEventArgs args) {
            sun.Update(args);
        }

        private void canvasMain_CreateResources(CanvasAnimatedControl sender, CanvasCreateResourcesEventArgs args) {
            Panels.Add(new PanelCurrentWeatherSnapshot(sender.Device, new Vector2(200, 200), 400, 400));
            args.TrackAsyncAction(CreateResourcesAsync(sender).AsAsyncAction());
        }

        private async Task CreateResourcesAsync(CanvasAnimatedControl sender) {
            CanvasBitmap bitmapSun = await CanvasBitmap.LoadAsync(sender, "images/sun.png");
            sun = new AnimatedSprite(bitmapSun, new Vector2(1000, 0), 256, 256, 16, 200.0);
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
