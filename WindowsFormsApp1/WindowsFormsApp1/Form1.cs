using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool islem = false;
        

        private void Form1_Load(object sender, EventArgs e)
        {
            SoundPlayer ses = new SoundPlayer();
            string dizin = Application.StartupPath + "\\Assassin's Creed Eagle Sound.wav";
            ses.SoundLocation = dizin;
            ses.Play();
            


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(!islem)
            {
                this.Opacity += 0.0077;

            }
            if(this.Opacity==1.0)
            {
                islem = true;
            }
            if(islem)
            {
                this.Opacity -= 0.0077;
                if(this.Opacity==0)
                {
                    Form2 gtr = new Form2();
                    gtr.Show();
                    
                    timer1.Enabled = false;
                    //this.Close();

                }
            }

        }
    }
}
