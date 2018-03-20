using Newtonsoft.Json;
using Q1Base.JSon;
using Q1Base.Pers.Tables;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Q1Base {
   public class CoinMarketCap : IProvider {

      private string nada;

      private Web web = new Web();

      public decimal getEuro() {
         return web.getEuro();
      }

      public List<Ticker> getTickers(List<Cierres> monedas) {
         List<Ticker> tickers = new List<Ticker>();
          String raiz = "https://api.coinmarketcap.com/v1/ticker";
          String res = web.getUrl(raiz);

         JsonSerializerSettings settings = new JsonSerializerSettings();
         settings.NullValueHandling = NullValueHandling.Ignore;
         String txt = res.Replace("24h_volume_usd", "volume_usd_24h");
         //string value = Regex.Replace(txt, "\\.", ",");
          
         tickers.AddRange(JsonConvert.DeserializeObject<Ticker[]>(txt, settings));
         return tickers;
      }
      public Dictionary<String, Ticker> getTickersMap(List<Cierres> monedas) {
         Dictionary<String, Ticker> data = new Dictionary<String, Ticker>();
         foreach (Ticker t in getTickers(null)) {
            data.Add(t.symbol, t);
         }
         return data;
      }

      /**
       * No se pueden enviar mas de 10 peticiones por minuto
       */
      public List<Cierre> getCierres(List<Cierres> data) {
         List<Cierre> cierres = new List<Cierre>();
         String b = "https://coinmarketcap.com/currencies/";
         int count = 0;
         try {
            foreach (Cierres c in data) {
               if (count % 10 == 0) Thread.Sleep(1000);
               String fecha = calculateFecha(c.Fecha);
               String url = b + c.Nombre + "/historical-data/?start=" + fecha;
               String res = web.getUrl(url);
               List<Cierre> cc = extractData(c.Moneda, res);
               cierres.AddRange(cc);
               count++;
            }
         }
         catch (Exception e) {
            LogMgr.err(e.Message);
         }
         return cierres;
      }

      private List<Cierre> extractData(String moneda, String data) {
         int end = 0;
         int field = 0;
         string valor;
         decimal dValor = 0;
         List<Cierre> cierres = new List<Cierre>();
         Cierre c = null;

         try {
            int pos = data.IndexOf("<td");
            while (pos != -1) {
               pos = data.IndexOf(">", pos);
               end = data.IndexOf("<", pos);
               valor = data.Substring(pos + 1, end - pos - 1);
               if (field % 7 != 0) dValor = makeDecimal(valor);
               switch (field % 7) {
                  case 1: c.open = dValor; break;
                  case 2: c.high = dValor; break;
                  case 3: c.low = dValor; break;
                  case 4: c.close = dValor; break;
                  case 5: c.volumen = dValor; break;
                  //case 6: c.marketcap = dValor; break;
                  case 6: c.marketcap = 0; break;
                  default:
                     if (c != null) cierres.Add(c);
                     c = new Cierre();
                     c.moneda = moneda;
                     DateTime dt = DateTime.Parse(valor);
                     c.fecha = (long)(dt - new DateTime(1970, 1, 1)).TotalSeconds;
                     break;
               }
               field++;
               pos = data.IndexOf("<td", pos);
            }
            if (c != null) cierres.Add(c);
         } catch (Exception e) {
            LogMgr.err(e.Message);
         }
         return cierres;
      }


      private String calculateFecha(long epoch) {
         if (epoch == 0) return "20000101"; 
         DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
         dt.AddSeconds(epoch);
         dt.AddDays(1);
         try {
            return String.Format("{0:D4}{1:D2}{2:D2}", dt.Year, dt.Month, dt.Day);
         }
         catch (Exception e) {
            LogMgr.err(e.Message);
         }
         return "20000101";
      }

      private decimal makeDecimal(String data) {
         String valor = data;
         int pos = 0;
         decimal res = 0m;
         if (data.CompareTo("-") == 0) return res;
         try {
            while ((pos = valor.IndexOf(',')) != -1) {
            valor = valor.Remove(pos, 1);
         }
         valor = valor.Replace(".", ",");
         
            res = System.Convert.ToDecimal(valor);
         }
         catch (System.FormatException f) {
            nada = f.Message;
            res = 0m;
         }
         return res;
      }
   }
}
