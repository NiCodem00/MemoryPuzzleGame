using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memorki
{
    public partial class Plain96 : Form
    {
        public static PlainSettings plainS = new PlainSettings();
        public static WinFormcs win = new WinFormcs();

        public static Stopwatch stopWatch;
        public static Stopwatch stopWatch2;
        public static Stopwatch stopWatch3;

        Image[] imgs = new Image[97];
        List<int> eachMoveTimes = new List<int>();
        List<int> genNums = new List<int>();

        public Random rng = new Random();
        int[] imgIds = Enumerable.Range(1, 48).Concat(Enumerable.Range(1, 48)).ToArray();

        public static float averageMoveTime;
        public static string GameTime = "";
        public static string Date = "";
        public static int missCounter = 0;
        public static int totalGameMinutes = 0;
        public static int totalGameSeconds = 0;
        public static int moves = 0;
        public static string rankTime = "";
        public static bool isGamebegan = false;

        public int arg = 1;
        public int matchCounter = 0;
        public int timeTick2 = 0;
        public int value = 0;
        public int IniEachWait = 50;
        public int theImageI = 0;
        public bool hasIniBeenShowed = false;
        public bool hasIniBeenHidden = false;
        public bool notMatchTick = false;
        public bool doneOp = false;
        public bool match = false;

        int firstClickedIm = 0;
        int secondClickedIm = 0;

        int firstButton = 0;
        int secondButton = 0;

        public Plain96()
        {
            InitializeComponent();
        }     

        public void Plain96_Load(object sender, EventArgs e)
        {
            SetVariables();
            ImagesLoad();
            ButtonFocus();
            txtLoad();
            ReverseLoad();
            SetStopWatch();
        }
        private void ImageBackSet()
        {
            for (int i = 1; i <= 96;)
            {
                SetIniPictureBack(Pictures(i));
                i++;
            }
        }
        public void btnPlain96Start_Click(object sender, EventArgs e)
        {
            if (Ustawienia.InitialMode == "On")
            {
                if (isGamebegan == false)
                {
                    stopWatch.Stop();
                    stopWatch2.Stop();

                    Thread.Sleep(1000);

                    PictureIniShow();
                }
            }
            else
            {
                isGamebegan = true;
            }
            if (isGamebegan == true)
            {
                stopWatch.Start();
            }
            stopWatch2.Start();

            btnPlain96Start.Visible = false;
            btn96Stop.Visible = true;

            isGamebegan = true;
            hasIniBeenShowed = true;
        }
        private void btn96Stop_Click(object sender, EventArgs e)
        {
            if (Ustawienia.InitialMode == "On")
            {
                if (hasIniBeenHidden == true)
                {
                    stopWatch.Stop();
                    stopWatch2.Stop();

                    btn96Stop.Visible = false;
                    btnPlain96Start.Visible = true;


                }
                else
                {
                    PictureIniHide();

                    hasIniBeenHidden = true;

                    stopWatch.Stop();
                    stopWatch2.Stop();

                    btn96Stop.Visible = false;
                    btnPlain96Start.Visible = true;
                }
            }
            else
            {
                stopWatch.Stop();
                stopWatch2.Stop();

                btn96Stop.Visible = false;
                btnPlain96Start.Visible = true;
            }
        }
        private void btn96Settings_Click(object sender, EventArgs e)
        {
            if (Ustawienia.InitialMode == "On")
            {
                if (isGamebegan == true)
                {
                    if (hasIniBeenHidden == false)
                    {
                        PictureIniHide();
                        hasIniBeenHidden = true;
                    }
                }
            }

            plainS.ShowDialog();

            stopWatch.Stop();
            stopWatch2.Stop();

            btn96Stop.Visible = false;
            btnPlain96Start.Visible = true;
        }
        private void btn96Pomoc_Click(object sender, EventArgs e)
        {
            if (Ustawienia.InitialMode == "On")
            {
                if (hasIniBeenHidden == false)
                {
                    PictureIniHide();
                    hasIniBeenHidden = true;
                }
            }

            stopWatch.Stop();
            stopWatch2.Stop();

            btn96Stop.Visible = false;
            btnPlain96Start.Visible = true;

            MessageBox.Show("In order to win, you must match the pictures correctly with as little mistakes as possible. ", "Help", MessageBoxButtons.OK);
        }
        public void timer1_Tick_1(object sender, EventArgs e)
        {
            if (stopWatch != null)
            {
                txt96CzRuchu.Text = String.Format("{0:mm\\:ss\\.ff}", stopWatch.Elapsed);
            }
            if (isGamebegan == true)
            {
                if (stopWatch.Elapsed.Minutes >= 59)
                {
                    stopWatch.Stop();
                    stopWatch2.Stop();

                    btn96Stop.Visible = false;
                    btnPlain96Start.Visible = true;
                }
            }
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (stopWatch2 != null)
            {
                txt96CzGry.Text = String.Format("{0:mm\\:ss\\.ff}", stopWatch2.Elapsed);
            }
            if (Ustawienia.InitialMode == "On")
            {
                if (isGamebegan == true && hasIniBeenShowed == true && hasIniBeenHidden == false)
                {
                    if (stopWatch2.Elapsed.Seconds == Ustawienia.IniTime)
                    {
                        do
                        {
                            PictureIniHide();
                        }
                        while (arg == 0);
                        hasIniBeenHidden = true;
                    }
                }
            }
            if (notMatchTick == true)
            {
                if (stopWatch2.Elapsed.TotalSeconds >= timeTick2 + Ustawienia.OdwTime && doneOp == false)
                {
                    timeTick2 = (int)stopWatch2.Elapsed.TotalSeconds;
                }
                if (stopWatch2.Elapsed.TotalSeconds >= timeTick2 + Ustawienia.OdwTime)
                {
                    var p1 = this.Controls.OfType<PictureBox>().FirstOrDefault(e => e.Name == "pb" + firstButton.ToString());
                    var p2 = this.Controls.OfType<PictureBox>().FirstOrDefault(e => e.Name == "pb" + secondButton.ToString());

                    p1.Image = imgs[0];
                    p2.Image = imgs[0];

                    firstClickedIm = 0;
                    secondClickedIm = 0;
                    firstButton = 0;
                    secondButton = 0;

                    eachMoveTimes.Add(stopWatch.Elapsed.Seconds);
                    moves++;

                    stopWatch.Restart();
                    stopWatch.Start();

                    notMatchTick = false;
                    doneOp = true;

                }
            }
            if (isGamebegan == true)
            {
                if (stopWatch2.Elapsed.Minutes >= 59)
                {
                    stopWatch.Stop();
                    stopWatch2.Stop();

                    btn96Stop.Visible = false;
                    btnPlain96Start.Visible = true;

                    DialogResult result = MessageBox.Show("Time's up.", "Defeat!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (result == DialogResult.OK)
                    {
                        Menu menu = new Menu();
                        menu.Show();

                        this.Hide();
                        this.Close();
                    }
                }
            }
            if(missCounter >= 9999)
            {
                LoseLoad();
            }
            doneOp = true;

        }
        private void LostAllFocus(object sender, EventArgs e)
        {
            this.lblNick.Focus();
            Button obiekt = (Button)sender;
        }

        private void txtLoad()
        {
            txt96CzGry.Text = "";
            txt96CzRuchu.Text = "";
            txt96Difficulty.Text = "";

            lblNick.Text = "";
            lblNick.Text = DataInput.CurrentNick;

            lbl96Pomylka.Text = $"Mistakes: {missCounter}";

            txt96CzGry.Text = "00:00.00";
            txt96CzRuchu.Text = "00:00.00";

            if (Ustawienia.DiffLevel != null)
            {
                txt96Difficulty.Text = "Difficulty: " + Ustawienia.DiffLevel;
            }
            else
            {
                txt96Difficulty.Text = "Difficulty: Easy";
            }

        }
        public void SetVariables()
        {
            isGamebegan = false;
            GameTime = "";
            averageMoveTime = 0;
            moves = 0;
            missCounter = 0;
            theImageI = 0;

            IEnumerable<int> molist = GenerateNoDuplicateRandom(1, 96);
            genNums = molist.ToList();
        }
        public void SetStopWatch()
        {
            stopWatch = new Stopwatch();
            stopWatch2 = new Stopwatch();
            stopWatch3 = new Stopwatch();

            stopWatch2.Stop();
            stopWatch.Stop();

            btn96Stop.Visible = false;
            btnPlain96Start.Visible = true;

            if (Ustawienia.InitialMode == "Off")
            {
                hasIniBeenShowed = true;
                ImageBackSet();
                hasIniBeenHidden = true;
            }
        }

        public IEnumerable<int>
        GenerateNoDuplicateRandom(int minValue, int maxValue)
        {
            return Enumerable.Range(minValue, maxValue).OrderBy(g => Guid.NewGuid());
        }
        public int Pictures(int picture)
        {
            return picture;
        }
        public void SetPicture(int pic)
        {
            var p = this.Controls.OfType<PictureBox>().FirstOrDefault(e => e.Name == "pb" + pic.ToString());
            p.Image = imgs[genNums[pic - 1]];
            p.Refresh();
        }
        public void SetIniPictureBack(int pic)
        {
            var p = this.Controls.OfType<PictureBox>().FirstOrDefault(e => e.Name == "pb" + pic.ToString());
            p.Image = imgs[0];
            p.Refresh();
        }
        public void PictureIniShow()
        {
            for (int i = 1; i <= 96;)
            {
                SetPicture(Pictures(i));
                Thread.Sleep(25);
                i++;
            }
        }
        public void PictureIniHide()
        {
            stopWatch3.Start();

            for (int i = 1; i <= 96;)
            {
                if (stopWatch3.ElapsedMilliseconds == 13 * i)
                {
                    SetIniPictureBack(Pictures(i));
                    i++;
                }
                // Thread.Sleep(50);              
            }

            stopWatch3.Stop();
            stopWatch3.Reset();
            stopWatch.Start();
        }

        private void ReverseLoad()
        {
            for (int i = 1; i <= 96;)
            {
                var p = this.Controls.OfType<PictureBox>().FirstOrDefault(e => e.Name == "pb" + i.ToString());
                p.Image = Properties.Resources._0; //4/5/b2
                p.Refresh();
                i++;                
            }
        }
        public void CheckIfMatch(int first, int second, int firstCButton, int secondCButton)
        {

            if (imgIds[first - 1] == imgIds[second - 1])
            {
                match = true;
            }
            else
            {
                match = false;
            }

            if (match == true)
            {
                matchCounter++;

                firstClickedIm = 0;
                secondClickedIm = 0;
                firstButton = 0;
                secondButton = 0;

                eachMoveTimes.Add(stopWatch.Elapsed.Seconds);
                moves++;
                stopWatch.Restart();
            }
            else
            {
                stopWatch.Stop();
                missCounter++;

                lbl96Pomylka.Text = $"Mistakes: {missCounter}";

                doneOp = false;
                timeTick2 = stopWatch2.Elapsed.Seconds;
                notMatchTick = true;

            }

            if (matchCounter == 48)
            {
                WinLoad();
            }

        }
        public void WinLoad()
        {
            stopWatch.Stop();
            stopWatch2.Stop();

            totalGameSeconds = (int)stopWatch2.Elapsed.TotalSeconds;
            totalGameMinutes = (int)stopWatch2.Elapsed.TotalMinutes;

            GameTime = txt96CzGry.Text;
            rankTime = txt96CzGry.Text;

            Date = DateTime.Now.ToString("dd-MM-yyyy");


            foreach (int item in eachMoveTimes)
            {
                averageMoveTime = averageMoveTime + item;
            }
            averageMoveTime = averageMoveTime / moves;

            Thread.Sleep(500);
            win.ShowDialog();

            btn96Stop.Visible = false;
            btnPlain96Start.Visible = true;
        }
        public void LoseLoad()
        {
            DialogResult result = MessageBox.Show("How did you even manage that?", "Defeat!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (result == DialogResult.OK)
            {
                Menu menu = new Menu();
                menu.Show();

                this.Hide();
                this.Close();
            }
        }
        public void ImagesLoad()
        {
            for (int i = 0; i <= 96; i++)
            {
                if (theImageI == 49)
                {
                    theImageI = 1;
                }
                object img = Properties.Resources.ResourceManager.GetObject(theImageI.ToString(), new System.Globalization.CultureInfo("pl-PL"));

                imgs[i] = img as Image;
                theImageI++;
            }
        }
        public void CheckSet(int button)
        {
            var p = this.Controls.OfType<PictureBox>().FirstOrDefault(e => e.Name == "pb" + button.ToString());

            if (secondClickedIm == 0 && p.Image == imgs[0] && stopWatch2.IsRunning == true)
            {
                if (firstClickedIm == 0 && secondClickedIm == 0)
                {
                    firstClickedIm = genNums[button - 1];
                    firstButton = button;
                    p.Image = imgs[genNums[button - 1]];
                }
                else if (firstClickedIm != 0 && secondClickedIm == 0)
                {
                    secondClickedIm = genNums[button - 1];
                    secondButton = button;
                    p.Image = imgs[genNums[button - 1]];

                    CheckIfMatch(firstClickedIm, secondClickedIm, firstButton, secondButton);
                }
            }
        }
        public void ButtonClick(object sender, EventArgs e)
        {
            string[] btnNumber = null;

            var btn = (PictureBox)sender;
            btn.Text = btn.Name;

            btnNumber = btn.Text.ToString().Split('b');

            CheckSet(Int32.Parse(btnNumber[1]));
        }
        private void ButtonFocus()
        {
            this.btnPlain96Start.Click += LostAllFocus;
            this.btn96Stop.Click += LostAllFocus;
            this.btn96Pomoc.Click += LostAllFocus;
            this.btn96Settings.Click += LostAllFocus;
            this.btn96DesignRight.Click += LostAllFocus;
            this.btn96DesignRight2.Click += LostAllFocus;
            this.btn96DesignLeft0.Click += LostAllFocus;
            this.txt96CzGry.Text += LostAllFocus;
            this.txt96CzRuchu.Text += LostAllFocus;
            this.txt96Difficulty.Text += LostAllFocus;
        }
       
        private void Plain96_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.ExitThread();
            Application.Exit();
        }
    }
}
