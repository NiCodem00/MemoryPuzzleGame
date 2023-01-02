namespace Memorki
{
    partial class Stats
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Stats));
            this.lblStatsNick = new System.Windows.Forms.Label();
            this.lblStatsWynik = new System.Windows.Forms.Label();
            this.lblStatsGameTime = new System.Windows.Forms.Label();
            this.lblStatsMisses = new System.Windows.Forms.Label();
            this.lblStatsAvgMoveTime = new System.Windows.Forms.Label();
            this.lblDiffLvl = new System.Windows.Forms.Label();
            this.lblStatsDate = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblStatsNick
            // 
            this.lblStatsNick.AutoSize = true;
            this.lblStatsNick.BackColor = System.Drawing.Color.Transparent;
            this.lblStatsNick.Font = new System.Drawing.Font("Tempus Sans ITC", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblStatsNick.Location = new System.Drawing.Point(56, 22);
            this.lblStatsNick.Name = "lblStatsNick";
            this.lblStatsNick.Size = new System.Drawing.Size(139, 35);
            this.lblStatsNick.TabIndex = 0;
            this.lblStatsNick.Text = "Nickname";
            this.lblStatsNick.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStatsWynik
            // 
            this.lblStatsWynik.AutoSize = true;
            this.lblStatsWynik.BackColor = System.Drawing.Color.Transparent;
            this.lblStatsWynik.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblStatsWynik.Location = new System.Drawing.Point(12, 84);
            this.lblStatsWynik.Name = "lblStatsWynik";
            this.lblStatsWynik.Size = new System.Drawing.Size(47, 19);
            this.lblStatsWynik.TabIndex = 1;
            this.lblStatsWynik.Text = "Score:";
            // 
            // lblStatsGameTime
            // 
            this.lblStatsGameTime.AutoSize = true;
            this.lblStatsGameTime.BackColor = System.Drawing.Color.Transparent;
            this.lblStatsGameTime.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblStatsGameTime.Location = new System.Drawing.Point(12, 122);
            this.lblStatsGameTime.Name = "lblStatsGameTime";
            this.lblStatsGameTime.Size = new System.Drawing.Size(83, 19);
            this.lblStatsGameTime.TabIndex = 2;
            this.lblStatsGameTime.Text = "Game Time:";
            // 
            // lblStatsMisses
            // 
            this.lblStatsMisses.AutoSize = true;
            this.lblStatsMisses.BackColor = System.Drawing.Color.Transparent;
            this.lblStatsMisses.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblStatsMisses.Location = new System.Drawing.Point(12, 160);
            this.lblStatsMisses.Name = "lblStatsMisses";
            this.lblStatsMisses.Size = new System.Drawing.Size(67, 19);
            this.lblStatsMisses.TabIndex = 3;
            this.lblStatsMisses.Text = "Mistakes:";
            // 
            // lblStatsAvgMoveTime
            // 
            this.lblStatsAvgMoveTime.AutoSize = true;
            this.lblStatsAvgMoveTime.BackColor = System.Drawing.Color.Transparent;
            this.lblStatsAvgMoveTime.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblStatsAvgMoveTime.Location = new System.Drawing.Point(12, 236);
            this.lblStatsAvgMoveTime.Name = "lblStatsAvgMoveTime";
            this.lblStatsAvgMoveTime.Size = new System.Drawing.Size(136, 19);
            this.lblStatsAvgMoveTime.TabIndex = 4;
            this.lblStatsAvgMoveTime.Text = "Average Move Time:";
            // 
            // lblDiffLvl
            // 
            this.lblDiffLvl.AutoSize = true;
            this.lblDiffLvl.BackColor = System.Drawing.Color.Transparent;
            this.lblDiffLvl.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDiffLvl.Location = new System.Drawing.Point(12, 274);
            this.lblDiffLvl.Name = "lblDiffLvl";
            this.lblDiffLvl.Size = new System.Drawing.Size(71, 19);
            this.lblDiffLvl.TabIndex = 5;
            this.lblDiffLvl.Text = "Difficulty:";
            // 
            // lblStatsDate
            // 
            this.lblStatsDate.AutoSize = true;
            this.lblStatsDate.BackColor = System.Drawing.Color.Transparent;
            this.lblStatsDate.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblStatsDate.Location = new System.Drawing.Point(12, 198);
            this.lblStatsDate.Name = "lblStatsDate";
            this.lblStatsDate.Size = new System.Drawing.Size(45, 19);
            this.lblStatsDate.TabIndex = 6;
            this.lblStatsDate.Text = "Date: ";
            // 
            // Stats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = global::Memorki.Properties.Resources.istockphoto_475614720_612x612;
            this.ClientSize = new System.Drawing.Size(251, 328);
            this.Controls.Add(this.lblStatsDate);
            this.Controls.Add(this.lblDiffLvl);
            this.Controls.Add(this.lblStatsAvgMoveTime);
            this.Controls.Add(this.lblStatsMisses);
            this.Controls.Add(this.lblStatsGameTime);
            this.Controls.Add(this.lblStatsWynik);
            this.Controls.Add(this.lblStatsNick);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Stats";
            this.Opacity = 0.98D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Stats";
            this.Load += new System.EventHandler(this.Stats_Load);
            this.Leave += new System.EventHandler(this.Stats_Leave);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblStatsNick;
        private Label lblStatsWynik;
        private Label lblStatsGameTime;
        private Label lblStatsMisses;
        private Label lblStatsAvgMoveTime;
        private Label lblDiffLvl;
        private Label lblStatsDate;
    }
}