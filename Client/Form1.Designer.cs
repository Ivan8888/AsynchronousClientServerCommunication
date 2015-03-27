namespace Client
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.cmbProductInfo = new System.Windows.Forms.ComboBox();
            this.dgvProductOrders = new System.Windows.Forms.DataGridView();
            this.txtDisplayName = new System.Windows.Forms.TextBox();
            this.txtDisplayCurrency = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAveragePrice = new System.Windows.Forms.TextBox();
            this.chartQuantity = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label7 = new System.Windows.Forms.Label();
            this.btnRefreshData = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbProductInfo
            // 
            this.cmbProductInfo.FormattingEnabled = true;
            this.cmbProductInfo.Location = new System.Drawing.Point(25, 45);
            this.cmbProductInfo.Name = "cmbProductInfo";
            this.cmbProductInfo.Size = new System.Drawing.Size(121, 21);
            this.cmbProductInfo.TabIndex = 0;
            this.cmbProductInfo.SelectedIndexChanged += new System.EventHandler(this.cmbProductInfo_SelectedIndexChanged);
            this.cmbProductInfo.MouseEnter += new System.EventHandler(this.cmbProductInfo_MouseEnter);
            // 
            // dgvProductOrders
            // 
            this.dgvProductOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductOrders.Location = new System.Drawing.Point(25, 134);
            this.dgvProductOrders.Name = "dgvProductOrders";
            this.dgvProductOrders.Size = new System.Drawing.Size(356, 269);
            this.dgvProductOrders.TabIndex = 2;
            // 
            // txtDisplayName
            // 
            this.txtDisplayName.Location = new System.Drawing.Point(199, 45);
            this.txtDisplayName.Name = "txtDisplayName";
            this.txtDisplayName.ReadOnly = true;
            this.txtDisplayName.Size = new System.Drawing.Size(128, 20);
            this.txtDisplayName.TabIndex = 3;
            // 
            // txtDisplayCurrency
            // 
            this.txtDisplayCurrency.Location = new System.Drawing.Point(364, 45);
            this.txtDisplayCurrency.Name = "txtDisplayCurrency";
            this.txtDisplayCurrency.ReadOnly = true;
            this.txtDisplayCurrency.Size = new System.Drawing.Size(133, 20);
            this.txtDisplayCurrency.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Choose simbol";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(196, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(361, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Currency";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(564, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Average Price";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 105);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(179, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Chosen product in the last 50 entries";
            // 
            // txtAveragePrice
            // 
            this.txtAveragePrice.Location = new System.Drawing.Point(567, 46);
            this.txtAveragePrice.Name = "txtAveragePrice";
            this.txtAveragePrice.ReadOnly = true;
            this.txtAveragePrice.Size = new System.Drawing.Size(127, 20);
            this.txtAveragePrice.TabIndex = 12;
            // 
            // chartQuantity
            // 
            chartArea1.Name = "ChartArea1";
            this.chartQuantity.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartQuantity.Legends.Add(legend1);
            this.chartQuantity.Location = new System.Drawing.Point(387, 134);
            this.chartQuantity.Name = "chartQuantity";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Quantity";
            this.chartQuantity.Series.Add(series1);
            this.chartQuantity.Size = new System.Drawing.Size(540, 269);
            this.chartQuantity.TabIndex = 13;
            this.chartQuantity.Text = "chart1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(384, 105);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(181, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Cumulative quantity of chosen simbol";
            // 
            // btnRefreshData
            // 
            this.btnRefreshData.Location = new System.Drawing.Point(633, 75);
            this.btnRefreshData.Name = "btnRefreshData";
            this.btnRefreshData.Size = new System.Drawing.Size(210, 43);
            this.btnRefreshData.TabIndex = 15;
            this.btnRefreshData.Text = "Refresh Data";
            this.btnRefreshData.UseVisualStyleBackColor = true;
            this.btnRefreshData.Click += new System.EventHandler(this.btnRefreshData_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 415);
            this.Controls.Add(this.btnRefreshData);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.chartQuantity);
            this.Controls.Add(this.txtAveragePrice);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDisplayCurrency);
            this.Controls.Add(this.txtDisplayName);
            this.Controls.Add(this.dgvProductOrders);
            this.Controls.Add(this.cmbProductInfo);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbProductInfo;
        private System.Windows.Forms.DataGridView dgvProductOrders;
        private System.Windows.Forms.TextBox txtDisplayName;
        private System.Windows.Forms.TextBox txtDisplayCurrency;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAveragePrice;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartQuantity;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnRefreshData;
    }
}

