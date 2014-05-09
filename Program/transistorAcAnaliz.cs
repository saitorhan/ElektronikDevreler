using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization;
using ZedGraph;

namespace Program
{
    public partial class transistorAcAnaliz : Form
    {
        public transistorAcAnaliz()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panelaccdevree12.Visible = true;
          
            double Ie, Avs,A,Ic,e0,ein, Imax,Ib, Vth,VceAC,IcAC, Rth,Vin, Rc, Re, Vcc, Vce, Vbe, rdd,rb, beta, R1,v0, R2,RL,Rs,Res,gm,rin,Rin;
            try
            {
                rb = Convert.ToDouble(txtemitertekkatrbb.Text) * 1000;
                rdd = Convert.ToDouble(txtemitertekkatrd.Text) * 1000;
                Rc = Convert.ToDouble(txtemitertekkatRc.Text) * 1000;
                R1 = Convert.ToDouble(txtemitertekkatR1.Text) * 1000;
                R2 = Convert.ToDouble(txtemitertekkatR2.Text) * 1000;
                Re = Convert.ToDouble(txtemitertekkatrE.Text) * 1000;
                Vcc = Convert.ToDouble(txtemitertekkatVcc.Text);
                beta = Convert.ToDouble(txtemitertekkatBeta.Text);
                Vbe = Convert.ToDouble(txtemitertekkatVbe.Text);
                Rs = Convert.ToDouble(txtemitertekkatRs.Text) * 1000;
                RL = Convert.ToDouble(txtemitertekkatRl.Text) * 1000;
                ein = Convert.ToDouble(txtemiterein.Text);
                if (rb > 0 & Rc > 0 & rdd > 0 & Re > 0 & Rs > 0 & RL > 0 & Vbe > 0 & R1 > 0 & R2 > 0)
                {
                    Vth = R2 * Vcc / (R1 + R2);
                    Rth = R2 * R1 / (R1 + R2);
                    Ib = (Vth - Vbe) / (Rth + (beta + 1) * Re);
                    Ie = (beta + 1) * Ib;
                    Ic = Ie - Ib;
                    Vce = Vcc - Ic * Rc - Ie * Re;

                    rin = rb + (beta + 1) * rdd;
                    Rin = (Rth * rin) / (Rth + rin);
                    Res = (Rc * RL) / (Rc + RL);
                    A = -beta * Res / rin;
                    Avs = (Rin * A) / (Rin + Rs);
                    e0 = ein * Avs;
                    VceAC = Vce + Ic * Res;
                    IcAC = Ic + Vce / Res;

                    IcAC = IcAC * 1000;
                    Ic = Ic * 1000;
                    Imax = Vcc / (Rc + Re);
                    Imax = Imax * 1000;

                        

                    lblemitertekkatAvs.Text = " = " + Math.Round(Avs, 3);
                    lblemitertekkate0.Text = " = " + e0.ToString() + "mV";
                    lblemitertekkatRİN.Text = " = " + (Math.Pow(10, -3) * Rin).ToString() + "kOhm";
                    lblemitertekkatrin.Text = " = " + (Math.Pow(10, -3) * rin).ToString() + "kOhm";
                    lblemitertekkatRes.Text = "=" + (Math.Pow(10, -3) * Res).ToString() + "kOhm";
                    lblemitertekkatAv.Text = "=" + A.ToString() + "Avs";
                    ZedGraph.ZedGraphControl g = new ZedGraph.ZedGraphControl();
                    g.Size = new Size(panel6.Width - 2, panel6.Height - 2);
                    ZedGraph.GraphPane myGraphPane = g.GraphPane;
                    myGraphPane.Title.Text = "Ac-Dc yük eğrisi ";
                    myGraphPane.XAxis.Title.Text = "Volt (V)";
                    myGraphPane.YAxis.Title.Text = "Akım(ma)";
                    PointPairList list1 = new PointPairList();
                    myGraphPane.AddCurve("", new double[] { 0, VceAC }, new double[] { IcAC, 0 }, Color.Blue, ZedGraph.SymbolType.None);
                    
                   
                    myGraphPane.AddCurve("", new double[] { 0, Vcc }, new double[] { Imax, 0 }, Color.Blue, ZedGraph.SymbolType.None);
                   
                   
                    myGraphPane.Chart.Fill = new ZedGraph.Fill(Color.White, Color.Red, 3.0f);

                    g.AxisChange();

                    panel6.Controls.Add(g);




                }

                else MessageBox.Show("hatalideger girdiniz:");
            }
            catch (Exception)
            {

                Form1.HataMesaji();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panelacdevre21.Visible = true;
            double Ie, Avs, A, Ic, e0,Imax, ein,Re, Ib, Vth, VceAC, IcAC, Rth, Vin, Rc, Re1,Re2, Vcc, Vce, Vbe, rdd, rb, beta, R1, v0, R2, RL, Rs, Res, gm, rin, Rin;
            try
            {
                
                rb = Convert.ToDouble(txtdevre2RBB.Text) * 1000;
                rdd = Convert.ToDouble(txtdevre2Rd.Text) * 1000;
                Rc = Convert.ToDouble(txtdevre2Rc.Text) * 1000;
                R1 = Convert.ToDouble(txtdevre2rb1.Text) * 1000;
                R2 = Convert.ToDouble(txtdevre2Rb2.Text) * 1000;
                Re1 = Convert.ToDouble(txtdevre2Re1.Text) * 1000;
                Re2 = Convert.ToDouble(txtdevre2Re2.Text) * 1000;
                Vcc = Convert.ToDouble(txtdevre2Vcc.Text);
                beta = Convert.ToDouble(txtdevre2beta.Text);
                Vbe = Convert.ToDouble(txtdevre2vbe.Text);
                Rs = Convert.ToDouble(txtdevre2rs.Text) * 1000;
                RL = Convert.ToDouble(txtdevre2Rl.Text) * 1000;
                ein = Convert.ToDouble(txtdevre2ein.Text);
                if (rb > 0 & Rc > 0 & rdd > 0 & (Re1)>0 & (Re2)>0 &  Rs > 0 & RL > 0 & Vbe > 0 & R1 > 0 & R2 > 0)
                { Re = Re1 + Re2;
                Vth = R2 * Vcc / (R1 + R2);
                Rth = R2 * R1 / (R1 + R2);
                Ib = (Vth - Vbe) / (Rth + (beta + 1) * Re);
                Ie = (beta + 1) * Ib;
                Ic = Ie - Ib;
                Vce = Vcc - Ic * Rc - Ie * Re;
                Imax = Vcc / (Rc + Re);
                Imax = Imax * 1000;

                rin = rb + (beta + 1) * rdd;
                Rin = (Rth * rin) / (Rth + rin);
                Res = (Rc * RL) / (Rc + RL);
                A = -beta * Res / rin;
                Avs = (Rin * A) / (Rin + Rs);
                e0 = ein * Avs;
                VceAC = Vce + Ic * Res;
                IcAC = Ic + Vce / Res;

                IcAC = IcAC * 1000;
                Ic = Ic * 1000;

                lbldevre2AVS.Text = " = " + Avs.ToString();
                 lbldevre2E0.Text = " = " + e0.ToString() + "mV";
                lbldevre2RİN.Text= " = " + (Math.Pow(10, -3) * Rin).ToString() + "kOhm";
                lbldevre2rin.Text = " = " + (Math.Pow(10, -3) * rin).ToString() + "kOhm";
                lbldevre2rES.Text = "=" + (Math.Pow(10, -3) * Res).ToString() + "kOhm";
                lbldevre2a.Text = "=" + A.ToString() + "Avs";
                ZedGraph.ZedGraphControl g = new ZedGraph.ZedGraphControl();
                g.Size = new Size(panel7.Width - 2, panel7.Height - 2);
                ZedGraph.GraphPane myGraphPane = g.GraphPane;
                myGraphPane.Title.Text = "Ac-Dc yük eğrisi ";
                myGraphPane.XAxis.Title.Text = "Volt (V)";
                myGraphPane.YAxis.Title.Text = "Akım(ma)";
                PointPairList list1 = new PointPairList();
                myGraphPane.AddCurve("", new double[] { 0, VceAC }, new double[] { IcAC, 0 }, Color.Blue, ZedGraph.SymbolType.None);
                myGraphPane.AddCurve("", new double[] { 0, Vcc }, new double[] { Imax, 0 }, Color.Blue, ZedGraph.SymbolType.None);

                myGraphPane.Chart.Fill = new ZedGraph.Fill(Color.White, Color.Red, 3.0f);

                g.AxisChange();

                panel7.Controls.Add(g);
                }
                else MessageBox.Show("hatalideger  girdiniz.");
            }




            
            catch (Exception)
            {

                Form1.HataMesaji();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panellllacccdevre3.Visible = true;
            double Ie, Avs, A, Ic,Imax, e0, ein, Re, Ib, Vth, VceAC, IcAC, Rth, Vin, Rc, Re1, Re2, Vcc, Vce, Vbe, rdd, rb, beta, R1, v0, R2, RL, Rs, Res, gm, rin, Rin;
            try
            {
                rb = Convert.ToDouble(txtdevre3rbb.Text) * 1000;
                rdd = Convert.ToDouble(txtdevre3rd.Text) * 1000;
                Rc = Convert.ToDouble(txtdevre3rc.Text) * 1000;
                R1 = Convert.ToDouble(txtdevre3rb1.Text) * 1000;
                R2 = Convert.ToDouble(txtdevre3Rb2.Text) * 1000;
                Re1 = Convert.ToDouble(txtdevre3Re1.Text) * 1000;
                Re2 = Convert.ToDouble(txtdevre3Re2.Text) * 1000;
                Vcc = Convert.ToDouble(txtdevre3Vcc.Text);
                beta = Convert.ToDouble(txtdevre3beta.Text);
                Vbe = Convert.ToDouble(txtdevre3vbe.Text);
                Rs = Convert.ToDouble(txtdevre3Rs.Text) * 1000;
                RL = Convert.ToDouble(txtdevre3rL.Text) * 1000;
                ein = Convert.ToDouble(txtdevre3Ein.Text);
                Re = Re1 + Re2;
                Vth = R2 * Vcc / (R1 + R2);
                Rth = R2 * R1 / (R1 + R2);
                Ib = (Vth - Vbe) / (Rth + (beta + 1) * Re);
                Ie = (beta + 1) * Ib;
                Ic = Ie - Ib;
                Vce = Vcc - Ic * Rc - Ie * Re;
                Imax = Vcc / (Rc + Re);
                Imax = Imax * 1000;

                rin = rb + (beta + 1) * (rdd+Re1);
                Rin = (Rth * rin) / (Rth + rin);
                Res = (Rc * RL) / (Rc + RL);
                A = -beta * Res / rin;
                Avs = (Rin * A) / (Rin + Rs);
                e0 = ein * Avs;
                VceAC = Vce + Ic * Res;
                IcAC = Ic + Vce / Res;

                IcAC = IcAC * 1000;
                Ic = Ic * 1000;

                lbldevre3Avs.Text= " = " + Avs.ToString();
                lbldevre3e0.Text = " = " + e0.ToString() + "mV";
                lbldevre3Rin.Text = " = " + (Math.Pow(10, -3) * Rin).ToString() + "kOhm";
                lbldevre3kücükrin.Text = " = " + (Math.Pow(10, -3) * rin).ToString() + "kOhm";
                lbldevre3rES.Text = "=" + (Math.Pow(10, -3) * Res).ToString() + "kOhm";
                lbldevre3A.Text = "=" + A.ToString() + "Avs";
                ZedGraph.ZedGraphControl g = new ZedGraph.ZedGraphControl();
                g.Size = new Size(panel8.Width - 2, panel8.Height - 2);
                ZedGraph.GraphPane myGraphPane = g.GraphPane;
                myGraphPane.Title.Text = "Ac-Dc yük eğrisi ";
                myGraphPane.XAxis.Title.Text = "Volt (V)";
                myGraphPane.YAxis.Title.Text = "Akım(ma)";
                PointPairList list1 = new PointPairList();
                myGraphPane.AddCurve("", new double[] { 0, VceAC }, new double[] { IcAC, 0 }, Color.Blue, ZedGraph.SymbolType.None);
                myGraphPane.AddCurve("", new double[] { 0, Vcc }, new double[] { Imax, 0 }, Color.Blue, ZedGraph.SymbolType.None);

                myGraphPane.Chart.Fill = new ZedGraph.Fill(Color.White, Color.Red, 3.0f);

                g.AxisChange();

                panel8.Controls.Add(g);




            }
            catch (Exception)
            {

                Form1.HataMesaji();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            double Avs,Vcc, Av1, Av2,Rth,Res1,Res2, e0, ein, beta1, beta2, rbb1, rbb2, rd1, rd2, rin1, rin2, Rin1, Rin2, Rb3, rc1, Rb4, Rb1, re1, re2, rc2, rl, rs;
            try
            {
                Rb1 = Convert.ToDouble(txtciftkatlidevre1rb1.Text) * 1000;
                Rb3 = Convert.ToDouble(txtciftkatlidevre1rb3.Text) * 1000;
                Rb4 = Convert.ToDouble(txtciftkatlidevre1rb4.Text) * 1000;
                rl = Convert.ToDouble(txtciftkatlidevre1rl.Text) * 1000;
                re1 = Convert.ToDouble(txtciftkatlidevre1re1.Text) * 1000;
                re2 = Convert.ToDouble(txtciftkatlidevre1re2.Text) * 1000;
                rs = Convert.ToDouble(txtciftkatlidevre1Rs.Text) * 1000;
                rc2 = Convert.ToDouble(txtciftkatlidevre1Rc2.Text) * 1000;
                rc1 = Convert.ToDouble(txtciftkatlidevre1rc1.Text) * 1000;
                
                Vcc = Convert.ToDouble(txtciftkatlidevre1vcc.Text);
                beta1 = Convert.ToDouble(txtciftkatlidevre1beta1.Text);
                beta2 = Convert.ToDouble(txtciftkatlidevre1beta2.Text);
                rd1 = Convert.ToDouble(txtciftkatlidevre1rd1.Text) * 1000;
                rd2 = Convert.ToDouble(txtciftkatlidevre1rd2.Text) * 1000;
                rbb1 = Convert.ToDouble(txtciftkatlidevrerbb1.Text)*1000;
                rbb2 = Convert.ToDouble(txtciftkatlidevrerbb2.Text)*1000;
                ein = Convert.ToDouble(txtciftkatlidevre1ein.Text);

                Rth=Rb3*Rb4/(Rb4+Rb3);
                rin1 = rbb1 + (beta1 + 1) * (rd1 + re1);
                rin2 = rbb2 + (beta2 + 1) * rd2 ;
                Rin1 = (Rb1 * rin1) / (Rb1 + rin1);
                Rin2 = (Rth * rin2) / (Rth + rin2);
                Res1 = (rc1 * Rin2) / (rc1 + Rin2);
                Res2 = (rc2 * rl) / (rc2 + rl);
                Av1 = -beta1 * Res1 / rin1;
                Av2 = -beta2 * Res2 / rin2;
                Avs = Av2*Av1*Rin1 / (Rin1 + rs);
                e0 = ein * Avs;



                lblacciftkatlidevre1res1.Text = "res1=" +(Math.Pow(10,-3)* Res1).ToString()+"kOhm";
                lblacciftkatlidevre1res2.Text = "res2=" + (Math.Pow(10, -3) * Res2).ToString() + "kOhm";
                lblacciftkatlidevre1rin1.Text = "rin1=" + (Math.Pow(10, -3) * rin1).ToString() + "kOhm";
                lblacciftkatlidevre1rin2.Text = "rin2=" + (Math.Pow(10, -3) * rin2).ToString() + "kOhm";
                lblacciftkatlidevre1RİNN1.Text = "Rin1=" + (Math.Pow(10, -3) * Rin1).ToString() + "kOhm";
                lblacciftkatlidevre1RİNN2.Text = "Rin2=" + (Math.Pow(10, -3) * Rin2).ToString() + "kOhm";
                lblciftkatlidevre1a1.Text = " = " + Av1.ToString();
                lblciftkatlidevre1a2.Text = " = " + Av2.ToString() ;
                lblciftkatlidevre1Avs.Text = " = " + Avs.ToString(); 
                lblciftkatlidevre1e0.Text = " = " + e0.ToString() +"mVolt";
              





            }
            catch (Exception)
            {

                Form1.HataMesaji();
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {

            double Avs, Vcc, Av1, Av2, Rth1,Rth2,Rth3, Res1, Res2, e0, ein, beta1, beta2, rbb1, rbb2, rd1, rd2, rin1, rin2, Rin1, Rin2, Rb3, rc1, Rb4, Rb1, re1, re2, rc2, rl, Rb2;
            try
            {
                Rb1 = Convert.ToDouble(txtciftkatlidevre2rb1.Text) * 1000;
                Rb3 = Convert.ToDouble(txtciftkatlidevre2rb3.Text) * 1000;
                Rb4 = Convert.ToDouble(txtciftkatlidevre2rb4.Text) * 1000;
                rl = Convert.ToDouble(txtciftkatlidevre2rL.Text) * 1000;
                re1 = Convert.ToDouble(txtciftkatlidevre2re1.Text) * 1000;
                re2 = Convert.ToDouble(txtciftkatlidevre2re2.Text) * 1000;
                Rb2 = Convert.ToDouble(txtciftkatlidevre2rb2.Text) * 1000;
                rc2 = Convert.ToDouble(txtciftkatlidevre2rc2.Text) * 1000;
                rc1 = Convert.ToDouble(txtciftkatlidevre2rc1.Text) * 1000;

                Vcc = Convert.ToDouble(txtciftkatlidevre2vcc.Text);
                beta1 = Convert.ToDouble(txtciftkatlidevre2beta1.Text);
                beta2 = Convert.ToDouble(txtciftkatlidevre2beta2.Text);
                rd1 = Convert.ToDouble(txtciftkatlidevre2rd1.Text) * 1000;
                rd2 = Convert.ToDouble(txtciftkatlidevre2rd2.Text) * 1000;
                rbb1 = Convert.ToDouble(txtciftkatlidevre2rbb1.Text) * 1000;
                rbb2 = Convert.ToDouble(txtciftkatlidevre2rbb2.Text) * 1000;
                ein = Convert.ToDouble(txtciftkatlidevre2Ein.Text);
                Rth1=Rb1*Rb2/(Rb2+Rb1);
                Rth2 = Rb3 * Rb4 / (Rb4 + Rb3);
                Rth3 = rc1 * Rb3 / (rc1 + Rb3);
                rin1 = rbb1 + (beta1 + 1) * rd1 ;
                rin2 = rbb2 + (beta2 + 1) * (rd2+re2);
                Rin1 = (Rth1 * rin1) / (Rth1 + rin1);
                Rin2 = (Rth2 * rin2) / (Rth2 + rin2);
                Res1 = (Rth3 * Rin2) / (Rth3 + Rin2);
                Res2 = (rc2 * rl) / (rc2 + rl);
                Av1 = -beta1 * Res1 / rin1;
                Av2 = -beta2 * Res2 / rin2;
                Avs = Av2 * Av1;
                e0 = ein * Avs;




                lblciftkatlıdevre2Av1.Text = " = " + Av1.ToString();
                lblciftkatlıdevre2av2.Text = " = " + Av2.ToString();
                lblciftkatlıdevre2AVS.Text = " = " + Avs.ToString();
                lblciftkatlıdevre2E0.Text = " = " + e0.ToString() + "mVolt";
                


            }
            catch (Exception)
            {

                Form1.HataMesaji();
            }


        }

        private void button6_Click(object sender, EventArgs e)
        {
            double Avs, Av1, Av2, Rth1, Rth2, Res1, Res2, e0, ein, beta1, beta2, rbb1, rbb2, rd1, rd2, rin1, rin2, Rin1, Rin2, Rb3, rc1, Rb1, re1, re2, rc2, rl, Rb2;
            try
            {
                Rb1 = Convert.ToDouble(txtciftkatlidevre3rb1.Text) * 1000;
                Rb3 = Convert.ToDouble(txtciftkatlidevre3RB3.Text) * 1000;
               
                rl = Convert.ToDouble(txtciftkatlidevre3RL.Text) * 1000;
                re1 = Convert.ToDouble(txtciftkatlidevre3re1.Text) * 1000;
                re2 = Convert.ToDouble(txtciftkatlidevre3re2.Text) * 1000;
                Rb2 = Convert.ToDouble(txtciftkatlidevre3rb2.Text) * 1000;
                rc2 = Convert.ToDouble(txtciftkatlidevre3rc2.Text) * 1000;
                rc1 = Convert.ToDouble(txtciftkatlidevre3rc1.Text) * 1000;

                
                beta1 = Convert.ToDouble(txtciftkatlidevre3beta1.Text);
                beta2 = Convert.ToDouble(txtciftkatlidevre3beta2.Text);
                rd1 = Convert.ToDouble(txtciftkatlidevre3rd1.Text) * 1000;
                rd2 = Convert.ToDouble(txtciftkatlidevre3rd2.Text) * 1000;
                rbb1 = Convert.ToDouble(txtciftkatlidevre3rbb1.Text) * 1000;
                rbb2 = Convert.ToDouble(txtciftkatlidevre3rbb2.Text) * 1000;
                ein = Convert.ToDouble(txtciftkatlidevre3ein.Text);
                Rth1 = Rb1 * Rb2 / (Rb2 + Rb1);
               
                rin1 = rbb1 + (beta1 + 1) * rd1;
                rin2 = rbb2 + (beta2 + 1) * (rd2 + re2);
                Rin1 = (Rth1 * rin1) / (Rth1 + rin1);
                Rin2 = (Rb3 * rin2) / (Rb3 + rin2);
                Res1 = (rc1* Rin2) / (rc1 + Rin2);
                Res2 = (rc2 * rl) / (rc2 + rl);
                Av1 = -beta1 * Res1 / rin1;
                Av2 = -beta2 * Res2 / rin2;
                Avs = Av2 * Av1;
                e0 = ein * Avs;




                lblciftkatlidevree3av1.Text = " Av1= " + Av1.ToString();
                lblciftkatlidevree3av2.Text = " Av2= " + Av2.ToString();
                lblciftkatlidevree3avs.Text = " Avs= " + Avs.ToString();
               lblciftkatlidevreee0.Text = " e0= " + e0.ToString() + "mVolt";



            }
            catch (Exception)
            {

                Form1.HataMesaji();
            }
        }

        

        
        }

       

        

        

        

       
    }

