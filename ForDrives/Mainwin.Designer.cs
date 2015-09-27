namespace ForDrives
{
    partial class TMainWin
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TMainWin));
            this.GroupBoxIt = new System.Windows.Forms.GroupBox();
            this.ToLM = new System.Windows.Forms.RadioButton();
            this.ToCU = new System.Windows.Forms.RadioButton();
            this.MainTab = new System.Windows.Forms.TabControl();
            this.HideDrv = new System.Windows.Forms.TabPage();
            this.Label5 = new System.Windows.Forms.Label();
            this.WriteItIn = new System.Windows.Forms.Button();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.NewOrder = new System.Windows.Forms.TextBox();
            this.ShowCH = new System.Windows.Forms.TextBox();
            this.DisallowView = new System.Windows.Forms.TabPage();
            this.Label6 = new System.Windows.Forms.Label();
            this.SaveNoView = new System.Windows.Forms.Button();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.NewNoView = new System.Windows.Forms.TextBox();
            this.CUNoView = new System.Windows.Forms.TextBox();
            this.Backerb = new System.Windows.Forms.Button();
            this.linkTo = new System.Windows.Forms.LinkLabel();
            this.TakeEffects = new System.Windows.Forms.Button();
            this.GroupBoxIt.SuspendLayout();
            this.MainTab.SuspendLayout();
            this.HideDrv.SuspendLayout();
            this.DisallowView.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBoxIt
            // 
            this.GroupBoxIt.Controls.Add(this.ToLM);
            this.GroupBoxIt.Controls.Add(this.ToCU);
            this.GroupBoxIt.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.GroupBoxIt.Location = new System.Drawing.Point(12, 190);
            this.GroupBoxIt.Name = "GroupBoxIt";
            this.GroupBoxIt.Size = new System.Drawing.Size(230, 68);
            this.GroupBoxIt.TabIndex = 11;
            this.GroupBoxIt.TabStop = false;
            this.GroupBoxIt.Text = "新设置生效范围";
            // 
            // ToLM
            // 
            this.ToLM.AutoSize = true;
            this.ToLM.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ToLM.Location = new System.Drawing.Point(13, 28);
            this.ToLM.Name = "ToLM";
            this.ToLM.Size = new System.Drawing.Size(104, 22);
            this.ToLM.TabIndex = 7;
            this.ToLM.Text = "本机所有用户";
            this.ToLM.UseVisualStyleBackColor = true;
            // 
            // ToCU
            // 
            this.ToCU.AutoSize = true;
            this.ToCU.Checked = true;
            this.ToCU.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ToCU.Location = new System.Drawing.Point(123, 28);
            this.ToCU.Name = "ToCU";
            this.ToCU.Size = new System.Drawing.Size(92, 22);
            this.ToCU.TabIndex = 6;
            this.ToCU.TabStop = true;
            this.ToCU.Text = "仅当前用户";
            this.ToCU.UseVisualStyleBackColor = true;
            // 
            // MainTab
            // 
            this.MainTab.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.MainTab.Controls.Add(this.HideDrv);
            this.MainTab.Controls.Add(this.DisallowView);
            this.MainTab.HotTrack = true;
            this.MainTab.Location = new System.Drawing.Point(12, 13);
            this.MainTab.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MainTab.Multiline = true;
            this.MainTab.Name = "MainTab";
            this.MainTab.SelectedIndex = 0;
            this.MainTab.Size = new System.Drawing.Size(366, 170);
            this.MainTab.TabIndex = 10;
            // 
            // HideDrv
            // 
            this.HideDrv.Controls.Add(this.Label5);
            this.HideDrv.Controls.Add(this.WriteItIn);
            this.HideDrv.Controls.Add(this.Label2);
            this.HideDrv.Controls.Add(this.Label1);
            this.HideDrv.Controls.Add(this.NewOrder);
            this.HideDrv.Controls.Add(this.ShowCH);
            this.HideDrv.Location = new System.Drawing.Point(4, 26);
            this.HideDrv.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.HideDrv.Name = "HideDrv";
            this.HideDrv.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.HideDrv.Size = new System.Drawing.Size(358, 140);
            this.HideDrv.TabIndex = 0;
            this.HideDrv.Text = "隐藏驱动器";
            this.HideDrv.UseVisualStyleBackColor = true;
            this.HideDrv.MouseEnter += new System.EventHandler(this.HideDrv_MouseEnter);
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Label5.Location = new System.Drawing.Point(6, 100);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(260, 17);
            this.Label5.TabIndex = 7;
            this.Label5.Text = "如果不想对任何盘符作出设置，则将上框留空。";
            // 
            // WriteItIn
            // 
            this.WriteItIn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.WriteItIn.Location = new System.Drawing.Point(272, 102);
            this.WriteItIn.Name = "WriteItIn";
            this.WriteItIn.Size = new System.Drawing.Size(80, 23);
            this.WriteItIn.TabIndex = 6;
            this.WriteItIn.Text = "保存新设置";
            this.WriteItIn.UseVisualStyleBackColor = true;
            this.WriteItIn.Click += new System.EventHandler(this.WriteItIn_Click);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Label2.Location = new System.Drawing.Point(6, 52);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(296, 17);
            this.Label2.TabIndex = 5;
            this.Label2.Text = "将要被设置为隐藏的盘符（保存后，将覆盖原设置）：";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label1.Location = new System.Drawing.Point(6, 4);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(152, 17);
            this.Label1.TabIndex = 4;
            this.Label1.Text = "当前被设置为隐藏的盘符：";
            // 
            // NewOrder
            // 
            this.NewOrder.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NewOrder.Location = new System.Drawing.Point(6, 73);
            this.NewOrder.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.NewOrder.Name = "NewOrder";
            this.NewOrder.Size = new System.Drawing.Size(346, 23);
            this.NewOrder.TabIndex = 3;
            // 
            // ShowCH
            // 
            this.ShowCH.Location = new System.Drawing.Point(6, 25);
            this.ShowCH.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ShowCH.Name = "ShowCH";
            this.ShowCH.ReadOnly = true;
            this.ShowCH.Size = new System.Drawing.Size(346, 23);
            this.ShowCH.TabIndex = 2;
            // 
            // DisallowView
            // 
            this.DisallowView.Controls.Add(this.Label6);
            this.DisallowView.Controls.Add(this.SaveNoView);
            this.DisallowView.Controls.Add(this.Label4);
            this.DisallowView.Controls.Add(this.Label3);
            this.DisallowView.Controls.Add(this.NewNoView);
            this.DisallowView.Controls.Add(this.CUNoView);
            this.DisallowView.Location = new System.Drawing.Point(4, 26);
            this.DisallowView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DisallowView.Name = "DisallowView";
            this.DisallowView.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DisallowView.Size = new System.Drawing.Size(358, 140);
            this.DisallowView.TabIndex = 1;
            this.DisallowView.Text = "禁止浏览驱动器";
            this.DisallowView.UseVisualStyleBackColor = true;
            this.DisallowView.MouseEnter += new System.EventHandler(this.DisallowView_MouseEnter);
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Label6.Location = new System.Drawing.Point(6, 100);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(260, 17);
            this.Label6.TabIndex = 5;
            this.Label6.Text = "如果不想对任何盘符作出设置，则将上框留空。";
            // 
            // SaveNoView
            // 
            this.SaveNoView.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.SaveNoView.Location = new System.Drawing.Point(272, 102);
            this.SaveNoView.Name = "SaveNoView";
            this.SaveNoView.Size = new System.Drawing.Size(80, 23);
            this.SaveNoView.TabIndex = 4;
            this.SaveNoView.Text = "保存新设置";
            this.SaveNoView.UseVisualStyleBackColor = true;
            this.SaveNoView.Click += new System.EventHandler(this.SaveNoView_Click);
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Label4.Location = new System.Drawing.Point(6, 52);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(320, 17);
            this.Label4.TabIndex = 3;
            this.Label4.Text = "将要被设置为禁止浏览的盘符（保存后，将覆盖原设置）：";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Label3.Location = new System.Drawing.Point(6, 4);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(176, 17);
            this.Label3.TabIndex = 2;
            this.Label3.Text = "当前被设置为禁止浏览的盘符：";
            // 
            // NewNoView
            // 
            this.NewNoView.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NewNoView.Location = new System.Drawing.Point(6, 73);
            this.NewNoView.Name = "NewNoView";
            this.NewNoView.Size = new System.Drawing.Size(346, 23);
            this.NewNoView.TabIndex = 1;
            // 
            // CUNoView
            // 
            this.CUNoView.Location = new System.Drawing.Point(6, 25);
            this.CUNoView.Name = "CUNoView";
            this.CUNoView.ReadOnly = true;
            this.CUNoView.Size = new System.Drawing.Size(346, 23);
            this.CUNoView.TabIndex = 0;
            // 
            // Backerb
            // 
            this.Backerb.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Backerb.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Backerb.Location = new System.Drawing.Point(333, 234);
            this.Backerb.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Backerb.Name = "Backerb";
            this.Backerb.Size = new System.Drawing.Size(45, 23);
            this.Backerb.TabIndex = 9;
            this.Backerb.Text = "退出";
            this.Backerb.UseVisualStyleBackColor = true;
            this.Backerb.Click += new System.EventHandler(this.Backerb_Click);
            // 
            // linkTo
            // 
            this.linkTo.ActiveLinkColor = System.Drawing.Color.Lime;
            this.linkTo.AutoSize = true;
            this.linkTo.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkTo.LinkColor = System.Drawing.Color.Green;
            this.linkTo.Location = new System.Drawing.Point(271, 237);
            this.linkTo.Name = "linkTo";
            this.linkTo.Size = new System.Drawing.Size(56, 17);
            this.linkTo.TabIndex = 12;
            this.linkTo.TabStop = true;
            this.linkTo.Text = "技术支持";
            this.linkTo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkTo.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.linkTo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkTo_LinkClicked);
            // 
            // TakeEffects
            // 
            this.TakeEffects.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.TakeEffects.Location = new System.Drawing.Point(253, 190);
            this.TakeEffects.Name = "TakeEffects";
            this.TakeEffects.Size = new System.Drawing.Size(125, 23);
            this.TakeEffects.TabIndex = 13;
            this.TakeEffects.Text = "使新的设置立即生效";
            this.TakeEffects.UseVisualStyleBackColor = true;
            this.TakeEffects.Click += new System.EventHandler(this.TakeEffects_Click);
            // 
            // TMainWin
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.Backerb;
            this.ClientSize = new System.Drawing.Size(390, 270);
            this.Controls.Add(this.TakeEffects);
            this.Controls.Add(this.linkTo);
            this.Controls.Add(this.GroupBoxIt);
            this.Controls.Add(this.MainTab);
            this.Controls.Add(this.Backerb);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "TMainWin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ForDrives";
            this.Load += new System.EventHandler(this.tMainWin_Load);
            this.GroupBoxIt.ResumeLayout(false);
            this.GroupBoxIt.PerformLayout();
            this.MainTab.ResumeLayout(false);
            this.HideDrv.ResumeLayout(false);
            this.HideDrv.PerformLayout();
            this.DisallowView.ResumeLayout(false);
            this.DisallowView.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.GroupBox GroupBoxIt;
        internal System.Windows.Forms.RadioButton ToLM;
        internal System.Windows.Forms.RadioButton ToCU;
        internal System.Windows.Forms.TabControl MainTab;
        internal System.Windows.Forms.TabPage HideDrv;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Button WriteItIn;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox NewOrder;
        internal System.Windows.Forms.TextBox ShowCH;
        internal System.Windows.Forms.TabPage DisallowView;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Button SaveNoView;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TextBox NewNoView;
        internal System.Windows.Forms.TextBox CUNoView;
        internal System.Windows.Forms.Button Backerb;
        private System.Windows.Forms.LinkLabel linkTo;
        private System.Windows.Forms.Button TakeEffects;
    }
}
