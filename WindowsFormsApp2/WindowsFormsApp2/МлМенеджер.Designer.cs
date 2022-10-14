namespace WindowsFormsApp2
{
    partial class МлМенеджер
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
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.costInputForUpdateCost = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.updateCostButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.orderButton = new System.Windows.Forms.Button();
            this.feedCount = new System.Windows.Forms.NumericUpDown();
            this.feedInput = new System.Windows.Forms.ComboBox();
            this.кормBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.zooDataSet = new WindowsFormsApp2.ZooDataSet();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.кормTableAdapter = new WindowsFormsApp2.ZooDataSetTableAdapters.КормTableAdapter();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.costInputForUpdateCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.feedCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.кормBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zooDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(776, 414);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.costInputForUpdateCost);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.updateCostButton);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.orderButton);
            this.tabPage1.Controls.Add(this.feedCount);
            this.tabPage1.Controls.Add(this.feedInput);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(768, 388);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Склад";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // costInputForUpdateCost
            // 
            this.costInputForUpdateCost.DecimalPlaces = 2;
            this.costInputForUpdateCost.Location = new System.Drawing.Point(614, 201);
            this.costInputForUpdateCost.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.costInputForUpdateCost.Name = "costInputForUpdateCost";
            this.costInputForUpdateCost.Size = new System.Drawing.Size(120, 20);
            this.costInputForUpdateCost.TabIndex = 15;
            this.costInputForUpdateCost.ValueChanged += new System.EventHandler(this.costInputForUpdateCost_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(614, 184);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Введите стоимость";
            // 
            // updateCostButton
            // 
            this.updateCostButton.Location = new System.Drawing.Point(617, 226);
            this.updateCostButton.Name = "updateCostButton";
            this.updateCostButton.Size = new System.Drawing.Size(77, 38);
            this.updateCostButton.TabIndex = 6;
            this.updateCostButton.Text = "Изменить стоимость";
            this.updateCostButton.UseVisualStyleBackColor = true;
            this.updateCostButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(614, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Сумма: 0.00 р.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(614, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Количество";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(614, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Выберите корм";
            // 
            // orderButton
            // 
            this.orderButton.Location = new System.Drawing.Point(617, 133);
            this.orderButton.Name = "orderButton";
            this.orderButton.Size = new System.Drawing.Size(75, 23);
            this.orderButton.TabIndex = 3;
            this.orderButton.Text = "Заказать";
            this.orderButton.UseVisualStyleBackColor = true;
            this.orderButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // feedCount
            // 
            this.feedCount.Location = new System.Drawing.Point(614, 90);
            this.feedCount.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.feedCount.Name = "feedCount";
            this.feedCount.Size = new System.Drawing.Size(120, 20);
            this.feedCount.TabIndex = 2;
            this.feedCount.ValueChanged += new System.EventHandler(this.feedCount_ValueChanged);
            // 
            // feedInput
            // 
            this.feedInput.DataSource = this.кормBindingSource;
            this.feedInput.DisplayMember = "Наименование";
            this.feedInput.FormattingEnabled = true;
            this.feedInput.Location = new System.Drawing.Point(614, 41);
            this.feedInput.Name = "feedInput";
            this.feedInput.Size = new System.Drawing.Size(121, 21);
            this.feedInput.TabIndex = 1;
            this.feedInput.ValueMember = "id";
            this.feedInput.SelectedValueChanged += new System.EventHandler(this.feedInput_SelectedValueChanged);
            // 
            // кормBindingSource
            // 
            this.кормBindingSource.DataMember = "Корм";
            this.кормBindingSource.DataSource = this.zooDataSet;
            // 
            // zooDataSet
            // 
            this.zooDataSet.DataSetName = "ZooDataSet";
            this.zooDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(7, 7);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(570, 375);
            this.dataGridView1.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dataGridView3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(768, 388);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Расход";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dataGridView3
            // 
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(6, 7);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.Size = new System.Drawing.Size(756, 375);
            this.dataGridView3.TabIndex = 1;
            // 
            // кормTableAdapter
            // 
            this.кормTableAdapter.ClearBeforeFill = true;
            // 
            // МлМенеджер
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "МлМенеджер";
            this.Text = "Менеджер";
            this.Load += new System.EventHandler(this.МлМенеджер_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.costInputForUpdateCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.feedCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.кормBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zooDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button orderButton;
        private System.Windows.Forms.NumericUpDown feedCount;
        private System.Windows.Forms.ComboBox feedInput;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button updateCostButton;
        private ZooDataSet zooDataSet;
        private System.Windows.Forms.BindingSource кормBindingSource;
        private ZooDataSetTableAdapters.КормTableAdapter кормTableAdapter;
        private System.Windows.Forms.NumericUpDown costInputForUpdateCost;
    }
}