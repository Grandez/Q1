using Q1RDotNet;
using RDotNet;
using System;
using System.Collections.Generic;

using Q1Base.Pers;
using Q1Base.JSon;

namespace Q1RDotnet {
   public class Q1R {
      private static Q1R r = null;

      private REngine engine;

      private Q1R() {
         RDotNet.StartupParameter sp = new StartupParameter();
         sp.Interactive = false;
         sp.Quiet = false;

         //RDotNet.Devices.ICharacterDevice ic = new RConsola();
         RConsola ic = new RConsola();
         REngine.SetEnvironmentVariables();
         REngine engine = REngine.GetInstance("", true, sp, ic);

         if (engine.IsRunning == false) {
            engine.Initialize(sp, ic, true);
         }

         //engine.Evaluate code...

         string rConsoleMessages = ic.sb.ToString();
         REngine.SetEnvironmentVariables();
         engine = REngine.GetInstance();
         engine.Initialize();
         //engine.Evaluate("source('P:/Q1/R/Q1Linear.R')");
      }

      public static Q1R getInstance() {
         if (r == null) r = new Q1R();
         return r;
      }

      public void testR() {
         string result;
         string input;
         REngine engine;

         //init the R engine            
         REngine.SetEnvironmentVariables();
         engine = REngine.GetInstance();
         engine.Initialize();

         //input
         Console.WriteLine("Please enter the calculation");
         // input = Console.ReadLine();
         input = " 1 + 2";
         //calculate
         CharacterVector vector = engine.Evaluate(input).AsCharacter();
         result = vector[0];

         //clean up
         engine.Dispose();

         //output
         Console.WriteLine("");
         Console.WriteLine("Result: '{0}'", result);
         Console.WriteLine("Press any key to exit");
         // Console.ReadKey();
      }

      public void calculate(IService srv, String table) {
         foreach (Keys k in srv.getPending(table)) {
            List<decimal> data = srv.getLast(k.Moneda);
            calculatePercentage(srv, data, k);
            calculateData(srv, data, k);
         } 
         srv.markDone(table);
      }

      private void calculatePercentage(IService srv, List<decimal> data, Keys pend) {
         Trend t = new Trend();
         t.Moneda = pend.Moneda;
         t.Fecha = pend.Fecha;
         List<decimal> res = obtainPercentages(data);
         for (int pos = res.Count - 2, i = 0; pos >= 0; pos--, i++) {
              t.setValue(i, res[pos]);
         }
//         srv.insertPercentage(t);
      }

      private void calculateData(IService srv, List<decimal> data, Keys pend) {
         Trend t = new Trend();
         t.Moneda = pend.Moneda;
         t.Fecha = pend.Fecha;
         List<decimal> res = obtainTrend(data);
         for (int pos = data.Count - 2, i = 0; pos >= 0; pos--, i++) {
            t.setValue(i, data[pos]);
         }
         //srv.insertPercentage(t);
      }

      private List<decimal> obtainPercentages(List<decimal> data) {
         decimal[] res = new decimal[data.Count];
         int idx = data.Count - 1;
         decimal act = data[idx];
         int tmp = 0;
         while (--idx >= 0) {
            tmp = (int)(act / data[idx]) * 100;
            if (tmp >= 100) {
               tmp -= 100;
            } else {
               tmp = (100 - tmp) * -1;
            }
            res[idx] = tmp / 100;
         }
         return new List<decimal>(res);
      }

      private List<decimal> obtainTrend(List<decimal> data) {
         decimal[] res = new decimal[data.Count];
         double[] y;
         double[] x;
         
         for (int i = data.Count - 2; i >= 0; i--) {
            x = new double[data.Count - i];
            y = new double[data.Count - i];
            for (int j = i, idx = 0, x0 = 1; j < data.Count; j++, idx++, x0++) {
               y[idx] = System.Convert.ToDouble(data[j]);
               x[idx] = x0;
            }
            
            NumericVector vx = engine.CreateNumericVector(x);
            NumericVector vy = engine.CreateNumericVector(y);
            var lm = engine.Evaluate("calcLM").AsFunction();
            var sol = lm.Invoke(new SymbolicExpression[] { vx, vy });
         }
         return new List<decimal>(res);
      }
   }
}
