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
         txtDB.Text = CFG.getDataBase();

      }

      private void btnOpenDB_Click(object sender, EventArgs e) {
         dlgOpen = new OpenFileDialog();
         dlgOpen.Filter = "Databases|*.accdb";
         dlgOpen.Title = "Seleccionar la base de datos";

         // Show the Dialog.  
         // If the user clicked OK in the dialog and  
         // a .CUR file was selected, open it.  
         if (dlgOpen.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
            // Assign the cursor in the Stream to the Form's Cursor property.  
            //this.Cursor = new Cursor(openFileDialog1.OpenFile());
         }
      }
   }
}
