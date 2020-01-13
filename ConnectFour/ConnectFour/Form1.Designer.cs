namespace ConnectFour
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
            this.groupBoxPlayerNames = new System.Windows.Forms.GroupBox();
            this.labelWinsP2 = new System.Windows.Forms.Label();
            this.labelWinsP1 = new System.Windows.Forms.Label();
            this.circularButton2 = new ConnectFour.CircularButton();
            this.circularButton3 = new ConnectFour.CircularButton();
            this.circularButton1 = new ConnectFour.CircularButton();
            this.textBoxP2 = new System.Windows.Forms.TextBox();
            this.ExitButton = new System.Windows.Forms.Button();
            this.NewGameButton = new System.Windows.Forms.Button();
            this.textBoxP1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelPlayerTurn = new System.Windows.Forms.Label();
            this.circularButton5 = new ConnectFour.CircularButton();
            this.groupBoxPlayerNames.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxPlayerNames
            // 
            this.groupBoxPlayerNames.BackColor = System.Drawing.Color.Silver;
            this.groupBoxPlayerNames.Controls.Add(this.circularButton2);
            this.groupBoxPlayerNames.Controls.Add(this.circularButton1);
            this.groupBoxPlayerNames.Controls.Add(this.textBoxP2);
            this.groupBoxPlayerNames.Controls.Add(this.ExitButton);
            this.groupBoxPlayerNames.Controls.Add(this.NewGameButton);
            this.groupBoxPlayerNames.Controls.Add(this.textBoxP1);
            this.groupBoxPlayerNames.Controls.Add(this.label2);
            this.groupBoxPlayerNames.Controls.Add(this.label1);
            this.groupBoxPlayerNames.Location = new System.Drawing.Point(13, 13);
            this.groupBoxPlayerNames.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxPlayerNames.Name = "groupBoxPlayerNames";
            this.groupBoxPlayerNames.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxPlayerNames.Size = new System.Drawing.Size(770, 150);
            this.groupBoxPlayerNames.TabIndex = 1;
            this.groupBoxPlayerNames.TabStop = false;
            this.groupBoxPlayerNames.Text = "Connect Four Game";
            // 
            // labelWinsP2
            // 
            this.labelWinsP2.AutoSize = true;
            this.labelWinsP2.Location = new System.Drawing.Point(373, 181);
            this.labelWinsP2.Name = "labelWinsP2";
            this.labelWinsP2.Size = new System.Drawing.Size(17, 19);
            this.labelWinsP2.TabIndex = 2;
            this.labelWinsP2.Text = "0";
            // 
            // labelWinsP1
            // 
            this.labelWinsP1.AutoSize = true;
            this.labelWinsP1.Location = new System.Drawing.Point(278, 181);
            this.labelWinsP1.Name = "labelWinsP1";
            this.labelWinsP1.Size = new System.Drawing.Size(17, 19);
            this.labelWinsP1.TabIndex = 3;
            this.labelWinsP1.Text = "0";
            // 
            // circularButton2
            // 
            this.circularButton2.BackColor = System.Drawing.Color.Red;
            this.circularButton2.Enabled = false;
            this.circularButton2.FlatAppearance.BorderSize = 0;
            this.circularButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.circularButton2.Location = new System.Drawing.Point(7, 73);
            this.circularButton2.Name = "circularButton2";
            this.circularButton2.Size = new System.Drawing.Size(30, 30);
            this.circularButton2.TabIndex = 4;
            this.circularButton2.UseVisualStyleBackColor = false;
            // 
            // circularButton3
            // 
            this.circularButton3.BackColor = System.Drawing.Color.Blue;
            this.circularButton3.Enabled = false;
            this.circularButton3.FlatAppearance.BorderSize = 0;
            this.circularButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.circularButton3.Location = new System.Drawing.Point(242, 170);
            this.circularButton3.Name = "circularButton3";
            this.circularButton3.Size = new System.Drawing.Size(30, 30);
            this.circularButton3.TabIndex = 5;
            this.circularButton3.UseVisualStyleBackColor = false;
            // 
            // circularButton1
            // 
            this.circularButton1.BackColor = System.Drawing.Color.Blue;
            this.circularButton1.Enabled = false;
            this.circularButton1.FlatAppearance.BorderSize = 0;
            this.circularButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.circularButton1.Location = new System.Drawing.Point(7, 27);
            this.circularButton1.Name = "circularButton1";
            this.circularButton1.Size = new System.Drawing.Size(30, 30);
            this.circularButton1.TabIndex = 6;
            this.circularButton1.UseVisualStyleBackColor = false;
            // 
            // textBoxP2
            // 
            this.textBoxP2.Location = new System.Drawing.Point(150, 72);
            this.textBoxP2.Name = "textBoxP2";
            this.textBoxP2.Size = new System.Drawing.Size(600, 26);
            this.textBoxP2.TabIndex = 97;
            // 
            // ExitButton
            // 
            this.ExitButton.BackColor = System.Drawing.Color.Red;
            this.ExitButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitButton.ForeColor = System.Drawing.Color.White;
            this.ExitButton.Location = new System.Drawing.Point(601, 104);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(150, 40);
            this.ExitButton.TabIndex = 99;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = false;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // NewGameButton
            // 
            this.NewGameButton.BackColor = System.Drawing.Color.Green;
            this.NewGameButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewGameButton.ForeColor = System.Drawing.Color.White;
            this.NewGameButton.Location = new System.Drawing.Point(445, 104);
            this.NewGameButton.Name = "NewGameButton";
            this.NewGameButton.Size = new System.Drawing.Size(150, 40);
            this.NewGameButton.TabIndex = 98;
            this.NewGameButton.Text = "New Game";
            this.NewGameButton.UseVisualStyleBackColor = false;
            this.NewGameButton.Click += new System.EventHandler(this.NewGameButton_Click);
            // 
            // textBoxP1
            // 
            this.textBoxP1.Location = new System.Drawing.Point(150, 26);
            this.textBoxP1.Name = "textBoxP1";
            this.textBoxP1.Size = new System.Drawing.Size(600, 26);
            this.textBoxP1.TabIndex = 96;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(167, 181);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 19);
            this.label3.TabIndex = 11;
            this.label3.Text = "Wins:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 79);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 19);
            this.label2.TabIndex = 12;
            this.label2.Text = "Player 2 Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 19);
            this.label1.TabIndex = 13;
            this.label1.Text = "Player 1 Name:";
            // 
            // labelPlayerTurn
            // 
            this.labelPlayerTurn.AutoSize = true;
            this.labelPlayerTurn.Location = new System.Drawing.Point(167, 221);
            this.labelPlayerTurn.Name = "labelPlayerTurn";
            this.labelPlayerTurn.Size = new System.Drawing.Size(138, 19);
            this.labelPlayerTurn.TabIndex = 14;
            this.labelPlayerTurn.Text = "Player 1 is playing. . .";
            // 
            // circularButton5
            // 
            this.circularButton5.BackColor = System.Drawing.Color.Red;
            this.circularButton5.Enabled = false;
            this.circularButton5.FlatAppearance.BorderSize = 0;
            this.circularButton5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.circularButton5.Location = new System.Drawing.Point(337, 170);
            this.circularButton5.Name = "circularButton5";
            this.circularButton5.Size = new System.Drawing.Size(30, 30);
            this.circularButton5.TabIndex = 15;
            this.circularButton5.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 262);
            this.Controls.Add(this.labelWinsP2);
            this.Controls.Add(this.labelPlayerTurn);
            this.Controls.Add(this.circularButton5);
            this.Controls.Add(this.labelWinsP1);
            this.Controls.Add(this.groupBoxPlayerNames);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.circularButton3);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBoxPlayerNames.ResumeLayout(false);
            this.groupBoxPlayerNames.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBoxPlayerNames;

        private CircularButton circularButton1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxP1;

        private CircularButton circularButton2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxP2;

        private System.Windows.Forms.Button NewGameButton;
        private System.Windows.Forms.Button ExitButton;

        public System.Windows.Forms.Label labelPlayerTurn;

        private System.Windows.Forms.Label label3;

        private CircularButton circularButton3;

        public System.Windows.Forms.Label labelWinsP2;
        public System.Windows.Forms.Label labelWinsP1;

        private CircularButton circularButton5;
    }
}

