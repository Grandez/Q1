using Q1Base;
using Q1Base.JSon;
using Q1Base.Pers.Tables;
using System;
using System.Collections.Generic;

namespace Q1Base {
   public interface IProvider {
      decimal getEuro();
      List<Ticker> getTickers(List<Cierres> monedas);
      List<Cierre> getCierres(List<Cierres> monedas);
      Dictionary<String, Ticker> getTickersMap(List<Cierres> monedas);
   }  
}
