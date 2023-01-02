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
    public partial class Menu : Form
    {
      
        public string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "settings.txt");        
        public string[] fileLines = null;
        public bool ifuserChecked = false;
        public Menu()
        { 
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            ButtonFocus();
            CheckSettings();
            lblMenuNick.Text = DataInput.CurrentNick;
        }

        private void btnMenuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMenuLogOut_Click(object sender, EventArgs e)
        {
            DataInput data = new DataInput();
            data.Show();
            this.Hide();
        }

        private void btnMenuUstawienia_Click(object sender, EventArgs e)
        {
            Ustawienia ustawienia = new Ustawienia();
            ustawienia.Show();
            this.Hide();
        }
        private void btnMenuStart_Click(object sender, EventArgs e)
        {
            BoardLoad();
        }

        private void btnMenuRanking_Click(object sender, EventArgs e)
        {
            Ranking rank = new Ranking();
            rank.Show();
            this.Hide();
        }
        public void CheckSettings()
        {
            if(!Ustawienia.SettingsOpened == true)
            {
                fileLines = File.ReadAllLines(filePath);
                foreach (string line in fileLines)
                {
                    if (line.Contains($"|{DataInput.CurrentNick}|"))
                    {
                        ifuserChecked = true;
                    }
                }

                if(ifuserChecked)
                {
                    fileLines = File.ReadAllLines(filePath);
                    foreach (string line in fileLines)
                    {
                        if (line.Contains($"|{DataInput.CurrentNick}|"))
                        {
                            string[] parts = line.Split('!');
                            string part = parts[1];

                            switch (part)
                            {
                                case "Easy":
                                    {
                                        Ustawienia.DiffLevel = "Easy";
                                        break;
                                    }
                                case "Normal":
                                    {
                                        Ustawienia.DiffLevel = "Normal";
                                        break;
                                    }
                                case "Hard":
                                    {
                                        Ustawienia.DiffLevel = "Hard";
                                        break;
                                    }
                                default:
                                    {
                                        break;
                                    }
                            }
                            parts = null;
                            part = "";

                            parts = line.Split('@');
                            part = parts[1];

                            switch (part)
                            {
                                case "Standard":
                                    {
                                        Ustawienia.GameMode = "Standard";

                                        break;
                                    }
                                default:
                                    {
                                        break;
                                    }
                            }

                            parts = null;
                            part = "";

                            parts = line.Split('#');
                            part = parts[1];

                            switch (part)
                            {
                                case "On":
                                    {
                                        Ustawienia.InitialMode = "On";
                                        break;
                                    }
                                case "Off":
                                    {
                                        Ustawienia.InitialMode = "Off";
                                        break;
                                    }
                                default:
                                    {
                                        break;
                                    }
                            }

                            parts = null;
                            part = "";

                            parts = line.Split('%');
                            part = parts[1];

                            Ustawienia.OdwTime = Int32.Parse(part);

                            parts = null;
                            part = "";

                            parts = line.Split('&');
                            part = parts[1];

                            Ustawienia.IniTime = Int32.Parse(part);
                        }
                    }
                }
            }
        }
        private void BoardLoad()
        {
            switch (Ustawienia.DiffLevel)
            {
                case "Easy":
                    {
                        Plain24 plainN = new Plain24();
                        plainN.Show();
                        this.Hide();
                        break;
                    }
                case "Normal":
                    {

                        Plain48 plainN = new Plain48();
                        plainN.Show();
                        this.Hide();

                        break;
                    }
                case "Hard":
                    {
                        Plain96 plainH = new Plain96();
                        plainH.Show();
                        this.Hide();

                        break;
                    }
                default:
                    {
                        MessageBox.Show("Difficulty exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
            }
        }
        private void LostAllFocus(object sender, EventArgs e)
        {
            this.lblMenuMemorki.Focus();
            Button obiekt = (Button)sender;
        }
        private void ButtonFocus()
        {
            this.btnMenuStart.Click += LostAllFocus;
            this.btnMenuUstawienia.Click += LostAllFocus;
            this.btnMenuExit.Click += LostAllFocus;
            this.btnMenuRanking.Click += LostAllFocus;
        }
        private void Menu_Leave(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
