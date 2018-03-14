using Q1Base.Pers.Tables;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1Base.Pers {
   public class SrvMonedas : DB {

      public void updateMoneda(Monedas t) {
         Boolean exist = false;
         String qry = "SELECT Moneda FROM Monedas WHERE Moneda = ?";
         OleDbCommand cmd = new OleDbCommand(qry);
         cmd.Connection = cn;
         cmd.Parameters.AddWithValue("Moneda", t.Moneda);
         OleDbDataReader rdr = cmd.ExecuteReader();
         if (rdr.HasRows) exist = true;
         rdr.Close();
         cmd.Parameters.Clear();
         if (exist) {
            cmd.CommandText = "UPDATE Monedas SET Rango = ? WHERE Moneda = ?";
            cmd.Parameters.AddWithValue("Rango", t.Rango);
            cmd.Parameters.AddWithValue("Moneda", t.Moneda);
         }
         else {
            cmd.CommandText = "INSERT INTO Monedas (Moneda, Nombre, Rango) VALUES (?, ?, ?)";
            cmd.Parameters.AddWithValue("Moneda", t.Moneda);
            cmd.Parameters.AddWithValue("Nombre", t.Nombre);
            cmd.Parameters.AddWithValue("Rango", t.Rango);
         }
         cmd.ExecuteNonQuery();
         
      }

      public List<Monedas> listMonedas(Boolean active) {
         List<Monedas> data = new List<Monedas>();
         int activo = (active) ? 1 : 0;
         String qry = "SELECT Moneda, Nombre, Rango FROM Monedas WHERE Activo = ?";
         OleDbCommand cmd = new OleDbCommand(qry);
         cmd.Connection = cn;
         cmd.Parameters.AddWithValue("Activo", activo);
         OleDbDataReader rdr = cmd.ExecuteReader();
         while (rdr.Read()) {
            Monedas m = new Monedas();
            m.Moneda = rdr.GetString(0);
            m.Nombre = rdr.GetString(1);
            m.Rango = rdr.GetInt16(2);
            data.Add(m);
         }
         rdr.Close();
         return data;
      }

      public void updateEstado(Monedas moneda) {
         String qry = "UPDATE Monedas SET Activo = ? WHERE Moneda = ?";
         OleDbCommand cmd = new OleDbCommand(qry);
         cmd.Connection = cn;
         cmd.Parameters.AddWithValue("Activo", moneda.Activo);
         cmd.Parameters.AddWithValue("Moneda", moneda.Moneda);
         cmd.ExecuteNonQuery();
      }
   }
}
