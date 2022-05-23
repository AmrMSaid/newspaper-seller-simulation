namespace NewspaperSellerSimulation
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.totalSalesLabel = new System.Windows.Forms.Label();
            this.totalLostLabel = new System.Windows.Forms.Label();
            this.totalScrapLabel = new System.Windows.Forms.Label();
            this.totalNetLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.totalCostLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lostDaysLabel = new System.Windows.Forms.Label();
            this.scrapDaysLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1194, 620);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellContentClick);
            // 
            // totalSalesLabel
            // 
            this.totalSalesLabel.AutoSize = true;
            this.totalSalesLabel.Location = new System.Drawing.Point(744, 623);
            this.totalSalesLabel.Name = "totalSalesLabel";
            this.totalSalesLabel.Size = new System.Drawing.Size(70, 17);
            this.totalSalesLabel.TabIndex = 1;
            this.totalSalesLabel.Text = "totalSales";
            // 
            // totalLostLabel
            // 
            this.totalLostLabel.AutoSize = true;
            this.totalLostLabel.Location = new System.Drawing.Point(854, 623);
            this.totalLostLabel.Name = "totalLostLabel";
            this.totalLostLabel.Size = new System.Drawing.Size(62, 17);
            this.totalLostLabel.TabIndex = 2;
            this.totalLostLabel.Text = "totalLost";
            this.totalLostLabel.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // totalScrapLabel
            // 
            this.totalScrapLabel.AutoSize = true;
            this.totalScrapLabel.Location = new System.Drawing.Point(965, 623);
            this.totalScrapLabel.Name = "totalScrapLabel";
            this.totalScrapLabel.Size = new System.Drawing.Size(72, 17);
            this.totalScrapLabel.TabIndex = 3;
            this.totalScrapLabel.Text = "totalScrap";
            this.totalScrapLabel.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // totalNetLabel
            // 
            this.totalNetLabel.AutoSize = true;
            this.totalNetLabel.Location = new System.Drawing.Point(1079, 623);
            this.totalNetLabel.Name = "totalNetLabel";
            this.totalNetLabel.Size = new System.Drawing.Size(57, 17);
            this.totalNetLabel.TabIndex = 4;
            this.totalNetLabel.Text = "totalNet";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 623);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 17);
            this.label5.TabIndex = 5;
            this.label5.Text = "Total";
            // 
            // totalCostLabel
            // 
            this.totalCostLabel.AutoSize = true;
            this.totalCostLabel.Location = new System.Drawing.Point(632, 623);
            this.totalCostLabel.Name = "totalCostLabel";
            this.totalCostLabel.Size = new System.Drawing.Size(63, 17);
            this.totalCostLabel.TabIndex = 6;
            this.totalCostLabel.Text = "totalCost";
            this.totalCostLabel.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-3, 650);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Total Days";
            // 
            // lostDaysLabel
            // 
            this.lostDaysLabel.AutoSize = true;
            this.lostDaysLabel.Location = new System.Drawing.Point(854, 650);
            this.lostDaysLabel.Name = "lostDaysLabel";
            this.lostDaysLabel.Size = new System.Drawing.Size(62, 17);
            this.lostDaysLabel.TabIndex = 8;
            this.lostDaysLabel.Text = "lostDays";
            // 
            // scrapDaysLabel
            // 
            this.scrapDaysLabel.AutoSize = true;
            this.scrapDaysLabel.Location = new System.Drawing.Point(965, 650);
            this.scrapDaysLabel.Name = "scrapDaysLabel";
            this.scrapDaysLabel.Size = new System.Drawing.Size(75, 17);
            this.scrapDaysLabel.TabIndex = 9;
            this.scrapDaysLabel.Text = "scrapDays";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1194, 681);
            this.Controls.Add(this.scrapDaysLabel);
            this.Controls.Add(this.lostDaysLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.totalCostLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.totalNetLabel);
            this.Controls.Add(this.totalScrapLabel);
            this.Controls.Add(this.totalLostLabel);
            this.Controls.Add(this.totalSalesLabel);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label totalSalesLabel;
        private System.Windows.Forms.Label totalLostLabel;
        private System.Windows.Forms.Label totalScrapLabel;
        private System.Windows.Forms.Label totalNetLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label totalCostLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lostDaysLabel;
        private System.Windows.Forms.Label scrapDaysLabel;
    }
}