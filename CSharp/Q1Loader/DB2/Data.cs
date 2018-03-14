using Q1Loader.DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Data.OleDb;

namespace Q1Loader.DB {
   public class Data {
      private String insSql = "INSERT INTO ";
      private String insTicker = "Tickers (Moneda, Fecha, USD, EUR, BTC, Volumen, MarketCap, Available, Total) " +
                                 "VALUES  (?,      ?,     ?,   ?,   ?,   ?,       ?,         ?,         ?)";
      private String connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source = P:\\Cartera\\portfolio.accdb";
      //private String connString = "Driver={Microsoft Access Driver (*.mdb, *.accdb)}; " +
      //                            "DBQ = D:\\prj\\Cartera\\portfolio.accdb; UID =; PWD =; ";
      private String connString = "Dsn=Portfolio";
      private OleDbConnection cn = null;
      private Portfolio ds = new Portfolio();

      private static Data data = null;

      public static Data getInstance() {
         if (data == null) data = new Data();
         return data;
      }

      public Data() {
         cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source = P:\\Cartera\\portfolio.accdb");
         cn.Open();
         //cn.Close(); 
      }
      public void close() {
         cn.Close();
      }
      public void Dispose() {
         if (cn != null) cn.Close();
         GC.SuppressFinalize(this);
      }

      public void InsertTickers(List<Ticker> tickers) {
         OleDbCommand cmd = new OleDbCommand(insSql + insTicker);
         OleDbDataAdapter da = new OleDbDataAdapter();
         cmd.Connection = cn;


         foreach (Ticker t in tickers) {
               cmd.Parameters.AddWithValue("Moneda", t.symbol);
               cmd.Parameters.AddWithValue("Fecha", t.last_updated);
               cmd.Parameters.AddWithValue("USD", t.price_usd);
               cmd.Parameters.AddWithValue("EUR", t.price_usd);
               cmd.Parameters.AddWithValue("BTC", t.price_btc);
               cmd.Parameters.AddWithValue("Volumen", t.volume_usd);
               cmd.Parameters.AddWithValue("MarketCap", t.market_cap_usd);
               cmd.Parameters.AddWithValue("Available", t.available_supply);
               cmd.Parameters.AddWithValue("Total", t.total_supply);
               da.InsertCommand = cmd;
               da.InsertCommand.ExecuteNonQuery();
               cmd.Parameters.Clear();
         }
      }

      public void markTickersDone() {
         OleDbCommand cmd = new OleDbCommand("UPDATE Tickers SET Hecho = 1 WHERE Hecho = 0");
         cmd.Connection = cn;
         cmd.ExecuteNonQuery();
      }

      public List<TTicker> getTickersPending() {
         List<TTicker> data = new List<TTicker>();
         String qry = "SELECT Moneda, Fecha FROM Tickers WHERE Hecho = 0";
         OleDbCommand cmd = new OleDbCommand(qry);
         cmd.Connection = cn;
         OleDbDataReader rdr = cmd.ExecuteReader();
         try {
            while (rdr.Read()) {
               TTicker d = new TTicker();
               d.Moneda = rdr.GetString(0);
               d.Fecha = rdr.GetInt64(1);
               data.Add(d);
            }
         }
         finally {
            rdr.Close();
         }
         return data;
      }

      public List<decimal> getLastTickers(String moneda) {
         List<decimal> data = new List<decimal>();
         String qry = "SELECT TOP 6 USD, Fecha FROM Tickers WHERE Moneda = ? ORDER BY Tickers.Fecha DESC";
         OleDbCommand cmd = new OleDbCommand(qry);
         cmd.Connection = cn;
         OleDbDataReader rdr = cmd.ExecuteReader();
         try {
            while (rdr.Read()) {
               data.Add(rdr.GetDecimal(0));
            }
         }
         finally {
            rdr.Close();
         }
         return data;
      }

      private void insertTicker(Ticker ticker) {
         Portfolio.TickersRow r = ds.Tickers.NewTickersRow();

         r.Moneda = ticker.symbol;
         r.Fecha = ticker.last_updated;
         r.USD = ticker.price_usd;
         r.EUR = ticker.price_usd;
         r.BTC = ticker.price_btc;
         r.Volumen = ticker.volume_usd;
         r.MarketCap = ticker.market_cap_usd;
         r.Available = ticker.available_supply;
         r.Total = ticker.total_supply;
         ds.Tickers.Rows.Add(r);

      }

      /*
       * Verificar que el sistema ha estado corriendo
       * Si el tiempo entre el ultimo ticker y el actual es mayor que el intervalo de busqueda
       * entonces:
       * - Calcula la recta entre los dos puntos
       * - Genera un ticker ficticio en esa recta
       */
      private List<Ticker> calculateTickers(Ticker ticker) {

         long last;
         List<Ticker> list = new List<Ticker>();
         list.Add(ticker);
         //ReDim tickers(0)
         // tickers(0) = ticker

         last = getLastDate(ticker.symbol);

         if (last == 0) {
            //        Console.Write("Nulo");
         }
         /*
          * Leer max(fecha) 
          * Si diferencia > interval
          *   calcular recta
          *    bucle de puntos
          */
         return list;
      }

      private long getLastDate(String moneda) {
         //OdbcCommand cmd = new OdbcCommand("SELECT MAX(Fecha) FROM Tickers WHERE Moneda = ?", cn);
         //cmd.Parameters.Add("@Moneda", OdbcType.Text).Value = moneda;
         //OdbcDataReader reader = cmd.ExecuteReader();
         return 0;
      }
      private void PrintValues(DataSet dataSet, string label) {
         Console.WriteLine(label + "\n");
         foreach (DataTable table in dataSet.Tables) {
            Console.WriteLine("TableName: " + table.TableName);
            foreach (DataRow row in table.Rows) {
               foreach (DataColumn column in table.Columns) {
                  Console.Write("\table " + row[column]);
               }
               Console.WriteLine();
            }
         }

      }
   }
}