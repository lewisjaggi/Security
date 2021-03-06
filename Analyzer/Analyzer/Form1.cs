﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Analyzer
{
    public partial class Analyser : Form
    {
        public Analyser()
        {
            InitializeComponent();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            progressBar1.Value += random.Next(0,5);
            int idx =(int)Math.Round(progressBar1.Value/100.0*4);
            richTextBox1.AppendText(listText[idx]);
            if (progressBar1.Value > 95)
            {
                progressBar1.Value = 100;
                richTextBox1.AppendText("You account is safe now");
                timer1.Stop();
                if (MessageBox.Show("Your account is safe now", "facbook-secure", MessageBoxButtons.OK,MessageBoxIcon.Exclamation) == DialogResult.OK)
                {
                    Application.Exit();
                }

            }
            label1.Text = progressBar1.Value + "%";
            timer1.Interval=random.Next(0,2000);

        }


        private static Random random = new Random();
        private static List<String> listText = new List<string> {"Verifying Registry...\n","Scanning Cache...\n", "Checking Account Settings...\n","Cleaning useless files...\n", "Cleaning...\n" };

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Start Analyze", "facbook-secure", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
            {
                timer1.Start();
            }
            else
            {
                Application.Exit();
            }
        }


    }
}
