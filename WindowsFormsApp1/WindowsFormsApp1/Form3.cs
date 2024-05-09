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
    public partial class Form3 : Form
    {
        Image[] resimler =
       {
                Properties.Resources._1,
                Properties.Resources._2,
                Properties.Resources._3,
                Properties.Resources._4,
                Properties.Resources._5,
                Properties.Resources._6,
                Properties.Resources._7,
                Properties.Resources._8,

        };
        int[] indeksler = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7 };
        PictureBox ilkkutu;
        int ilkIndeks, bulunan, deneme,saniye=0,dakika=0,saat=0;
        
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            resimleriKaristir();

            
            timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Form2 yeniform = new Form2();
            yeniform.Show();
            
            
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (saniye == 10)
            {
                saniye = 0;
                dakika++;

            }
            if (dakika == 60)
            {
                dakika = 0;
                saniye = 0;
                saat++;
            }
            label1.Text = String.Format("{0:D2}", saat) + ":" + String.Format("{0:D2}", dakika) + ":" + String.Format("{0:D2}", saniye);
            saniye++;
             
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void resimleriKaristir()
        {
            Random rnd = new Random();
            for (int i = 0; i < 16; i++)
            {
                int sayi = rnd.Next(16);
                int gecici = indeksler[i];
                indeksler[i] = indeksler[sayi];
                indeksler[sayi] = gecici;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PictureBox kutu = (PictureBox)sender;
            int kutuNo = int.Parse(kutu.Name.Substring(10));
            int indeksNo = indeksler[kutuNo-1 ];
            kutu.Image = resimler[indeksNo];
            kutu.Refresh();

            if (ilkkutu == null)
            {
                ilkkutu = kutu;
                ilkIndeks = indeksNo;
                deneme++;
            }
            else
            {
                System.Threading.Thread.Sleep(1000);
                ilkkutu.Image = null;
                kutu.Image = null;
                if (ilkIndeks == indeksNo)
                {
                    bulunan++;
                    ilkkutu.Visible = false;
                    kutu.Visible = false;
                    if (bulunan == 8)
                    {
                        SoundPlayer ses = new SoundPlayer();
                        string dizin = Application.StartupPath + "\\sound1.wav";
                        ses.SoundLocation = dizin;
                        ses.Play();
                        MessageBox.Show("YOU ARE AN ASSASIN! \n NEVER FORGET \n-NOTHING IS TRUE EVERYTHING IS PERMITTED-");
                        
                        MessageBox.Show("Congratulations you finished the game on the " + deneme, " th try");
                        bulunan = 0;

                        deneme = 0;
                        foreach (Control kontrol in Controls)
                        {
                            kontrol.Visible = true;

                        }
                        resimleriKaristir();

                    }
                }
                ilkkutu = null;
            }
        }
    }
}
