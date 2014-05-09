using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Program
{
    public partial class OzelDiyotlar : Form
    {
        public OzelDiyotlar()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void buton_Click(object sender, EventArgs e)
        {
            double Vin, Vz, direnc, Izmax,Izmax2, It, Pd,direncmin,Ilmax,Izmin;
            try
            {
                Vin= Convert.ToDouble(txtzenerdiyotuyg1vin.Text);
                Izmin = Convert.ToDouble(txtIzmin.Text);
                Pd = Convert.ToDouble(txtzenerdiyotuyg1Pd.Text);
                direnc = 1000 * Convert.ToDouble(txtzenerdiyotuyg1R.Text);
                Vz = Convert.ToDouble(txtzenerdiyotuygVz.Text);

                    Izmax = Pd / Vz;
                    It = (Vin - Vz) / direnc;
                    Izmax2 = (Vin - Vz) / direnc;
                    Ilmax = 1000*Izmax2 - Izmin;
                    direncmin = Vz / Ilmax;
             
                lblzenerdiyotuyg1ızmax.Text =(1000*Izmax).ToString()+"mA" ;
                lblzenerdiyotuyg1Rl.Text = (1000*direncmin).ToString()+"Ohm" ;
                lblzenerdiyotuygIl.Text = Ilmax.ToString() ;
                lblzenerdiyotuygıt.Text = (1000*It).ToString()+"mA" ;
            }
            catch (Exception)
            {
                MessageBox.Show("Değerleri Kontrol Ediniz...", "Dikkat!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
             double Vinmin,Vinmax, Vz, direnc,Vrmin,Vrmax, Izmax, It, Pd,Izmin;
            try
            {
               
                Izmin = Convert.ToDouble(txtzenerdiyotuyg2izmin.Text);
                Pd = Convert.ToDouble(txtzenerdiyotuyg2Pd.Text);
                direnc = 1000 * Convert.ToDouble(Txtzenrdiyotuyg2R.Text);
                Vz = Convert.ToDouble(txtzenerdiyotuyg2vz.Text);

                    Izmax = Pd / Vz;
                    Vrmin=direnc*Izmin;
                Vinmin=Vrmin+Vz;
                Vrmax=direnc*Izmax;
                  Vinmax=Vrmax+Vz;
                    
             
                lblzenerdiyotuyg2ızmax.Text =(1000*Izmax).ToString()+"mA" ;
                lblzenerdiyotuyg2vrmin.Text = (Math.Pow(10,-3)*Vrmin).ToString()+"V" ;
                lblzenerdiyotuyg2vrmax.Text = Vrmax.ToString() + "Volt";
                lblzenerdiyotuyg2vinmin.Text = Vinmin.ToString()+"Volt" ;
                lblzenerdiyotuyg2vinmax.Text = Vinmax.ToString()+"Volt" ;
            }
            catch (Exception)
            {
                MessageBox.Show("Değerleri Kontrol Ediniz...", "Dikkat!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

      

    
    

    

       

     

        private void button2_Click(object sender, EventArgs e)
        {

            double vbe, vz, sonucust, sonucalt;
            vbe = Convert.ToDouble(txtpozifkırpıcıaltervbe.Text);
            vz = Convert.ToDouble(txtpozifkırpıcıaltervz.Text);
            if (vbe > 0)
            {
                sonucalt = -vbe;
                sonucust = vz;
                lblpozitifalternanssonuccalt.Text = sonucalt.ToString() + "Volt";
                lblpozitifalternanssonucustt.Text = sonucust.ToString() + "Volt";
            }
            else MessageBox.Show("hatali deger girdiniz");

           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            double vbe, vz, sonucust, sonucalt;
            vbe = Convert.ToDouble(txtnegatiffalternansvbe.Text);
            vz = Convert.ToDouble(txtnegatiffalternansvz.Text);
            if (vbe > 0)
            {
                sonucalt = -vz;
                sonucust = vbe;

                lblpozitifalternanssonuccaltttt.Text = sonucalt.ToString() + "Volt";
                lblnegatifalternanssonuccust.Text = sonucust.ToString() + "Volt";
            }
            else MessageBox.Show("hatali deger girdiniz");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            double vz1, vz2 ;
            vz1 = Convert.ToDouble(txtzenerdiyotkırpıcınepozvz1.Text);
            vz2 = Convert.ToDouble(txtzenerdiyotkırpıcınepozvz2.Text);
            if (vz2 > 0)
            {
                vz2 = -vz2;


                lblzenerdiyotkırpıcınepozvz1.Text = vz1.ToString() + "Volt";
                lblzenerdiyotkırpıcınepozvz2.Text = vz2.ToString() + "Volt";
            }
            else  MessageBox.Show("hatalideger girdiniz:");

        }

      

       
        }

      
        }

        
        

    

