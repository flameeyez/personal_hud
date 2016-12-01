using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personal_hud {
    enum MOON_PHASE {
        NEW,
        WAXING_CRESCENT,
        QUARTER,
        WAXING_GIBBOUS,
        FULL,
        WANING_GIBBOUS,
        LAST_QUARTER,
        WANING_CRESCENT
    }
    static class Moon {
        public static MOON_PHASE GetCurrentPhase() {
            int year = DateTime.Now.Year;
            int month = 12;// DateTime.Now.Month;
            int day = 7;// DateTime.Now.Day;

            double c = 0.0;
            double e = 0.0;
            double jd = 0.0;
            int b = 0;

            if(month < 3) {
                year--;
                month += 12;
            }

            month++;

            c = 365.25 * year;
            e = 30.6 * month;
            jd = c + e + day - 694039.09;
            jd /= 29.5305882;
            b = (int)jd;
            jd -= b;
            b = (int)Math.Round(jd * 8);
            if(b >= 8) { b = 0; }

            switch(b) {
                case 0: return MOON_PHASE.NEW;
                case 1: return MOON_PHASE.WAXING_CRESCENT;
                case 2: return MOON_PHASE.QUARTER;
                case 3: return MOON_PHASE.WAXING_GIBBOUS;
                case 4: return MOON_PHASE.FULL;
                case 5: return MOON_PHASE.WANING_GIBBOUS;
                case 6: return MOON_PHASE.LAST_QUARTER;
                case 7: return MOON_PHASE.WANING_CRESCENT;
                default: return MOON_PHASE.NEW;
            }
        }
    }
}
