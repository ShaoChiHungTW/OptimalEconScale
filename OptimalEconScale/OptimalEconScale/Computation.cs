using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimalEconScale
{
    public class Computation
    {

        #region CAPA
        //CAPA
        //行事曆天數
        int calenderDays = 30;
        //實驗天數
        int experimentDays_M2 = 2;
        int experimentDays_M3 = 2;
        int experimentDays_M4 = 2;
        //量產天數
        int produceDays_M2 = 29;
        int produceDays_M3 = 29;
        int produceDays_M4 = 29;
        //OEE目標
        double OEEObj_M2 = 0.728;
        double OEEObj_M3 = 0.709;
        double OEEObj_M4 = 0.740;
        //加權平均機速
        double WeightedAvgSpeed_M2 = 15.0;
        double WeightedAvgSpeed_M3 = 18.0;
        double WeightedAvgSpeed_M4 = 24.8;
        //產量
        double output_M2;
        double output_M3;
        double output_M4;

        double commitCAPA;
        double width = 1.47;
        double cAPA;
        #endregion
        #region 產銷平衡
        //產銷平衡
        //期數
        //int Period = 3;
        //本月總生產量
        double[] possibleoutput;
        //本月生產下月出貨
        double[] preProduced;
        //前越遞延入庫
        double[] Stock;
        //本月可出貨量
        double[] Ship;
        //銷量需求
        double[] demandAmount;
        //BU彈性調整
        double[] BUflexibleamount;
        double BUflexibleRate = 0.05;
        //6%良率損失
        double[] yieldLoss;
        //剩餘產能
        double[] surplus;

        double Upperbound;
        double Lowerbound;
        #endregion
        #region 試算表
        //試算表
        int ASP = 100;
        double[] TotalRevenue ;
        double RawMaterial;
        double PeriodCost;
        double PPV, QV, STD, FreightCost, StockProvision, Duty, SubMaterial, DLOH;

        double DirectCost;
        double DirectLabor;
        double Overhead;
        double Personnel, Depreciation, SundryPurchase, ToolingExp, IndirectMaterial, SubcontractExp, Utilities, OtherExp;

        double TotalCOGS;
        double[] grossMargin;
        double[] totalOperatingExp;
        double SMExp, GAExp, RDExp;
        double[] OperatingInc;

        double OptimalTotalOperatingExp;
        double optimalGrossMargin;
        double optimalTotalCOGS;

        double optimalOperatingInc;
        //最佳生產量
        double optimaloutput;
        double[] OptimalSetting;

        int range;
#endregion

        #region Properties
        //[Category("產銷平衡"), Description("期數")]
        //public int Period1 { get => Period; set => Period = value; }
        [Category("產銷平衡"), Description("本月總生產量")]
        public double[] Produced { get => possibleoutput; set => possibleoutput = value; }
        [Category("產銷平衡"), Description("本月生產下月出貨")]
        public double[] PreProduced { get => preProduced; set => preProduced = value; }
        [Category("產銷平衡"), Description("本月可出貨量")]
        public double[] Shippment { get => Ship; set => Ship = value; }
        [Category("產銷平衡"), Description("銷量需求")]
        public double[] Demand { get => demandAmount; set => demandAmount = value; }
        [Category("產銷平衡"), Description("BU彈性調整量")]
        public double[] BUFlexibleAmount { get => BUflexibleamount; set => BUflexibleamount = value; }
        [Category("產銷平衡"), Description("BU彈性調整率")]
        public double BUFlexibleRate { get => BUflexibleRate; set => BUflexibleRate = value; }
        [Category("產銷平衡"), Description("6%良率損失")]
        public double[] YieldLoss { get => yieldLoss; set => yieldLoss = value; }
        [Category("產銷平衡"), Description("剩餘產能")]
        public double[] Surplus { get => surplus; set => surplus = value; }

        [Category("試算表"), Description("營業收入")]
        public double[] OperatingIncome { get => OperatingInc; set => OperatingInc = value; }
        [Category("試算表"), Description("最佳營業費用")]
        public double OptimalTotalOperatingExpense { get => OptimalTotalOperatingExp; set => OptimalTotalOperatingExp = value; }
        [Category("試算表"), Description("最佳毛利")]
        public double OptimalGrossMargin { get => optimalGrossMargin; set => optimalGrossMargin = value; }
        [Category("試算表"), Description("最佳銷貨成本")]
        public double OptimalTotalCOGS { get => optimalTotalCOGS; set => optimalTotalCOGS = value; }
        [Category("試算表"), Description("最佳營業收入")]
        public double OptimalOperatingInc { get => optimalOperatingInc; set => optimalOperatingInc = value; }

        [Category("試算表"), Description("毛利")]
        public double[] GrossMargin { get => grossMargin; set => grossMargin = value; }
        [Category("試算表"), Description("營業費用")]
        public double[] TotalOperatingExp { get => totalOperatingExp; set => totalOperatingExp = value; }
        [Browsable(false)]
        public int Range { get => range; set => range = value; }
        [Browsable(false)]
        public double UpperBound { get => Upperbound; set => Upperbound = value; }
        [Category("試算表"), Description("最佳生產量")]
        public double OptimalOutput { get => optimaloutput; set => optimaloutput = value; }





        [Category("CAPA"), Description("Commit CAPA")]
        public double CommitCAPA { get => commitCAPA; set => commitCAPA = value; }
        [Category("CAPA"), Description("CAPA")]
        public double CAPA { get => cAPA; set => cAPA = value; }
        [Category("CAPA"), Description("幅寬係數")]
        public double Width { get => width; set => width = value; }

        [Category("CAPA"), Description("行事曆天數")]
        public int CalenderDays { get => calenderDays; set => calenderDays = value; }
        [Category("CAPA_實驗天數"), Description("M2_實驗天數")]
        public int ExperimentDays_M2 { get => experimentDays_M2; set => experimentDays_M2 = value; }
        [Category("CAPA_實驗天數"), Description("M3_實驗天數")]
        public int ExperimentDays_M3 { get => experimentDays_M3; set => experimentDays_M3 = value; }
        [Category("CAPA_實驗天數"), Description("M4_實驗天數")]
        public int ExperimentDays_M4 { get => experimentDays_M4; set => experimentDays_M4 = value; }
        [Category("CAPA_生產天數"), Description("M2_生產天數")]
        public int ProduceDays_M2 { get => produceDays_M2; set => produceDays_M2 = value; }
        [Category("CAPA_生產天數"), Description("M3_生產天數")]
        public int ProduceDays_M3 { get => produceDays_M3; set => produceDays_M3 = value; }
        [Category("CAPA_生產天數"), Description("M4_生產天數")]
        public int ProduceDays_M4 { get => produceDays_M4; set => produceDays_M4 = value; }
        [Category("CAPA_OEE目標"), Description("M2_OEE目標")]
        public double OEEObjective_M2 { get => OEEObj_M2; set => OEEObj_M2 = value; }
        [Category("CAPA_OEE目標"), Description("M3_OEE目標")]
        public double OEEObjective_M3 { get => OEEObj_M3; set => OEEObj_M3 = value; }
        [Category("CAPA_OEE目標"), Description("M4_OEE目標")]
        public double OEEObjective_M4 { get => OEEObj_M4; set => OEEObj_M4 = value; }
        [Category("CAPA_加權平均機速"), Description("M2_加權平均機速")]
        public double WeightedAverageSpeed_M2 { get => WeightedAvgSpeed_M2; set => WeightedAvgSpeed_M2 = value; }
        [Category("CAPA_加權平均機速"), Description("M3_加權平均機速")]
        public double WeightedAverageSpeed_M3 { get => WeightedAvgSpeed_M3; set => WeightedAvgSpeed_M3 = value; }
        [Category("CAPA_加權平均機速"), Description("M4_加權平均機速")]
        public double WeightedAverageSpeed_M4 { get => WeightedAvgSpeed_M4; set => WeightedAvgSpeed_M4 = value; }
        [Category("CAPA_產量"), Description("M2_產量")]
        public double Output_M2 { get => output_M2; set => output_M2 = value; }
        [Category("CAPA_產量"), Description("M3_產量")]
        public double Output_M3 { get => output_M3; set => output_M3 = value; }
        [Category("CAPA_產量"), Description("M4_產量")]
        public double Output_M4 { get => output_M4; set => output_M4 = value; }





        #endregion
        public Computation(int experimentdays_M2, int experimentdays_M3, int experimentdays_M4, int producedays_M2, int producedays_M3, int producedays_M4, double weightedavgSpeed_M2, double weightedavgSpeed_M3, double weightedavgSpeed_M4)
        {
            this.experimentDays_M2 = experimentdays_M2;
            this.experimentDays_M3 = experimentdays_M3;
            this.experimentDays_M4 = experimentdays_M4;
            this.produceDays_M2 = producedays_M2;
            this.produceDays_M3 = producedays_M3;
            this.produceDays_M4 = producedays_M4;
            this.WeightedAvgSpeed_M2 = weightedavgSpeed_M2;
            this.WeightedAvgSpeed_M3 = weightedavgSpeed_M3;
            this.WeightedAvgSpeed_M4 = weightedavgSpeed_M4;
        }

        //Step1:計算CAPA
        public virtual void ComputeCAPA()
        {
            output_M2 = WeightedAvgSpeed_M2 * 60 * 24 * produceDays_M2 * OEEObj_M2 / 1000;
            output_M3 = WeightedAvgSpeed_M3 * 60 * 24 * produceDays_M3 * OEEObj_M3 / 1000;
            output_M4 = WeightedAvgSpeed_M4 * 60 * 24 * produceDays_M4 * OEEObj_M4 / 1000;
            commitCAPA = output_M2 + output_M3 + output_M4;
            cAPA = commitCAPA * width;
            Upperbound = cAPA;

        }

        //計算產銷平衡
        public virtual void ComputeProduceNSales()
        {
            //UpperBound = Convert.ToInt32(Math.Ceiling(cAPA));
            //LowerBound = 0;
            //double Range = UpperBound - LowerBound;

            ////考慮存貨找出Opt
            //for (int i = 0; i < UpperBound; i++)
            //{
            //    possibleProduce[i] = i;
            //    //本月可出貨量=前月遞延+本月總生產-下月出貨
            //    Ship[i] = preProduced[i - 1] + possibleProduce[i] - preProduced[i];
            //    //計算BU彈性調整
            //    BUflexibleamount[i] = BUflexibleRate * Ship[i];
            //    //4%良率損失
            //    yieldLoss[i] = 0.04 * (demandAmount[i] + BUflexibleamount[i]);
            //    //剩餘產能=可出貨-需求-BU調整-良率損失
            //    surplus[i] = Ship[i] - demandAmount[i] - BUflexibleamount[i] - yieldLoss[i];
            //}



        }

        //Step2:CAPA as max, find out opt output
        public virtual void ComputeTrialTable(double upperbound )
        {
            this.Upperbound = upperbound;
            range = Convert.ToInt16(Math.Floor(Upperbound)) ;
            TotalRevenue = new double[range + 1];
            possibleoutput = new double[range + 1];
            grossMargin = new double[range + 1];
            OperatingInc = new double[range + 1];
            totalOperatingExp = new double[range + 1];
            optimalOperatingInc = double.MinValue;


            for ( int i = range; i > 0; i-- )
            {
                //Every possible produce level up to CAPA
                possibleoutput[i] = i;
                TotalRevenue[i] = possibleoutput[i] * ASP;

                PeriodCost = PPV + QV + STD + FreightCost + StockProvision + Duty + SubMaterial + DLOH;
                Overhead = Personnel + Depreciation + SundryPurchase + ToolingExp + IndirectMaterial + SubcontractExp + Utilities + OtherExp;
                TotalCOGS = RawMaterial + PeriodCost + DirectCost + DirectLabor + Overhead;
                grossMargin[i] = TotalRevenue[i] - TotalCOGS;
                totalOperatingExp[i] = SMExp + GAExp + RDExp;
                OperatingInc[i] = grossMargin[i] - totalOperatingExp[i];

                if (OperatingInc[i] > optimalOperatingInc)
                {
                    optimalOperatingInc = OperatingInc[i];
                    optimalGrossMargin = grossMargin[i];
                    optimaloutput = possibleoutput[i];
                    optimalTotalCOGS = TotalCOGS;
                    OptimalTotalOperatingExp = totalOperatingExp[i];
                    
                }
            }

        }

        //public virtual void BrutalForce()
        //{
        //    int Upperbound = Convert.ToInt32(Math.Floor(Ship.Max()));
        //    int LowerBound = Convert.ToInt32(Math.Ceiling(Ship.Min()));
        //    int Range = Upperbound - LowerBound + 1;
        //    Ship = new double[Range];

        //    //OptimalSetting = new double[????????????];

        //    for (int i = Upperbound; i > LowerBound; i--)
        //    {
        //        Ship[i] = i;
        //        ComputeProduceNSales();
        //        ComputeTrialTable();

        //        if ( OperatingInc > OptimalOperatingInc )
        //        {
        //            OptimalOperatingInc = OperatingInc;
        //            OptimalShip = i;

        //        }
                
        //    }

        //}
    }
}
