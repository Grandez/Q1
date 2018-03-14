namespace Q1Base.Pers.Tables {
   public class CierresTrend {
      public string Moneda { get; set; }
      public long Fecha { get; set; }
      public decimal D01 { get; set; }
      public decimal D07 { get; set; }
      public decimal D30 { get; set; }
      public decimal D90 { get; set; }

      public void setValue(int pos, decimal value) {
         switch (pos) {
            case 0: D01 = value; break;
            case 1: D07 = value; break;
            case 2: D30 = value; break;
            case 3: D90 = value; break;
         }
      }
   }
}
