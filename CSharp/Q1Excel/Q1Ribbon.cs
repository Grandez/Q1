using Microsoft.Office.Tools.Ribbon;
using Q1Base;

namespace Q1Excel {
   public partial class Q1Ribbon {

      private void btnConfig_Click(object sender, RibbonControlEventArgs e) {
         frmConfig frm = new frmConfig();
         frm.ShowDialog();
      }

      private void btnCartera_Click(object sender, RibbonControlEventArgs e) {
         frmCartera frm = new frmCartera();
         frm.ShowDialog();
      }

      private void btnLoad_Click(object sender, RibbonControlEventArgs e) {
         frmLoad frm = new frmLoad();
         frm.ShowDialog();
      }

      private void btnStock_Click(object sender, RibbonControlEventArgs e) {
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Q1Ribbon));
         CFG.Loading = !CFG.Loading;
         if (CFG.Loading) {
            btnStock.Image = ((System.Drawing.Image)(resources.GetObject("btnStockOK.Image")));
            btnStock.Label = "Cotizacion\nActivo";
            Q1Threading t = Q1Threading.getInstance();
            t.startTickers();
         }
         else {
            btnStock.Image = ((System.Drawing.Image)(resources.GetObject("btnStockKO.Image")));
            btnStock.Label = "Cotizacion";
         }
      }
   }
}
