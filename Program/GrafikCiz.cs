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
    public partial class GrafikCiz : Form
    {
        public GrafikCiz()
        {
            InitializeComponent();
        }

        public GrafikCiz(double Vcc, double Ic, double Imax, double Vce)
        {
            grafigim(Vcc, Ic, Imax, Vce);
        }

        void grafigim(double Vcc, double Ic, double Imax, double Vce)
        {
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

    }
}
