using Q1Base.JSon;
using System;
using System.Collections.Generic;

namespace Q1Base.Pers {
   public interface IService {
      List<decimal> getLast(String moneda);
      List<Keys> getPending(String table);

      void insertPercentages(List<Trend> data);
      void insertPercentage(Trend data);
      void markDone(String table);
   }
}
