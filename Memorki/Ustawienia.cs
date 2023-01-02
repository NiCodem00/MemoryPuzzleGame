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
    public partial class Ustawienia : Form
    {
        public List<string> lines = new List<string>();

        public string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "settings.txt");

        public string[] fileLines = null;

        public static int IniTime = 10;
        public static int OdwTime = 2;

        public static string DiffLevel = "Normal";
        public static string GameMode = "Standard";
        public static string InitialMode = "On";

        public static bool save = false;
        public static bool SettingsOpened = false;

        public int tempDiffLevel;
        public int tempGameMode;
        public int tempInitialMode;

        public string tempIniTime;
        public string tempOdwTime;

        public string chwilowyDifflvl;
        public string chwilowyGMMode;
        public string chwilowyInitialMode;
        public string chwilowyIniTime;
        public string chwilowyOdwTime;

        public bool tempCheckBox;
        public bool diffSettings; //Checks if settings changed
        public bool ifuserChecked = false;
        public bool justloaded = true;
        public bool correctData = false;
        public bool digitsOnly = false;
        //difflevel = !, Gamemode = @, Initialmode = #, WidOdw = %, WidIni = &

        public Ustawienia()
        {
            InitializeComponent();
        }
        private void Ustawienia_Load(object sender, EventArgs e)
        {
            InitialSet();
            ButtonFocus(); 
            
            CheckSet();
            Statements();

            GetTemp();

            SettingsOpened = true;
            justloaded = false;

        }

        private void btnPoziomTrudnosci_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The set of cards expands with difficulty level (Easy,Normal,Hard) (24,48,96)", "Difficulty", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }                  //

        private void btnTrybGry_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Standard or Expanded (Expanded - work in progress)", "Game Mode", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnWidzialnoscIni_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Time in seconds, that represents how long the cards stay visible at the beginning of the round before they reverse. \nMax time: 120 seconds.", "Initial Visibility", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        
        private void btnWidzialnoscOdw_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" Time in seconds, that represents reversed cards visibility \n Min 1 second \n Max 360 seconds", "Reversed Visibility", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnUstawieniaPowrot_Click(object sender, EventArgs e)
        {
            CheckIfDiff();

            if (diffSettings)
            {
                CheckCorrectData();

                if (correctData)
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
        private void btnUstReset_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                cmbPoziomTrudnosci.SelectedIndex = 1;
                cmbTrybGry.SelectedIndex = 0;
                cmbUstawieniaIniMode.SelectedIndex = 0;

                txtWidzialnoscIni.Text = "10";
                txtWidzialnoscOdw.Text = "2";
            }
        }

        private void btnUstawieniaIniMode_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This option is responsible for the initial revealing of cards. ", "Initial Mode", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }                   

        private void MessageYes()
        {
            SetVariables();

            save = true;

            CheckBoxSave();

            SettingsClose();
        }
        private void MessageNo()
        {
            SettingsClose();
        }
        private void SettingsClose()
        {
            Menu menu = new Menu();
            menu.Show();
            this.Hide();
        }
        public void InitialSet()
        {
            switch (DiffLevel)
            {
                case "Easy":
                    {
                        cmbPoziomTrudnosci.SelectedIndex = 0;
                        break;
                    }
                case "Normal":
                    {
                        cmbPoziomTrudnosci.SelectedIndex = 1;
                        break;
                    }
                case "Hard":
                    {
                        cmbPoziomTrudnosci.SelectedIndex = 2;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            if (InitialMode == "On")
            {
                cmbUstawieniaIniMode.SelectedIndex = 0;
            }
            else if (InitialMode == "Off")
            {
                cmbUstawieniaIniMode.SelectedIndex = 1;
            }
            else
            {
                cmbUstawieniaIniMode.SelectedIndex = 0;
            }

            txtWidzialnoscIni.Text = IniTime.ToString();
            txtWidzialnoscOdw.Text = OdwTime.ToString();
        }
        public void CheckSet()
        {
            fileLines = File.ReadAllLines(filePath);
            foreach (string line in fileLines)
            {
                if (line.Contains($"|{DataInput.CurrentNick}|"))
                {
                    ifuserChecked = true;
                }
            }
        }
        private void SetVariables()
        {
            DiffLevel = cmbPoziomTrudnosci.SelectedItem.ToString();
            GameMode = cmbTrybGry.SelectedItem.ToString();
            InitialMode = cmbUstawieniaIniMode.SelectedItem.ToString();

            IniTime = Int32.Parse(txtWidzialnoscIni.Text);
            OdwTime = Int32.Parse(txtWidzialnoscOdw.Text);
        }
        public void Statements()
        {
            if (save == false && ifuserChecked == false)
            {
                cmbPoziomTrudnosci.SelectedIndex = 1;
                cmbTrybGry.SelectedIndex = 0;
                cmbUstawieniaIniMode.SelectedIndex = 0;

                txtWidzialnoscOdw.Text = "2";
                txtWidzialnoscIni.Text = "10";

                SetVariables();
            }
            else if (save == true && ifuserChecked == false)
            {
                switch (DiffLevel)
                {
                    case "Easy":
                        {
                            cmbPoziomTrudnosci.SelectedIndex = 0;
                            break;
                        }
                    case "Normal":
                        {
                            cmbPoziomTrudnosci.SelectedIndex = 1;
                            break;
                        }
                    case "Hard":
                        {
                            cmbPoziomTrudnosci.SelectedIndex = 2;
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
                switch (GameMode)
                {
                    case "Standard":
                        {
                            cmbTrybGry.SelectedIndex = 0;
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }

                switch (InitialMode)
                {
                    case "On":
                        {
                            cmbUstawieniaIniMode.SelectedIndex = 0;
                            break;
                        }
                    case "Off":
                        {
                            cmbUstawieniaIniMode.SelectedIndex = 1;
                            break;
                        }
                }

                txtWidzialnoscOdw.Text = OdwTime.ToString();
                txtWidzialnoscIni.Text = IniTime.ToString();

                SetVariables();
            }
            else if (save == false && ifuserChecked == true)
            {
                chkBoxSave.Checked = true;

                justloaded = false;
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
                                    cmbPoziomTrudnosci.SelectedIndex = 0;
                                    break;
                                }
                            case "Normal":
                                {
                                    cmbPoziomTrudnosci.SelectedIndex = 1;
                                    break;
                                }
                            case "Hard":
                                {
                                    cmbPoziomTrudnosci.SelectedIndex = 2;
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
                                    cmbTrybGry.SelectedIndex = 0;

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
                                    cmbUstawieniaIniMode.SelectedIndex = 0;
                                    break;
                                }
                            case "Off":
                                {
                                    cmbUstawieniaIniMode.SelectedIndex = 1;
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

                        txtWidzialnoscOdw.Text = part;

                        parts = null;
                        part = "";

                        parts = line.Split('&');
                        part = parts[1];

                        txtWidzialnoscIni.Text = part;
                    }
                }
                SetVariables();
            }
            else if (save == true && ifuserChecked == true)
            {
                chkBoxSave.Checked = true;
                switch (DiffLevel)
                {
                    case "Easy":
                        {
                            cmbPoziomTrudnosci.SelectedIndex = 0;
                            break;
                        }
                    case "Normal":
                        {
                            cmbPoziomTrudnosci.SelectedIndex = 1;
                            break;
                        }
                    case "Hard":
                        {
                            cmbPoziomTrudnosci.SelectedIndex = 2;
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
                switch (GameMode)
                {
                    case "Standard":
                        {
                            cmbTrybGry.SelectedIndex = 0;
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }

                switch (InitialMode)
                {
                    case "On":
                        {
                            cmbUstawieniaIniMode.SelectedIndex = 0;
                            break;
                        }
                    case "Off":
                        {
                            cmbUstawieniaIniMode.SelectedIndex = 1;
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }

                txtWidzialnoscOdw.Text = OdwTime.ToString();
                txtWidzialnoscIni.Text = IniTime.ToString();

                SetVariables();
            }
        }
        private void GetTemp() //TO CHECK IF DIFFRENT AT THE END
        {
           tempDiffLevel = cmbPoziomTrudnosci.SelectedIndex;
           tempGameMode = cmbTrybGry.SelectedIndex;
           tempInitialMode = cmbUstawieniaIniMode.SelectedIndex;
 
           tempIniTime = txtWidzialnoscIni.Text;
           tempOdwTime = txtWidzialnoscOdw.Text;

           if(chkBoxSave.Checked)
            {
                tempCheckBox = true;
            }
            else
            {
                tempCheckBox = false;
            }
        }
        private void CheckIfDiff()
        {
            if(cmbPoziomTrudnosci.SelectedIndex != tempDiffLevel || cmbTrybGry.SelectedIndex != tempGameMode || cmbUstawieniaIniMode.SelectedIndex != tempInitialMode || txtWidzialnoscIni.Text != tempIniTime || txtWidzialnoscOdw.Text != tempOdwTime)
            {
                diffSettings = true;
            }
            else
            {
                if (chkBoxSave.Checked && tempCheckBox == true || chkBoxSave.Checked == false && tempCheckBox == false)
                {
                    diffSettings = false;
                }
                else
                {
                    diffSettings = true;
                }
            }
        }
        private void chkBoxSave_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBoxSave.Checked == true)
            {
                ifuserChecked = true;
            }
            else
            {
                ifuserChecked = false;
            }
        }
        private void chkBoxSave_MouseHover(object sender, EventArgs e)
        {
            AccSaveLabelToolTip.Show("Saves current setting on your account", chkBoxSave);
        }
        public void CheckCorrectData()
        {
            correctData = false;
            digitsOnly = false;

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
                    MessageBox.Show("Incorrect data!", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    correctData = true;
                }
            }
        }
        public void CheckBoxSave()
        {
            bool tempContains = false;

            if (chkBoxSave.Checked)
            {
                fileLines = File.ReadAllLines(filePath);
                foreach (string line in fileLines)
                {
                    if (line.Contains($"|{DataInput.CurrentNick}|"))
                    {
                        tempContains = true;
                    }
                }
                if(tempContains)
                {
                    lines.Clear();
                    foreach (string line in fileLines)
                    {
                        if (!line.Contains($"|{DataInput.CurrentNick}|"))
                        {
                            lines.Add(line);
                        }
                    }
                    lines.Add($"|{DataInput.CurrentNick}|" + $"|!{DiffLevel}!|" + $"|@{GameMode}@|" + $"|#{InitialMode}#|" + $"|%{OdwTime}%|" + $"|&{IniTime}&|");
                    File.WriteAllLines(filePath, lines);
                    lines.Clear();
                }
   /*             if (tempContains == true)
                {
                    foreach (string line in fileLines)
                    {
                        if (line.Contains($"|{DataInput.CurrentNick}|"))
                        {
                            line.Replace(line, $"|{DataInput.CurrentNick}|" + $"|!{DiffLevel}!|" + $"|@{GameMode}@|" + $"|#{InitialMode}#|" + $"|%{OdwTime}%|" + $"|&{IniTime}&|");
                            File.AppendAllLines(filePath, lines);
                            lines.Clear();
                        }
                    }
                }*/
                else
                {
                    lines.Add($"|{DataInput.CurrentNick}|" + $"|!{DiffLevel}!|" + $"|@{GameMode}@|" + $"|#{InitialMode}#|" + $"|%{OdwTime}%|" + $"|&{IniTime}&|");
                    File.AppendAllLines(filePath, lines);
                    lines.Clear();
                }
                //  fileLines = null;
                ifuserChecked = true;
            }
            else
            {
                List<string> linesList = File.ReadAllLines(filePath).ToList();
                foreach (string line in linesList)
                {
                    if (line.Contains($"|{DataInput.CurrentNick}|"))
                    {
                        linesList.Remove(line);
                        File.WriteAllLines(filePath, linesList.ToArray());
                        break;
                    }
                }
                ifuserChecked = false;
                linesList.Clear();
            }
        }
        private void LostAllFocus(object sender, EventArgs e)
        {
            this.lblUstawieniaUstawienia.Focus();
            Button obiekt = (Button)sender;
        }
        private void ButtonFocus()
        {
            this.btnPoziomTrudnosci.Click += LostAllFocus;
            this.btnTrybGry.Click += LostAllFocus;
            this.btnUstawieniaIniMode.Click += LostAllFocus;
            this.btnWidzialnoscIni.Click += LostAllFocus;
            this.btnWidzialnoscOdw.Click += LostAllFocus;
            this.btnUstReset.Click += LostAllFocus;

            justloaded = true;

        }      
        private void Ustawienia_Leave(object sender, EventArgs e)
        {
            Environment.Exit(0);
            Application.Exit();
        }
    }
}
