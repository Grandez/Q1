
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using Q1Base;
using Q1Base.JSon;

namespace Q1Base.Pers {
   public class DB {
      private String connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source = D:\\Prj\\Cartera\\portfolio.accdb";
      protected OleDbConnection cn = null;
      protected static DB data = null;

      public static DB getInstance() {
         if (data == null) data = new DB();
         return data;
      }

      public DB() {
         String db = Config.getDataBase();
         cn = new OleDbConnection(connStr);
         cn.Open();
      }

      public void close() {
         cn.Close();
      }
      /*
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
      */
      protected List<decimal> getLastData(String qry, String moneda) {
         List<decimal> data = new List<decimal>();
         OleDbCommand cmd = new OleDbCommand(qry);
         cmd.Connection = cn;
         cmd.Parameters.AddWithValue("Moneda", moneda);
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

      public List<Keys> getPending(String table) {
         List<Keys> data = new List<Keys>();
         String qry = "SELECT Moneda, Fecha FROM " + table + " WHERE Hecho = 0";
         OleDbCommand cmd = new OleDbCommand(qry);
         cmd.Connection = cn;
         OleDbDataReader rdr = cmd.ExecuteReader();
         try {
            while (rdr.Read()) {
               Keys d = new Keys();
               d.Moneda = rdr.GetString(0);
               d.Fecha = rdr.GetInt32(1);
               data.Add(d);
            }
         }
         finally {
            rdr.Close();
         }
         return data;
      }

      public void markDone(String table) {
         String qry = "UPDATE " + table + " SET Hecho = 1 WHERE Hecho = 0";
         OleDbCommand cmd = new OleDbCommand(qry);
         cmd.Connection = cn;
         cmd.ExecuteNonQuery();
      }

      protected void insertFromTrend(String sqlIns, List<Trend> data, int nParms) {
         OleDbCommand cmd = new OleDbCommand(sqlIns);
         cmd.Connection = cn;
         foreach (Trend t in data) {
            insertFromTrend(sqlIns, t, nParms);
         }
      }
      protected void insertFromTrend(String sqlIns, Trend t, int nParms) {
         OleDbCommand cmd = new OleDbCommand(sqlIns);
         cmd.Connection = cn;
         cmd.Parameters.AddWithValue("Moneda", t.Moneda);
         cmd.Parameters.AddWithValue("Fecha", t.Fecha);
         for (int idx = 0; idx < nParms; idx++) {
              cmd.Parameters.AddWithValue("P" + idx, t.getValue(idx));
         }
         cmd.ExecuteNonQuery();
         cmd.Parameters.Clear();
      }

      protected List<Row> list(String qry, params object[] args) {
         List<Row> data = new List<Row>();
         OleDbCommand cmd = new OleDbCommand(qry);
         cmd.Connection = cn;
         for (int idx = 0; idx < args.Length; idx++) {
            cmd.Parameters.AddWithValue("Prm" + idx, args[idx]);
         }
         OleDbDataReader rdr = cmd.ExecuteReader();
         DataTable dt = rdr.GetSchemaTable();
         while (rdr.Read()) {
            Row row = new Row();
            for (int idx = 0; idx < rdr.FieldCount; idx++) {
               row.Add(rdr.GetName(idx), rdr.GetValue(idx));
            }
            data.Add(row);
         }
         return data;
      }
   }
}