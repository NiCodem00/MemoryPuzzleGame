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
    public partial class DataInput : Form
    {
        public List<string> lines = new List<string>();

        public string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "users.txt");
        public string filePath2 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ranking.txt");
        public string filePath3 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "settings.txt");

        public string[] fileLines=null;

        private static string CurrentLogin = "";
        public static string CurrentNick { get { return CurrentLogin; } }            

        public DataInput()
        {        
            InitializeComponent();     
        }
        private void DataInput_Load(object sender, EventArgs e)
        {
            FileCheck();
            ButtonFocus();
            InitialEyeIconLoad();
        }

        public void btnRegister_Click(object sender, EventArgs e)
        {
            RegisterCheck();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoginCheck();
        }
        private void pbEyePass_Click(object sender, EventArgs e)
        {

            EyePBCheck();
           // object obj = Properties.Resources.ResourceManager.GetObject("10", new System.Globalization.CultureInfo("pl-PL"));      
           // pbEyePass.Image = obj as Image;
           // pbEyePass.Refresh();
        }
        private void btnDataExit_Click(object sender, EventArgs e)
        { 
            Application.Exit();
        }
        private void InitialEyeIconLoad() //Password eye icon switch
        {
            if (txtHaslo.PasswordChar == '*')
            {
                pbEyePass.Image = Properties.Resources.eyeClosed;
                pbEyePass.Refresh();
                pbEyePass.Visible = true;
            }
            else if (txtHaslo.PasswordChar == '\0')
            {
                pbEyePass.Image = Properties.Resources.eyeOpened;
                pbEyePass.Refresh();
                pbEyePass.Visible = true;
            }
        }
        public void RegisterCheck()
        {
            bool poprawne1 = false;
            bool poprawne2 = true;

            int counter;
            string Scounter;

            if (txtLogin.Text.Length >= 3 && txtLogin.Text.Length <= 12 && txtLogin.Text.All(char.IsLetterOrDigit) && txtHaslo.Text.Length >= 6 && txtHaslo.Text.Length <= 32 && txtHaslo.Text.Any(char.IsLetter) && txtHaslo.Text.Any(char.IsDigit))
            {
                poprawne1 = true;
            }
            else
            {
                MessageBox.Show("  Login must contain at least 2 characters \n  and may only be composed of letters and digits. \n  Password must be at least 5 characters long and \n  contain a digit and a letter.", "Incorrect data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }                      
            if (File.ReadAllBytes(filePath).Length == 0)
            {
                counter = 1;
            }
            else
            {
                Scounter = File.ReadLines(filePath).Last().Substring(0, 1);
                Int32.TryParse(Scounter, out counter);
                counter = counter + 1;
            }
            //    MessageBox.Show(counter.ToString(), "Info");

            if (poprawne1)
            {
                fileLines = File.ReadAllLines(filePath);

                foreach (string line in fileLines)
                {
                    if (line.EndsWith(" " + txtLogin.Text))
                    {
                        txtLogin.Text = "";
                        txtHaslo.Text = "";

                        MessageBox.Show("The user already exists.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        poprawne2 = false;
                    }
                }
            }
            if (poprawne1)
            {
                if (poprawne1 && poprawne2)
                {
                    lines.Add(counter.ToString() + ". " + txtHaslo.Text + " " + txtLogin.Text);
                    File.AppendAllLines(filePath, lines);
                    lines.Clear();

                    counter++;

                    txtLogin.Text = "";
                    txtHaslo.Text = "";

                    MessageBox.Show("      Registered     ", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                fileLines = null;
            }
        }
        public void LoginCheck()
        {
            CurrentLogin = "";
            bool poprawneLog = false;

            fileLines = File.ReadAllLines(filePath);

            foreach (string line in fileLines)
            {
                if (line.EndsWith(" " + txtHaslo.Text + " " + txtLogin.Text))
                {
                    poprawneLog = true;
                }
            }
            if (poprawneLog == true)
            {
                MessageBox.Show("   Login Successful   ", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CurrentLogin = txtLogin.Text;

                txtLogin.Text = "";
                txtHaslo.Text = "";

                Menu menu = new Menu();
                menu.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Incorrect login or password", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            fileLines = null;
        }
        public void EyePBCheck()
        {
            if (txtHaslo.PasswordChar == '*')
            {
                txtHaslo.PasswordChar = '\0';

                pbEyePass.Image = Properties.Resources.eyeOpened;
                pbEyePass.Refresh();
                pbEyePass.Visible = true;
            }
            else if (txtHaslo.PasswordChar == '\0')
            {
                txtHaslo.PasswordChar = '*';

                pbEyePass.Image = Properties.Resources.eyeClosed;
                pbEyePass.Refresh();
                pbEyePass.Visible = true;
            }
        }
        private void FileCheck()
        {
            if(!File.Exists(filePath))
            {
                File.Create(filePath);
            }
            if(!File.Exists(filePath2))
            {
                File.Create(filePath2);
            }
            if(!File.Exists(filePath3))
            {
                File.Create(filePath3);
            }
        }
        private void LostAllFocus(object sender, EventArgs e)
        {
            this.lblDataMemorki.Focus();
            Button obiekt = (Button)sender;
        }
        private void ButtonFocus()
        {
            this.btnLogin.Click += LostAllFocus;
            this.btnRegister.Click += LostAllFocus;
            this.btnDataExit.Click += LostAllFocus;
        }
        private void DataInput_Leave(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}