namespace Q1Excel {
   partial class frmLoad {
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLoad));
         this.lstMonedas = new System.Windows.Forms.ListBox();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.btnPeriodoTri = new System.Windows.Forms.RadioButton();
         this.btnPeriodoMes = new System.Windows.Forms.RadioButton();
         this.btnPeriodSem = new System.Windows.Forms.RadioButton();
         this.btnLoad = new System.Windows.Forms.Button();
         this.btnCancel = new System.Windows.Forms.Button();
         this.btnPeriodAgno = new System.Windows.Forms.RadioButton();
         this.btnPeriodYTD = new System.Windows.Forms.RadioButton();
         this.radioButton1 = new System.Windows.Forms.RadioButton();
         this.chkInterval = new System.Windows.Forms.CheckBox();
         this.groupBox1.SuspendLayout();
         this.SuspendLayout();
         // 
         // lstMonedas
         // 
         this.lstMonedas.FormattingEnabled = true;
         this.lstMonedas.Location = new System.Drawing.Point(18, 21);
         this.lstMonedas.Name = "lstMonedas";
         this.lstMonedas.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
         this.lstMonedas.Size = new System.Drawing.Size(195, 212);
         this.lstMonedas.TabIndex = 0;
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this.chkInterval);
         this.groupBox1.Controls.Add(this.radioButton1);
         this.groupBox1.Controls.Add(this.btnPeriodYTD);
         this.groupBox1.Controls.Add(this.btnPeriodAgno);
         this.groupBox1.Controls.Add(this.btnPeriodoTri);
         this.groupBox1.Controls.Add(this.btnPeriodoMes);
         this.groupBox1.Controls.Add(this.btnPeriodSem);
         this.groupBox1.Location = new System.Drawing.Point(238, 21);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(138, 212);
         this.groupBox1.TabIndex = 2;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "Periodo";
         // 
         // btnPeriodoTri
         // 
         this.btnPeriodoTri.AutoSize = true;
         this.btnPeriodoTri.Location = new System.Drawing.Point(21, 70);
         this.btnPeriodoTri.Name = "btnPeriodoTri";
         this.btnPeriodoTri.Size = new System.Drawing.Size(68, 17);
         this.btnPeriodoTri.TabIndex = 3;
         this.btnPeriodoTri.Text = "Trimestre";
         this.btnPeriodoTri.UseVisualStyleBackColor = true;
         this.btnPeriodoTri.CheckedChanged += new System.EventHandler(this.btnPeriodoTri_CheckedChanged);
         // 
         // btnPeriodoMes
         // 
         this.btnPeriodoMes.AutoSize = true;
         this.btnPeriodoMes.Checked = true;
         this.btnPeriodoMes.Location = new System.Drawing.Point(21, 47);
         this.btnPeriodoMes.Name = "btnPeriodoMes";
         this.btnPeriodoMes.Size = new System.Drawing.Size(45, 17);
         this.btnPeriodoMes.TabIndex = 2;
         this.btnPeriodoMes.TabStop = true;
         this.btnPeriodoMes.Text = "Mes";
         this.btnPeriodoMes.UseVisualStyleBackColor = true;
         this.btnPeriodoMes.CheckedChanged += new System.EventHandler(this.btnPeriodoMes_CheckedChanged);
         // 
         // btnPeriodSem
         // 
         this.btnPeriodSem.AutoSize = true;
         this.btnPeriodSem.Location = new System.Drawing.Point(21, 24);
         this.btnPeriodSem.Name = "btnPeriodSem";
         this.btnPeriodSem.Size = new System.Drawing.Size(64, 17);
         this.btnPeriodSem.TabIndex = 1;
         this.btnPeriodSem.Text = "Semana";
         this.btnPeriodSem.UseVisualStyleBackColor = true;
         this.btnPeriodSem.CheckedChanged += new System.EventHandler(this.btnPeriodSem_CheckedChanged);
         // 
         // btnLoad
         // 
         this.btnLoad.Image = ((System.Drawing.Image)(resources.GetObject("btnLoad.Image")));
         this.btnLoad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
         this.btnLoad.Location = new System.Drawing.Point(97, 253);
         this.btnLoad.Name = "btnLoad";
         this.btnLoad.Size = new System.Drawing.Size(95, 30);
         this.btnLoad.TabIndex = 4;
         this.btnLoad.Text = "&Cargar";
         this.btnLoad.UseVisualStyleBackColor = true;
         this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
         // 
         // btnCancel
         // 
         this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
         this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
         this.btnCancel.Location = new System.Drawing.Point(214, 253);
         this.btnCancel.Name = "btnCancel";
         this.btnCancel.Size = new System.Drawing.Size(95, 30);
         this.btnCancel.TabIndex = 5;
         this.btnCancel.Text = "&Cancelar";
         this.btnCancel.UseVisualStyleBackColor = true;
         this.btnCancel.Click += new System.EventHandler(this.button1_Click);
         // 
         // btnPeriodAgno
         // 
         this.btnPeriodAgno.AutoSize = true;
         this.btnPeriodAgno.Location = new System.Drawing.Point(21, 93);
         this.btnPeriodAgno.Name = "btnPeriodAgno";
         this.btnPeriodAgno.Size = new System.Drawing.Size(44, 17);
         this.btnPeriodAgno.TabIndex = 4;
         this.btnPeriodAgno.Text = "Año";
         this.btnPeriodAgno.UseVisualStyleBackColor = true;
         this.btnPeriodAgno.CheckedChanged += new System.EventHandler(this.btnPeriodAgno_CheckedChanged);
         // 
         // btnPeriodYTD
         // 
         this.btnPeriodYTD.AutoSize = true;
         this.btnPeriodYTD.Location = new System.Drawing.Point(21, 116);
         this.btnPeriodYTD.Name = "btnPeriodYTD";
         this.btnPeriodYTD.Size = new System.Drawing.Size(76, 17);
         this.btnPeriodYTD.TabIndex = 5;
         this.btnPeriodYTD.Text = "Año actual";
         this.btnPeriodYTD.UseVisualStyleBackColor = true;
         // 
         // radioButton1
         // 
         this.radioButton1.AutoSize = true;
         this.radioButton1.Location = new System.Drawing.Point(21, 139);
         this.radioButton1.Name = "radioButton1";
         this.radioButton1.Size = new System.Drawing.Size(50, 17);
         this.radioButton1.TabIndex = 6;
         this.radioButton1.Text = "Todo";
         this.radioButton1.UseVisualStyleBackColor = true;
         this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
         // 
         // chkInterval
         // 
         this.chkInterval.AutoSize = true;
         this.chkInterval.Checked = true;
         this.chkInterval.CheckState = System.Windows.Forms.CheckState.Checked;
         this.chkInterval.Location = new System.Drawing.Point(25, 180);
         this.chkInterval.Name = "chkInterval";
         this.chkInterval.Size = new System.Drawing.Size(67, 17);
         this.chkInterval.TabIndex = 7;
         this.chkInterval.Text = "Intervalo";
         this.chkInterval.UseVisualStyleBackColor = true;
         // 
         // frmLoad
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(402, 300);
         this.Controls.Add(this.btnCancel);
         this.Controls.Add(this.btnLoad);
         this.Controls.Add(this.groupBox1);
         this.Controls.Add(this.lstMonedas);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "frmLoad";
         this.Text = "Cargar datos";
         this.Load += new System.EventHandler(this.frmLoad_Load);
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.ListBox lstMonedas;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.RadioButton btnPeriodoTri;
      private System.Windows.Forms.RadioButton btnPeriodoMes;
      private System.Windows.Forms.RadioButton btnPeriodSem;
      private System.Windows.Forms.Button btnLoad;
      private System.Windows.Forms.Button btnCancel;
      private System.Windows.Forms.CheckBox chkInterval;
      private System.Windows.Forms.RadioButton radioButton1;
      private System.Windows.Forms.RadioButton btnPeriodYTD;
      private System.Windows.Forms.RadioButton btnPeriodAgno;
   }
}