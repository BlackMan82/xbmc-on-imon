namespace iMon.XBMC.Dialogs
{
    partial class AboutDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutDialog));
            this.bClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lVersion = new System.Windows.Forms.Label();
            this.lCopyright = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lJsonRpcApiVersion = new System.Windows.Forms.Label();
            this.lImonDisplayApiVersion = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lImonDisplayApiWrapperVersion = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bClose
            // 
            this.bClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bClose.Location = new System.Drawing.Point(164, 391);
            this.bClose.Name = "bClose";
            this.bClose.Size = new System.Drawing.Size(75, 23);
            this.bClose.TabIndex = 0;
            this.bClose.Text = "Close";
            this.bClose.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(117, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "XBMC on iMON Display";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lVersion
            // 
            this.lVersion.AutoSize = true;
            this.lVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lVersion.Location = new System.Drawing.Point(174, 31);
            this.lVersion.Name = "lVersion";
            this.lVersion.Size = new System.Drawing.Size(54, 13);
            this.lVersion.TabIndex = 2;
            this.lVersion.Text = "v0.0.0.0";
            // 
            // lCopyright
            // 
            this.lCopyright.AutoSize = true;
            this.lCopyright.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lCopyright.Location = new System.Drawing.Point(93, 174);
            this.lCopyright.Name = "lCopyright";
            this.lCopyright.Size = new System.Drawing.Size(203, 13);
            this.lCopyright.TabIndex = 3;
            this.lCopyright.Text = "Copyright Sascha Montellese 2010";
            this.lCopyright.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 196);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(378, 169);
            this.label3.TabIndex = 4;
            this.label3.Text = resources.GetString("label3.Text");
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // linkLabel1
            // 
            this.linkLabel1.ActiveLinkColor = System.Drawing.Color.Blue;
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.AlwaysUnderline;
            this.linkLabel1.LinkColor = System.Drawing.Color.Blue;
            this.linkLabel1.Location = new System.Drawing.Point(109, 365);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(184, 13);
            this.linkLabel1.TabIndex = 5;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "http://www.gnu.org/copyleft/gpl.html";
            this.linkLabel1.VisitedLinkColor = System.Drawing.Color.Blue;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.openLink);
            // 
            // linkLabel2
            // 
            this.linkLabel2.ActiveLinkColor = System.Drawing.Color.Blue;
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.LinkBehavior = System.Windows.Forms.LinkBehavior.AlwaysUnderline;
            this.linkLabel2.LinkColor = System.Drawing.Color.Blue;
            this.linkLabel2.Location = new System.Drawing.Point(108, 59);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(236, 13);
            this.linkLabel2.TabIndex = 6;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "http://forum.xbmc.org/showthread.php?t=84166";
            this.linkLabel2.VisitedLinkColor = System.Drawing.Color.Blue;
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.openLink);
            // 
            // linkLabel3
            // 
            this.linkLabel3.ActiveLinkColor = System.Drawing.Color.Blue;
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.LinkBehavior = System.Windows.Forms.LinkBehavior.AlwaysUnderline;
            this.linkLabel3.LinkColor = System.Drawing.Color.Blue;
            this.linkLabel3.Location = new System.Drawing.Point(108, 44);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(229, 13);
            this.linkLabel3.TabIndex = 7;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "https://sourceforge.net/projects/xbmc-on-imon";
            this.linkLabel3.VisitedLinkColor = System.Drawing.Color.Blue;
            this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.openLink);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(55, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Project:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(55, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Support:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(139, 85);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Third Party Libraries:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(103, 107);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "XBMC JSON RPC#";
            // 
            // lJsonRpcApiVersion
            // 
            this.lJsonRpcApiVersion.AutoSize = true;
            this.lJsonRpcApiVersion.Location = new System.Drawing.Point(251, 107);
            this.lJsonRpcApiVersion.Name = "lJsonRpcApiVersion";
            this.lJsonRpcApiVersion.Size = new System.Drawing.Size(51, 13);
            this.lJsonRpcApiVersion.TabIndex = 12;
            this.lJsonRpcApiVersion.Text = "unknown";
            // 
            // lImonDisplayApiVersion
            // 
            this.lImonDisplayApiVersion.AutoSize = true;
            this.lImonDisplayApiVersion.Location = new System.Drawing.Point(251, 125);
            this.lImonDisplayApiVersion.Name = "lImonDisplayApiVersion";
            this.lImonDisplayApiVersion.Size = new System.Drawing.Size(58, 13);
            this.lImonDisplayApiVersion.TabIndex = 14;
            this.lImonDisplayApiVersion.Text = "v1.0.0.929";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(103, 125);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "iMON Display API";
            // 
            // lImonDisplayApiWrapperVersion
            // 
            this.lImonDisplayApiWrapperVersion.AutoSize = true;
            this.lImonDisplayApiWrapperVersion.Location = new System.Drawing.Point(251, 144);
            this.lImonDisplayApiWrapperVersion.Name = "lImonDisplayApiWrapperVersion";
            this.lImonDisplayApiWrapperVersion.Size = new System.Drawing.Size(51, 13);
            this.lImonDisplayApiWrapperVersion.TabIndex = 16;
            this.lImonDisplayApiWrapperVersion.Text = "unknown";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(103, 144);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(142, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "iMON Display API Wrapper#";
            // 
            // AboutDialog
            // 
            this.AcceptButton = this.bClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bClose;
            this.ClientSize = new System.Drawing.Size(400, 426);
            this.Controls.Add(this.lImonDisplayApiWrapperVersion);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lImonDisplayApiVersion);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lJsonRpcApiVersion);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.linkLabel3);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lCopyright);
            this.Controls.Add(this.lVersion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About XBMC on iMON Display";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lVersion;
        private System.Windows.Forms.Label lCopyright;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lJsonRpcApiVersion;
        private System.Windows.Forms.Label lImonDisplayApiVersion;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lImonDisplayApiWrapperVersion;
        private System.Windows.Forms.Label label10;
    }
}