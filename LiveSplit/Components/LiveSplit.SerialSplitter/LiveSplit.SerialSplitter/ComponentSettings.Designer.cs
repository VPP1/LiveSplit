namespace LiveSplit.UI.Components
{
    partial class ComponentSettings
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbCOMPorts = new System.Windows.Forms.Label();
            this.cbCOMPorts = new System.Windows.Forms.ComboBox();
            this.lbBaudRate = new System.Windows.Forms.Label();
            this.cbBaudRate = new System.Windows.Forms.ComboBox();
            this.lbConnectivityMonitoring = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbConnectivityMonitoring = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 201F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.lbCOMPorts, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbCOMPorts, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbBaudRate, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.cbBaudRate, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lbConnectivityMonitoring, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.cbConnectivityMonitoring, 1, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(7, 7);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 9F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(462, 498);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // lbCOMPorts
            // 
            this.lbCOMPorts.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbCOMPorts.AutoSize = true;
            this.lbCOMPorts.Location = new System.Drawing.Point(56, 12);
            this.lbCOMPorts.Name = "lbCOMPorts";
            this.lbCOMPorts.Size = new System.Drawing.Size(88, 13);
            this.lbCOMPorts.TabIndex = 1;
            this.lbCOMPorts.Text = "Select COM port:";
            this.lbCOMPorts.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cbCOMPorts
            // 
            this.cbCOMPorts.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbCOMPorts.FormattingEnabled = true;
            this.cbCOMPorts.Location = new System.Drawing.Point(271, 8);
            this.cbCOMPorts.Name = "cbCOMPorts";
            this.cbCOMPorts.Size = new System.Drawing.Size(121, 21);
            this.cbCOMPorts.TabIndex = 0;
            // 
            // lbBaudRate
            // 
            this.lbBaudRate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbBaudRate.AutoSize = true;
            this.lbBaudRate.Location = new System.Drawing.Point(58, 46);
            this.lbBaudRate.Name = "lbBaudRate";
            this.lbBaudRate.Size = new System.Drawing.Size(85, 13);
            this.lbBaudRate.TabIndex = 2;
            this.lbBaudRate.Text = "Select baudrate:";
            this.lbBaudRate.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cbBaudRate
            // 
            this.cbBaudRate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbBaudRate.FormattingEnabled = true;
            this.cbBaudRate.Location = new System.Drawing.Point(271, 42);
            this.cbBaudRate.Name = "cbBaudRate";
            this.cbBaudRate.Size = new System.Drawing.Size(121, 21);
            this.cbBaudRate.TabIndex = 3;
            // 
            // lbConnectivityMonitoring
            // 
            this.lbConnectivityMonitoring.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbConnectivityMonitoring.AutoSize = true;
            this.lbConnectivityMonitoring.Location = new System.Drawing.Point(41, 86);
            this.lbConnectivityMonitoring.Name = "lbConnectivityMonitoring";
            this.lbConnectivityMonitoring.Size = new System.Drawing.Size(119, 13);
            this.lbConnectivityMonitoring.TabIndex = 5;
            this.lbConnectivityMonitoring.Text = "Connectivity monitoring:";
            this.lbConnectivityMonitoring.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(218, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 65);
            this.label1.TabIndex = 4;
            this.label1.Text = "Recieved serial messages and their respective actions:\r\n\r\n\'1\' = Start/Stop timer\r" +
    "\n\'2\' = Pause/Resume timer";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cbConnectivityMonitoring
            // 
            this.cbConnectivityMonitoring.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbConnectivityMonitoring.AutoSize = true;
            this.cbConnectivityMonitoring.Location = new System.Drawing.Point(324, 86);
            this.cbConnectivityMonitoring.Name = "cbConnectivityMonitoring";
            this.cbConnectivityMonitoring.Size = new System.Drawing.Size(15, 14);
            this.cbConnectivityMonitoring.TabIndex = 6;
            this.cbConnectivityMonitoring.UseVisualStyleBackColor = true;
            // 
            // ComponentSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ComponentSettings";
            this.Padding = new System.Windows.Forms.Padding(7);
            this.Size = new System.Drawing.Size(476, 512);
            this.Load += new System.EventHandler(this.ComponentSettings_Load);
            this.Leave += new System.EventHandler(this.ComponentSettings_Leave);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lbCOMPorts;
        private System.Windows.Forms.Label lbBaudRate;
        public System.Windows.Forms.ComboBox cbCOMPorts;
        public System.Windows.Forms.ComboBox cbBaudRate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbConnectivityMonitoring;
        private System.Windows.Forms.CheckBox cbConnectivityMonitoring;
    }
}
