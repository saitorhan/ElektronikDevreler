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
    public partial class polarmali_kirpici_devreler : Form
    {
        public polarmali_kirpici_devreler()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double volt, diyot, sonuc;
                volt = Convert.ToDouble(txtvolt.Text);
                diyot = Convert.ToDouble(txtdiyot.Text);
                sonuc = volt + diyot;
                lblsonuc.Text = sonuc.ToString() + " Volt";
            }
            catch (Exception)
            {

                MessageBox.Show("Değerleri Kontrol Ediniz...", "Dikkat!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                double volt, diyot, sonuc;
                volt = Convert.ToDouble(txtNgtfVolt.Text);
                diyot = Convert.ToDouble(txtngtfDiyot.Text);
                sonuc = -(volt + diyot);
                lblngtfsonuc.Text = sonuc.ToString() + " Volt";
            }
            catch (Exception)
            {

                MessageBox.Show("Değerleri Kontrol Ediniz...", "Dikkat!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                double volt, diyot, sonuc;
                volt = Convert.ToDouble(txtpozitifsinirlayiciVa.Text);
                diyot = Convert.ToDouble(txtpozitifsinirlayicidiyot.Text);
                sonuc = volt - diyot;
                lblpozitifsinirlayicisonuc.Text = sonuc.ToString() + " Volt";
            }
            catch (Exception)
            {
                Form1.HataMesaji();

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                double volt, diyot, sonuc;
                volt = Convert.ToDouble(txtseriparalelvolt.Text);
                diyot = Convert.ToDouble(txtseriparaleldiyot.Text);
                sonuc = volt + diyot;
                lblseriparalelsonuc.Text = sonuc.ToString() + " Volt";
            }
            catch (Exception)
            {
                Form1.HataMesaji();

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                double volt, diyot, sonuc;
                volt = Convert.ToDouble(txtseriparalelva2.Text);
                diyot = Convert.ToDouble(txtseriparaleldiyot2.Text);
                sonuc = -volt - diyot;
                lblseriparalelsonuc2.Text = sonuc.ToString() + " Volt";
            }
            catch (Exception)
            {
                Form1.HataMesaji();


            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                double volt, diyot, sonuc;
                volt = Convert.ToDouble(txtseriparalelva3.Text);
                diyot = Convert.ToDouble(txtseriparaleldiyot3.Text);
                sonuc = volt - diyot;
                lblseriparalelsonuc3.Text = sonuc.ToString() + " Volt";
            }
            catch (Exception)
            {
                Form1.HataMesaji();


            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                double volt, diyot, sonuc;
                volt = Convert.ToDouble(txtseriparalelva4.Text);
                diyot = Convert.ToDouble(txtseriparaleldiyot4.Text);
                sonuc = -volt + diyot;
                lblseriparalelsonuc4.Text = sonuc.ToString() + " Volt";
            }
            catch (Exception)
            {
                Form1.HataMesaji();


            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
             try
            {
                double volt, diyot, sonuc;
                volt = Convert.ToDouble(txtnegatifsinirVa.Text);
                diyot = Convert.ToDouble(txtnegatifsinirdiyot.Text);
                sonuc = -volt + diyot;
                lblnegatifsinirsonuc.Text = sonuc.ToString() + " Volt";
            }
            catch (Exception)
            {
                Form1.HataMesaji();

            }
        }

        }
        
    }
