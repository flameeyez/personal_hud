using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personal_hud {
    static class Statics {
        public static readonly double _panelRefreshThresholdMilliseconds = 1000;
        public static readonly double _weatherDataRefreshThreshold = 360000;
        public static readonly Random r = new Random();
    }
}