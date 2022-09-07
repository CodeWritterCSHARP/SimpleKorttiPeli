using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Blackjack
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            button1.Enabled = false;
            button2.Enabled = false;
            label1.Visible = false;
        }

        public List<Tuple<Color, int>> startpack = new List<Tuple<Color, int>>();
        public Color kortticolor;
        public int counter = 0;

        public bool start = true;

        public int playerpoints = 0; public int botpoints = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            Checking();

            ButtonsOff();

            AddingToPlayer();
            timer1.Start();

            Checking();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(start == true) {
                Regeneration();

                userControl11.panel1.BackColor = startpack[0].Item1;
                userControl11.textBox1.Text = startpack[0].Item2.ToString();

                button1.Enabled = true;
                button2.Enabled = true;

                start = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Checking();

            ButtonsOff();

            AddingToBot();
            timer1.Start();

            Checking();
        }

        public void AddingToPlayer()
        {
            this.flowLayoutPanel2.Controls.Add(new UserControl1());
            UserControl1 us = flowLayoutPanel2.Controls.OfType<UserControl1>().Last();
            us.textBox1.Text = startpack[counter].Item2.ToString();
            us.panel1.BackColor = startpack[counter].Item1;
            playerpoints += startpack[counter].Item2;
            Regeneration();
            counter++;
            userControl11.panel1.BackColor = startpack[counter].Item1;
            userControl11.textBox1.Text = startpack[counter].Item2.ToString();
            label2.Text = playerpoints.ToString(); label3.Text = botpoints.ToString();
        }

        public void AddingToBot()
        {
            this.flowLayoutPanel3.Controls.Add(new UserControl1());
            UserControl1 us = flowLayoutPanel3.Controls.OfType<UserControl1>().Last();
            us.textBox1.Text = startpack[counter].Item2.ToString();
            us.panel1.BackColor = startpack[counter].Item1;
            timer1.Start();
            botpoints += startpack[counter].Item2;
            Regeneration();
            counter++;
            userControl11.panel1.BackColor = startpack[counter].Item1;
            userControl11.textBox1.Text = startpack[counter].Item2.ToString();
            label2.Text = playerpoints.ToString(); label3.Text = botpoints.ToString();
        }

        public void Regeneration()
        {
            Random rand = new Random();
            int color = 0;
            color = rand.Next(1, 5);
            switch (color)
            {
                case 1: kortticolor = Color.Orange; break; //Hertta
                case 2: kortticolor = Color.Red; break; //Ruutu
                case 3: kortticolor = Color.Black; break; //Pata
                case 4: kortticolor = Color.DarkGray; break; //Risti
                default: break;
            }

            Kortti kortti = new Kortti(rand.Next(1,13), kortticolor);

            if (startpack.Count < 1)
            {
                startpack.Add(new Tuple<Color, int>(kortti.maa, kortti.arvo));
            }
            else
            {
                if (startpack.Contains(new Tuple<Color, int>(kortti.maa, kortti.arvo)))
                {
                    Regeneration();
                }
                else
                {
                    startpack.Add(new Tuple<Color, int>(kortti.maa, kortti.arvo));
                }
            }
        }

        void Checking()
        {
            if (botpoints > 21)
            {
                label1.Text = "Player Wins";
                label1.Visible = true;
            }

            if (playerpoints > 21)
            {
                label1.Text = "Bot Wins";
                label1.Visible = true;
            }
        }

        void ButtonsOff()
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (21 - playerpoints - startpack[counter].Item2 < 0 || botpoints + startpack[counter].Item2 > 21)
            {
                AddingToPlayer();
            }
            else AddingToBot();

            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;

            timer1.Stop();
        }
    }
}
