namespace HáziKöltségNyilvántartó.Forms
{
    partial class LoginForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.usernameBox = new System.Windows.Forms.TextBox();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.belépés = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.regisztráció = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password";
            // 
            // usernameBox
            // 
            this.usernameBox.Location = new System.Drawing.Point(144, 65);
            this.usernameBox.Name = "usernameBox";
            this.usernameBox.Size = new System.Drawing.Size(160, 20);
            this.usernameBox.TabIndex = 2;
            // 
            // passwordBox
            // 
            this.passwordBox.Location = new System.Drawing.Point(144, 133);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.PasswordChar = '*';
            this.passwordBox.Size = new System.Drawing.Size(160, 20);
            this.passwordBox.TabIndex = 3;
            // 
            // belépés
            // 
            this.belépés.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.belépés.Location = new System.Drawing.Point(102, 227);
            this.belépés.Name = "belépés";
            this.belépés.Size = new System.Drawing.Size(75, 23);
            this.belépés.TabIndex = 4;
            this.belépés.Text = "Belépés";
            this.belépés.UseVisualStyleBackColor = true;
            // 
            // cancel
            // 
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Location = new System.Drawing.Point(330, 227);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 5;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            // 
            // regisztráció
            // 
            this.regisztráció.Location = new System.Drawing.Point(202, 227);
            this.regisztráció.Name = "regisztráció";
            this.regisztráció.Size = new System.Drawing.Size(102, 23);
            this.regisztráció.TabIndex = 6;
            this.regisztráció.Text = "Regisztráció";
            this.regisztráció.UseVisualStyleBackColor = true;
            this.regisztráció.Click += new System.EventHandler(this.regisztráció_Click);
            // 
            // LoginForm
            // 
            this.AcceptButton = this.belépés;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancel;
            this.ClientSize = new System.Drawing.Size(446, 279);
            this.Controls.Add(this.regisztráció);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.belépés);
            this.Controls.Add(this.passwordBox);
            this.Controls.Add(this.usernameBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoginForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox usernameBox;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.Button belépés;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button regisztráció;
    }
}