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
    public partial class Diyot_Uygulamalari : Form
    {
        public Diyot_Uygulamalari()
        {
            InitializeComponent();
        }

        private void txtVolt_MouseDown(object sender, MouseEventArgs e)
        {
            txtVolt.Text = "";
        }

        private void txtDiyot_MouseDown(object sender, MouseEventArgs e)
        {
            txtDiyot.Text = "";
        }

        private void txtDirenc_MouseDown(object sender, MouseEventArgs e)
        {
            txtDirenc.Text = "";
        }

        void Degerleri_Hesapla()
        {
            double volt, diyot, direnc, akim_max, akim_ort, volt_ort;
            try
            {
                volt = Convert.ToDouble(txtVolt.Text);
                diyot = Convert.ToDouble(txtDiyot.Text);
                if (cmbDirencSecim.SelectedItem == "1000")
                direnc = 1000*Convert.ToDouble(txtDirenc.Text);
                else
                    direnc = Convert.ToDouble(txtDirenc.Text);
                if (diyot > 0 & direnc > 0)
                {
                    volt_ort = (volt - diyot) / Math.PI;
                    akim_ort = volt_ort / direnc;
                    akim_max = volt / direnc;
                    lblI_max.Text = akim_max.ToString() + " Max Akım";
                    lblI_Ort.Text = akim_ort.ToString() + " Max Volt";
                    lblV_Max.Text = (volt - diyot).ToString() + " Ort Volt";
                    lblV_Ort.Text = volt_ort.ToString() + " Ort Akım";
                }
                else MessageBox.Show("değerleri doğru giriniz");

            }
            catch (Exception)
            {
                MessageBox.Show("Değerleri Kontrol Ediniz...","Dikkat!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            Degerleri_Hesapla();
        }

        private void btnHesap_Click(object sender, EventArgs e)
        {
            Degerleri_Hesapla2();
        }

        private void Degerleri_Hesapla2()
        {
            double volt, diyot, direnc, akim_max,sarimsayisi1,sarimsayisi2, akim_ort, volt_ort;
            try
            {
                volt = Convert.ToDouble(txtVoltaj.Text);
                diyot = Convert.ToDouble(txtDiyots.Text);
                sarimsayisi1=Convert.ToDouble(txttamdalgasarimsayisi1.Text);
                sarimsayisi2=Convert.ToDouble(txttamdalgasarimsayisi2.Text);
                    direnc = 1000 * Convert.ToDouble(txtDirencs.Text);
               
                    direnc = Convert.ToDouble(txtDirencs.Text);
                    if (diyot > 0)
                    {
                        volt = volt * (sarimsayisi2 / sarimsayisi1);
                        volt_ort = (volt - diyot) * 2 / Math.PI;
                        akim_ort = volt_ort / direnc;
                        akim_max = volt / direnc;
                        lblMax_akim.Text = akim_max.ToString() + " Max Akım";
                        lblMax_Voltaj.Text = (volt - diyot).ToString() + " Max Volt";
                        lblOrt_Voltaj.Text = volt_ort.ToString() + " Ort Volt";
                        lblOrt_Akim.Text = akim_ort.ToString() + " Ort Akım";
                    }
                    else
                        MessageBox.Show("Degeleri doğru giriniz:");

            }
            catch (Exception)
            {
                MessageBox.Show("Değerleri Kontrol Ediniz...", "Dikkat!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnHesap_Click_1(object sender, EventArgs e)
        {
            Degerleri_Hesapla2();
        }

        private void txtFltrDirenc_MouseDown(object sender, MouseEventArgs e)
        {
            lblFltreDirencUyari.Text = "Direnci KOhm cinsinden giriniz...";
        }

        private void btnFltreHesapla_Click(object sender, EventArgs e)
        {
            double frekans, direnc, kapasitor, sarimsayisi1, sarimsayisi2, VP, Imax, Iort, Vdc, VMax, VR, RF, Vort, diyot;
            try
            {

                diyot = Convert.ToDouble(txtFltreDiyot.Text);
                frekans = Convert.ToDouble(txtFltrFrekans.Text);
                kapasitor = Convert.ToDouble(txtFltrKondansator.Text) * Math.Pow(10, (-6));
                VP = Convert.ToDouble(txtFltreVP.Text);
                direnc = Convert.ToDouble(txtFltrDirenc.Text) * 1000;
                sarimsayisi2 = Convert.ToDouble(txtfiltresarimsayisi2.Text);
                sarimsayisi1 = Convert.ToDouble(txtfiltresarimsayisi1.Text);
                if (diyot > 0 & direnc > 0 & kapasitor > 0)
                {
                    VP = VP * sarimsayisi2 / sarimsayisi1;

                    VMax = VP - 2 * diyot;
                    Vdc = 2 * VMax / Math.PI;
                    Imax = VMax / direnc;
                    Iort = 2 * Imax / Math.PI;
                    Vort = VMax - (VMax / (2 * frekans * direnc * kapasitor));
                    VR = VMax / (2 * Math.Sqrt(3) * frekans * direnc * kapasitor);
                    RF = (VR / Vort) * 100;
                    LBLfiltreeeVort.Text = "Vort=" + Vdc.ToString();
                    LBLfiltreeeVmax.Text = "Vmax=" + VMax.ToString();
                    LBLfiltreeeIort.Text = "Iort=" + (1000 * Iort).ToString() + "mA";
                    LBLfiltreeeImax.Text = "Imax=" + (1000 * Imax).ToString() + "mA";

                    lblFltreRF.Text = "=%" + RF.ToString();
                }
                else
                    MessageBox.Show("değerleri doğru giriniz:");

            }
            catch (Exception)
            {

                MessageBox.Show("Değerleri Kontrol Ediniz...", "Dikkat!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

       

        private void txtFltreVP_MouseDown(object sender, MouseEventArgs e)
        {
            lblFltreVPUyari.Text = "VP değeri giriniz.";
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void lblFltreDigerFiltre_Click(object sender, EventArgs e)
        {
            digerFiltreDevreleri diger = new digerFiltreDevreleri();
            diger.ShowDialog();
        }

        private void cmbSecilen_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbSecilen.SelectedItem == "Negatif Kırpıcı Devre")
            {
                pnl_pozitif_kirpici.Visible = false;
                pnl_negatif_kirpici.Visible = true;
            }
            if (cmbSecilen.SelectedItem == "Pozitif Kırpıcı Devre")
            {
                pnl_pozitif_kirpici.Visible = true;
                pnl_negatif_kirpici.Visible = false;
            }

            if (cmbSecilen.SelectedItem == "Polarmalı Kırpıcı Devre")
            {
                polarmali_kirpici_devreler devre2 = new polarmali_kirpici_devreler();
                devre2.ShowDialog();
            }
        }

        private void Diyot_Uygulamalari_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double diyot, Vt, sonucust, sonucorta, sonucalt;
                diyot = Convert.ToDouble(txtgerilimdiyot.Text);
                Vt = Convert.ToDouble(txtgerilimVolt.Text);
                sonucust = diyot;
                sonucorta = -Vt + diyot;
                sonucalt = -2 * Vt + diyot;
                lblgerilimsonucalt.Text = sonucalt.ToString();
                lblgerilimsonucorta.Text = sonucorta.ToString();
                lblgerilimsonucust.Text = sonucust.ToString();
            }
            catch (Exception)
            {
                Form1.HataMesaji();
            }
        }


        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void cmbGerilimSecilen_SelectedIndexChanged(object sender, EventArgs e)
        {
            string secilen = cmbGerilimSecilen.SelectedItem.ToString();
            if (secilen=="Negatif Kenetleyici Devre")
            {
                    pnlGerilimNegatif.Visible = true;
                    pnlGerilimPozitif.Visible = false;
                    pnlGerilimPolarma.Visible = false;
            }
            else if (secilen=="Pozitif Kenetleyici Devre")
	        {
		            pnlGerilimPozitif.Visible = true;
                    pnlGerilimNegatif.Visible = false;
                    pnlGerilimPolarma.Visible = false;
	        }
            else
            {
                pnlGerilimPozitif.Visible = false;
                pnlGerilimNegatif.Visible = false;
                pnlGerilimPolarma.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                double diyot, Vt, sonucust, sonucorta, sonucalt;
                diyot = Convert.ToDouble(txtgerilimpozitifdiyot.Text);
                Vt = Convert.ToDouble(txtgerilimpozitifVolt.Text);
                sonucust = 2 * Vt - diyot;
                sonucorta = Vt - diyot;
                sonucalt = -diyot;
                lblgerilimpozitifalt.Text = sonucalt.ToString();
                lblgerilimpozitiforta.Text = sonucorta.ToString();
                lblgerilimpozitifust.Text = sonucust.ToString();
            }
            catch (Exception)
            {
                Form1.HataMesaji();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                double va, vm, sonucalt, sonucust;
                va = Convert.ToDouble(txtgerilimpolarmaVa.Text);
                vm = Convert.ToDouble(txtgerilimpolarmavolt.Text);
                sonucalt = -2 * vm + va;
                sonucust = va;
                lblgerilimpolarmaalt.Text = sonucalt.ToString();
                lblgerilimpolarmaust.Text = sonucust.ToString();
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
                double vt, vd, sonucalt, sonucust;
                vt = Convert.ToDouble(txtkirpicidiyotlarvt.Text);
                vd = Convert.ToDouble(txtkirpicidiyotlarvd.Text);
                sonucalt = -vt;
                sonucust = vd;
                lblkırpıcıdevreelerpozitifsonucalt.Text = sonucalt.ToString() + "Volt";
                lblkırpıcıdevrelerpozitifsonucust.Text = sonucust.ToString()+"Volt";
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
                double vt, vd, sonucalt, sonucust;
                vt = Convert.ToDouble(txttkirpicinegatifvtt.Text);
                vd = Convert.ToDouble(txttkirpicinegatifvd.Text);
                sonucalt = -vd;
                sonucust = vt;
                lblkirpicidevrelersonucaltt.Text = sonucalt.ToString() + "Volt";
                lblkirpicidevrelersonucustt.Text = sonucust.ToString() + "Volt";
            }
            catch (Exception)
            {

                Form1.HataMesaji();
            }

        }

        
        }
        }

    

