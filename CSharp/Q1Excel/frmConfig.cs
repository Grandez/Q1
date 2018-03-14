using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Q1Base;

namespace Q1Excel {
   public partial class frmConfig : Form {
      public frmConfig() {
         InitializeComponent();
      }

      private void btnCancel_Click(object sender, EventArgs e) {
         this.Close();
      }

      private void btnOK_Click(object sender, EventArgs e) {

      }

      private void frmConfig_Load(object sender, EventArgs e) {
         txtDB.Text = Config.getDataBase();

      }
   }
}
