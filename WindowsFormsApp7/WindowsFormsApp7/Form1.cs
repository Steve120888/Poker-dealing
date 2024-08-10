using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public PictureBox[] pb;
        private void Form1_Load(object sender, EventArgs e)
        {
            //產生一副牌
            string[] poker = new string[52];
            for (int i = 0; i < poker.Length; i++)
            {
                poker[i] = i.ToString();
            }
            //洗牌
            int t = 0;
            string tmp = "";
            Random r = new Random();
            for (int i = 0; i < poker.Length; i++)
            {
                t = r.Next(0, 52);
                tmp = poker[i];
                poker[i] = poker[t];
                poker[t] = tmp;
            }
            //發牌

            pb = new PictureBox[52];
            for (int i = 0; i < poker.Length; i++)
            {
                pb[i] = new PictureBox();
                pb[i].Image = Image.FromFile(@"../../../pic/g" + poker[i] + ".jpg");
                pb[i].SizeMode = PictureBoxSizeMode.AutoSize;
                int x = (pb[i].Width + 20) * (i % 13);
                int y = (pb[i].Height + 10) * (i / 13);
                pb[i].Location = new Point(x+110, y);
                this.Controls.Add(pb[i]);

            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            for(int i=0;i<52;i++)
            {
                this.Controls.Remove(pb[i]);
            }
            Form1_Load(sender, e);
        }
    }
}
