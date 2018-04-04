namespace KatarinaInjectorGUI
{
    partial class Form1
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
            this.btnLeagueClient = new System.Windows.Forms.Button();
            this.btnLeagueClientUx = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.cmbDlls = new System.Windows.Forms.ComboBox();
            this.btnReloadDlls = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLeagueClient
            // 
            this.btnLeagueClient.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLeagueClient.Location = new System.Drawing.Point(12, 88);
            this.btnLeagueClient.Name = "btnLeagueClient";
            this.btnLeagueClient.Size = new System.Drawing.Size(618, 80);
            this.btnLeagueClient.TabIndex = 0;
            this.btnLeagueClient.Text = "LeagueClient";
            this.btnLeagueClient.UseVisualStyleBackColor = true;
            this.btnLeagueClient.Click += new System.EventHandler(this.btnLeagueClient_Click);
            // 
            // btnLeagueClientUx
            // 
            this.btnLeagueClientUx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLeagueClientUx.Location = new System.Drawing.Point(12, 174);
            this.btnLeagueClientUx.Name = "btnLeagueClientUx";
            this.btnLeagueClientUx.Size = new System.Drawing.Size(617, 80);
            this.btnLeagueClientUx.TabIndex = 1;
            this.btnLeagueClientUx.Text = "LeagueClientUx";
            this.btnLeagueClientUx.UseVisualStyleBackColor = true;
            this.btnLeagueClientUx.Click += new System.EventHandler(this.btnLeagueClientUx_Click);
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.Location = new System.Drawing.Point(12, 260);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.Size = new System.Drawing.Size(617, 297);
            this.txtLog.TabIndex = 2;
            // 
            // cmbDlls
            // 
            this.cmbDlls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbDlls.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDlls.FormattingEnabled = true;
            this.cmbDlls.ItemHeight = 24;
            this.cmbDlls.Location = new System.Drawing.Point(12, 43);
            this.cmbDlls.Name = "cmbDlls";
            this.cmbDlls.Size = new System.Drawing.Size(322, 32);
            this.cmbDlls.TabIndex = 3;
            // 
            // btnReloadDlls
            // 
            this.btnReloadDlls.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReloadDlls.Location = new System.Drawing.Point(340, 34);
            this.btnReloadDlls.Name = "btnReloadDlls";
            this.btnReloadDlls.Size = new System.Drawing.Size(290, 48);
            this.btnReloadDlls.TabIndex = 4;
            this.btnReloadDlls.Text = "Reload DLLs";
            this.btnReloadDlls.UseVisualStyleBackColor = true;
            this.btnReloadDlls.Click += new System.EventHandler(this.btnReloadDlls_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 569);
            this.Controls.Add(this.btnReloadDlls);
            this.Controls.Add(this.cmbDlls);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.btnLeagueClientUx);
            this.Controls.Add(this.btnLeagueClient);
            this.Name = "Form1";
            this.Text = "Katarina Injector";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLeagueClient;
        private System.Windows.Forms.Button btnLeagueClientUx;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.ComboBox cmbDlls;
        private System.Windows.Forms.Button btnReloadDlls;
    }
}

