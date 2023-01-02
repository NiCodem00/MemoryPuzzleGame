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
    public partial class PlainSettings : Form
    {
        public static bool menuCalled = false;
        public bool save = false;

        public int tempDiffLevel;
        public int tempGameMode;
        public int tempInitialMode;

        public string tempIniTime;
        public string tempOdwTime;

        public bool diffSettings;
        
        public PlainSettings()
        {
            InitializeComponent();
        }
        public void PlainSettings_Load(object sender, EventArgs e)
        {
            StopWatchHalt();
            ButtonFocus();

            Ustawienia ustawienia = new Ustawienia();

            txtWidzialnoscOdw.Text = Ustawienia.OdwTime.ToString();
            txtWidzialnoscIni.Text = Ustawienia.IniTime.ToString();

            GetTemp();
            GameBeganStop();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnPowrot_Click(object sender, EventArgs e)
        {
            CheckIfDiff();
            GameBeganStop();

            if (diffSettings)
            {
                bool correctData = false;
                bool tempCorrectData2 = false; //remove this if u wish to develop other gamemodes
                bool digitsOnly = false;

                if (txtWidzialnoscIni.Text.All(char.IsDigit) && txtWidzialnoscOdw.Text.All(char.IsDigit))
                {
                    digitsOnly = true;
                }
                else
                {
                    MessageBox.Show("The value of initial visibility and reversed visibility must be a number.");
                }                  

                if (digitsOnly)
                {
                    if (txtWidzialnoscIni.Text.Length < 1 || txtWidzialnoscOdw.Text.Length < 1 || Int32.Parse(txtWidzialnoscIni.Text) > 120 || Int32.Parse(txtWidzialnoscIni.Text) < 1 || Int32.Parse(txtWidzialnoscOdw.Text) < 1 || Int32.Parse(txtWidzialnoscOdw.Text) > 360)
                    {
                        MessageBox.Show("Incorrect data.", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        correctData = true;
                    }
                }
                tempCorrectData2 = true;

                if (correctData && tempCorrectData2)
                {
                    DialogResult result = MessageBox.Show("Save changes?", "Return", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);

                    if (result == DialogResult.Yes)
                    {
                        MessageYes();
                    }
                    else if (result == DialogResult.No)
                    {
                        MessageNo();
                    }
                    else if (result == DialogResult.Cancel)
                    {

                    }
                }
            }
            else
            {
                SettingsClose();
            }
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            PSettingLogOut();
        }
        private void btnWidzialnoscOdw_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" Time in seconds, that represents reversed cards visibility \n Min 1 second \n Max 360 seconds", "Reversed Visibility", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }                   
        private void btnWidzialnoscIni_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Time in seconds, that represents how long the cards stay visible at the beginning of the round before they reverse. \nMax time: 120 seconds.", "Initial Visibility", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }                  
        private void btnPSettMenu_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure, you wish to return to the menu?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                PSettingMenu();
            }
        }
        private void GameBeganStop()
        {
            switch (Ustawienia.DiffLevel)
            {
                case "Easy":
                    {
                            Plain24 plain = new Plain24();

                        if (Plain24.isGamebegan == false)
                        {
                            plain.txt24CzRuchu.Text = "00:00.00";
                            Plain24.stopWatch.Reset();
                            Plain24.stopWatch.Stop();

                            Plain24.stopWatch2.Reset();
                            Plain24.stopWatch2.Stop();
                        }
                        break;
                    }
                case "Normal":
                    {
                        Plain48 plain = new Plain48();

                        if (Plain48.isGamebegan == false)
                        {
                            plain.txt48CzRuchu.Text = "00:00.00";
                            Plain48.stopWatch.Reset();
                            Plain48.stopWatch.Stop();

                            Plain48.stopWatch2.Reset();
                            Plain48.stopWatch2.Stop();
                        }

                        break;
                    }
                case "Hard":
                    {
                        Plain96 plain = new Plain96();
                        if (Plain96.isGamebegan == false)
                        {
                            plain.txt96CzRuchu.Text = "00:00.00";
                            Plain96.stopWatch.Reset();
                            Plain96.stopWatch.Stop();

                            Plain96.stopWatch2.Reset();
                            Plain96.stopWatch2.Stop();
                        }
                            break;
                    }
                default:
                    {
                        MessageBox.Show("Difficulty exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }

            }
        }
        private void StopWatchHalt()
        {
            switch (Ustawienia.DiffLevel)
            {
                case "Easy":
                    {
                        Plain24 plain = new Plain24();

                        Plain24.stopWatch.Stop();
                        Plain24.stopWatch2.Stop();

                        plain.btn24Stop.Visible = false;
                        plain.btnPlain24Start.Visible = true;
                        break;
                    }
                case "Normal":
                    {
                        Plain48 plain = new Plain48();

                        Plain48.stopWatch.Stop();
                        Plain48.stopWatch2.Stop();

                        plain.btn48Stop.Visible = false;
                        plain.btnPlain48Start.Visible = true;

                        break;
                    }
                case "Hard":
                    {
                        Plain96 plain = new Plain96();
                        Plain96.stopWatch.Stop();
                        Plain96.stopWatch2.Stop();

                        plain.btn96Stop.Visible = false;
                        plain.btnPlain96Start.Visible = true;
                        break;
                    }
                default:
                    {
                        MessageBox.Show("Difficulty exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
            }
        }
        private void MessageYes()
        {
            Ustawienia.IniTime = Int32.Parse(txtWidzialnoscIni.Text);
            Ustawienia.OdwTime = Int32.Parse(txtWidzialnoscOdw.Text);

            save = true;

            SettingsClose();
        }
        private void MessageNo()
        {
            SettingsClose();
        }
        private void SettingsClose()
        {
            this.Hide();
        }
        private void GetTemp()
        {
            tempIniTime = txtWidzialnoscIni.Text;
            tempOdwTime = txtWidzialnoscOdw.Text;
        }
        private void CheckIfDiff()
        {
            if (txtWidzialnoscIni.Text != tempIniTime || txtWidzialnoscOdw.Text != tempOdwTime)
            {
                diffSettings = true;
            }
            else
            {
                diffSettings = false;
            }
        }

        private void PlainSettings_Leave(object sender, EventArgs e)
        {
            GameBeganStop();
        }
        private void PSettingMenu()
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
            menu.ShowDialog();
        }
        private void PSettingLogOut()
        {
            this.Hide();
            DataInput data = new DataInput();
            data.Show();

            Application.Restart();
            this.Hide();
        }
        private void LostAllFocus(object sender, EventArgs e)
        {
            this.lblUstawieniaUstawienia.Focus();
            Button obiekt = (Button)sender;
        }
        private void ButtonFocus()
        {
            this.btnWidzialnoscIni.Click += LostAllFocus;
            this.btnWidzialnoscOdw.Click += LostAllFocus;
            this.btnExit.Click += LostAllFocus;
            this.btnLogOut.Click += LostAllFocus;
            this.btnPowrot.Click += LostAllFocus;
            this.btnPSettMenu.Click +=LostAllFocus;
        }
    }
}
