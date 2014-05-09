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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Diyot diyotlar = new Diyot();
            diyotlar.ShowDialog();
        }

        private void btnDiyot_Uygulama_Click(object sender, EventArgs e)
        {
            Diyot_Uygulamalari diyotlar_uygulama = new Diyot_Uygulamalari();
            diyotlar_uygulama.ShowDialog();
        }

        static public void HataMesaji()
        {
            MessageBox.Show("Değerleri Kontrol Ediniz...", "Dikkat!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnOzel_Diyot_Click(object sender, EventArgs e)
        {
            OzelDiyotlar ozeldiyot = new OzelDiyotlar();
            ozeldiyot.ShowDialog();
        }

        private void btnTransistor_DC_Click(object sender, EventArgs e)
        {
            TransistorDCAnaliz dcanaliz = new TransistorDCAnaliz();
            dcanaliz.ShowDialog();
        }

        private void btnTransistor_AC_Click(object sender, EventArgs e)
        {
            transistorAcAnaliz analiz = new transistorAcAnaliz();
            analiz.ShowDialog();
        }
    }
}
