using Q1Base.JSon;
using System;
using System.Collections.Generic;
using System.Data.OleDb;

using Q1Base;


namespace Q1Base.Pers {
   public class SrvTickers : DB , IService {
      private string msg = "";
      private String insSql = "INSERT INTO ";
      private String insTicker = "Tickers (Moneda, Fecha, USD, EUR, BTC, Volumen, MarketCap, Available, Total) " +
                                 "VALUES  (?,      ?,     ?,   ?,   ?,   ?,       ?,         ?,         ?)";

      private String insPrc  = "TickersPrc (Moneda, Fecha, H01, H02, H04, H08, H12) " +
                                 "VALUES   (?,      ?,     ?,   ?,   ?,   ?,   ?)";

      public void insert(List<Ticker> tickers) {
         OleDbCommand cmd = new OleDbCommand(insSql + insTicker);
         OleDbDataAdapter da = new OleDbDataAdapter();
         OleDbParameter parm;
         cmd.Connection = cn;

         foreach (Ticker t in tickers) {
            //Console.WriteLine("Moneda: " + t.symbol + " - Fecha: " + t.last_updated);
            //Console.WriteLine(Math.Round(t.price_usd / Config.getEuro(), 2));
            
           
            cmd.Parameters.AddWithValue("Moneda", t.symbol);
            cmd.Parameters.AddWithValue("Epoch", t.last_updated);
            cmd.Parameters.AddWithValue("Fecha", BASE.epoch2DateTime(t.last_updated));

            parm = new OleDbParameter("USD", OleDbType.VarChar);
            parm.Value = t.price_usd.ToString();
            cmd.Parameters.Add(parm);
            parm = new OleDbParameter("EUR", OleDbType.VarChar);
            parm.Value = Math.Round(t.price_usd / CFG.getEuro(), 2);
            cmd.Parameters.Add(parm);
            parm = new OleDbParameter("BTC", OleDbType.VarChar);
            parm.Value = t.price_btc.ToString();
            cmd.Parameters.Add(parm);

            cmd.Parameters.AddWithValue("Volumen", t.volume_usd / 1000);
            cmd.Parameters.AddWithValue("MarketCap", t.market_cap_usd / 1000);
            cmd.Parameters.AddWithValue("Available", t.available_supply / 1000);
            cmd.Parameters.AddWithValue("Total", t.total_supply / 100);
            da.InsertCommand = cmd;
            try {
               da.InsertCommand.ExecuteNonQuery();
            }
            // Ignoramos el catch
            // En principio esto solo puede darse si un ticker 
            // No ha sido actualizado en el servidor desde la ultima carga
            catch (Exception e) {
               msg = e.Message;
            }
            finally {
               cmd.Parameters.Clear();
            }
         }
         //Console.WriteLine("Fin");
      }

      public void insertPercentage(Trend data) {
         insertFromTrend(insSql + insPrc, data, 5);
      }
      public void insertPercentages(List<Trend> data) {
            insertFromTrend(insSql + insPrc, data, 5);
      }

      public List<decimal> getLast(String moneda) {
         String qry = "SELECT TOP 6 USD, Fecha FROM Tickers WHERE Moneda = ? ORDER BY Fecha DESC";
         return getLastData(qry, moneda);
      }

      /*
       * Verificar que el sistema ha estado corriendo
       * Si el tiempo entre el ultimo ticker y el actual es mayor que el intervalo de busqueda
       * entonces:
       * - Calcula la recta entre los dos puntos
       * - Genera un ticker ficticio en esa recta
       */
      private List<Ticker> calculateTickers(Ticker ticker) {

         List<Ticker> list = new List<Ticker>();
         list.Add(ticker);
         //ReDim tickers(0)
         // tickers(0) = ticker
         /*
         last = getLastDate(ticker.symbol);

         if (last == 0) {
            //        Console.Write("Nulo");
         }
         */
         /*
          * Leer max(fecha) 
          * Si diferencia > interval
          *   calcular recta
          *    bucle de puntos
          */
         return list;
      }

   }
}
