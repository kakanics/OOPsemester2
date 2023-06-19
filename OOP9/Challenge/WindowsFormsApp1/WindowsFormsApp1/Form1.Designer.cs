namespace WindowsFormsApp1
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtColor = new System.Windows.Forms.TextBox();
            this.btnNext = new System.Windows.Forms.Button();
            this.previous = new System.Windows.Forms.Button();
            this.txtColor2 = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.txtColor2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtColor, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnNext, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.previous, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(398, 188);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // txtColor
            // 
            this.txtColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtColor.Enabled = false;
            this.txtColor.Font = new System.Drawing.Font("Ubuntu", 30F);
            this.txtColor.Location = new System.Drawing.Point(3, 3);
            this.txtColor.Multiline = true;
            this.txtColor.Name = "txtColor";
            this.txtColor.Size = new System.Drawing.Size(193, 88);
            this.txtColor.TabIndex = 0;
            // 
            // btnNext
            // 
            this.btnNext.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNext.Font = new System.Drawing.Font("Ubuntu", 15F);
            this.btnNext.Location = new System.Drawing.Point(202, 97);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(193, 88);
            this.btnNext.TabIndex = 1;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // previous
            // 
            this.previous.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previous.Font = new System.Drawing.Font("Ubuntu", 15F);
            this.previous.Location = new System.Drawing.Point(3, 97);
            this.previous.Name = "previous";
            this.previous.Size = new System.Drawing.Size(193, 88);
            this.previous.TabIndex = 2;
            this.previous.Text = "Previous";
            this.previous.UseVisualStyleBackColor = true;
            this.previous.Click += new System.EventHandler(this.previous_Click);
            // 
            // txtColor2
            // 
            this.txtColor2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtColor2.Enabled = false;
            this.txtColor2.Font = new System.Drawing.Font("Ubuntu", 30F);
            this.txtColor2.Location = new System.Drawing.Point(202, 3);
            this.txtColor2.Multiline = true;
            this.txtColor2.Name = "txtColor2";
            this.txtColor2.Size = new System.Drawing.Size(193, 88);
            this.txtColor2.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 188);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox txtColor;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button previous;
        private System.Windows.Forms.TextBox txtColor2;
    }
}

