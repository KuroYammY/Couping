
namespace Test
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
            this.startButton = new System.Windows.Forms.Button();
            this.endButton = new System.Windows.Forms.Button();
            this.levelLabel = new System.Windows.Forms.Label();
            this.game1 = new Couping.Game();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(55, 403);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 1;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // endButton
            // 
            this.endButton.Location = new System.Drawing.Point(55, 444);
            this.endButton.Name = "endButton";
            this.endButton.Size = new System.Drawing.Size(75, 23);
            this.endButton.TabIndex = 4;
            this.endButton.Text = "End";
            this.endButton.UseVisualStyleBackColor = true;
            this.endButton.Click += new System.EventHandler(this.endButton_Click);
            // 
            // levelLabel
            // 
            this.levelLabel.AutoSize = true;
            this.levelLabel.Location = new System.Drawing.Point(62, 376);
            this.levelLabel.Name = "levelLabel";
            this.levelLabel.Size = new System.Drawing.Size(39, 13);
            this.levelLabel.TabIndex = 5;
            this.levelLabel.Text = "Level: ";
            // 
            // game1
            // 
            this.game1.gameLevel = 2;
            this.game1.iSize = 120;
            this.game1.Location = new System.Drawing.Point(12, 12);
            this.game1.Name = "game1";
            this.game1.Size = new System.Drawing.Size(890, 361);
            this.game1.TabIndex = 0;
            this.game1.Text = "game1";
            this.game1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.game1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1189, 664);
            this.Controls.Add(this.levelLabel);
            this.Controls.Add(this.endButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.game1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.Button startButton;
        private Couping.Game game1;
        private System.Windows.Forms.Button endButton;
        private System.Windows.Forms.Label levelLabel;
    }
}

