namespace Q1Excel {
   partial class frmConfig {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing) {
         if (disposing && (components != null)) {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent() {
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfig));
         this.btnOK = new System.Windows.Forms.Button();
         this.btnCancel = new System.Windows.Forms.Button();
         this.lblDB = new System.Windows.Forms.Label();
         this.txtDB = new System.Windows.Forms.TextBox();
         this.lblExcel = new System.Windows.Forms.Label();
         this.txtLibro = new System.Windows.Forms.TextBox();
         this.lblHoja = new System.Windows.Forms.Label();
         this.txtHoja = new System.Windows.Forms.TextBox();
         this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
         this.btnOpenDB = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // btnOK
         // 
         this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
         this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
         this.btnOK.Location = new System.Drawing.Point(169, 141);
         this.btnOK.Name = "btnOK";
         this.btnOK.Size = new System.Drawing.Size(75, 23);
         this.btnOK.TabIndex = 4;
         this.btnOK.Text = "&Acceptar";
         this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
         // 
         // btnCancel
         // 
         this.btnCancel.Location = new System.Drawing.Point(290, 141);
         this.btnCancel.Name = "btnCancel";
         this.btnCancel.Size = new System.Drawing.Size(75, 23);
         this.btnCancel.TabIndex = 5;
         this.btnCancel.Text = "&Cancelar";
         this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
         // 
         // lblDB
         // 
         this.lblDB.AutoSize = true;
         this.lblDB.Location = new System.Drawing.Point(23, 24);
         this.lblDB.Name = "lblDB";
         this.lblDB.Size = new System.Drawing.Size(75, 13);
         this.lblDB.TabIndex = 2;
         this.lblDB.Text = "Base de datos";
         // 
         // txtDB
         // 
         this.txtDB.Location = new System.Drawing.Point(114, 20);
         this.txtDB.Name = "txtDB";
         this.txtDB.Size = new System.Drawing.Size(240, 20);
         this.txtDB.TabIndex = 0;
         // 
         // lblExcel
         // 
         this.lblExcel.AutoSize = true;
         this.lblExcel.Location = new System.Drawing.Point(24, 55);
         this.lblExcel.Name = "lblExcel";
         this.lblExcel.Size = new System.Drawing.Size(59, 13);
         this.lblExcel.TabIndex = 4;
         this.lblExcel.Text = "Libro Excel";
         // 
         // txtLibro
         // 
         this.txtLibro.Location = new System.Drawing.Point(115, 51);
         this.txtLibro.Name = "txtLibro";
         this.txtLibro.Size = new System.Drawing.Size(240, 20);
         this.txtLibro.TabIndex = 2;
         // 
         // lblHoja
         // 
         this.lblHoja.AutoSize = true;
         this.lblHoja.Location = new System.Drawing.Point(24, 88);
         this.lblHoja.Name = "lblHoja";
         this.lblHoja.Size = new System.Drawing.Size(29, 13);
         this.lblHoja.TabIndex = 6;
         this.lblHoja.Text = "Hoja";
         // 
         // txtHoja
         // 
         this.txtHoja.Location = new System.Drawing.Point(115, 84);
         this.txtHoja.Name = "txtHoja";
         this.txtHoja.Size = new System.Drawing.Size(240, 20);
         this.txtHoja.TabIndex = 3;
         // 
         // btnOpenDB
         // 
         this.btnOpenDB.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnOpenDB.BackgroundImage")));
         this.btnOpenDB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
         this.btnOpenDB.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenDB.Image")));
         this.btnOpenDB.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
         this.btnOpenDB.Location = new System.Drawing.Point(359, 22);
         this.btnOpenDB.Name = "btnOpenDB";
         this.btnOpenDB.Size = new System.Drawing.Size(29, 20);
         this.btnOpenDB.TabIndex = 1;
         this.btnOpenDB.UseVisualStyleBackColor = true;
         this.btnOpenDB.Click += new System.EventHandler(this.btnOpenDB_Click);
         // 
         // frmConfig
         // 
         this.ClientSize = new System.Drawing.Size(579, 347);
         this.Controls.Add(this.btnOpenDB);
         this.Controls.Add(this.txtHoja);
         this.Controls.Add(this.lblHoja);
         this.Controls.Add(this.txtLibro);
         this.Controls.Add(this.lblExcel);
         this.Controls.Add(this.txtDB);
         this.Controls.Add(this.lblDB);
         this.Controls.Add(this.btnCancel);
         this.Controls.Add(this.btnOK);
         this.Name = "frmConfig";
         this.Text = "Configuracion";
         this.Load += new System.EventHandler(this.frmConfig_Load);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label lblDB;
      private System.Windows.Forms.TextBox txtDB;
      private System.Windows.Forms.OpenFileDialog dlgOpen;
      private System.Windows.Forms.Button btnOK;
      private System.Windows.Forms.Button btnCancel;
      private System.Windows.Forms.Label lblExcel;
      private System.Windows.Forms.TextBox txtLibro;
      private System.Windows.Forms.Label lblHoja;
      private System.Windows.Forms.TextBox txtHoja;
      private System.Windows.Forms.Button btnOpenDB;
   }
}