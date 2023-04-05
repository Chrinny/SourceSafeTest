namespace Pilkngton.ProjectPaint.PaintApp
{
    partial class frmPassword
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
            this.cmdPasswordOK = new System.Windows.Forms.Button();
            this.cmdPasswordCancel = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmdPasswordOK
            // 
            this.cmdPasswordOK.Location = new System.Drawing.Point(43, 101);
            this.cmdPasswordOK.Name = "cmdPasswordOK";
            this.cmdPasswordOK.Size = new System.Drawing.Size(75, 36);
            this.cmdPasswordOK.TabIndex = 1;
            this.cmdPasswordOK.Text = "&OK";
            this.cmdPasswordOK.UseVisualStyleBackColor = true;
            this.cmdPasswordOK.Click += new System.EventHandler(this.cmdPasswordOK_Click);
            // 
            // cmdPasswordCancel
            // 
            this.cmdPasswordCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdPasswordCancel.Location = new System.Drawing.Point(164, 101);
            this.cmdPasswordCancel.Name = "cmdPasswordCancel";
            this.cmdPasswordCancel.Size = new System.Drawing.Size(75, 36);
            this.cmdPasswordCancel.TabIndex = 2;
            this.cmdPasswordCancel.Text = "&Cancel";
            this.cmdPasswordCancel.UseVisualStyleBackColor = true;
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(43, 48);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(196, 24);
            this.txtPassword.TabIndex = 0;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(250, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Enter password here to proceed";
            // 
            // frmPassword
            // 
            this.AcceptButton = this.cmdPasswordOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.CancelButton = this.cmdPasswordCancel;
            this.ClientSize = new System.Drawing.Size(286, 182);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.cmdPasswordCancel);
            this.Controls.Add(this.cmdPasswordOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Password";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdPasswordOK;
        private System.Windows.Forms.Button cmdPasswordCancel;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label1;
    }
}