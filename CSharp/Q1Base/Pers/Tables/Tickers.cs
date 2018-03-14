using System;
namespace Q1Base.Pers.Tables {
   public class Tickers {
      public string Moneda { get; set; }
      public long Fecha { get; set; }
      public string symbol { get; set; }
      public int rank { get; set; }
      public decimal USD { get; set; }
      public decimal EUR { get; set; }
      public decimal BTC { get; set; }
      public decimal Volumen { get; set; }
      public decimal MarketCap { get; set; }
      public decimal Available { get; set; }
      public decimal Total { get; set; }
      public DateTime tms { get; set; }
   }
}
