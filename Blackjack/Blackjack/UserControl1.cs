using System;
using System.Drawing;
using System.Windows.Forms;

namespace Blackjack
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }

    public class Kortti
    {
        public int arvo;
        public Color maa;

        public Kortti(int _arvo, Color _maa)
        {
            this.arvo = _arvo;
            this.maa = _maa;
        }
    }
}
