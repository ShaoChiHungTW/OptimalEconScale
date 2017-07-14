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
        //產銷平衡
        //期數
        int Period = 3;
        //本月總生產量
        double[] Manufact;
        //本月生產下月出貨,前月遞延入庫
        double[] PreManufact;
        //本月可出貨量
        double[] Ship;
        //銷量需求
        double[] Demand;
        //BU彈性調整
        double[] BUFlexibleAmount;
        double BUFlexibleRate = 0.05;
        //6%良率損失
        double[] YieldLoss;
        //剩餘產能
        double[] Surplus;

        //試算表
        double TotalRevenue ;
        double RawMaterial;
        double PeriodCost;
        double PPV, QV, STD, FreightCost, StockProvision, Duty, SubMaterial, DLOH;

        double DirectCost;
        double DirectLabor;
        double Overhead;
        double Personnel, Depreciation, SundryPurchase, ToolingExp, IndirectMaterial, SubcontractExp, Utilities, OtherExp;

        double TotalCOGS;
        double GrossMargin;
        double TotalOperatingExp;
        double SMExp, GAExp, RDExp;
        double OperatingInc;

        double OptimalTotalOperatingExp = double.MaxValue;
        double OptimalGrossMargin = double.MinValue;
        double OptimalTotalCOGS = double.MaxValue;

        double OptimalOperatingInc = double.MinValue;
        double OptimalShip = double.MinValue;
        double[] OptimalSetting;

        #region Properties
        [Category("產銷平衡"), Description("期數")]
        public int Period1 { get => Period; set => Period = value; }
        [Category("產銷平衡"), Description("本月總生產量")]
        public double[] Manufact1 { get => Manufact; set => Manufact = value; }
        [Category("產銷平衡"), Description("本月生產下月出貨")]
        public double[] PreManufact1 { get => PreManufact; set => PreManufact = value; }
        [Category("產銷平衡"), Description("本月可出貨量")]
        public double[] Ship1 { get => Ship; set => Ship = value; }
        [Category("產銷平衡"), Description("銷量需求")]
        public double[] Demand1 { get => Demand; set => Demand = value; }
        [Category("產銷平衡"), Description("BU彈性調整量")]
        public double[] BUFlexibleAmount1 { get => BUFlexibleAmount; set => BUFlexibleAmount = value; }
        [Category("產銷平衡"), Description("BU彈性調整率")]
        public double BUFlexibleRate1 { get => BUFlexibleRate; set => BUFlexibleRate = value; }
        [Category("產銷平衡"), Description("6%良率損失")]
        public double[] YieldLoss1 { get => YieldLoss; set => YieldLoss = value; }
        [Category("產銷平衡"), Description("剩餘產能")]
        public double[] Surplus1 { get => Surplus; set => Surplus = value; }

        [Category("試算表"), Description("營業收入")]
        public double OperatingInc1 { get => OperatingInc; set => OperatingInc = value; }



        #endregion

        public Computation(double[] Manufact, double[] preManufact, double[] demand )
        {
            this.Manufact = Manufact;
            PreManufact = preManufact;
            Demand = demand;

            

        }

        //計算產銷平衡
        public virtual void ComputeProduceNSales()
        {
            Manufact = new double[] { 2503, 2228, 2291 };
            PreManufact = new double[] { 285, 206, 206 };
            Ship = new double[Period];
            Demand = new double[] { 2055, 1997, 2037 };
            BUFlexibleAmount = new double[Period];
            YieldLoss = new double[Period];
            Surplus = new double[Period];
          

            for ( int i = 0; i<Period; i++ )
            {
                if (i == 0)
                {
                    Ship[i] = Manufact[0] - PreManufact[0];
                }
                //本月可出貨量=前月遞延+本月總生產-下月出貨
                Ship[i] = PreManufact[i - 1] + Manufact[i] - PreManufact[i];
                //計算BU彈性調整
                BUFlexibleAmount[i] = BUFlexibleRate * Ship[i];                   
                //6%良率損失
                YieldLoss[i] = 0.06 * (Demand[i] + BUFlexibleAmount[i]);
                //剩餘產能=可出貨-需求-BU調整-良率損失
                Surplus[i] = Ship[i] - Demand[i] - BUFlexibleAmount[i] - YieldLoss[i];
            }
        }

        public virtual void ComputeTrialTable()
        {
           
            TotalRevenue = Demand.Max();


            PeriodCost = PPV + QV + STD + FreightCost + StockProvision + Duty + SubMaterial + DLOH;
            Overhead = Personnel + Depreciation + SundryPurchase + ToolingExp + IndirectMaterial + SubcontractExp + Utilities + OtherExp;
            TotalCOGS = RawMaterial + PeriodCost + DirectCost + DirectLabor + Overhead ;
            GrossMargin = TotalRevenue - TotalCOGS;
            TotalOperatingExp = SMExp + GAExp + RDExp;
            OperatingInc = GrossMargin - TotalOperatingExp;
        }

        public virtual void BrutalForce()
        {
            int Upperbound = Convert.ToInt32(Math.Floor(Ship.Max()));
            int LowerBound = Convert.ToInt32(Math.Ceiling(Ship.Min()));
            int Range = Upperbound - LowerBound + 1;
            Ship = new double[Range];

            //OptimalSetting = new double[????????????];

            for (int i = Upperbound; i > LowerBound; i--)
            {
                Ship[i] = i;
                ComputeProduceNSales();
                ComputeTrialTable();

                if ( OperatingInc > OptimalOperatingInc )
                {
                    OptimalOperatingInc = OperatingInc;
                    OptimalShip = i;

                }
                
            }

        }
    }
}
