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
    public partial class Ranking : Form
    {

        public List<string> lines = new List<string>();
        public List<string> firtsLines = new List<string>();
        public string[] actualLines = new string[7];
        List<Tuple<int, string>> scores = new List<Tuple<int, string>>();

        public string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ranking.txt");

        public string[] fileLines = null;
        public int[] tempscores = new int[7] {0,0,0,0,0,0,0};
        public bool inRanking = false;

        public string[] temp1S;
        public string[] temp2S;
        public string[] temp3S;
        public string[] theSplit;
        public string[] theLaterSplit;

        public int maxScore = 0;
        public int counter = 0;
        public int linesCounter = 0;
        public int indexx = 0;
        public int previousScore;
        public int indexxCounter = 0;
        public int betterindex = 0;
        public int counter3 = 0;
        public int ii = 0;
        public int ii2 = 0;
        public int indexior = 0;

        public bool istherePlace = false;
        public bool alreadyRanked = false;
        public bool betterself = false;
        public bool isEmpty = true;

        public Ranking()
        {
            InitializeComponent();
        }

        private void Ranking_Load(object sender, EventArgs e)
        {
            ButtonFocus();
            SetInitialVisibility();

            switch (Ustawienia.DiffLevel)
            {
                case "Easy":
                    {
                        if (Plain24.isGamebegan == true)
                        {
                            CheckBoard();
                        }
                        break;
                    }
                case "Normal":
                    {
                        if (Plain48.isGamebegan == true)
                        {
                            CheckBoard();
                        }
                        break;
                    }
                case "Hard":
                    {
                        if (Plain96.isGamebegan == true)
                        {
                            CheckBoard();
                        }
                        break;
                    }
                default:
                    {
                        MessageBox.Show("Difficulty exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }

            }
            DisplayBoard();

        }
        private void btnRanExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRanPowrot_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();

            Menu menu = new Menu();
            menu.Show();
        }   
        private void Ranking_Leave(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void CheckBoard()
        {
            fileLines = File.ReadAllLines(filePath);

            foreach (string line in fileLines)
            {
                if (line.Contains($"|{DataInput.CurrentNick}|"))
                {
                    alreadyRanked = true;
                    betterindex = counter3;
                    temp3S = line.Split(';');

                    if (WinFormcs.currentScore >= Int32.Parse(temp3S[1]))
                    {
                        betterself = true;
                    }
                    else
                    {
                        betterself = false;
                    }
                }
                if (line.Length > 1)
                {
                    isEmpty = false;
                }
                counter3++;
            }
            if (isEmpty == false)
            {
                if (betterself)
                {
                    foreach (string line in fileLines)
                    {
                        if (!line.Contains($"|{DataInput.CurrentNick}|") && line.Length > 1)
                        {
                            lines.Add(line);
                        }
                    }

                    File.WriteAllLines(filePath, lines);
                    lines.Clear();
                }
                fileLines = File.ReadAllLines(filePath);

                if (fileLines.Count() < 7)
                {
                    istherePlace = true;
                }
                else
                {
                    istherePlace = false;
                }

                //   if (istherePlace == false)
                //    {
                fileLines = File.ReadAllLines(filePath);

                foreach (string line in fileLines)
                {
                    if (fileLines.Count() > 0)
                    {
                        if (line.Length > 1)
                        {
                            firtsLines.Add(line);
                            temp1S = line.Split(';');

                            scores.Add(new Tuple<int, string>(Int32.Parse(temp1S[1]), temp1S[0]));

                            //          tempscores[counter] = Int32.Parse(temp1S[1]);
                            counter++;
                        }
                    }
                }
                scores = scores.OrderByDescending(tuple => tuple.Item1).ToList();
                //  }

                while (ii < scores.Count())
                {
                    actualLines[ii] = scores[ii].Item2 + ";" + scores[ii].Item1.ToString();
                    foreach (string line in firtsLines)
                    {
                        if (line.Contains(scores[ii].Item2) && line.Contains(scores[ii].Item2.ToString()))
                        {
                            indexior = ii2;
                        }
                        ii2++;
                    }
                    theSplit = firtsLines[indexior].Split(';');
                    actualLines[ii] = scores[ii].Item2 + ";" + scores[ii].Item1.ToString() + ";" + theSplit[2] + ";" + theSplit[3] + ";" + theSplit[4] + ";" + theSplit[5] + ";" + theSplit[6];
                    ii++;
                    ii2 = 0;
                }
                File.WriteAllLines(filePath, actualLines);
                fileLines = File.ReadAllLines(filePath);

                lines.Clear();
                foreach (string line in fileLines)
                {
                    if (line.Length >= 1)
                    {
                        lines.Add(line);
                    }
                }
                File.WriteAllLines(filePath, lines);
                lines.Clear();
                fileLines = File.ReadAllLines(filePath);

                for(int i=0; i<=scores.Count-1; i++)
                {
                    tempscores[i] = scores[i].Item1;
                }

                for (int i = 0; i <= 6; i++)
                {
                    if (WinFormcs.currentScore >= tempscores[i])
                    {
                        indexx = i;
                        if(tempscores[i] > 0 && betterself == true && alreadyRanked == true || tempscores[i] > 0 && betterself == false && alreadyRanked == false)
                        {
                            inRanking = true;
                        }
                        i = 7;
                    }        
                }

                fileLines = File.ReadAllLines(filePath);

                if(betterself == true && fileLines.Count() < 1)
                {
                    lines.Clear();
                    switch (Ustawienia.DiffLevel)
                    {
                        case "Easy":
                            {
                                lines.Add($"|{DataInput.CurrentNick}|" + ";" + WinFormcs.currentScore + ";" + Plain24.rankTime + ";" + Math.Round(Plain24.averageMoveTime, 2) + ";" + WinFormcs.missWinCounter + ";" + Ustawienia.DiffLevel + ";" + Plain24.Date);
                                break;
                            }
                        case "Normal":
                            {
                                lines.Add($"|{DataInput.CurrentNick}|" + ";" + WinFormcs.currentScore + ";" + Plain48.rankTime + ";" + Math.Round(Plain48.averageMoveTime, 2) + ";" + WinFormcs.missWinCounter + ";" + Ustawienia.DiffLevel + ";" + Plain48.Date);
                                break;
                            }
                        case "Hard":
                            {
                                lines.Add($"|{DataInput.CurrentNick}|" + ";" + WinFormcs.currentScore + ";" + Plain96.rankTime + ";" + Math.Round(Plain96.averageMoveTime, 2) + ";" + WinFormcs.missWinCounter + ";" + Ustawienia.DiffLevel + ";" + Plain96.Date);
                                break;
                            }
                        default:
                            {
                                MessageBox.Show("Difficulty exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }

                    }                      
                    File.WriteAllLines(filePath, lines);
                    lines.Clear();

                    inRanking = false;
                    istherePlace = false;

                }
                    
                if (inRanking == true && istherePlace == true)
                {
                    foreach (string line in fileLines)
                    {
                        if (indexxCounter == indexx)
                        {
                            switch (Ustawienia.DiffLevel)
                            {
                                case "Easy":
                                    {
                                        lines.Add($"|{DataInput.CurrentNick}|" + ";" + WinFormcs.currentScore + ";" + Plain24.rankTime + ";" + Math.Round(Plain24.averageMoveTime, 2) + ";" + WinFormcs.missWinCounter + ";" + Ustawienia.DiffLevel + ";" + Plain24.Date);
                                        break;
                                    }
                                case "Normal":
                                    {
                                        lines.Add($"|{DataInput.CurrentNick}|" + ";" + WinFormcs.currentScore + ";" + Plain48.rankTime + ";" + Math.Round(Plain48.averageMoveTime, 2) + ";" + WinFormcs.missWinCounter + ";" + Ustawienia.DiffLevel + ";" + Plain48.Date);
                                        break;
                                    }
                                case "Hard":
                                    {
                                        lines.Add($"|{DataInput.CurrentNick}|" + ";" + WinFormcs.currentScore + ";" + Plain96.rankTime + ";" + Math.Round(Plain96.averageMoveTime, 2) + ";" + WinFormcs.missWinCounter + ";" + Ustawienia.DiffLevel + ";" + Plain96.Date);
                                        break;
                                    }
                                default:
                                    {
                                        MessageBox.Show("Difficulty exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        break;
                                    }

                            }

                            lines.Add(line);
                        }
                        else
                        {
                            lines.Add(line);
                        }
                        indexxCounter++;
                    }
                    File.WriteAllLines(filePath, lines);
                    lines.Clear();
                }
                else if (inRanking == false && istherePlace == true && alreadyRanked == false)
                {
                    lines = fileLines.ToList();

                    switch (Ustawienia.DiffLevel)
                    {
                        case "Easy":
                            {
                                lines.Add($"|{DataInput.CurrentNick}|" + ";" + WinFormcs.currentScore + ";" + Plain24.rankTime + ";" + Math.Round(Plain24.averageMoveTime, 2) + ";" + WinFormcs.missWinCounter + ";" + Ustawienia.DiffLevel + ";" + Plain24.Date);
                                break;
                            }
                        case "Normal":
                            {
                                lines.Add($"|{DataInput.CurrentNick}|" + ";" + WinFormcs.currentScore + ";" + Plain48.rankTime + ";" + Math.Round(Plain48.averageMoveTime, 2) + ";" + WinFormcs.missWinCounter + ";" + Ustawienia.DiffLevel + ";" + Plain48.Date);
                                break;
                            }
                        case "Hard":
                            {
                                lines.Add($"|{DataInput.CurrentNick}|" + ";" + WinFormcs.currentScore + ";" + Plain96.rankTime + ";" + Math.Round(Plain96.averageMoveTime, 2) + ";" + WinFormcs.missWinCounter + ";" + Ustawienia.DiffLevel + ";" + Plain96.Date);
                                break;
                            }
                        default:
                            {
                                MessageBox.Show("Difficulty exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }

                    }

                    File.WriteAllLines(filePath, lines);
                    lines.Clear();
                }
                else if (inRanking == true && istherePlace == false)
                {
                    foreach (string line in fileLines)
                    {
                        if (indexxCounter == indexx)
                        {
                            switch (Ustawienia.DiffLevel)
                            {
                                case "Easy":
                                    {
                                        lines.Add($"|{DataInput.CurrentNick}|" + ";" + WinFormcs.currentScore + ";" + Plain24.rankTime + ";" + Math.Round(Plain24.averageMoveTime, 2) + ";" + WinFormcs.missWinCounter + ";" + Ustawienia.DiffLevel + ";" + Plain24.Date);
                                        break;
                                    }
                                case "Normal":
                                    {
                                        lines.Add($"|{DataInput.CurrentNick}|" + ";" + WinFormcs.currentScore + ";" + Plain48.rankTime + ";" + Math.Round(Plain48.averageMoveTime, 2) + ";" + WinFormcs.missWinCounter + ";" + Ustawienia.DiffLevel + ";" + Plain48.Date);
                                        break;
                                    }
                                case "Hard":
                                    {
                                        lines.Add($"|{DataInput.CurrentNick}|" + ";" + WinFormcs.currentScore + ";" + Plain96.rankTime + ";" + Math.Round(Plain96.averageMoveTime, 2) + ";" + WinFormcs.missWinCounter + ";" + Ustawienia.DiffLevel + ";" + Plain96.Date);
                                        break;
                                    }
                                default:
                                    {
                                        MessageBox.Show("Difficulty exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        break;
                                    }

                            }
                            lines.Add(line);
                        }
                        else
                        {
                            lines.Add(line);
                        }
                        indexxCounter++;
                    }
                    lines = lines.SkipLast(1).ToList();
                    File.WriteAllLines(filePath, lines);
                    lines.Clear();
                }
              
            }
            else
            {
                switch (Ustawienia.DiffLevel)
                {
                    case "Easy":
                        {
                            lines.Add($"|{DataInput.CurrentNick}|" + ";" + WinFormcs.currentScore + ";" + Plain24.rankTime + ";" + Math.Round(Plain24.averageMoveTime, 2) + ";" + WinFormcs.missWinCounter + ";" + Ustawienia.DiffLevel + ";" + Plain24.Date);
                            break;
                        }
                    case "Normal":
                        {
                            lines.Add($"|{DataInput.CurrentNick}|" + ";" + WinFormcs.currentScore + ";" + Plain48.rankTime + ";" + Math.Round(Plain48.averageMoveTime, 2) + ";" + WinFormcs.missWinCounter + ";" + Ustawienia.DiffLevel + ";" + Plain48.Date);
                            break;
                        }
                    case "Hard":
                        {
                            lines.Add($"|{DataInput.CurrentNick}|" + ";" + WinFormcs.currentScore + ";" + Plain96.rankTime + ";" + Math.Round(Plain96.averageMoveTime, 2) + ";" + WinFormcs.missWinCounter + ";" + Ustawienia.DiffLevel + ";" + Plain96.Date);
                            break;
                        }
                    default:
                        {
                            MessageBox.Show("Difficulty exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }

                }
                File.WriteAllLines(filePath, lines);
                lines.Clear();
            }

        }
        private void DisplayBoard()
        {
            int counter1 = 1;
            string[] tempS;
            fileLines = File.ReadAllLines(filePath);
            foreach(string line in fileLines)
            {
                if(line.Length > 0)
                {
                    var p = this.Controls.OfType<Label>().FirstOrDefault(e => e.Name == "lblName" + counter1.ToString());
                    var p2 = this.Controls.OfType<Label>().FirstOrDefault(e => e.Name == "lblScore" + counter1.ToString());
                    var p3 = this.Controls.OfType<Label>().FirstOrDefault(e => e.Name == "lblTime" + counter1.ToString());
                    var p4 = this.Controls.OfType<PictureBox>().FirstOrDefault(e => e.Name == "pbPlace" + counter1.ToString());

                    tempS = line.Split(';');

                    p.Visible = true;
                    p2.Visible = true;
                    p3.Visible = true;
                    p4.Visible = true;
                    
                    string Name = tempS[0].Substring(1, tempS[0].Length-2);
                    
                    p.Text = Name.ToString();
                    p2.Text = tempS[1].ToString();
                    p3.Text = tempS[2].ToString();

                    counter1++;
                }
            }
        }
        private void SetInitialVisibility()
        {
            for(int i=1;i<=7;i++)
            {
                var p = this.Controls.OfType<Label>().FirstOrDefault(e => e.Name == "lblName" + i.ToString());
                var p2 = this.Controls.OfType<Label>().FirstOrDefault(e => e.Name == "lblScore" + i.ToString());
                var p3 = this.Controls.OfType<Label>().FirstOrDefault(e => e.Name == "lblTime" + i.ToString());
                var p4 = this.Controls.OfType<PictureBox>().FirstOrDefault(e => e.Name == "pbPlace" + i.ToString());

                p.Visible=false;
                p2.Visible=false;
                p3.Visible=false;
                p4.Visible=false;
            }
        }          
        public void StatInfo(string label)
        {
            lines = File.ReadAllLines(filePath).ToList();
            string[] line;

            for (int i = 1; i <= 7; i++)
            {
                var p = this.Controls.OfType<Label>().FirstOrDefault(e => e.Name == "lblName" + i.ToString());

                if(p.Name.ToString() == label)
                {
                    Stats stats = new Stats();
                    line = lines[i - 1].Split(';');

                    stats.Name = line[0].Substring(1, line[0].Length - 2);
                    stats.Score = line[1];
                    stats.GameTime = line[2];
                    stats.avrgMoveTime = line[3];
                    stats.missCounterS = line[4];
                    stats.DiffLvl = line[5];
                    stats.Date = line[6];

                    stats.ShowDialog();

                    line = null;
                }
            }
        }
        private void lblName1_Click(object sender, EventArgs e)
        {
            string name = "lblName1";
            StatInfo(name);
        }

        private void lblName2_Click(object sender, EventArgs e)
        {
            string name = "lblName2";
            StatInfo(name);
        }

        private void lblName6_Click(object sender, EventArgs e)
        {
            string name = "lblName6";
            StatInfo(name);
        }

        private void lblName5_Click(object sender, EventArgs e)
        {
            string name = "lblName5";
            StatInfo(name);
        }

        private void lblName4_Click(object sender, EventArgs e)
        {
            string name = "lblName4";
            StatInfo(name);
        }

        private void lblName3_Click(object sender, EventArgs e)
        {
            string name = "lblName3";
            StatInfo(name);
        }

        private void lblName7_Click(object sender, EventArgs e)
        {
            string name = "lblName7";
            StatInfo(name);
        }
        private void LostAllFocus(object sender, EventArgs e)
        {
            this.lblRanking.Focus();
            Button obiekt = (Button)sender;
        }
        private void ButtonFocus()
        {
            this.btnRanPowrot.Click += LostAllFocus;
            this.btnRanExit.Click += LostAllFocus;
        }
        private void SetLocation()
        {   //DOESNT WORK && NOT USED
            for (int i = 1; i <= 7; i++)
            {
                var p = this.Controls.OfType<Label>().FirstOrDefault(e => e.Name == "lblName" + i.ToString());
                var p2 = this.Controls.OfType<Label>().FirstOrDefault(e => e.Name == "lblScore" + i.ToString());

                if (p2.Text.Length == 1)
                {
                    p2.Location = new Point(192, 168);
                }
                else if (p2.Text.Length == 2)
                {
                    p2.Location = new Point(188, 168);
                }
                else if (p2.Text.Length == 3)
                {
                    p2.Location = new Point(185, 168);
                }
                else if (p2.Text.Length == 4)
                {
                    p2.Location = new Point(181, 168);
                }
                else if (p2.Text.Length == 5)
                {
                    p2.Location = new Point(176, 168);
                }

                if (p.Text.Length == 3)
                {
                    p.Location = new Point(78, 173);
                }
                else if (p.Text.Length == 4)
                {
                    p.Location = new Point(73, 173);
                }
                else if (p.Text.Length == 5)
                {
                    p.Location = new Point(71, 173);
                }
                else if (p.Text.Length == 6)
                {
                    p.Location = new Point(68, 173);
                }
                else if (p.Text.Length == 7)
                {
                    p.Location = new Point(66, 173);
                }
                else if (p.Text.Length == 8)
                {
                    p.Location = new Point(64, 173);
                }
                else if (p.Text.Length == 9)
                {
                    p.Location = new Point(63, 173);
                }
                else if (p.Text.Length == 10)
                {
                    p.Location = new Point(62, 173);
                }
                else if (p.Text.Length == 11)
                {
                    p.Location = new Point(61, 173);
                }
                else if (p.Text.Length == 12)
                {
                    p.Location = new Point(59, 173);
                }
                else if (p.Text.Length == 13)
                {
                    p.Location = new Point(59, 173);
                }
                else if (p.Text.Length == 14)
                {
                    p.Location = new Point(59, 173);
                }
                else if (p.Text.Length == 15)
                {
                    p.Location = new Point(59, 173);
                }
                else if (p.Text.Length == 16)
                {
                    p.Location = new Point(59, 173);
                }

            }
        }
    }
}
