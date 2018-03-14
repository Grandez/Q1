namespace Q1Excel {
   partial class Q1Ribbon : Microsoft.Office.Tools.Ribbon.RibbonBase {
      /// <summary>
      /// Variable del diseñador necesaria.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      public Q1Ribbon()
          : base(Globals.Factory.GetRibbonFactory()) {
         InitializeComponent();
      }

      /// <summary> 
      /// Limpiar los recursos que se estén usando.
      /// </summary>
      /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
      protected override void Dispose(bool disposing) {
         if (disposing && (components != null)) {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Código generado por el Diseñador de componentes

      /// <summary>
      /// Método necesario para admitir el Diseñador. No se puede modificar
      /// el contenido de este método con el editor de código.
      /// </summary>
      private void InitializeComponent() {
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Q1Ribbon));
         this.tabQ1 = this.Factory.CreateRibbonTab();
         this.grpQ1 = this.Factory.CreateRibbonGroup();
         this.btnLoad = this.Factory.CreateRibbonButton();
         this.btnCartera = this.Factory.CreateRibbonButton();
         this.btnConfig = this.Factory.CreateRibbonButton();
         this.tabQ1.SuspendLayout();
         this.grpQ1.SuspendLayout();
         this.SuspendLayout();
         // 
         // tabQ1
         // 
         this.tabQ1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
         this.tabQ1.Groups.Add(this.grpQ1);
         this.tabQ1.Label = "Quant Q1";
         this.tabQ1.Name = "tabQ1";
         // 
         // grpQ1
         // 
         this.grpQ1.Items.Add(this.btnLoad);
         this.grpQ1.Items.Add(this.btnCartera);
         this.grpQ1.Items.Add(this.btnConfig);
         this.grpQ1.Label = "Q1";
         this.grpQ1.Name = "grpQ1";
         // 
         // btnLoad
         // 
         this.btnLoad.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
         this.btnLoad.Image = ((System.Drawing.Image)(resources.GetObject("btnLoad.Image")));
         this.btnLoad.Label = "Cargar";
         this.btnLoad.Name = "btnLoad";
         this.btnLoad.ShowImage = true;
         this.btnLoad.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnLoad_Click);
         // 
         // btnCartera
         // 
         this.btnCartera.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
         this.btnCartera.Image = ((System.Drawing.Image)(resources.GetObject("btnCartera.Image")));
         this.btnCartera.Label = "Cartera";
         this.btnCartera.Name = "btnCartera";
         this.btnCartera.ShowImage = true;
         this.btnCartera.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnCartera_Click);
         // 
         // btnConfig
         // 
         this.btnConfig.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
         this.btnConfig.Image = ((System.Drawing.Image)(resources.GetObject("btnConfig.Image")));
         this.btnConfig.Label = "Configurar";
         this.btnConfig.Name = "btnConfig";
         this.btnConfig.ShowImage = true;
         this.btnConfig.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnConfig_Click);
         // 
         // Q1Ribbon
         // 
         this.Name = "Q1Ribbon";
         this.RibbonType = "Microsoft.Excel.Workbook";
         this.Tabs.Add(this.tabQ1);
         this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.Ribbon2_Load);
         this.tabQ1.ResumeLayout(false);
         this.tabQ1.PerformLayout();
         this.grpQ1.ResumeLayout(false);
         this.grpQ1.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      internal Microsoft.Office.Tools.Ribbon.RibbonTab tabQ1;
      internal Microsoft.Office.Tools.Ribbon.RibbonGroup grpQ1;
      internal Microsoft.Office.Tools.Ribbon.RibbonButton btnConfig;
      internal Microsoft.Office.Tools.Ribbon.RibbonButton btnLoad;
      internal Microsoft.Office.Tools.Ribbon.RibbonButton btnCartera;
   }

   partial class ThisRibbonCollection {
      internal Q1Ribbon Ribbon2 {
         get { return this.GetRibbon<Q1Ribbon>(); }
      }
   }
}
