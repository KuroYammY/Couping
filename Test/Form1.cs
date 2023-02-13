using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using Couping;


namespace Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            levelLabel.Text = "Level: " + game1.gameLevel;
            
            //game1.StarProcess();
        }

        private void gl()
        {
            levelLabel.Text = "Level: " + game1.gameLevel.ToString();
        }
        private void endButton_Click(object sender, EventArgs e)
        {
            //game1.gameLevel = 1;
            //gl();
            //game1.EndProcess();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            //game1.gameLevel += 1;
            //gl();
            game1.StarProcess();
        }

        private void game1_Click(object sender, MouseEventArgs e)
        {
            game1.onMouseClick(e);
        }
    }
}