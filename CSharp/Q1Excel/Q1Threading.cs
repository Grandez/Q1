using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using Excel = Microsoft.Office.Interop.Excel;

using Q1Base;

namespace Q1Excel {
   class Q1Threading {

      private Dictionary<String, Int32> monedas = null;
      private IProvider web = Provider.getProvider();

      private static Q1Threading thr = null;

      private Q1Threading() {

      }

      public static Q1Threading getInstance() {
         if (thr == null) thr = new Q1Threading();
         return thr;
      }

      public void startTickers() {
         if (monedas == null) monedas = getMonedas();
         Thread t = new Thread(new ThreadStart(threadTickers));
         t.Start();
      }

      private void threadTickers() {
         int row = 2;
         Excel.Worksheet sh = Q1XLS.getSheet(CFG.getMasterSheet());
         while (CFG.Loading) {
            decimal euro = web.getEuro();
            Dictionary<String, Ticker> tickers = web.getTickersMap(null);
            
            foreach(String m in monedas.Keys) {
               row = monedas[m];
               Ticker t = tickers[m];
               sh.Cells[row, 2] = t.rank;
               sh.Cells[row, 3] = Math.Round(t.price_usd / euro, 2);
               sh.Cells[row, 4] = t.available_supply;
               sh.Cells[row, 5] = t.percent_change_1h;
               sh.Cells[row, 6] = t.percent_change_24h;
               sh.Cells[row, 7] = t.percent_change_7d;
               sh.Cells[row, 9] = DateTime.Now;
            }
            Thread.Sleep(CFG.Interval);
         }
         sh.Cells[row, 15] = "Acaba";
      }

      private Dictionary<String, Int32> getMonedas() {
         Dictionary<String, Int32> monedas = new Dictionary<String, Int32>();
         Excel.Worksheet sh = Q1XLS.getSheet(CFG.getMasterSheet());

         if (sh == null) return null;

         Boolean done = false;
         int row = 2;

         while (!done) {
            String m = sh.Cells[row, 1].Value();
            if (m == null) return monedas;
               if (m.Length > 2) {
                  monedas.Add(m, row);
                  row++;
               } else {
                  done = true;
               }
         }
         return monedas;
      }
   }
}
