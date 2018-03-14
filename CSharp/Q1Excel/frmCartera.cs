using Q1Base.Pers;
using Q1Base.Pers.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Q1Excel {
   public partial class frmCartera : Form {
      private Dictionary<String, Monedas> cambios = new Dictionary<String, Monedas>();

      public frmCartera() {
         InitializeComponent();
      }

      private void frmCartera_Load(object sender, EventArgs e) {
         SrvMonedas srv = new SrvMonedas();
         this.lstList.DisplayMember = "Nombre";
         this.lstList.ValueMember = "Moneda";
         foreach (Monedas m in srv.listMonedas(false)) {
            this.lstList.Items.Add(m);
         }
         this.lstCartera.DisplayMember = "Nombre";
         this.lstCartera.ValueMember = "Moneda";
         foreach (Monedas m in srv.listMonedas(true)) {
            this.lstCartera.Items.Add(m);
         }
         btnRemove.Enabled = false;
         btnAdd.Enabled = false;

      }

      private void btnRemove_Click(object sender, EventArgs e) {
         int pos = this.lstCartera.SelectedIndex;
         Monedas m = this.lstCartera.Items[pos] as Monedas;
         m.Activo = 0;
         cambios[m.Moneda] = m;
         this.lstCartera.Items.Remove(pos);
         this.lstList.Items.Add(m);
         btnRemove.Enabled = false;
      }

      private void btnAdd_Click(object sender, EventArgs e) {
         int pos = this.lstList.SelectedIndex;
         Monedas m = this.lstList.Items[pos] as Monedas;
         m.Activo = 1;
         cambios[m.Moneda] = m;
         this.lstList.Items.RemoveAt(pos);
         this.lstCartera.Items.Add(m);
         btnAdd.Enabled = false;
      }

      private void btnCancel_Click(object sender, EventArgs e) {
         this.Close();
      }

      private void btnOK_Click(object sender, EventArgs e) {
         SrvMonedas srv = new SrvMonedas();
         foreach (var pair in cambios) {
            srv.updateEstado(pair.Value);
         }
      }

      private void lstList_SelectedIndexChanged(object sender, EventArgs e) {
         this.btnAdd.Enabled = true;
      }

      private void lstCartera_SelectedIndexChanged(object sender, EventArgs e) {
         this.btnRemove.Enabled = true;
      }
   }
}
