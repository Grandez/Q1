using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1Base {
   public class Provider {
      public static IProvider getProvider() {
         String proveedor = CFG.getProvider();
         if (proveedor == null) {
            LogMgr.err("No se ha especificado un proveedor de informacion");
            Environment.Exit(16);
         }
         switch (Int32.Parse(proveedor)) {
            case 1: return new CoinMarketCap();
         }
         return null;
      }

   }
}
