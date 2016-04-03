namespace CTS
{
    partial class Screen1SeatSel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.screenmasterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cTSDBDataSet1 = new CTS.CTSDBDataSet1();
            this.screenmasterTableAdapter = new CTS.CTSDBDataSet1TableAdapters.ScreenmasterTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.screenmasterBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cTSDBDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // screenmasterBindingSource
            // 
            this.screenmasterBindingSource.DataMember = "Screenmaster";
            this.screenmasterBindingSource.DataSource = this.cTSDBDataSet1;
            // 
            // cTSDBDataSet1
            // 
            this.cTSDBDataSet1.DataSetName = "CTSDBDataSet1";
            this.cTSDBDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // screenmasterTableAdapter
            // 
            this.screenmasterTableAdapter.ClearBeforeFill = true;
            // 
            // Screen1SeatSel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1362, 741);
            this.MaximizeBox = false;
            this.Name = "Screen1SeatSel";
            this.Text = "Screen 1 Seat Selection";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Screen1SeatSel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.screenmasterBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cTSDBDataSet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private CTSDBDataSet1 cTSDBDataSet1;
        private System.Windows.Forms.BindingSource screenmasterBindingSource;
        private CTSDBDataSet1TableAdapters.ScreenmasterTableAdapter screenmasterTableAdapter;
    }
}