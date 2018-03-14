using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1Base.JSon {
   public class Trend {
      public string Moneda { get; set; }
      public long Fecha { get; set; }
      public string symbol { get; set; }
      public decimal[] data = { 0m, 0m, 0m, 0m, 0m, 0m, 0m, 0m, 0m, 0m };

      public void setValue(int pos, decimal value) {
         data[pos] = value;
      }
      public decimal getValue(int pos) {
         return data[pos];
      }
   }

}
