
namespace Q1Base.Pers.Tables {
   public class TickersPrc {
      public string Moneda { get; set; }
      public long   Fecha { get; set; }
      public string symbol { get; set; }
      public decimal H01 { get; set; }
      public decimal H02 { get; set; }
      public decimal H04 { get; set; }
      public decimal H08 { get; set; }
      public decimal H12 { get; set; }

      public void setValue(int pos, decimal value) {
         switch(pos) {
            case 0: H01 = value; break;
            case 1: H02 = value; break;
            case 2: H04 = value; break;
            case 3: H08 = value; break;
            case 4: H12 = value; break;
         }
      }
   }
}
