using System;
using System.Collections.Generic;
using System.IO;

using Q1Loader.INet;
using Q1Base.Pers;
using Q1Base.Pers.Tables;
using Q1Base;
using Q1Base.JSon;

namespace Q1Loader {
   class Q1Loader {
      private Web web = new Web();
      private DB db = null;
      private R r = null;

      static void Main(string[] args) {
         Q1Loader loader = new Q1Loader();
         loader.start(args);

      }
      private void start(String[] args) {
         try {
            LogMgr.info("Proceso iniciado");
            processArguments(args);
            //Config.setDatabase("D:\\Prj\\Cartera\\portfolio.accdb");
            DateTime start = DateTime.Now;

            db = DB.getInstance();
            r = R.getInstance();

            Config2.euro = web.getEuro();
            //R r = new R();
            //r.testR();
            if ((Config2.mode & 0x01) != 0) processCotizacion();
            if ((Config2.mode & 0x02) != 0) processCierre();
            //processCierre();

            db.close();

            // Do some work
            TimeSpan timeDiff = DateTime.Now - start;

            //         Console.WriteLine(timeDiff.TotalMilliseconds);
            //         Console.ReadLine();
         }catch(Exception e) {
            using (StreamWriter sw = File.AppendText(@"D:\tmp\AAA.txt")) {
               sw.WriteLine(e.Message);
            }
            LogMgr.err(e.Message);
         } finally  {
            using (StreamWriter sw = File.AppendText(@"D:\tmp\AAA.txt")) {
               sw.WriteLine("Acaba");
            }
}

      }

      private void processCotizacion() {
         Ticker[] tickers = web.getCotizacion();
         List<Ticker> data = new List<Ticker>(tickers);
         // Actualiza monedas
         SrvMonedas srv1 = new SrvMonedas();
         foreach (Ticker t in data) {
            Monedas m = new Monedas();
            m.Moneda = t.symbol;
            m.Nombre = t.id;
            m.Rango = t.rank;
            srv1.updateMoneda(m);
         }
         SrvTickers srv = new SrvTickers();
         srv.insert(new List<Ticker>(tickers));        
         r.calculate(srv, TABLES.TICKERS);
      }

      private void processCierre() {
          List<Cierre> total = new List<Cierre>();
          SrvCierres srv = new SrvCierres();
          foreach(Cierres c in srv.getUltimoCierre()) {
              String start = calculateFecha(c.Fecha);
              List<Cierre> cc = web.getCierre(c.Moneda, c.Nombre, start);
              total.AddRange(cc);
          }
          srv.insert(total);
          r.calculate(srv, TABLES.CIERRRES);
      }

      private void processArguments(String[] args) {
         Config2.mode = 0x01;
         for (int idx = 0; idx < args.Length; idx++) {
            if (!args[idx].StartsWith("/")) {
               LogMgr.err("ERROR: Parametro erroneo: " + args[idx]);
               System.Environment.Exit(1);
            }
            String parm = args[idx].Substring(1);
            if (parm.Length > 1) { 
               LogMgr.err("ERROR: Parametro erroneo: " + args[idx]);
               System.Environment.Exit(1);
             }
            if (parm.ToUpper().CompareTo("C") == 0) Config2.mode = 0x02; 
         }
         DateTime local = DateTime.Now;
         if (local.Hour == 0) Config2.mode |= 0x02;

      }

      private String calculateFecha(long epoch) {
         if (epoch == 0) return "20000101";
         DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
         dt.AddSeconds(epoch);
         dt.AddDays(1);
         return String.Format("{0:D4}{1:D2}{2:D2}", dt.Year, dt.Month, dt.Day);
         }



      /*
      int tipo = 0;
      int mode = 
      for (int idx = 0; idx < args.Length; idx++) {
         switch(tipo) {
            case 0: if (args[idx].CompareTo("/F",StringComparison.OrdinalIgnoreCase) == 0) 
         }
      }
     For Each arg In args
         Select Case tipo
             Case 0
                 Select Case arg
                     Case "/F"
                         tipo = 10
                     Case "/A"
                         tipo = 20
                     Case "/T"
                         Config.mode = 0
                         tipo = 0
                     Case "/D"
                         Config.mode = 1
                         tipo = 0
                 End Select
             Case 10
                 Config.folder = arg
                 tipo = 0
             Case 20
                 Config.file = arg
                 tipo = 0
             Case Else
                 tipo = -1
         End Select
     Next
     Select Case tipo
         Case 0
         Case 10
             writeFile("Falta el nombre del archivo Excel")
         Case Else
             writeFile("Parametros erroneos")
     End Select
     If tipo<> 0 Then
         Environment.Exit(1)
     End If
 End Sub
*/
   }

}