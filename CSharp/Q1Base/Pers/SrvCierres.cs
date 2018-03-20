using Q1Base.JSon;
using Q1Base.Pers.Tables;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using Q1Base;

namespace Q1Base.Pers  {
   public class SrvCierres : DB,  IService {
      private String qryCierres = "SELECT Monedas.Moneda, Monedas.Nombre, Max(Cierres.Fecha) AS Fecha " +
                                  "FROM   Monedas LEFT JOIN Cierres ON Monedas.Moneda = Cierres.Moneda " +
                                  "GROUP BY Monedas.Moneda, Monedas.Nombre";

      private String insPrc = "CierresPrc (Moneda, Fecha, D01, D07, D30, D90) " +
                                 "VALUES   (?,      ?,     ?,   ?,   ?,   ?)";


      public void insert(List<Cierre> cierres) {
        String insSql = "INSERT INTO ";
        String insCierre = "Cierres (Moneda, Epoch, Fecha, FOpen, FHigh, FLow, FClose, FCloseEuro, Volumen, MarketCap) " +
                           "VALUES  (?,      ?,     ?,     ?,     ?,     ?,    ?,      ?,          ?,       ?)";

      String msg = "";
         OleDbCommand cmd = new OleDbCommand(insSql + insCierre);
         OleDbDataAdapter da = new OleDbDataAdapter();
         OleDbParameter parm;
         cmd.Connection = cn;
         
         foreach (Cierre c in cierres) {
            //Console.WriteLine("Moneda: " + c.moneda + " - Fecha: " + c.fecha);
            cmd.Parameters.AddWithValue("Moneda", c.moneda);
            cmd.Parameters.AddWithValue("Epoch", c.fecha);
            cmd.Parameters.AddWithValue("Fecha", epoch2DateTime(c.fecha));
            parm = new OleDbParameter("Open", OleDbType.VarChar);
            parm.Value = c.open.ToString();
            cmd.Parameters.Add(parm);
            parm = new OleDbParameter("High", OleDbType.VarChar);
            parm.Value = c.high.ToString();
            cmd.Parameters.Add(parm);
            parm = new OleDbParameter("Low", OleDbType.VarChar);
            parm.Value = c.low.ToString();
            cmd.Parameters.Add(parm);
            parm = new OleDbParameter("Close", OleDbType.VarChar);
            parm.Value = c.close.ToString();
            cmd.Parameters.Add(parm);
            parm = new OleDbParameter("Euro", OleDbType.VarChar);
            parm.Value = Math.Round(c.close / CFG.getEuro(), 2).ToString();
            cmd.Parameters.Add(parm);
            cmd.Parameters.AddWithValue("Volumen", c.volumen / 1000);
            cmd.Parameters.AddWithValue("Market", c.marketcap / 1000);
            da.InsertCommand = cmd;
            try {
               da.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception e) {
               // En principio esto solo puede darse si un ticker 
               // No ha sido actualizado en el servidor desde la ultima carga
               msg = e.Message;
            }
            cmd.Parameters.Clear();
         }
      }

      public List<Row> getData(String moneda, long from) {
         String qry = "SELECT * FROM Cierres WHERE Moneda = ? ";
         if (from > 0) {
            qry = qry + "AND Epoch > ?";
         }
         qry = qry + " ORDER BY Epoch DESC";
         
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
         insertFromTrend("INSERT INTO " + insPrc, data, 4);
      }
      public void insertPercentages(List<Trend> data) {
           insertFromTrend("INSERT INTO " + insPrc, data, 4);
      }

      public List<decimal> getLast(String moneda) {
         String qry = "SELECT TOP 6 FClose, Fecha FROM Cierres WHERE Moneda = ? ORDER BY Fecha DESC";
         return getLastData(qry, moneda);
      }

      private DateTime epoch2DateTime(long epoch) {
         if (epoch <= 0) return DateTime.Now;
         return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddSeconds(epoch);
      }
   }

}
