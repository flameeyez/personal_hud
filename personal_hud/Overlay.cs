using Microsoft.Graphics.Canvas.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personal_hud {
    class Overlay {
        public List<Panel> Panels = new List<Panel>();

        public void Draw(CanvasAnimatedDrawEventArgs args) {
            foreach(Panel panel in Panels) {
                panel.Draw(args, false);
            }
        }
    }
}
