namespace OptimalEconScale
{
    partial class OptimalEconScale
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnComputeProduceNSale = new System.Windows.Forms.Button();
            this.btnComputeTrialTable = new System.Windows.Forms.Button();
            this.btnComputeOpt = new System.Windows.Forms.Button();
            this.listBoxSetting = new System.Windows.Forms.ListBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Location = new System.Drawing.Point(3, 3);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(274, 305);
            this.propertyGrid1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Indigo;
            this.panel1.Controls.Add(this.propertyGrid1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(283, 460);
            this.panel1.TabIndex = 1;
            // 
            // btnComputeProduceNSale
            // 
            this.btnComputeProduceNSale.Location = new System.Drawing.Point(310, 12);
            this.btnComputeProduceNSale.Name = "btnComputeProduceNSale";
            this.btnComputeProduceNSale.Size = new System.Drawing.Size(135, 49);
            this.btnComputeProduceNSale.TabIndex = 2;
            this.btnComputeProduceNSale.Text = "計算產銷平衡";
            this.btnComputeProduceNSale.UseVisualStyleBackColor = true;
            this.btnComputeProduceNSale.Click += new System.EventHandler(this.btnComputeProduceNSale_Click);
            // 
            // btnComputeTrialTable
            // 
            this.btnComputeTrialTable.Location = new System.Drawing.Point(310, 67);
            this.btnComputeTrialTable.Name = "btnComputeTrialTable";
            this.btnComputeTrialTable.Size = new System.Drawing.Size(135, 49);
            this.btnComputeTrialTable.TabIndex = 3;
            this.btnComputeTrialTable.Text = "計算試算表";
            this.btnComputeTrialTable.UseVisualStyleBackColor = true;
            // 
            // btnComputeOpt
            // 
            this.btnComputeOpt.Location = new System.Drawing.Point(310, 122);
            this.btnComputeOpt.Name = "btnComputeOpt";
            this.btnComputeOpt.Size = new System.Drawing.Size(135, 49);
            this.btnComputeOpt.TabIndex = 4;
            this.btnComputeOpt.Text = "計算最佳利潤";
            this.btnComputeOpt.UseVisualStyleBackColor = true;
            // 
            // listBoxSetting
            // 
            this.listBoxSetting.FormattingEnabled = true;
            this.listBoxSetting.ItemHeight = 12;
            this.listBoxSetting.Location = new System.Drawing.Point(310, 189);
            this.listBoxSetting.Name = "listBoxSetting";
            this.listBoxSetting.Size = new System.Drawing.Size(135, 280);
            this.listBoxSetting.TabIndex = 5;
            // 
            // OptimalEconScale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Thistle;
            this.ClientSize = new System.Drawing.Size(637, 513);
            this.Controls.Add(this.listBoxSetting);
            this.Controls.Add(this.btnComputeOpt);
            this.Controls.Add(this.btnComputeTrialTable);
            this.Controls.Add(this.btnComputeProduceNSale);
            this.Controls.Add(this.panel1);
            this.Name = "OptimalEconScale";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnComputeProduceNSale;
        private System.Windows.Forms.Button btnComputeTrialTable;
        private System.Windows.Forms.Button btnComputeOpt;
        private System.Windows.Forms.ListBox listBoxSetting;
    }
}

