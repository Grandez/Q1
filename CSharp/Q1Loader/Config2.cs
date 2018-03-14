using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1Loader {
    class Config2 {
        public static Boolean decPoint = true;
        public static decimal euro = 1.0m;
        public String file = "D:\\Prj\\Cartera\\AAACartera.xlsm";
        public String folder = "D:\\Prj\\Cartera";
        public static int mode = 0;
        public int HoraRowBeg = 3;
        public String SH_HOUR = "Hora";
        public int[] INTERVALS = { 1, 2, 4, 8, 12, 24, 144, 612 };
        public int INTERVALS_SIZE = 8;
        public String TEMPLATE = "AAATemplate.xlsx";
    }
}
