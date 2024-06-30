namespace Enthapy
{
    partial class End
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
            this.btnExit = new Guna.UI2.WinForms.Guna2GradientButton();
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.TextAnimation = new System.Windows.Forms.Timer(this.components);
            this.loadingPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.TextAnimation2 = new System.Windows.Forms.Timer(this.components);
            this.DragTimer = new System.Windows.Forms.Timer(this.components);
            this.lbLoading = new FlatLabel();
            this.sldProgress = new FlatTrackBar();
            this.loadingPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.BorderRadius = 2;
            this.btnExit.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnExit.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnExit.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnExit.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnExit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnExit.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.btnExit.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(28)))), ((int)(((byte)(34)))));
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(711, 8);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(24, 22);
            this.btnExit.TabIndex = 3;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // guna2Separator1
            // 
            this.guna2Separator1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.guna2Separator1.Location = new System.Drawing.Point(1, 36);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(744, 10);
            this.guna2Separator1.TabIndex = 2;
            // 
            // TextAnimation
            // 
            this.TextAnimation.Interval = 50;
            this.TextAnimation.Tick += new System.EventHandler(this.TextAnimation_Tick);
            // 
            // loadingPanel
            // 
            this.loadingPanel.Controls.Add(this.lbLoading);
            this.loadingPanel.Location = new System.Drawing.Point(279, 132);
            this.loadingPanel.Name = "loadingPanel";
            this.loadingPanel.Size = new System.Drawing.Size(190, 100);
            this.loadingPanel.TabIndex = 7;
            // 
            // TextAnimation2
            // 
            this.TextAnimation2.Interval = 50;
            this.TextAnimation2.Tick += new System.EventHandler(this.TextAnimation2_Tick);
            // 
            // DragTimer
            // 
            this.DragTimer.Interval = 1;
            this.DragTimer.Tick += new System.EventHandler(this.DragTimer_Tick);
            // 
            // lbLoading
            // 
            this.lbLoading.BackColor = System.Drawing.Color.Transparent;
            this.lbLoading.Font = new System.Drawing.Font("Poppins", 13.8F);
            this.lbLoading.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(107)))), ((int)(((byte)(107)))));
            this.lbLoading.Location = new System.Drawing.Point(37, 27);
            this.lbLoading.Name = "lbLoading";
            this.lbLoading.Opacity = 1F;
            this.lbLoading.Size = new System.Drawing.Size(126, 40);
            this.lbLoading.TabIndex = 8;
            this.lbLoading.Text = "Loading...";
            // 
            // sldProgress
            // 
            this.sldProgress.Boolean_0 = false;
            this.sldProgress.Boolean_1 = true;
            this.sldProgress.Color_0 = System.Drawing.Color.Empty;
            this.sldProgress.Color_1 = System.Drawing.Color.Empty;
            this.sldProgress.Color_2 = System.Drawing.Color.Empty;
            this.sldProgress.Color_3 = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(25)))), ((int)(((byte)(28)))));
            this.sldProgress.Color_4 = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(106)))), ((int)(((byte)(194)))));
            this.sldProgress.Color_5 = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(27)))), ((int)(((byte)(30)))));
            this.sldProgress.Int32_0 = 0;
            this.sldProgress.Int32_3 = 8;
            this.sldProgress.Location = new System.Drawing.Point(78, 351);
            this.sldProgress.Name = "sldProgress";
            this.sldProgress.ShowText = false;
            this.sldProgress.Single_0 = 1F;
            this.sldProgress.Single_1 = 1F;
            this.sldProgress.Size = new System.Drawing.Size(597, 19);
            this.sldProgress.TabIndex = 6;
            this.sldProgress.Text = "flatTrackBar1";
            this.sldProgress.MouseDown += new System.Windows.Forms.MouseEventHandler(this.sldProgress_MouseDown);
            this.sldProgress.MouseEnter += new System.EventHandler(this.sldProgress_MouseEnter);
            this.sldProgress.MouseLeave += new System.EventHandler(this.sldProgress_MouseLeave);
            this.sldProgress.MouseHover += new System.EventHandler(this.sldProgress_MouseHover);
            this.sldProgress.MouseMove += new System.Windows.Forms.MouseEventHandler(this.sldProgress_MouseMove);
            this.sldProgress.MouseUp += new System.Windows.Forms.MouseEventHandler(this.sldProgress_MouseUp);
            // 
            // End
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(17)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(747, 425);
            this.Controls.Add(this.loadingPanel);
            this.Controls.Add(this.sldProgress);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.guna2Separator1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "End";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.loadingPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientButton btnExit;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
        private FlatTrackBar sldProgress;
        private System.Windows.Forms.Timer TextAnimation;
        private Guna.UI2.WinForms.Guna2Panel loadingPanel;
        private FlatLabel lbLoading;
        private System.Windows.Forms.Timer TextAnimation2;
        private System.Windows.Forms.Timer DragTimer;
    }
}