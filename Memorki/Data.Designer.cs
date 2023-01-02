namespace Memorki
{
    partial class DataInput
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataInput));
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.txtHaslo = new System.Windows.Forms.TextBox();
            this.lblLogin = new System.Windows.Forms.Label();
            this.lblHaslo = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lblDataMemorki = new System.Windows.Forms.Label();
            this.btnRegister = new System.Windows.Forms.Button();
            this.pbEyePass = new System.Windows.Forms.PictureBox();
            this.btnDataExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbEyePass)).BeginInit();
            this.SuspendLayout();
            // 
            // txtLogin
            // 
            this.txtLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtLogin.Location = new System.Drawing.Point(96, 130);
            this.txtLogin.MaxLength = 12;
            this.txtLogin.Multiline = true;
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(250, 23);
            this.txtLogin.TabIndex = 0;
            // 
            // txtHaslo
            // 
            this.txtHaslo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtHaslo.Location = new System.Drawing.Point(96, 179);
            this.txtHaslo.MaxLength = 32;
            this.txtHaslo.Name = "txtHaslo";
            this.txtHaslo.PasswordChar = '*';
            this.txtHaslo.Size = new System.Drawing.Size(250, 23);
            this.txtHaslo.TabIndex = 1;
            // 
            // lblLogin
            // 
            this.lblLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblLogin.AutoSize = true;
            this.lblLogin.BackColor = System.Drawing.Color.Transparent;
            this.lblLogin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblLogin.Location = new System.Drawing.Point(29, 132);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(53, 21);
            this.lblLogin.TabIndex = 3;
            this.lblLogin.Text = "Login";
            // 
            // lblHaslo
            // 
            this.lblHaslo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblHaslo.AutoSize = true;
            this.lblHaslo.BackColor = System.Drawing.Color.Transparent;
            this.lblHaslo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblHaslo.Location = new System.Drawing.Point(29, 177);
            this.lblHaslo.Name = "lblHaslo";
            this.lblHaslo.Size = new System.Drawing.Size(53, 21);
            this.lblHaslo.TabIndex = 4;
            this.lblHaslo.Text = "Haslo";
            // 
            // btnLogin
            // 
            this.btnLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLogin.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnLogin.Location = new System.Drawing.Point(121, 231);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(192, 51);
            this.btnLogin.TabIndex = 6;
            this.btnLogin.Text = "Log In";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // lblDataMemorki
            // 
            this.lblDataMemorki.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDataMemorki.AutoSize = true;
            this.lblDataMemorki.BackColor = System.Drawing.Color.Transparent;
            this.lblDataMemorki.Font = new System.Drawing.Font("Tempus Sans ITC", 36.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDataMemorki.Location = new System.Drawing.Point(111, 25);
            this.lblDataMemorki.Name = "lblDataMemorki";
            this.lblDataMemorki.Size = new System.Drawing.Size(212, 64);
            this.lblDataMemorki.TabIndex = 7;
            this.lblDataMemorki.Text = "Memory";
            // 
            // btnRegister
            // 
            this.btnRegister.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRegister.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnRegister.Location = new System.Drawing.Point(135, 288);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(112, 37);
            this.btnRegister.TabIndex = 8;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // pbEyePass
            // 
            this.pbEyePass.BackColor = System.Drawing.Color.Transparent;
            this.pbEyePass.Image = ((System.Drawing.Image)(resources.GetObject("pbEyePass.Image")));
            this.pbEyePass.Location = new System.Drawing.Point(352, 178);
            this.pbEyePass.Name = "pbEyePass";
            this.pbEyePass.Size = new System.Drawing.Size(25, 25);
            this.pbEyePass.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbEyePass.TabIndex = 10;
            this.pbEyePass.TabStop = false;
            this.pbEyePass.Click += new System.EventHandler(this.pbEyePass_Click);
            // 
            // btnDataExit
            // 
            this.btnDataExit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDataExit.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDataExit.Location = new System.Drawing.Point(253, 288);
            this.btnDataExit.Name = "btnDataExit";
            this.btnDataExit.Size = new System.Drawing.Size(47, 37);
            this.btnDataExit.TabIndex = 11;
            this.btnDataExit.Text = "Exit";
            this.btnDataExit.UseVisualStyleBackColor = true;
            this.btnDataExit.Click += new System.EventHandler(this.btnDataExit_Click);
            // 
            // DataInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(434, 354);
            this.Controls.Add(this.btnDataExit);
            this.Controls.Add(this.pbEyePass);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.lblDataMemorki);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.lblHaslo);
            this.Controls.Add(this.lblLogin);
            this.Controls.Add(this.txtHaslo);
            this.Controls.Add(this.txtLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "DataInput";
            this.Opacity = 0.97D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.DataInput_Load);
            this.Leave += new System.EventHandler(this.DataInput_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.pbEyePass)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txtLogin;
        private TextBox txtHaslo;
        private Label lblLogin;
        private Label lblHaslo;
        private Button btnLogin;
        private Label lblDataMemorki;
        private Button btnRegister;
        private PictureBox pbEyePass;
        private Button btnDataExit;
    }
}