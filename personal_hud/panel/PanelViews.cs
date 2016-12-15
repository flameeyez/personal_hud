using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.UI.Xaml;
using Windows.Foundation;

namespace personal_hud {
    class PanelViews : Panel {
        public PanelViews(CanvasDevice device, Vector2 position, double width, double height) : base(device, position, width, height) {
        }

        public override void Draw(CanvasAnimatedDrawEventArgs args, Point mouseCoordinates) {
            base.Draw(args, mouseCoordinates);
        }

        public override void RefreshData() { }
        public override void Update(CanvasAnimatedUpdateEventArgs args) { }
    }
}
