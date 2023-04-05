namespace ASRE
{
    partial class frmMain
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
            this.btRefresh = new System.Windows.Forms.Button();
            this.ScriptMonitor = new System.IO.FileSystemWatcher();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.activeScripts = new System.Windows.Forms.CheckedListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ScriptMonitor)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btRefresh
            // 
            this.btRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btRefresh.BackColor = System.Drawing.Color.Gainsboro;
            this.btRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btRefresh.Image = global::ASRE.Properties.Resources.refresh;
            this.btRefresh.Location = new System.Drawing.Point(9, 350);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(23, 23);
            this.btRefresh.TabIndex = 2;
            this.btRefresh.UseVisualStyleBackColor = false;
            this.btRefresh.Click += new System.EventHandler(this.btRefresh_Click);
            // 
            // ScriptMonitor
            // 
            this.ScriptMonitor.EnableRaisingEvents = true;
            this.ScriptMonitor.Filter = "*.xml";
            this.ScriptMonitor.Path = "D:\\ASRE\\Scripts";
            this.ScriptMonitor.SynchronizingObject = this;
            this.ScriptMonitor.Renamed += new System.IO.RenamedEventHandler(this.ScriptMonitor_Renamed);
            this.ScriptMonitor.Deleted += new System.IO.FileSystemEventHandler(this.ScriptMonitor_Deleted);
            this.ScriptMonitor.Created += new System.IO.FileSystemEventHandler(this.ScriptMonitor_Created);
            this.ScriptMonitor.Changed += new System.IO.FileSystemEventHandler(this.ScriptMonitor_Changed);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(590, 412);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.activeScripts);
            this.tabPage1.Controls.Add(this.btRefresh);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(582, 386);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // activeScripts
            // 
            this.activeScripts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.activeScripts.FormattingEnabled = true;
            this.activeScripts.Location = new System.Drawing.Point(9, 21);
            this.activeScripts.Name = "activeScripts";
            this.activeScripts.ScrollAlwaysVisible = true;
            this.activeScripts.Size = new System.Drawing.Size(275, 319);
            this.activeScripts.TabIndex = 3;
            this.activeScripts.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.activeScripts_ItemCheck);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(582, 382);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 437);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmMain";
            this.Text = "ASRE - A Sequoia Replication Engine";
            ((System.ComponentModel.ISupportInitialize)(this.ScriptMonitor)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btRefresh;
        private System.IO.FileSystemWatcher ScriptMonitor;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.CheckedListBox activeScripts;
        private System.Windows.Forms.Timer timer1;
    }
}

