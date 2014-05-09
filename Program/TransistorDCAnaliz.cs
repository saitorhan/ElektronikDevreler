using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ZedGraph;

namespace Program
{
    public partial class TransistorDCAnaliz : Form
    {
        public TransistorDCAnaliz()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double Ib, Ie, Ic, Rc, Rb, Re, Vcc, Vce, Imax, beta;
            try
            {
                
                Rc = Convert.ToDouble(txtemiterdirencRC.Text)*1000;
                Rb = Convert.ToDouble(txtemiterdirencRB.Text)*1000;
                Re = Convert.ToDouble(txtemiterdirencRe.Text)*1000;
                Vcc = Convert.ToDouble(txtemiterdirencVcc.Text);
                Imax = Vcc / (Rc + Re);
                Imax = Imax * 1000;
                beta = Convert.ToDouble(txtemiterdirencBeta.Text);
                double Vbe;
                Vbe = Convert.ToDouble(txtemiterdirencVbe.Text);
                if (Rc > 0 & Rb > 0 & Re >0  )
                {
                    Ib = ((Vcc - Vbe) / (Rb + (beta + 1) * Re)) * Math.Pow(10, 6);
                    Ic = beta * Ib * Math.Pow(10, -3);
                    Ie = (beta + 1) * Ib * Math.Pow(10, -3);
                    Vce = Vcc - Ic * Rc * Math.Pow(10, -3) - Ie * Re * Math.Pow(10, -3);

                    lblemiterdirencIb.Text = " = " + Math.Round(Ib, 3);

                    lblemiterdirencIc.Text = " = " + Math.Round(Ic, 3) + "mA";
                    lblemiterdirencIe.Text = " = " + Math.Round(Ie, 3) + "mA";
                    lblemiterdirencImax.Text = " = " + Imax.ToString() + "mA";
                    lblemiterdirencVce.Text = " = " + Math.Round(Vce, 3) + "Volt";
                    btnEmiterDireclYukEgrisi.Enabled = true;
                }
                else
                    MessageBox.Show("Direnc Degerlerini yanlış girdiniz:");

            }
            catch (Exception)
            {

                Form1.HataMesaji();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
                double Ib, Ie, Ic, Rc, Rb, Re, Vcc, Vce, Imax, beta;
                Rc = Convert.ToDouble(txtemiterdirencRC.Text)*1000;
                Rb = Convert.ToDouble(txtemiterdirencRB.Text)*1000;
                Re = Convert.ToDouble(txtemiterdirencRe.Text)*1000;
                Vcc = Convert.ToDouble(txtemiterdirencVcc.Text);
                Imax = Vcc / (Rc + Re);
                beta = Convert.ToDouble(txtemiterdirencBeta.Text);
                double Vbe;
                Vbe = Convert.ToDouble(txtemiterdirencVbe.Text);
                Ib = ((Vcc - Vbe) / (Rb + (beta + 1) * Re));
                Ic = beta * Ib;
                Ie = (beta + 1) * Ib;
                Vce = Vcc - Ic * Rc - Ie * Re;
                Imax = 1000 * Imax;
                Ic = 1000 * Ic;
                ZedGraph.ZedGraphControl g = new ZedGraph.ZedGraphControl();
                g.Size = new Size(panel1.Width - 2, panel1.Height - 2);
                ZedGraph.GraphPane myGraphPane = g.GraphPane;
                myGraphPane.Title.Text = "Dc yük eğrisi ";
                myGraphPane.XAxis.Title.Text = "Volt (V)";
                myGraphPane.YAxis.Title.Text = "Akım(ma)";
                PointPairList list1 = new PointPairList();
                myGraphPane.AddCurve("", new double[] { 0, Vcc }, new double[] { Imax, 0 }, Color.Blue, ZedGraph.SymbolType.None);
                myGraphPane.AddCurve("", new double[] { 0, Vce }, new double[] { Ic, Ic }, Color.Blue, ZedGraph.SymbolType.None);
                myGraphPane.AddCurve("", new double[] { Vce, Vce }, new double[] { Ic, 0 }, Color.Blue, ZedGraph.SymbolType.None);

                myGraphPane.Chart.Fill = new ZedGraph.Fill(Color.White, Color.Red, 3.0f);

                g.AxisChange();

                panel1.Controls.Add(g);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            double Ib,  Ic, Rc, Rb, Vcc, Vce,Vbe, Imax, beta;
            try
            {
                Rc =Convert.ToDouble(txtbeyzrc.Text) * 1000;
                Rb = Convert.ToDouble(txtbeyzrb.Text) * 1000;
              
                Vcc = Convert.ToDouble(txtbeyzvcc.Text);
                Imax = (1000 * Vcc) / Rc;
                beta = Convert.ToDouble(txtbeyzbeta.Text);
                
                Vbe = Convert.ToDouble(txtbeyzvbe.Text);
                if (Rc > 0 & Rb > 0)
                {
                    Ib = ((Vcc - Vbe) / Rb) * Math.Pow(10, 6);
                    Ic = beta * Ib * Math.Pow(10, -3);

                    Vce = Vcc - Ic * Rc * Math.Pow(10, -3);
                    lblbeyzib.Text = " = " + Ib.ToString();
                    lblbeyzıc.Text = " = " + Ic.ToString();
                    lblbeyzımax.Text = " = " + Imax.ToString();
                    lblbeyzvce.Text = " = " + Vce.ToString();
                }
                else MessageBox.Show("Direnc Degerlerini yanlış girdiniz:");
                
               
            }
            catch (Exception)
            {

                Form1.HataMesaji();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
             double Ib,  Ic, Rc, Rb, Vcc, Vce,Vbe, Imax, beta;
           
                Rc =Convert.ToDouble(txtbeyzrc.Text) * 1000;
                Rb = Convert.ToDouble(txtbeyzrb.Text) * 1000;
              
                Vcc = Convert.ToDouble(txtbeyzvcc.Text);
                Imax = (1000*Vcc) / Rc ;
                beta = Convert.ToDouble(txtbeyzbeta.Text);
                
                Vbe = Convert.ToDouble(txtbeyzvbe.Text);
                Ib = ((Vcc - Vbe) / Rb)  * Math.Pow(10, 6);
                Ic = beta * Ib * Math.Pow(10, -3);

                Vce = Vcc - Ic * Rc * Math.Pow(10, -3);
                lblbeyzib.Text = " = " + Ib.ToString();
                lblbeyzıc.Text= " = " + Ic.ToString();
                lblbeyzımax.Text = " = " + Imax.ToString();
                lblbeyzvce.Text = " = " + Vce.ToString();
                ZedGraph.ZedGraphControl g = new ZedGraph.ZedGraphControl();
                g.Size = new Size(panel2.Width - 2, panel2.Height - 2);
                ZedGraph.GraphPane myGraphPane = g.GraphPane;
                myGraphPane.Title.Text = "Dc yük eğrisi ";
                myGraphPane.XAxis.Title.Text = "Volt (V)";
                myGraphPane.YAxis.Title.Text = "Akım(ma)";
                PointPairList list1 = new PointPairList();
                myGraphPane.AddCurve("", new double[] { 0, Vcc }, new double[] { Imax, 0 }, Color.Blue, ZedGraph.SymbolType.None);
                myGraphPane.AddCurve("", new double[] { 0, Vce }, new double[] { Ic, Ic }, Color.Blue, ZedGraph.SymbolType.None);
                myGraphPane.AddCurve("", new double[] { Vce, Vce }, new double[] { Ic, 0 }, Color.Blue, ZedGraph.SymbolType.None);

                myGraphPane.Chart.Fill = new ZedGraph.Fill(Color.White, Color.Red, 3.0f);

                g.AxisChange();

                panel2.Controls.Add(g);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            double Ie, Ic, Rc,Re, Rb, Vcc, Vce, Vbe, Imax, Vee,vc,vmax;
            try
            {
                Rc = Convert.ToDouble(txtemiterpolarmarc.Text) * 1000;
                Rb = Convert.ToDouble(txtemiterpolarmarb.Text) * 1000;
                Re = Convert.ToDouble(txtemiterpolarmare.Text) * 1000;
                Vcc = Convert.ToDouble(txtemiterpolarmavcc.Text);
                Imax = (1000 * Vcc) / Rc;
                Vee = Convert.ToDouble(txtemiterpolarmavee.Text);

                Vbe = Convert.ToDouble(txtemiterpolarmavbe.Text);
                if (Rc > 0 & Rb > 0 & Re > 0)
                {
                    Ie = -1000 * (Vee + Vbe) / Re;
                    vc = Vcc - (Math.Pow(10, -3) * Ie * Rc);
                    Vce = vc + Vbe;
                    Imax = 1000 * (Vcc - Vee) / (Rc + Re);
                    vmax = Vcc - Vee;



                    lblemiterIe.Text = " = " + Ie.ToString();
                    lblemiterIc.Text = " = " + Ie.ToString();
                    lblemitervc.Text = " = " + vc.ToString();
                    lblemitervce.Text = " = " + Vce.ToString();
                    lblemiterVmax.Text = vmax.ToString();
                    lblemiterımax.Text = Imax.ToString();
                }
                else MessageBox.Show("Direnc Degerlerini yanlış girdiniz:");

            }
            catch (Exception)
            {

                Form1.HataMesaji();
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            double Ie, Ic, Rc,Re, Rb, Vcc, Vce, Vbe, Imax, Vee,vc,vmax;
            
                Rc = Convert.ToDouble(txtemiterpolarmarc.Text) * 1000;
                Rb = Convert.ToDouble(txtemiterpolarmarb.Text) * 1000;
                Re = Convert.ToDouble(txtemiterpolarmare.Text) * 1000;
                Vcc = Convert.ToDouble(txtemiterpolarmavcc.Text);
                Imax = (1000 * Vcc) / Rc;
                Vee = Convert.ToDouble(txtemiterpolarmavee.Text);

                Vbe = Convert.ToDouble(txtemiterpolarmavbe.Text);
                Ie = -1000*(Vee + Vbe) / Re;
                vc = Vcc - (Math.Pow(10,-3)*Ie * Rc);
                Vce = vc + Vbe;
                Imax = 1000*(Vcc-Vee) /( Rc+Re);
                vmax = Vcc - Vee;
                ZedGraph.ZedGraphControl g = new ZedGraph.ZedGraphControl();
                g.Size = new Size(panel3.Width - 2, panel3.Height - 2);
                ZedGraph.GraphPane myGraphPane = g.GraphPane;
                myGraphPane.Title.Text = "Dc yük eğrisi ";
                myGraphPane.XAxis.Title.Text = "Volt (V)";
                myGraphPane.YAxis.Title.Text = "Akım(ma)";
                PointPairList list1 = new PointPairList();
                myGraphPane.AddCurve("", new double[] { 0, vmax}, new double[] { Imax, 0 }, Color.Blue, ZedGraph.SymbolType.None);
                myGraphPane.AddCurve("", new double[] { 0, Vce }, new double[] { Ie, Ie }, Color.Blue, ZedGraph.SymbolType.None);
                myGraphPane.AddCurve("", new double[] { Vce, Vce }, new double[] { Ie, 0 }, Color.Blue, ZedGraph.SymbolType.None);

                myGraphPane.Chart.Fill = new ZedGraph.Fill(Color.White, Color.Red, 3.0f);

                g.AxisChange();

                panel3.Controls.Add(g);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            double Ie, Ic,Ib,Vth,Rth, Rc, Re,  Vcc, Vce, Vbe, Imax, vmax,beta,R1,R2;
            try
            {
                Rc = Convert.ToDouble(txtgerilimbölücüpolarmarc.Text) * 1000;
                R1 = Convert.ToDouble(txtgerilimbölücüpolarmaR1.Text) * 1000;
                R2 = Convert.ToDouble(txtgerilimbölücüpolarmaR2.Text) * 1000;
                Re = Convert.ToDouble(txtgerilimbölücüpolarmare.Text) * 1000;
                Vcc = Convert.ToDouble(txtgerilimbölücüpolarmavcc.Text);
                beta = Convert.ToDouble(txtgerilimbölücüpolarmabeta.Text);
                Vbe = Convert.ToDouble(txtgerilimbölücüpolarmavbe.Text);

                if (Rc > 0 & R1 > 0 & R2 > 0 & Re > 0)
                {
                    Imax = (1000 * Vcc) / (Rc + Re);
                    Vth = R2 * Vcc / (R1 + R2);
                    Rth = R2 * R1 / (R1 + R2);
                    Ib = (Vth - Vbe) / (Rth + (beta + 1) * Re);
                    Ie = (beta + 1) * Ib;
                    Ic = Ie - Ib;
                    Vce = Vcc - Ic * Rc - Ie * Re;
                    vmax = Vcc;

                    lblgerilimbölücüpolarmaıb.Text = " = " + (Math.Pow(10, 6) * Ib).ToString() + "μA";
                    lblgerilimbölücüpolarmaıc.Text = " = " + (1000 * Ic).ToString() + "mA";
                    lblgerilimbölücüpolarmaıe.Text = " = " + (1000 * Ie).ToString() + "mA";
                    lblgerilimbölücüpolarmaImax.Text = " = " + Imax.ToString() + "mA";
                    lblgerilimbölücüpolarmavth.Text = Vth.ToString() + "Volt";
                    lblgerilimbölücüpolarmarth.Text = Rth.ToString();
                    lblgerilimbölücüpolarmavce.Text = Vce.ToString() + "Volt";
                    Ic = Ic * 1000;


                    ZedGraph.ZedGraphControl g = new ZedGraph.ZedGraphControl();
                    g.Size = new Size(panel4.Width - 2, panel4.Height - 2);
                    ZedGraph.GraphPane myGraphPane = g.GraphPane;
                    myGraphPane.Title.Text = "Dc yük eğrisi ";
                    myGraphPane.XAxis.Title.Text = "Volt (V)";
                    myGraphPane.YAxis.Title.Text = "Akım(ma)";
                    PointPairList list1 = new PointPairList();
                    myGraphPane.AddCurve("", new double[] { 0, vmax }, new double[] { Imax, 0 }, Color.Blue, ZedGraph.SymbolType.None);
                    myGraphPane.AddCurve("", new double[] { 0, Vce }, new double[] { Ic, Ic }, Color.Blue, ZedGraph.SymbolType.None);
                    myGraphPane.AddCurve("", new double[] { Vce, Vce }, new double[] { Ic, 0 }, Color.Blue, ZedGraph.SymbolType.None);

                    myGraphPane.Chart.Fill = new ZedGraph.Fill(Color.White, Color.Red, 3.0f);

                    g.AxisChange();

                    panel4.Controls.Add(g);





                }
                else
                    MessageBox.Show("Direnc Degerlerini yanlış girdiniz:");
            }
            catch (Exception)
            {

                Form1.HataMesaji();
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            double Ie, Ic, Ib, Rb, Rc, Re, Vcc, Vce, Vbe, Imax, vmax, beta;
            try
            {
                Rc = Convert.ToDouble(txtgeribeslemelirc.Text) * 1000;
                Rb = Convert.ToDouble(txtgeribeslemelirb.Text) * 1000;
                Re = Convert.ToDouble(txtgeribeslemeliRe.Text) * 1000;
                Vcc = Convert.ToDouble(txtgeribeslemeliVcc.Text);
                beta = Convert.ToDouble(txtgeribeslemelibeta.Text);
                Vbe = Convert.ToDouble(txtgeribeslemelivbe.Text);
                if (Rc > 0 & Rb > 0 & Re > 0)
                {
                    Imax = (1000 * Vcc) / (Rc + Re);

                    Ib = (Vcc - Vbe) / (Rb + (beta + 1) * (Re + Rc));
                    Ie = (beta + 1) * Ib;
                    Ic = beta * Ib;
                    Vce = Vcc - Ie * (Rc + Re);
                    vmax = Vcc;





                    lblgeribeslemeliIb.Text = " = " + (Math.Pow(10, 6) * Ib).ToString() + "μA";
                    lblgeribeslemeliIc.Text = " = " + (1000 * Ic).ToString() + "mA";
                    lblgeribeslemeliIe.Text = " = " + (1000 * Ie).ToString() + "mA";
                    lblgeribeslemeliımax.Text = " = " + Imax.ToString() + "mA";

                    lblgeribeslemeliVce.Text = Vce.ToString() + "Volt";



                    Ic = Ic * 1000;




                    ZedGraph.ZedGraphControl g = new ZedGraph.ZedGraphControl();
                    g.Size = new Size(panel5.Width - 2, panel5.Height - 2);
                    ZedGraph.GraphPane myGraphPane = g.GraphPane;
                    myGraphPane.Title.Text = "Dc yük eğrisi ";
                    myGraphPane.XAxis.Title.Text = "Volt (V)";
                    myGraphPane.YAxis.Title.Text = "Akım(ma)";
                    PointPairList list1 = new PointPairList();
                    myGraphPane.AddCurve("", new double[] { 0, vmax }, new double[] { Imax, 0 }, Color.Blue, ZedGraph.SymbolType.None);
                    myGraphPane.AddCurve("", new double[] { 0, Vce }, new double[] { Ic, Ic }, Color.Blue, ZedGraph.SymbolType.None);
                    myGraphPane.AddCurve("", new double[] { Vce, Vce }, new double[] { Ic, 0 }, Color.Blue, ZedGraph.SymbolType.None);

                    myGraphPane.Chart.Fill = new ZedGraph.Fill(Color.White, Color.Red, 3.0f);

                    g.AxisChange();

                    panel5.Controls.Add(g);
                }
                else MessageBox.Show("Direnc Degerlerini yanlış girdiniz:");





            }
            catch (Exception)
            {

                Form1.HataMesaji();
            }
        }

        
      
       
        }

    }

