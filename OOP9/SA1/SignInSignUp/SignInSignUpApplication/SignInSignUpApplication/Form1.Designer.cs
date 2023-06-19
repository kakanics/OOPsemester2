namespace SignInSignUpApplication
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
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.cBoxSignIn = new System.Windows.Forms.CheckBox();
            this.btnNext = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Ubuntu", 20F);
            this.label1.Location = new System.Drawing.Point(186, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(428, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sign in/sign up application";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Font = new System.Drawing.Font("Ubuntu", 10F);
            this.checkBox1.Location = new System.Drawing.Point(233, 277);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(86, 25);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "SignUp";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // cBoxSignIn
            // 
            this.cBoxSignIn.AutoSize = true;
            this.cBoxSignIn.Font = new System.Drawing.Font("Ubuntu", 10F);
            this.cBoxSignIn.Location = new System.Drawing.Point(440, 277);
            this.cBoxSignIn.Name = "cBoxSignIn";
            this.cBoxSignIn.Size = new System.Drawing.Size(79, 25);
            this.cBoxSignIn.TabIndex = 2;
            this.cBoxSignIn.Text = "SignIn";
            this.cBoxSignIn.UseVisualStyleBackColor = true;
            this.cBoxSignIn.CheckedChanged += new System.EventHandler(this.cBoxSignIn_CheckedChanged);
            // 
            // btnNext
            // 
            this.btnNext.Font = new System.Drawing.Font("Ubuntu", 15F);
            this.btnNext.Location = new System.Drawing.Point(558, 361);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(135, 43);
            this.btnNext.TabIndex = 3;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.cBoxSignIn);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox cBoxSignIn;
        private System.Windows.Forms.Button btnNext;
    }
}

