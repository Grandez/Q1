using Q1Base.Pers;
using Q1Base.Pers.Tables;
using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Q1Excel {
   public partial class frmLoad : Form {
      private int periodo = 30;

      public frmLoad() {
         InitializeComponent();
      }

      private void button1_Click(object sender, EventArgs e) {
         this.Close();
      }

      private void frmLoad_Load(object sender, EventArgs e) {
         SrvMonedas srv = new SrvMonedas();
         this.lstMonedas.DisplayMember = "Nombre";
         this.lstMonedas.ValueMember = "Moneda";
         foreach (Monedas m in srv.listMonedas(true)) {
            this.lstMonedas.Items.Add(m);
         }

      }

      private void btnLoad_Click(object sender, EventArgs e) {
         Q1Excel xls = new Q1Excel();
         List<Monedas> monedas = new List<Monedas>();
         foreach (Monedas m in this.lstMonedas.SelectedItems) {
            xls.loadData(m, periodo);
         }
         this.Close();
      }

      private void btnPeriodSem_CheckedChanged(object sender, EventArgs e) {
         periodo = 7;
      }

      private void btnPeriodoMes_CheckedChanged(object sender, EventArgs e) {
         periodo = 30;
      }

      private void btnPeriodoTri_CheckedChanged(object sender, EventArgs e) {
         periodo = 90;
      }

      private void btnPeriodAgno_CheckedChanged(object sender, EventArgs e) {
         periodo = 365;
      }

      private void radioButton1_CheckedChanged(object sender, EventArgs e) {
         periodo = -1;
      }
   }
}
