using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;

namespace Q1Excel {
   public partial class Q1Ribbon {
      private void Ribbon2_Load(object sender, RibbonUIEventArgs e) {

      }

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
   }
}
