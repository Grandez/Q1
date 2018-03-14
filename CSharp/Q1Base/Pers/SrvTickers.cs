using Q1Base.JSon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

namespace Q1Base.Pers {
   public class SrvTickers : DB , IService {
      private String insSql = "INSERT INTO ";
      private String insTicker = "Tickers (Moneda, Fecha, USD, EUR, BTC, Volumen, MarketCap, Available, Total) " +
                                 "VALUES  (?,      ?,     ?,   ?,   ?,   ?,       ?,         ?,         ?)";

      private String insPrc  = "TickersPrc (Moneda, Fecha, H01, H02, H04, H08, H12) " +
                                 "VALUES   (?,      ?,     ?,   ?,   ?,   ?,   ?)";

      public void insert(List<Ticker> tickers) {
         OleDbCommand cmd = new OleDbCommand(insSql + insTicker);
         OleDbDataAdapter da = new OleDbDataAdapter();
         cmd.Connection = cn;

         foreach (Ticker t in tickers) {
            //Console.WriteLine("Moneda: " + t.symbol + " - Fecha: " + t.last_updated);
            cmd.Parameters.AddWithValue("Moneda", t.symbol);
            cmd.Parameters.AddWithValue("Fecha", t.last_updated);
            cmd.Parameters.AddWithValue("USD", t.price_usd);
            cmd.Parameters.AddWithValue("EUR", t.price_usd);
            cmd.Parameters.AddWithValue("BTC", t.price_btc);
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

            }
            finally {
               cmd.Parameters.Clear();
            }
         }
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
