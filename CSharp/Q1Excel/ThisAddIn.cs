using Excel = Microsoft.Office.Interop.Excel;
using Q1Base;

namespace Q1Excel
{
    public partial class ThisAddIn
    {
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
      }

      private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }

      void wbOpen(Excel.Workbook Wb) {
         string shName = CFG.getMasterSheet();
         Excel.Worksheet sh = Q1XLS.getSheet(shName);
         if (sh != null) {
            Q1Threading t = Q1Threading.getInstance();
            t.startTickers();
            // Ocultar la opcion de menu
         }
      }

      void wbActivate(Excel.Workbook Wb) {
         
         string shName = CFG.getMasterSheet();
         Excel.Worksheet sh = Q1XLS.getSheet(shName);
         if (sh != null) {
            // Ocultar la opcion de menu
         }
      }

      #region Código generado por VSTO

      /// <summary>
      /// Método necesario para admitir el Diseñador. No se puede modificar
      /// el contenido de este método con el editor de código.
      /// </summary>
      private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
            this.Application.WorkbookOpen += new Excel.AppEvents_WorkbookOpenEventHandler(wbOpen);
            this.Application.WorkbookActivate += new Excel.AppEvents_WorkbookActivateEventHandler(wbActivate);
      }
        
        #endregion
    }
}
