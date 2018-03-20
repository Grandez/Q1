using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace Q1Excel {
   class Q1XLS {
      public static Excel.Worksheet getSheet(String name) {
         Excel.Workbook wb = Globals.ThisAddIn.Application.ActiveWorkbook;
         return wb.Worksheets.OfType<Excel.Worksheet>().FirstOrDefault(ws => ws.Name == name);
      }
   }
}
