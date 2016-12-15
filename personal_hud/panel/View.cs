using Microsoft.Graphics.Canvas.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;

namespace personal_hud {
    class View {
        public List<Panel> Panels = new List<Panel>();

        public void Draw(CanvasAnimatedDrawEventArgs args, Point mouseCoordinates) {
            foreach(Panel panel in Panels) {
                panel.Draw(args, mouseCoordinates);
            }
        }

        public void Update(CanvasAnimatedUpdateEventArgs args) {
            foreach(Panel panel in Panels) {
                panel.Update(args);
            }
        }
    }
}
