using System;
using System.Collections.Generic;
using System.IO;

using Q1Base.Pers;
using Q1Base.Pers.Tables;
using Q1Base;
using Q1Base.JSon;
using Q1RDotnet;

namespace Q1Loader {
   class Q1Loader {
      private IProvider web = null;
      private DB db = null;
      //private R r = null;

      static void Main(string[] args) {
         Q1Loader loader = new Q1Loader();
         loader.start(args);

      }
      private void start(String[] args) {
         DateTime start = DateTime.Now;
         try {
            processArguments(args);
            LogMgr.log("Proceso iniciado");

            db = DB.getInstance();
            web = Provider.getProvider();
            //r = R.getInstance();

            CFG.setEuro(web.getEuro());
            SrvCierres srv = new SrvCierres();
            List<Cierres> monedas = srv.getUltimoCierre();

            Q1R r = Q1R.getInstance();
            //r.testR();
            //if ((CFG.mode & 0x01) != 0) processCotizacion(monedas);
            //if ((CFG.mode & 0x02) != 0) processCierre(monedas);
            processCierre(monedas);
         }
         catch(Exception e) {
            LogMgr.err(e.Message);
         } finally  {
            db.close();
         }
         TimeSpan timeDiff = DateTime.Now - start;
         LogMgr.log("Proceso finalizado: " + timeDiff.ToString());
      }

      private void processCotizacion(List<Cierres> monedas) {
         LogMgr.log("Recuperando cotizaciones");
         List<Ticker> tickers = web.getTickers(monedas);

         // Actualiza monedas
         SrvMonedas srv1 = new SrvMonedas();
         foreach (Ticker t in tickers) {
            Monedas m = new Monedas();
            m.Moneda = t.symbol;
            m.Nombre = t.id;
            m.Rango = t.rank;
            srv1.updateMoneda(m);
         }
         SrvTickers srv = new SrvTickers();
         srv.insert(new List<Ticker>(tickers));        
         //r.calculate(srv, TABLES.TICKERS);
      }

      private void processCierre(List<Cierres> monedas) {
         LogMgr.log("Recuperando cierres");
         try {
            List<Cierre> cierres = web.getCierres(monedas);
            SrvCierres srv = new SrvCierres();
            srv.insert(cierres);
            //r.calculate(srv, TABLES.CIERRRES);
         }
         catch (Exception e) {
            LogMgr.err(e.Message);
         }
      }


      private void processArguments(String[] args) {
         CFG.mode = 0x01;
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
            if (parm.ToUpper().CompareTo("C") == 0) CFG.mode = 0x02;
            if (parm.ToUpper().CompareTo("T") == 0) CFG.mode = 0x01;
            if (parm.ToUpper().CompareTo("A") == 0) CFG.mode = 0x03;
            if (parm.ToUpper().CompareTo("L") == 0) CFG.log = 0x02;
            if (parm.ToUpper().CompareTo("D") == 0) CFG.log = 0x06;
            if (parm.ToUpper().CompareTo("S") == 0) CFG.log = 0x00;
            if (parm.ToUpper().CompareTo("H") == 0) {
               Console.WriteLine("Cargador de datos");
               Console.WriteLine("/C - Carga cierres");
               Console.WriteLine("/T - Carga tickers");
               Console.WriteLine("/A - Carga todo");
               Console.WriteLine("/L - Muestra log en consola");
               Console.WriteLine("/D - Muestra debug");
               Console.WriteLine("/S - No graba info de proceso");
               Environment.Exit(0);
            }
         }
         DateTime local = DateTime.Now;
         if (local.Hour == 0) CFG.mode |= 0x02;

      }

 
   }

}