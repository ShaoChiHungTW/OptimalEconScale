using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OptimalEconScale
{
    public partial class OptimalEconScale : Form
    {
        Computation ComputationSolver;

        public OptimalEconScale()
        {
            InitializeComponent();
        }

        private void btnComputeProduceNSale_Click(object sender, EventArgs e)
        {
            ComputationSolver.ComputeProduceNSales();
            //寫出解
            string sol = " ";
            for (int i = 0; i < ComputationSolver.Ship1.Length; i++)
            {
                sol += "[ " + ComputationSolver.OperatingInc1 + " ] ";
            }
            listBoxSetting.Items.Add(sol);
        }
    }
}
