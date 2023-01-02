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
    public partial class Plain48 : Form
    {
        public static PlainSettings plainS = new PlainSettings();
        public static WinFormcs win = new WinFormcs();

        public static Stopwatch stopWatch;
        public static Stopwatch stopWatch2;
        public static Stopwatch stopWatch3;       

        Image[] imgs = new Image[49];
        List<int> eachMoveTimes = new List<int>();
        List<int> genNums = new List<int>();

        public Random rng = new Random();
        int[] imgIds = Enumerable.Range(1, 24).Concat(Enumerable.Range(1, 24)).ToArray();

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

        public Plain48()
        {
            InitializeComponent();
        }

        public void Plain48_Load(object sender, EventArgs e)
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
            for (int i = 1; i <= 48;)
            {
                SetIniPictureBack(Pictures(i));
                i++;                        
            }
        }
        public void btnPlain48Start_Click(object sender, EventArgs e)
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
                isGamebegan=true;
            }
            if(isGamebegan==true)
            {
               stopWatch.Start();
            }
            stopWatch2.Start();     

            btnPlain48Start.Visible = false;
            btn48Stop.Visible = true;

            isGamebegan = true;
            hasIniBeenShowed=true;
        }
        public void btn48Stop_Click(object sender, EventArgs e)
        {

            if (Ustawienia.InitialMode == "On")
            {
                if (hasIniBeenHidden == true)
                {
                    stopWatch.Stop();
                    stopWatch2.Stop();

                    btn48Stop.Visible = false;
                    btnPlain48Start.Visible = true;


                }
                else
                {
                    PictureIniHide();

                    hasIniBeenHidden = true;

                    stopWatch.Stop();
                    stopWatch2.Stop();

                    btn48Stop.Visible = false;
                    btnPlain48Start.Visible = true;
                }
            }
            else
            {
                stopWatch.Stop();
                stopWatch2.Stop();

                btn48Stop.Visible = false;
                btnPlain48Start.Visible = true;
            }
        }
        private void btn48Settings_Click(object sender, EventArgs e)
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

                btn48Stop.Visible = false;
                btnPlain48Start.Visible = true;                      

        }
        private void btn48Pomoc_Click(object sender, EventArgs e)
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

            btn48Stop.Visible = false;
            btnPlain48Start.Visible = true;

            MessageBox.Show("In order to win, you must match the pictures correctly with as little mistakes as possible. ", "Help", MessageBoxButtons.OK);

        }
        public void timer1_Tick_1(object sender, EventArgs e)
        {
            if (stopWatch != null)
            {
                txt48CzRuchu.Text = String.Format("{0:mm\\:ss\\.ff}", stopWatch.Elapsed);
            }
            if (isGamebegan == true)
            {
                if (stopWatch.Elapsed.Minutes >= 59)
                {
                    stopWatch.Stop();
                    stopWatch2.Stop();

                    btn48Stop.Visible = false;
                    btnPlain48Start.Visible = true;
                }
            }
        }
        private void timer2_Tick(object sender, EventArgs e)
        {         
            if (stopWatch2 != null)
            {
                txt48CzGry.Text = String.Format("{0:mm\\:ss\\.ff}", stopWatch2.Elapsed);
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
                if(stopWatch2.Elapsed.TotalSeconds >= timeTick2 + Ustawienia.OdwTime && doneOp == false)
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

                    btn48Stop.Visible = false;
                    btnPlain48Start.Visible = true;

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

            if (missCounter >= 9999)
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
            txt48CzGry.Text = "";
            txt48CzRuchu.Text = "";
            txt48Difficulty.Text = "";

            lblNick.Text = "";
            lblNick.Text = DataInput.CurrentNick;

            lbl48Pomylka.Text = $"Mistakes: {missCounter}";

            txt48CzGry.Text = "00:00.00";
            txt48CzRuchu.Text = "00:00.00";

            if (Ustawienia.DiffLevel != null)
            {
                txt48Difficulty.Text = "Difficulty: " + Ustawienia.DiffLevel;
            }
            else
            {
                txt48Difficulty.Text = "Difficulty: Easy";
            }

        }
        public void SetVariables()
        {
            isGamebegan = false;
            GameTime = "";
            averageMoveTime = 0;
            moves = 0;
            missCounter = 0;

            IEnumerable<int> molist = GenerateNoDuplicateRandom(1, 48);
            genNums = molist.ToList();
        }
        public void SetStopWatch()
        {
            stopWatch = new Stopwatch();
            stopWatch2 = new Stopwatch();
            stopWatch3 = new Stopwatch();

            stopWatch2.Stop();
            stopWatch.Stop();

            btn48Stop.Visible = false;
            btnPlain48Start.Visible = true;

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
            p.Image = imgs[genNums[pic-1]];
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
            for(int i=1;i<=48;)
            {             
                SetPicture(Pictures(i));
                Thread.Sleep(50);
                i++;
            }
        }
        public void PictureIniHide()
        {
            stopWatch3.Start();

            for (int i = 1; i <= 48;)
            {
                if (stopWatch3.ElapsedMilliseconds == 25 * i)
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
            for (int i = 1; i <= 48;)
            {
                var p = this.Controls.OfType<PictureBox>().FirstOrDefault(e => e.Name == "pb" + i.ToString());
                p.Image = Properties.Resources._0; //4/5/b2
                p.Refresh();
                i++;
            }                                
        }      
        public void CheckIfMatch(int first, int second, int firstCButton, int secondCButton)
        {

            if(imgIds[first-1] == imgIds[second-1])
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

                lbl48Pomylka.Text = $"Mistakes: {missCounter}";

                doneOp = false;
                timeTick2 = stopWatch2.Elapsed.Seconds;
                notMatchTick = true;

            }

            if(matchCounter == 24)
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

            GameTime = txt48CzGry.Text;
            rankTime = txt48CzGry.Text;

            Date = DateTime.Now.ToString("dd-MM-yyyy");


            foreach (int item in eachMoveTimes)
            {
                averageMoveTime = averageMoveTime + item;
            }
            averageMoveTime = averageMoveTime / moves;

            Thread.Sleep(700);
            win.ShowDialog();

            btn48Stop.Visible = false;
            btnPlain48Start.Visible = true;
        }
        public void LoseLoad()
        {
            DialogResult result = MessageBox.Show("How did you even manage that?", "Defeat!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        
            if(result == DialogResult.OK)
            {
                Menu menu = new Menu();
                menu.Show();

                this.Hide();
                this.Close();
            }
        }
        public void ImagesLoad()
        {
            for (int i = 0; i <= 48; i++)
            {
                if (theImageI == 25)
                {
                    theImageI = 1;
                }
                object img = Properties.Resources.ResourceManager.GetObject(theImageI.ToString(), new System.Globalization.CultureInfo("pl-PL"));

                imgs[i] = img as Image;
                theImageI++;
            }         
        }
        private void ButtonFocus()
        {
            this.btnPlain48Start.Click += LostAllFocus;
            this.btn48Stop.Click += LostAllFocus;
            this.btn48Pomoc.Click += LostAllFocus;
            this.btn48Settings.Click += LostAllFocus;
            this.btn48DesignRight.Click += LostAllFocus;
            this.button1.Click += LostAllFocus;
            this.button2.Click += LostAllFocus;
            this.txt48CzGry.Text += LostAllFocus;
            this.txt48CzRuchu.Text += LostAllFocus;
            this.txt48Difficulty.Text += LostAllFocus;
        }
        public void CheckSet(int button)
        {
            var p = this.Controls.OfType<PictureBox>().FirstOrDefault(e => e.Name == "pb" + button.ToString());
            
            if (secondClickedIm == 0 && p.Image == imgs[0] && stopWatch2.IsRunning == true)
            {
                if (firstClickedIm == 0 && secondClickedIm == 0)
                {
                    firstClickedIm = genNums[button-1];
                    firstButton = button;
                    p.Image = imgs[genNums[button-1]];
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
        private void Plain48_Leave(object sender, EventArgs e)
        {
            Application.ExitThread();
            Application.Exit();
        }
    }
}
