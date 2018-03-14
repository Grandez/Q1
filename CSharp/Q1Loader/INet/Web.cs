using System;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using Q1Base.JSon;
using Q1Base;

namespace Q1Loader.INet
{
    class Web {
        private String b = "https://api.coinmarketcap.com/v1/";
        public Ticker[] getCotizacion() {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.NullValueHandling = NullValueHandling.Ignore;

            String data = getUrl(b + "ticker");
            String txt = data.Replace("24h_volume_usd", "volume_usd_24h");
            return JsonConvert.DeserializeObject<Ticker[]>(txt, settings);
        }

      public List<Cierre> getCierre(String moneda, String nombre, String fecha) {
         String b = "https://coinmarketcap.com/currencies/";
         JsonSerializerSettings settings = new JsonSerializerSettings();
         settings.NullValueHandling = NullValueHandling.Ignore;

         
         String url = b + nombre + "/historical-data/?start=" + fecha;
         String data = getUrl(url);
         return extractData(moneda, data);
      }

      private List<Cierre> extractData(String moneda, String data) {
         int end = 0;
         int field = 0;
         string valor;
         decimal dValor = 0;
         List<Cierre> cierres = new List<Cierre>();
         Cierre c = null;
         
         int pos = data.IndexOf("<td");
         while (pos != -1) {
            //data = data.Substring(pos + 1);
            pos = data.IndexOf(">", pos);
            end = data.IndexOf("<", pos);
            valor = data.Substring(pos + 1, end - pos - 1);
            if (field % 7 != 0) {
               while ((end = valor.IndexOf(',')) != -1) {
                  valor = valor.Remove(end, 1);
               }
               dValor = System.Convert.ToDecimal(valor);
            }
            switch(field % 7) {
               case 1: c.open =      dValor; break;
               case 2: c.high =      dValor; break;
               case 3: c.low =       dValor; break;
               case 4: c.close =     dValor; break;
               case 5: c.volumen =   dValor; break;
               case 6: c.marketcap = dValor; break;
               default: if (c != null) cierres.Add(c);
                        c = new Cierre();
                        c.moneda = moneda;
                        DateTime dt = DateTime.Parse(valor);
                        c.fecha = (long) (dt - new DateTime(1970, 1, 1)).TotalSeconds;
                        break;
            }
            field++;
            pos = data.IndexOf("<td", pos);
         }
         if (c != null) cierres.Add(c);
         return cierres;
      }
      public decimal getEuro() {
            String res = getUrl("https://api.fixer.io/latest?symbols=USD");
            int beg = res.LastIndexOf(":");
            String val = res.Substring(beg + 1, res.Length - 3 - beg);
            // If Config.decPoint = False Then val = val.Replace(".", ",")
            return Decimal.Parse(val);
        }

        private String getUrl(String url)  {
            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            String data = reader.ReadToEnd();
            reader.Close();
            response.Close();
            return data;
        }
    }
}
