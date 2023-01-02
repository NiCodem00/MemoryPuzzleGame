namespace Memorki
{
    partial class Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.lblMenuMemorki = new System.Windows.Forms.Label();
            this.btnMenuStart = new System.Windows.Forms.Button();
            this.btnMenuUstawienia = new System.Windows.Forms.Button();
            this.lblMenuNick = new System.Windows.Forms.Label();
            this.btnMenuExit = new System.Windows.Forms.Button();
            this.btnMenuLogOut = new System.Windows.Forms.Button();
            this.btnMenuRanking = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblMenuMemorki
            // 
            this.lblMenuMemorki.AutoSize = true;
            this.lblMenuMemorki.BackColor = System.Drawing.Color.Transparent;
            this.lblMenuMemorki.Font = new System.Drawing.Font("Tempus Sans ITC", 44.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblMenuMemorki.Location = new System.Drawing.Point(94, 11);
            this.lblMenuMemorki.Name = "lblMenuMemorki";
            this.lblMenuMemorki.Size = new System.Drawing.Size(255, 77);
            this.lblMenuMemorki.TabIndex = 0;
            this.lblMenuMemorki.Text = "Memory";
            // 
            // btnMenuStart
            // 
            this.btnMenuStart.Font = new System.Drawing.Font("Nirmala UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnMenuStart.Location = new System.Drawing.Point(127, 125);
            this.btnMenuStart.Name = "btnMenuStart";
            this.btnMenuStart.Size = new System.Drawing.Size(186, 39);
            this.btnMenuStart.TabIndex = 1;
            this.btnMenuStart.TabStop = false;
            this.btnMenuStart.Text = "PLAY";
            this.btnMenuStart.UseVisualStyleBackColor = true;
            this.btnMenuStart.Click += new System.EventHandler(this.btnMenuStart_Click);
            // 
            // btnMenuUstawienia
            // 
            this.btnMenuUstawienia.Font = new System.Drawing.Font("Nirmala UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnMenuUstawienia.Location = new System.Drawing.Point(127, 173);
            this.btnMenuUstawienia.Name = "btnMenuUstawienia";
            this.btnMenuUstawienia.Size = new System.Drawing.Size(186, 39);
            this.btnMenuUstawienia.TabIndex = 2;
            this.btnMenuUstawienia.TabStop = false;
            this.btnMenuUstawienia.Text = "Settings";
            this.btnMenuUstawienia.UseVisualStyleBackColor = true;
            this.btnMenuUstawienia.Click += new System.EventHandler(this.btnMenuUstawienia_Click);
            // 
            // lblMenuNick
            // 
            this.lblMenuNick.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblMenuNick.AutoSize = true;
            this.lblMenuNick.BackColor = System.Drawing.Color.Transparent;
            this.lblMenuNick.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblMenuNick.Location = new System.Drawing.Point(12, 11);
            this.lblMenuNick.Name = "lblMenuNick";
            this.lblMenuNick.Size = new System.Drawing.Size(0, 14);
            this.lblMenuNick.TabIndex = 3;
            // 
            // btnMenuExit
            // 
            this.btnMenuExit.Font = new System.Drawing.Font("Nirmala UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnMenuExit.Location = new System.Drawing.Point(127, 269);
            this.btnMenuExit.Name = "btnMenuExit";
            this.btnMenuExit.Size = new System.Drawing.Size(186, 39);
            this.btnMenuExit.TabIndex = 3;
            this.btnMenuExit.TabStop = false;
            this.btnMenuExit.Text = "Exit";
            this.btnMenuExit.UseVisualStyleBackColor = true;
            this.btnMenuExit.Click += new System.EventHandler(this.btnMenuExit_Click);
            // 
            // btnMenuLogOut
            // 
            this.btnMenuLogOut.Font = new System.Drawing.Font("Lucida Sans", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnMenuLogOut.Location = new System.Drawing.Point(4, 310);
            this.btnMenuLogOut.Name = "btnMenuLogOut";
            this.btnMenuLogOut.Size = new System.Drawing.Size(60, 24);
            this.btnMenuLogOut.TabIndex = 4;
            this.btnMenuLogOut.TabStop = false;
            this.btnMenuLogOut.Text = "Log Out";
            this.btnMenuLogOut.UseVisualStyleBackColor = true;
            this.btnMenuLogOut.Click += new System.EventHandler(this.btnMenuLogOut_Click);
            // 
            // btnMenuRanking
            // 
            this.btnMenuRanking.Font = new System.Drawing.Font("Nirmala UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnMenuRanking.Location = new System.Drawing.Point(127, 221);
            this.btnMenuRanking.Name = "btnMenuRanking";
            this.btnMenuRanking.Size = new System.Drawing.Size(186, 39);
            this.btnMenuRanking.TabIndex = 5;
            this.btnMenuRanking.TabStop = false;
            this.btnMenuRanking.Text = "Ranking";
            this.btnMenuRanking.UseVisualStyleBackColor = true;
            this.btnMenuRanking.Click += new System.EventHandler(this.btnMenuRanking_Click);
            // 
            // Menu
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.MenuBar;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(442, 338);
            this.Controls.Add(this.btnMenuRanking);
            this.Controls.Add(this.btnMenuLogOut);
            this.Controls.Add(this.lblMenuNick);
            this.Controls.Add(this.btnMenuExit);
            this.Controls.Add(this.btnMenuUstawienia);
            this.Controls.Add(this.btnMenuStart);
            this.Controls.Add(this.lblMenuMemorki);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.Leave += new System.EventHandler(this.Menu_Leave);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblMenuMemorki;
        private Button btnMenuStart;
        private Button btnMenuUstawienia;
        private Label lblMenuNick;
        private Button btnMenuExit;
        private Button btnMenuLogOut;
        private Button btnMenuRanking;
    }
}