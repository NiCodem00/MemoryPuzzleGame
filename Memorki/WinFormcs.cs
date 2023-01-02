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
    public partial class WinFormcs : Form
    {
        public static int totalSeconds;
        public static int totalMinutes;
        public static int cardsCount;
        public static int totalGameTime;
        public static int missWinCounter;
        public static string totalTimeG;
        public static float currentScore;

        public string[] tempS;
        public string[] tempS2;

        public bool minutes = false;
        public bool seconds = false;

        public int GenMoves = 0;

        Ranking rank = new Ranking();
        public WinFormcs()
        {
            InitializeComponent();
        }

        private void WinFormcs_Load(object sender, EventArgs e)
        {
            GetTotalTime();
            CheckCardCount();

            ScoreCal();
            BufforRanking();

            ButtonFocus();
            TotalGameTime();

            DisplayScore();
            DisplayInfo();
        }
        private void btnWinBackToMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();

            foreach (var form in Application.OpenForms.OfType<Plain24>().ToList())
            {
                form.Close();
            }
            foreach (var form in Application.OpenForms.OfType<Plain48>().ToList())
            {
                form.Close();
            }

            foreach (var form in Application.OpenForms.OfType<Plain96>().ToList())
            {
                form.Close();
            }

            Menu menu = new Menu();
            menu.Show();
        }

        private void btnWinExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnWinRanking_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();

            foreach (var form in Application.OpenForms.OfType<Plain24>().ToList())
            {
                form.Close();
            }

            foreach (var form in Application.OpenForms.OfType<Plain48>().ToList())
            {
                form.Close();
            }

            foreach (var form in Application.OpenForms.OfType<Plain96>().ToList())
            {
                form.Close();
            }

            rank.Show();

        }
        public void BufforRanking()
        {
            rank.Show();
            rank.Hide();
        }
        public void TotalGameTime()
        {
            string mins = "";
            switch (Ustawienia.DiffLevel)
            {
                case "Easy":
                    {
                        tempS2 = Plain24.GameTime.Split('.', StringSplitOptions.RemoveEmptyEntries);
                        break;
                    }
                case "Normal":
                    {
                        tempS2 = Plain48.GameTime.Split('.', StringSplitOptions.RemoveEmptyEntries);
                        break;
                    }
                case "Hard":
                    {
                        tempS2 = Plain96.GameTime.Split('.', StringSplitOptions.RemoveEmptyEntries);
                        break;
                    }
                default:
                    {
                        MessageBox.Show("Difficulty exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }

            }
            tempS = tempS2[0].Split(':',StringSplitOptions.RemoveEmptyEntries);
            if(tempS[0].StartsWith("0"))
            {
               mins = tempS[0].Substring(1,1);
            }
            else
            {
                mins = tempS[0];
            }

            if(Int32.Parse(mins) > 0)
            {
                minutes = true;
                seconds = false;
            }
            else
            {
                minutes = false;
                seconds = true;
            }
        }
        public void ScoreCal()
        {
            switch (Ustawienia.DiffLevel)
            {
                case "Easy":
                    {
                        currentScore = cardsCount - totalGameTime * 12 - Plain24.moves * 45 - (int)Plain24.averageMoveTime * 10 - 600;
                        GenMoves = Plain24.moves;
                        break;
                    }
                case "Normal":
                    {
                        currentScore = cardsCount - totalGameTime * 12 - Plain48.moves * 15 - (int)Plain48.averageMoveTime * 10 - 600;
                        GenMoves = Plain48.moves;
                        break;
                    }
                case "Hard":
                    {
                        currentScore = cardsCount - totalGameTime * 12 - Plain96.moves * 15 - (int)Plain96.averageMoveTime * 10 - 600;
                        GenMoves = Plain96.moves;
                        break;
                    }
                default:
                    {
                        MessageBox.Show("Difficulty exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
            }
            if(currentScore <= 0)
            {
                if(GenMoves <= 200)
                {
                    currentScore = GenMoves - 50;
                }
                else
                {
                    currentScore = GenMoves / 10;
                }

                if(currentScore > 200)
                {
                    Random r = new Random();
                    int x = r.Next(90);

                    currentScore = 100 - x;
                }

                if(currentScore < 0)
                {
                    currentScore = 0;
                }
            }
        }
        public void GetTotalTime()
        {
            switch (Ustawienia.DiffLevel)
            {
                case "Easy":
                    {
                        totalGameTime = Plain24.totalGameSeconds;
                        break;
                    }
                case "Normal":
                    {
                        totalGameTime = Plain48.totalGameSeconds / 15;
                        break;
                    }
                case "Hard":
                    {
                        totalGameTime = Plain96.totalGameSeconds / 15;
                        break;
                    }
                default:
                    {
                        MessageBox.Show("Difficulty exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
            }            
        }
        public void DisplayInfo()
        {
            if (minutes == true && seconds == false)
            {
                lblWinGameTime.Text = "Game Time:  " + tempS2[0].Substring(1, 4) + " minutes";
            }
            else if (minutes == false && seconds == true)
            {
                lblWinGameTime.Text = "Game Time: " + tempS[1].ToString() + " seconds";
            }
            switch (Ustawienia.DiffLevel)
            {
                case "Easy":
                    {
                        missWinCounter = Plain24.missCounter;
                        lblWinPomylki.Text = "Mistakes: " + missWinCounter;
                        lblWinSredniCzas.Text = "Average Move Time:  " + Math.Round(Plain24.averageMoveTime, 2) + " seconds";
                        break;
                    }
                case "Normal":
                    {
                        missWinCounter = Plain48.missCounter;
                        lblWinPomylki.Text = "Mistakes: " + missWinCounter;
                        lblWinSredniCzas.Text = "Average Move Time:  " + Math.Round(Plain48.averageMoveTime, 2) + " seconds";

                        break;
                    }
                case "Hard":
                    {
                        missWinCounter = Plain96.missCounter;
                        lblWinPomylki.Text = "Mistakes: " + missWinCounter;
                        lblWinSredniCzas.Text = "Average Move Time:  " + Math.Round(Plain96.averageMoveTime, 2) + " seconds";

                        break;
                    }
                default:
                    {
                        MessageBox.Show("Difficulty exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
            }
        }
        public void CheckCardCount()
        {
            switch (Ustawienia.DiffLevel)
            {
                case "Easy":
                    {
                        cardsCount = 2780;
                        break;
                    }
                case "Normal":
                    {
                        cardsCount = 2550;
                        break;
                    }
                case "Hard":
                    {
                        cardsCount = 4050;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        private void DisplayScore()
        {
            lblWynik.Text = $"Score:  {currentScore}";
        }

        private void LostAllFocus(object sender, EventArgs e)
        {
            this.lblWinVic.Focus();
            Button obiekt = (Button)sender;
        }
        private void ButtonFocus()
        {
            this.btnWinBackToMenu.Click += LostAllFocus;
            this.btnWinExit.Click += LostAllFocus;
            this.btnWinRanking.Click += LostAllFocus;
        }    
    }
}
