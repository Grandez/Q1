using Q1Base.JSon;
using Q1Base.Pers.Tables;
using System;
using System.Collections.Generic;
using System.Data.OleDb;

namespace Q1Base.Pers  {
   public class SrvCierres : DB,  IService {
      private String insSql = "INSERT INTO ";
      private String insCierre = "Cierres (Moneda, Fecha, FOpen, FHigh, FLow, FClose, Volumen, MarketCap) " +
                                 "VALUES  (?,      ?,     ?,    ?,    ?,   ?,     ?,       ?)";
      
   
      private String qryCierres = "SELECT Monedas.Moneda, Monedas.Descripcion, Max(Cierres.fecha) AS Fecha " +
                                  "FROM   Monedas LEFT JOIN Cierres ON Monedas.Moneda = Cierres.Moneda " +
                                  "GROUP BY Monedas.Moneda, Monedas.Descripcion";

      private String insPrc = "CierresPrc (Moneda, Fecha, D01, D07, D30, D90) " +
                                 "VALUES   (?,      ?,     ?,   ?,   ?,   ?)";


      public void insert(List<Cierre> cierres) {
         OleDbCommand cmd = new OleDbCommand(insSql + insCierre);
         OleDbDataAdapter da = new OleDbDataAdapter();
         cmd.Connection = cn;
         
         foreach (Cierre c in cierres) {
            //Console.WriteLine("Moneda: " + c.moneda + " - Fecha: " + c.fecha);
            cmd.Parameters.AddWithValue("Moneda", c.moneda);
            cmd.Parameters.AddWithValue("Fecha", c.fecha);
            cmd.Parameters.AddWithValue("Open", c.open);
            cmd.Parameters.AddWithValue("High", c.high);
            cmd.Parameters.AddWithValue("Low", c.low);
            cmd.Parameters.AddWithValue("Close", c.close);
            cmd.Parameters.AddWithValue("Volumen", c.volumen / 1000);
            cmd.Parameters.AddWithValue("MarketCap", c.marketcap / 1000);
            da.InsertCommand = cmd;
            try {
               da.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception e) {
               LogMgr.err(e.Message);
               // En principio esto solo puede darse si un ticker 
               // No ha sido actualizado en el servidor desde la ultima carga
            }
            cmd.Parameters.Clear();
         }
      }

      public List<Row> getData(String moneda, long from) {
         String qry = "SELECT * FROM Cierres WHERE Moneda = ? ";
         if (from > 0) {
            qry = qry + "AND Fecha > ?";
         }
         qry = qry + " ORDER BY Fecha ASC";
         List<Row> data;
         if (from > 0) {
            return list(qry, moneda, from);
         }
         return list(qry, moneda);
      }

      public List<Cierres> getUltimoCierre() {
         List<Cierres> data = new List<Cierres>();
         OleDbCommand cmd = new OleDbCommand(qryCierres);
         cmd.Connection = cn;
         OleDbDataReader rdr = cmd.ExecuteReader();
         try {
            while (rdr.Read()) {
               Cierres d = new Cierres();
               d.Moneda = rdr.GetString(0);
               d.Nombre = rdr.GetString(1);
               d.Fecha = (rdr.IsDBNull(2)) ? 0 : rdr.GetInt32(2);
               data.Add(d);
            }
         }
         finally {
            rdr.Close();
         }
         return data;
      }

      public void insertPercentage(Trend data) {
         insertFromTrend(insSql + insPrc, data, 4);
      }
      public void insertPercentages(List<Trend> data) {
           insertFromTrend(insSql + insPrc, data, 4);
      }

      public List<decimal> getLast(String moneda) {
         String qry = "SELECT TOP 6 FClose, Fecha FROM Cierres WHERE Moneda = ? ORDER BY Fecha DESC";
         return getLastData(qry, moneda);
      }


   }

}
