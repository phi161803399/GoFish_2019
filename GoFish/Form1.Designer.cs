namespace GoFish
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
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.lstHand = new System.Windows.Forms.ListBox();
            this.lblHand = new System.Windows.Forms.Label();
            this.txtProgress = new System.Windows.Forms.TextBox();
            this.txtBooks = new System.Windows.Forms.TextBox();
            this.btnAsk = new System.Windows.Forms.Button();
            this.lblGameProgress = new System.Windows.Forms.Label();
            this.lblBooks = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(41, 48);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(225, 20);
            this.txtName.TabIndex = 0;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(38, 24);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(58, 13);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Your name";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(292, 46);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(199, 23);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Start the game!";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lstHand
            // 
            this.lstHand.Enabled = false;
            this.lstHand.FormattingEnabled = true;
            this.lstHand.Location = new System.Drawing.Point(522, 46);
            this.lstHand.Name = "lstHand";
            this.lstHand.Size = new System.Drawing.Size(178, 680);
            this.lstHand.TabIndex = 3;
            // 
            // lblHand
            // 
            this.lblHand.AutoSize = true;
            this.lblHand.Location = new System.Drawing.Point(519, 24);
            this.lblHand.Name = "lblHand";
            this.lblHand.Size = new System.Drawing.Size(56, 13);
            this.lblHand.TabIndex = 4;
            this.lblHand.Text = "Your hand";
            // 
            // txtProgress
            // 
            this.txtProgress.Location = new System.Drawing.Point(41, 97);
            this.txtProgress.Multiline = true;
            this.txtProgress.Name = "txtProgress";
            this.txtProgress.ReadOnly = true;
            this.txtProgress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtProgress.Size = new System.Drawing.Size(450, 500);
            this.txtProgress.TabIndex = 5;
            // 
            // txtBooks
            // 
            this.txtBooks.Location = new System.Drawing.Point(41, 627);
            this.txtBooks.Multiline = true;
            this.txtBooks.Name = "txtBooks";
            this.txtBooks.ReadOnly = true;
            this.txtBooks.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBooks.Size = new System.Drawing.Size(450, 136);
            this.txtBooks.TabIndex = 6;
            // 
            // btnAsk
            // 
            this.btnAsk.Enabled = false;
            this.btnAsk.Location = new System.Drawing.Point(522, 740);
            this.btnAsk.Name = "btnAsk";
            this.btnAsk.Size = new System.Drawing.Size(178, 23);
            this.btnAsk.TabIndex = 7;
            this.btnAsk.Text = "Ask for a card";
            this.btnAsk.UseVisualStyleBackColor = true;
            this.btnAsk.Click += new System.EventHandler(this.btnAsk_Click);
            // 
            // lblGameProgress
            // 
            this.lblGameProgress.AutoSize = true;
            this.lblGameProgress.Location = new System.Drawing.Point(38, 81);
            this.lblGameProgress.Name = "lblGameProgress";
            this.lblGameProgress.Size = new System.Drawing.Size(79, 13);
            this.lblGameProgress.TabIndex = 8;
            this.lblGameProgress.Text = "Game Progress";
            // 
            // lblBooks
            // 
            this.lblBooks.AutoSize = true;
            this.lblBooks.Location = new System.Drawing.Point(38, 611);
            this.lblBooks.Name = "lblBooks";
            this.lblBooks.Size = new System.Drawing.Size(37, 13);
            this.lblBooks.TabIndex = 9;
            this.lblBooks.Text = "Books";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 818);
            this.Controls.Add(this.lblBooks);
            this.Controls.Add(this.lblGameProgress);
            this.Controls.Add(this.btnAsk);
            this.Controls.Add(this.txtBooks);
            this.Controls.Add(this.txtProgress);
            this.Controls.Add(this.lblHand);
            this.Controls.Add(this.lstHand);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Go Fish";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ListBox lstHand;
        private System.Windows.Forms.Label lblHand;
        private System.Windows.Forms.TextBox txtProgress;
        private System.Windows.Forms.TextBox txtBooks;
        private System.Windows.Forms.Button btnAsk;
        private System.Windows.Forms.Label lblGameProgress;
        private System.Windows.Forms.Label lblBooks;
    }
}

