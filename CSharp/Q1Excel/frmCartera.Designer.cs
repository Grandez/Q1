namespace Q1Excel {
   partial class frmCartera {
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCartera));
         this.lstList = new System.Windows.Forms.ListBox();
         this.lstCartera = new System.Windows.Forms.ListBox();
         this.btnAdd = new System.Windows.Forms.Button();
         this.btnRemove = new System.Windows.Forms.Button();
         this.btnCancel = new System.Windows.Forms.Button();
         this.btnOK = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // lstList
         // 
         this.lstList.FormattingEnabled = true;
         this.lstList.Location = new System.Drawing.Point(26, 44);
         this.lstList.Name = "lstList";
         this.lstList.Size = new System.Drawing.Size(251, 355);
         this.lstList.Sorted = true;
         this.lstList.TabIndex = 0;
         this.lstList.SelectedIndexChanged += new System.EventHandler(this.lstList_SelectedIndexChanged);
         // 
         // lstCartera
         // 
         this.lstCartera.FormattingEnabled = true;
         this.lstCartera.Location = new System.Drawing.Point(418, 44);
         this.lstCartera.Name = "lstCartera";
         this.lstCartera.Size = new System.Drawing.Size(264, 342);
         this.lstCartera.Sorted = true;
         this.lstCartera.TabIndex = 1;
         this.lstCartera.SelectedIndexChanged += new System.EventHandler(this.lstCartera_SelectedIndexChanged);
         // 
         // btnAdd
         // 
         this.btnAdd.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAdd.BackgroundImage")));
         this.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
         this.btnAdd.Location = new System.Drawing.Point(307, 127);
         this.btnAdd.Name = "btnAdd";
         this.btnAdd.Size = new System.Drawing.Size(65, 43);
         this.btnAdd.TabIndex = 2;
         this.btnAdd.UseVisualStyleBackColor = true;
         this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
         // 
         // btnRemove
         // 
         this.btnRemove.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRemove.BackgroundImage")));
         this.btnRemove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
         this.btnRemove.Location = new System.Drawing.Point(307, 190);
         this.btnRemove.Name = "btnRemove";
         this.btnRemove.Size = new System.Drawing.Size(65, 43);
         this.btnRemove.TabIndex = 3;
         this.btnRemove.UseVisualStyleBackColor = true;
         this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
         // 
         // btnCancel
         // 
         this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
         this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
         this.btnCancel.Location = new System.Drawing.Point(307, 331);
         this.btnCancel.Name = "btnCancel";
         this.btnCancel.Size = new System.Drawing.Size(95, 30);
         this.btnCancel.TabIndex = 5;
         this.btnCancel.Text = "&Cancelar";
         this.btnCancel.UseVisualStyleBackColor = true;
         this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
         // 
         // btnOK
         // 
         this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
         this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
         this.btnOK.Location = new System.Drawing.Point(307, 274);
         this.btnOK.Name = "btnOK";
         this.btnOK.Size = new System.Drawing.Size(95, 30);
         this.btnOK.TabIndex = 4;
         this.btnOK.Text = "&Aceptar";
         this.btnOK.UseVisualStyleBackColor = true;
         this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
         // 
         // frmCartera
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(800, 450);
         this.Controls.Add(this.btnCancel);
         this.Controls.Add(this.btnOK);
         this.Controls.Add(this.btnRemove);
         this.Controls.Add(this.btnAdd);
         this.Controls.Add(this.lstCartera);
         this.Controls.Add(this.lstList);
         this.Name = "frmCartera";
         this.Text = "Cartera";
         this.Load += new System.EventHandler(this.frmCartera_Load);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.ListBox lstList;
      private System.Windows.Forms.ListBox lstCartera;
      private System.Windows.Forms.Button btnAdd;
      private System.Windows.Forms.Button btnRemove;
      private System.Windows.Forms.Button btnCancel;
      private System.Windows.Forms.Button btnOK;
   }
}