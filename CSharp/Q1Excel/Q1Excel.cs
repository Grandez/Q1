using Q1Base.Pers.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Excel;
using Q1Base.Pers;

namespace Q1Excel {
   public class Q1Excel {

      public void loadData(Monedas moneda, int interval) {
         String name = moneda.Moneda + " Day";
         Excel.Workbook wb = Globals.ThisAddIn.Application.ActiveWorkbook;
         Excel.Worksheet sh =  wb.Worksheets.OfType<Excel.Worksheet>().FirstOrDefault(ws => ws.Name == name);
      
         if (sh == null) {
            sh = wb.Worksheets.Add();
            sh.Name = name;
         }
         long fecha = calculateEpoch(interval);
         loadDay(moneda.Moneda, fecha, sh);
      }

      private void loadDay(String moneda, long fecha, Excel.Worksheet sh) {
         String[] headers = { "Moneda", "Fecha", "Open", "High", "Low", "Close" };
         SrvCierres srvCierre = new SrvCierres();
         Excel.Range rng = sh.Cells;
         rng.ClearContents();
         int row = 1;
         for (int idx = 0; idx < headers.Length; idx++) {
            sh.Cells[row, idx + 1] = headers[idx];
         }
         row++;
         foreach (Row r in srvCierre.getData(moneda, fecha)) {
            int col = 1;
            sh.Cells[row, col++] = r.get("Moneda");
            sh.Cells[row, col++] = r.get("Fecha");
            sh.Cells[row, col++] = r.get("FOpen");
            sh.Cells[row, col++] = r.get("FHigh");
            sh.Cells[row, col++] = r.get("FLow");
            sh.Cells[row, col++] = r.get("FClose");
            row++;
         }

      }

      private long calculateEpoch(int interval) {
         if (interval <= 0) return 0;
         DateTime dt = DateTime.Now;
         dt.AddDays(interval * -1);
         DateTime org = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

         return (long) (dt - org).TotalSeconds;
      }

   }
}
