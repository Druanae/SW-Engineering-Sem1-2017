namespace loginForm
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.login_L_lbl = new System.Windows.Forms.Label();
            this.userName_L_lbl = new System.Windows.Forms.Label();
            this.password_L_lbl = new System.Windows.Forms.Label();
            this.userName_L_tb = new System.Windows.Forms.TextBox();
            this.password_L_tb = new System.Windows.Forms.TextBox();
            this.Loginbx = new System.Windows.Forms.GroupBox();
            this.choiceBx = new System.Windows.Forms.GroupBox();
            this.prescriptionBtn = new System.Windows.Forms.Button();
            this.scheduleBtn = new System.Windows.Forms.Button();
            this.testResultsBtn = new System.Windows.Forms.Button();
            this.patientBtn = new System.Windows.Forms.Button();
            this.logOutBtn = new System.Windows.Forms.Button();
            this.Loginbx.SuspendLayout();
            this.choiceBx.SuspendLayout();
            this.SuspendLayout();
            // 
            // login_L_lbl
            // 
            this.login_L_lbl.AutoSize = true;
            this.login_L_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.login_L_lbl.Location = new System.Drawing.Point(211, 28);
            this.login_L_lbl.Name = "login_L_lbl";
            this.login_L_lbl.Size = new System.Drawing.Size(65, 26);
            this.login_L_lbl.TabIndex = 0;
            this.login_L_lbl.Text = "Login";
            this.login_L_lbl.Click += new System.EventHandler(this.login_L_lbl_Click);
            // 
            // userName_L_lbl
            // 
            this.userName_L_lbl.AutoSize = true;
            this.userName_L_lbl.Location = new System.Drawing.Point(80, 120);
            this.userName_L_lbl.Name = "userName_L_lbl";
            this.userName_L_lbl.Size = new System.Drawing.Size(60, 13);
            this.userName_L_lbl.TabIndex = 1;
            this.userName_L_lbl.Text = "User Name";
            // 
            // password_L_lbl
            // 
            this.password_L_lbl.AutoSize = true;
            this.password_L_lbl.Location = new System.Drawing.Point(80, 186);
            this.password_L_lbl.Name = "password_L_lbl";
            this.password_L_lbl.Size = new System.Drawing.Size(53, 13);
            this.password_L_lbl.TabIndex = 2;
            this.password_L_lbl.Text = "Password";
            // 
            // userName_L_tb
            // 
            this.userName_L_tb.Location = new System.Drawing.Point(162, 117);
            this.userName_L_tb.Name = "userName_L_tb";
            this.userName_L_tb.Size = new System.Drawing.Size(213, 20);
            this.userName_L_tb.TabIndex = 3;
            this.userName_L_tb.TextChanged += new System.EventHandler(this.userName_L_tb_TextChanged);
            // 
            // password_L_tb
            // 
            this.password_L_tb.Location = new System.Drawing.Point(162, 183);
            this.password_L_tb.Name = "password_L_tb";
            this.password_L_tb.Size = new System.Drawing.Size(213, 20);
            this.password_L_tb.TabIndex = 4;
            this.password_L_tb.TextChanged += new System.EventHandler(this.password_L_tb_TextChanged);
            // 
            // Loginbx
            // 
            this.Loginbx.Controls.Add(this.login_L_lbl);
            this.Loginbx.Controls.Add(this.password_L_tb);
            this.Loginbx.Controls.Add(this.userName_L_lbl);
            this.Loginbx.Controls.Add(this.userName_L_tb);
            this.Loginbx.Controls.Add(this.password_L_lbl);
            this.Loginbx.Location = new System.Drawing.Point(28, 60);
            this.Loginbx.Name = "Loginbx";
            this.Loginbx.Size = new System.Drawing.Size(475, 249);
            this.Loginbx.TabIndex = 5;
            this.Loginbx.TabStop = false;
            this.Loginbx.Text = "Login Box";
            this.Loginbx.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // choiceBx
            // 
            this.choiceBx.Controls.Add(this.logOutBtn);
            this.choiceBx.Controls.Add(this.prescriptionBtn);
            this.choiceBx.Controls.Add(this.scheduleBtn);
            this.choiceBx.Controls.Add(this.testResultsBtn);
            this.choiceBx.Controls.Add(this.patientBtn);
            this.choiceBx.Location = new System.Drawing.Point(556, 60);
            this.choiceBx.Name = "choiceBx";
            this.choiceBx.Size = new System.Drawing.Size(423, 249);
            this.choiceBx.TabIndex = 6;
            this.choiceBx.TabStop = false;
            this.choiceBx.Text = "Choice Box";
            // 
            // prescriptionBtn
            // 
            this.prescriptionBtn.Location = new System.Drawing.Point(206, 160);
            this.prescriptionBtn.Name = "prescriptionBtn";
            this.prescriptionBtn.Size = new System.Drawing.Size(113, 50);
            this.prescriptionBtn.TabIndex = 13;
            this.prescriptionBtn.Text = "Prescriptions";
            this.prescriptionBtn.UseVisualStyleBackColor = true;
            // 
            // scheduleBtn
            // 
            this.scheduleBtn.Location = new System.Drawing.Point(26, 160);
            this.scheduleBtn.Name = "scheduleBtn";
            this.scheduleBtn.Size = new System.Drawing.Size(113, 50);
            this.scheduleBtn.TabIndex = 12;
            this.scheduleBtn.Text = "Schedule";
            this.scheduleBtn.UseVisualStyleBackColor = true;
            // 
            // testResultsBtn
            // 
            this.testResultsBtn.Location = new System.Drawing.Point(206, 39);
            this.testResultsBtn.Name = "testResultsBtn";
            this.testResultsBtn.Size = new System.Drawing.Size(113, 50);
            this.testResultsBtn.TabIndex = 11;
            this.testResultsBtn.Text = "Test Results";
            this.testResultsBtn.UseVisualStyleBackColor = true;
            // 
            // patientBtn
            // 
            this.patientBtn.Location = new System.Drawing.Point(26, 39);
            this.patientBtn.Name = "patientBtn";
            this.patientBtn.Size = new System.Drawing.Size(113, 50);
            this.patientBtn.TabIndex = 10;
            this.patientBtn.Text = "Patient";
            this.patientBtn.UseVisualStyleBackColor = true;
            // 
            // logOutBtn
            // 
            this.logOutBtn.Location = new System.Drawing.Point(352, 19);
            this.logOutBtn.Name = "logOutBtn";
            this.logOutBtn.Size = new System.Drawing.Size(65, 29);
            this.logOutBtn.TabIndex = 14;
            this.logOutBtn.Text = "Log Out";
            this.logOutBtn.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1061, 374);
            this.Controls.Add(this.choiceBx);
            this.Controls.Add(this.Loginbx);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Loginbx.ResumeLayout(false);
            this.Loginbx.PerformLayout();
            this.choiceBx.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label login_L_lbl;
        private System.Windows.Forms.Label userName_L_lbl;
        private System.Windows.Forms.Label password_L_lbl;
        private System.Windows.Forms.TextBox userName_L_tb;
        private System.Windows.Forms.TextBox password_L_tb;
        private System.Windows.Forms.GroupBox Loginbx;
        private System.Windows.Forms.GroupBox choiceBx;
        private System.Windows.Forms.Button prescriptionBtn;
        private System.Windows.Forms.Button scheduleBtn;
        private System.Windows.Forms.Button testResultsBtn;
        private System.Windows.Forms.Button patientBtn;
        private System.Windows.Forms.Button logOutBtn;
    }
}

