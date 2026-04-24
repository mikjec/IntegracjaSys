namespace JWTClient
{
    partial class Form1
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
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            txtToken = new TextBox();
            btnLogin = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            btnGetCount = new Button();
            btnGetPrime = new Button();
            btnGethuj = new Button();
            txtResult = new RichTextBox();
            SuspendLayout();
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(59, 52);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(120, 26);
            txtUsername.TabIndex = 0;
            txtUsername.TextChanged += textBox1_TextChanged;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(59, 116);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(120, 26);
            txtPassword.TabIndex = 1;
            // 
            // txtToken
            // 
            txtToken.Location = new Point(59, 310);
            txtToken.Multiline = true;
            txtToken.Name = "txtToken";
            txtToken.ReadOnly = true;
            txtToken.Size = new Size(366, 220);
            txtToken.TabIndex = 2;
            txtToken.TextChanged += textBox3_TextChanged;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(72, 166);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(90, 28);
            btnLogin.TabIndex = 3;
            btnLogin.Text = "Zaloguj";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(67, 29);
            label1.Name = "label1";
            label1.Size = new Size(75, 20);
            label1.TabIndex = 4;
            label1.Text = "Username";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(72, 93);
            label2.Name = "label2";
            label2.Size = new Size(70, 20);
            label2.TabIndex = 5;
            label2.Text = "Password";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(225, 30);
            label3.Name = "label3";
            label3.Size = new Size(130, 20);
            label3.TabIndex = 6;
            label3.Text = "Get Users Counter:";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(225, 93);
            label4.Name = "label4";
            label4.Size = new Size(138, 20);
            label4.TabIndex = 7;
            label4.Text = "Get Magic Number:";
            label4.Click += label4_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(225, 166);
            label5.Name = "label5";
            label5.Size = new Size(74, 20);
            label5.TabIndex = 8;
            label5.Text = "Get Users:";
            label5.Click += label5_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(90, 278);
            label6.Name = "label6";
            label6.Size = new Size(36, 20);
            label6.TabIndex = 9;
            label6.Text = "JWT";
            // 
            // btnGetCount
            // 
            btnGetCount.Location = new Point(403, 25);
            btnGetCount.Name = "btnGetCount";
            btnGetCount.Size = new Size(90, 28);
            btnGetCount.TabIndex = 10;
            btnGetCount.Text = "send";
            btnGetCount.UseVisualStyleBackColor = true;
            btnGetCount.Click += button1_Click_1;
            // 
            // btnGetPrime
            // 
            btnGetPrime.Location = new Point(403, 88);
            btnGetPrime.Name = "btnGetPrime";
            btnGetPrime.Size = new Size(90, 28);
            btnGetPrime.TabIndex = 11;
            btnGetPrime.Text = "send";
            btnGetPrime.UseVisualStyleBackColor = true;
            btnGetPrime.Click += button1_Click_2;
            // 
            // btnGethuj
            // 
            btnGethuj.Location = new Point(403, 158);
            btnGethuj.Name = "btnGethuj";
            btnGethuj.Size = new Size(90, 28);
            btnGethuj.TabIndex = 12;
            btnGethuj.Text = "send";
            btnGethuj.UseVisualStyleBackColor = true;
            btnGethuj.Click += btnGethuj_Click;
            // 
            // txtResult
            // 
            txtResult.Location = new Point(531, 25);
            txtResult.Name = "txtResult";
            txtResult.Size = new Size(371, 505);
            txtResult.TabIndex = 13;
            txtResult.Text = "";
            txtResult.TextChanged += richTextBox1_TextChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(929, 568);
            Controls.Add(txtResult);
            Controls.Add(btnGethuj);
            Controls.Add(btnGetPrime);
            Controls.Add(btnGetCount);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnLogin);
            Controls.Add(txtToken);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtUsername;
        private TextBox txtPassword;
        private TextBox txtToken;
        private Button btnLogin;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Button btnGetCount;
        private Button btnGetPrime;
        private Button btnGethuj;
        private RichTextBox txtResult;
    }
}
