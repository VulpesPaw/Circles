namespace CirclesCore
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnStart = new System.Windows.Forms.Button();
            this.tbxTimeShow = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbxMinSize = new System.Windows.Forms.TextBox();
            this.tbxMaxSize = new System.Windows.Forms.TextBox();
            this.tbxCircleAmount = new System.Windows.Forms.TextBox();
            this.tbxTimeHide = new System.Windows.Forms.TextBox();
            this.lblVers = new System.Windows.Forms.Label();
            this.btnFullscreen = new System.Windows.Forms.Button();
            this.grpBxControls = new System.Windows.Forms.GroupBox();
            this.lblSpaceStop = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbxTimeBeforeStart = new System.Windows.Forms.TextBox();
            this.btnCanvasSize = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxCanvasHeight = new System.Windows.Forms.TextBox();
            this.tbxCanvasTop = new System.Windows.Forms.TextBox();
            this.tbxDecoy = new System.Windows.Forms.TextBox();
            this.lblContinue = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.grpBxControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(35, 436);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(209, 60);
            this.btnStart.TabIndex = 11;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // tbxTimeShow
            // 
            this.tbxTimeShow.ForeColor = System.Drawing.Color.Black;
            this.tbxTimeShow.Location = new System.Drawing.Point(144, 70);
            this.tbxTimeShow.Name = "tbxTimeShow";
            this.tbxTimeShow.Size = new System.Drawing.Size(100, 20);
            this.tbxTimeShow.TabIndex = 2;
            this.tbxTimeShow.Text = "3000";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Time shown (ms):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Time hidden (ms):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(58, 205);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Max size:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Amount of circles:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(61, 249);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Min size:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(45, 293);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Canvas top:";
            // 
            // tbxMinSize
            // 
            this.tbxMinSize.ForeColor = System.Drawing.Color.Black;
            this.tbxMinSize.Location = new System.Drawing.Point(144, 246);
            this.tbxMinSize.Name = "tbxMinSize";
            this.tbxMinSize.Size = new System.Drawing.Size(100, 20);
            this.tbxMinSize.TabIndex = 6;
            this.tbxMinSize.Text = "75";
            this.tbxMinSize.TextChanged += new System.EventHandler(this.tbxMinSize_TextChanged);
            // 
            // tbxMaxSize
            // 
            this.tbxMaxSize.ForeColor = System.Drawing.Color.Black;
            this.tbxMaxSize.Location = new System.Drawing.Point(144, 202);
            this.tbxMaxSize.Name = "tbxMaxSize";
            this.tbxMaxSize.Size = new System.Drawing.Size(100, 20);
            this.tbxMaxSize.TabIndex = 5;
            this.tbxMaxSize.Text = "250";
            this.tbxMaxSize.TextChanged += new System.EventHandler(this.tbxMaxSize_TextChanged);
            // 
            // tbxCircleAmount
            // 
            this.tbxCircleAmount.ForeColor = System.Drawing.Color.Gray;
            this.tbxCircleAmount.Location = new System.Drawing.Point(144, 158);
            this.tbxCircleAmount.Name = "tbxCircleAmount";
            this.tbxCircleAmount.Size = new System.Drawing.Size(100, 20);
            this.tbxCircleAmount.TabIndex = 4;
            this.tbxCircleAmount.Text = "Empty = Endless";
            this.tbxCircleAmount.Enter += new System.EventHandler(this.tbxCircleAmount_Enter);
            this.tbxCircleAmount.Leave += new System.EventHandler(this.tbxCircleAmount_Leave);
            // 
            // tbxTimeHide
            // 
            this.tbxTimeHide.ForeColor = System.Drawing.Color.Black;
            this.tbxTimeHide.Location = new System.Drawing.Point(144, 114);
            this.tbxTimeHide.Name = "tbxTimeHide";
            this.tbxTimeHide.Size = new System.Drawing.Size(100, 20);
            this.tbxTimeHide.TabIndex = 3;
            this.tbxTimeHide.Tag = "gui";
            this.tbxTimeHide.Text = "4000";
            // 
            // lblVers
            // 
            this.lblVers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVers.AutoSize = true;
            this.lblVers.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.lblVers.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblVers.Location = new System.Drawing.Point(1169, 9);
            this.lblVers.Name = "lblVers";
            this.lblVers.Size = new System.Drawing.Size(77, 13);
            this.lblVers.TabIndex = 50;
            this.lblVers.Text = "Circles v. 1.0.1";
            // 
            // btnFullscreen
            // 
            this.btnFullscreen.Location = new System.Drawing.Point(12, 12);
            this.btnFullscreen.Name = "btnFullscreen";
            this.btnFullscreen.Size = new System.Drawing.Size(93, 23);
            this.btnFullscreen.TabIndex = 50;
            this.btnFullscreen.Text = "Fullscreen (F11)";
            this.btnFullscreen.UseVisualStyleBackColor = true;
            this.btnFullscreen.Click += new System.EventHandler(this.btnFullscreen_Click);
            // 
            // grpBxControls
            // 
            this.grpBxControls.Controls.Add(this.lblSpaceStop);
            this.grpBxControls.Controls.Add(this.label8);
            this.grpBxControls.Controls.Add(this.tbxTimeBeforeStart);
            this.grpBxControls.Controls.Add(this.btnCanvasSize);
            this.grpBxControls.Controls.Add(this.tbxCircleAmount);
            this.grpBxControls.Controls.Add(this.btnStart);
            this.grpBxControls.Controls.Add(this.tbxTimeShow);
            this.grpBxControls.Controls.Add(this.label1);
            this.grpBxControls.Controls.Add(this.tbxTimeHide);
            this.grpBxControls.Controls.Add(this.label2);
            this.grpBxControls.Controls.Add(this.label3);
            this.grpBxControls.Controls.Add(this.tbxMaxSize);
            this.grpBxControls.Controls.Add(this.label4);
            this.grpBxControls.Controls.Add(this.tbxMinSize);
            this.grpBxControls.Controls.Add(this.label5);
            this.grpBxControls.Controls.Add(this.tbxCanvasHeight);
            this.grpBxControls.Controls.Add(this.label6);
            this.grpBxControls.Controls.Add(this.tbxCanvasTop);
            this.grpBxControls.Controls.Add(this.label7);
            this.grpBxControls.Location = new System.Drawing.Point(27, 111);
            this.grpBxControls.Name = "grpBxControls";
            this.grpBxControls.Size = new System.Drawing.Size(279, 526);
            this.grpBxControls.TabIndex = 20;
            this.grpBxControls.TabStop = false;
            this.grpBxControls.Text = "Controls";
            // 
            // lblSpaceStop
            // 
            this.lblSpaceStop.AutoSize = true;
            this.lblSpaceStop.Location = new System.Drawing.Point(40, 498);
            this.lblSpaceStop.Name = "lblSpaceStop";
            this.lblSpaceStop.Size = new System.Drawing.Size(198, 13);
            this.lblSpaceStop.TabIndex = 120;
            this.lblSpaceStop.Text = "Press Space to stop current play session";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 29);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(111, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Time before start (ms):";
            // 
            // tbxTimeBeforeStart
            // 
            this.tbxTimeBeforeStart.ForeColor = System.Drawing.Color.Black;
            this.tbxTimeBeforeStart.Location = new System.Drawing.Point(144, 26);
            this.tbxTimeBeforeStart.Name = "tbxTimeBeforeStart";
            this.tbxTimeBeforeStart.Size = new System.Drawing.Size(100, 20);
            this.tbxTimeBeforeStart.TabIndex = 1;
            this.tbxTimeBeforeStart.Text = "9500";
            // 
            // btnCanvasSize
            // 
            this.btnCanvasSize.Location = new System.Drawing.Point(34, 370);
            this.btnCanvasSize.Name = "btnCanvasSize";
            this.btnCanvasSize.Size = new System.Drawing.Size(209, 60);
            this.btnCanvasSize.TabIndex = 10;
            this.btnCanvasSize.Text = "Set canvas size \r\n (double click on canvas; fullscreen only)";
            this.btnCanvasSize.UseVisualStyleBackColor = true;
            this.btnCanvasSize.Click += new System.EventHandler(this.btnCanvasSize_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 337);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Canvas height:";
            // 
            // tbxCanvasHeight
            // 
            this.tbxCanvasHeight.Location = new System.Drawing.Point(144, 334);
            this.tbxCanvasHeight.Name = "tbxCanvasHeight";
            this.tbxCanvasHeight.Size = new System.Drawing.Size(100, 20);
            this.tbxCanvasHeight.TabIndex = 8;
            this.tbxCanvasHeight.TextChanged += new System.EventHandler(this.tbxCanvasHeight_TextChanged);
            // 
            // tbxCanvasTop
            // 
            this.tbxCanvasTop.Location = new System.Drawing.Point(144, 290);
            this.tbxCanvasTop.Name = "tbxCanvasTop";
            this.tbxCanvasTop.Size = new System.Drawing.Size(100, 20);
            this.tbxCanvasTop.TabIndex = 7;
            this.tbxCanvasTop.TextChanged += new System.EventHandler(this.tbxCanvasTop_TextChanged);
            // 
            // tbxDecoy
            // 
            this.tbxDecoy.Location = new System.Drawing.Point(12, 41);
            this.tbxDecoy.Name = "tbxDecoy";
            this.tbxDecoy.ReadOnly = true;
            this.tbxDecoy.Size = new System.Drawing.Size(93, 20);
            this.tbxDecoy.TabIndex = 50;
            this.tbxDecoy.TabStop = false;
            this.tbxDecoy.Text = " I AM INVISIBLE!";
            this.tbxDecoy.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbxDecoy.Visible = false;
            // 
            // lblContinue
            // 
            this.lblContinue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblContinue.AutoSize = true;
            this.lblContinue.BackColor = System.Drawing.Color.Black;
            this.lblContinue.Font = new System.Drawing.Font("Microsoft Sans Serif", 63.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContinue.ForeColor = System.Drawing.Color.White;
            this.lblContinue.Location = new System.Drawing.Point(318, 184);
            this.lblContinue.Margin = new System.Windows.Forms.Padding(0);
            this.lblContinue.Name = "lblContinue";
            this.lblContinue.Size = new System.Drawing.Size(979, 96);
            this.lblContinue.TabIndex = 51;
            this.lblContinue.Text = "Press Space to Continue";
            this.lblContinue.Visible = false;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(1172, 25);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 52;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblContinue);
            this.Controls.Add(this.tbxDecoy);
            this.Controls.Add(this.grpBxControls);
            this.Controls.Add(this.btnFullscreen);
            this.Controls.Add(this.lblVers);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Circles";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDoubleClick);
            this.grpBxControls.ResumeLayout(false);
            this.grpBxControls.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox tbxTimeShow;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbxMinSize;
        private System.Windows.Forms.TextBox tbxMaxSize;
        private System.Windows.Forms.TextBox tbxCircleAmount;
        private System.Windows.Forms.TextBox tbxTimeHide;
        private System.Windows.Forms.Label lblVers;
        private System.Windows.Forms.Button btnFullscreen;
        private System.Windows.Forms.GroupBox grpBxControls;
        private System.Windows.Forms.Button btnCanvasSize;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbxCanvasHeight;
        private System.Windows.Forms.TextBox tbxCanvasTop;
        private System.Windows.Forms.TextBox tbxDecoy;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbxTimeBeforeStart;
        private System.Windows.Forms.Label lblContinue;
        private System.Windows.Forms.Label lblSpaceStop;
        private System.Windows.Forms.Button btnExit;
    }
}

