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

        int ExperimentdaysM2, ExperimentdaysM3, ExperimentdaysM4;
        int ProducedaysM2, ProducedaysM3, ProducedaysM4;
        double SpeedM2, SpeedM3, SpeedM4;
        double OptOutput;
        int count = 0;
        



        public OptimalEconScale()
        {
            InitializeComponent();
            btnComputeProduceNSale.Enabled = false;
            btnComputeTrialTable.Enabled = false;
            btnRecomputeOptproduce.Enabled = false;
            btnComputeOpt.Enabled = false;

            listBoxRecordOptOutput.Items.Add("     [ 最佳產量 ]   " + "  [ Operating Inc. ]   ");
            
            DataGridViewRowCollection rows = dataGridView1.Rows;
        }

        private void btnComputeProduceNSale_Click(object sender, EventArgs e)
        {
            ComputationSolver.ComputeProduceNSales();
           
        }

        private void btnComputeCAPA_Click(object sender, EventArgs e)
        {
            ExperimentdaysM2 = Convert.ToInt32(txbExpDayM2.Text);
            ExperimentdaysM3 = Convert.ToInt32(txbExpDayM3.Text);
            ExperimentdaysM4 = Convert.ToInt32(txbExpDayM4.Text);
            ProducedaysM2 = Convert.ToInt32(txbProduceDaysM2.Text);
            ProducedaysM3 = Convert.ToInt32(txbProduceDaysM3.Text);
            ProducedaysM4 = Convert.ToInt32(txbProduceDaysM4.Text);
            SpeedM2 = Convert.ToDouble(txbWeightAvgSpM2.Text);
            SpeedM3 = Convert.ToDouble(txbWeightAvgSpM3.Text);
            SpeedM4 = Convert.ToDouble(txbWeightAvgSpM4.Text);

            ComputationSolver = new Computation(ExperimentdaysM2,ExperimentdaysM3,ExperimentdaysM4, ProducedaysM2,ProducedaysM3,ProducedaysM4, SpeedM2,SpeedM3,SpeedM4);
            ComputationSolver.ComputeCAPA();
            tbxCommitCAPA.Text = Convert.ToString(ComputationSolver.CommitCAPA);
            tbxCAPA.Text = Convert.ToString(ComputationSolver.CAPA);
            propertyGrid1.SelectedObject = ComputationSolver;

            btnComputeTrialTable.Enabled = true;
        }

        //計算試算表
        private void btnComputeTrialTable_Click(object sender, EventArgs e)
        {
            //First:CAPA as max
            ComputationSolver.ComputeTrialTable(ComputationSolver.CAPA);
            propertyGrid1.SelectedObject = ComputationSolver;

            string sol = " ";
            for (int i = ComputationSolver.Range; i > 0 ; i--)
            {
                //update series
                chart1.Series[0].Points.AddXY(i , ComputationSolver.GrossMargin[i]);
                chart1.Series[1].Points.AddXY(i , ComputationSolver.TotalOperatingExp[i]);
                chart1.Series[2].Points.AddXY(i , ComputationSolver.OptimalOperatingInc);


                    sol = " Produced Level " + "[ " + ComputationSolver.Produced[i] + " ] " + " GrossMargin " + "[ " + ComputationSolver.GrossMargin[i] + " ] ";
 
                listBoxSln.Items.Add(sol);
                listBoxSln.Refresh();

            }

            count++;
            listBoxRecordOptOutput.Items.Add("[第" + count + "次] " + " [ " + Convert.ToString(ComputationSolver.OptimalOutput) + " ] " + " [ " + Convert.ToString(ComputationSolver.OptimalOperatingInc) + " ] " );
            tbxOptoutput.Text = Convert.ToString(ComputationSolver.OptimalOutput);
            dataGridView1.Rows[0].Cells[0].Value = ComputationSolver.OptimalOutput;
            dataGridView1.Rows[0].Cells[1].Value = ComputationSolver.OptimalOperatingInc;

            btnRecomputeOptproduce.Enabled = true;
            btnComputeProduceNSale.Enabled = true;

        }

        private void btnRecomputeOptproduce_Click(object sender, EventArgs e)
        {
            //Second:Opt as CAPA
            OptOutput = Convert.ToDouble(tbxOptoutput.Text);
            ComputationSolver.ComputeTrialTable(OptOutput);
            propertyGrid1.Update();
            tbx2ndOutput.Text = Convert.ToString(ComputationSolver.OptimalOutput);

            for (int i = ComputationSolver.Range; i > 0; i--)
            {
                //update series
                chart1.ChartAreas[1].Visible = true;
                chart1.Series[3].Points.AddXY(i, ComputationSolver.GrossMargin[i]);
                chart1.Series[4].Points.AddXY(i, ComputationSolver.TotalOperatingExp[i]);
                chart1.Series[5].Points.AddXY(i, ComputationSolver.OptimalOperatingInc);
            }

            count++;
            listBoxRecordOptOutput.Items.Add("[第" + count + "次] " + " [ " + Convert.ToString(ComputationSolver.OptimalOutput) + " ] "  + " [ " + Convert.ToString(ComputationSolver.OptimalOperatingInc) + " ] ");
            int a = count - 1;

            dataGridView1.Rows.Add(1);
            dataGridView1.Rows[a].Cells[0].Value = ComputationSolver.OptimalOutput;
            dataGridView1.Rows[a].Cells[1].Value = ComputationSolver.OptimalOperatingInc;

            btnComputeCAPA.Enabled = false;
            btnComputeTrialTable.Enabled = false;

        }
    }
}
