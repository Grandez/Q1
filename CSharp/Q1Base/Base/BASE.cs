using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1Base {
   public class BASE {
      public static DateTime epoch2DateTime(long epoch) {
         if (epoch <= 0) return DateTime.Now;
         return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddSeconds(epoch);
      }
      
      public static long DateTime2Epoch(DateTime dt) {
         return 0;

      }
   }
}
