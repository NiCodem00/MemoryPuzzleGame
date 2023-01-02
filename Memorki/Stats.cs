using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memorki
{
    public partial class Stats : Form
    {
        public string Name = "";
        public string Score = "";

        public string GameTime = "";
        public string missCounterS = "";

        public string Date = "";
        public string avrgMoveTime = "";

        public string DiffLvl = "";
        public Stats()
        {
            InitializeComponent();
        }

        private void Stats_Load(object sender, EventArgs e)
        {
            SetLabels();
            CenterNick();         
        }
        private void LoadSetNull()
        {
            Name = "";
            Score = "";
            GameTime = "";
            missCounterS = "";
            Date = "";
            avrgMoveTime = "";
            DiffLvl = "";

        }
        private void SetLabels()
        {
            lblStatsNick.Text = Name;
            lblStatsWynik.Text = "Score: " + Score;
            lblStatsGameTime.Text = "Game Time: " + GameTime;
            lblStatsMisses.Text = "Mistakes: " + missCounterS;
            lblStatsDate.Text = "Date: " + Date;
            lblStatsAvgMoveTime.Text = "Average Move Time: " + avrgMoveTime;
            lblDiffLvl.Text = "Difficulty: " + DiffLvl;
            
        }
        private void CenterNick()
        {
            lblStatsNick.Location = new Point(
            this.ClientSize.Width / 2 - lblStatsNick.Size.Width / 2,22);
            lblStatsNick.Anchor = AnchorStyles.None;
        }

        private void Stats_Leave(object sender, EventArgs e)
        {
            LoadSetNull();
            this.Close();
        }

    }
}
