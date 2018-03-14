using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1Base.Pers.Tables {
   public class Cierres {
      public string Moneda { get; set; }
      public string Nombre { get; set; }
      public long Fecha { get; set; }
      public string symbol { get; set; }
      public int rank { get; set; }
      public decimal Open { get; set; }
      public decimal High { get; set; }
      public decimal Low { get; set; }
      public decimal Close { get; set; }
      public decimal MarketCap { get; set; }
      public decimal Volumen { get; set; }
      public DateTime tms { get; set; }

   }
}
