
namespace MachineTableTool
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCreate = new System.Windows.Forms.Button();
            this.cbxTableName = new System.Windows.Forms.ComboBox();
            this.dtpCreateStart = new System.Windows.Forms.DateTimePicker();
            this.txtCreateNumber = new System.Windows.Forms.TextBox();
            this.btnCompare = new System.Windows.Forms.Button();
            this.btnSync = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnExecIndex = new System.Windows.Forms.Button();
            this.txtTargetIndexSql = new System.Windows.Forms.TextBox();
            this.txtSourceIndexSql = new System.Windows.Forms.TextBox();
            this.btnIndex = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(274, 48);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(124, 23);
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Text = "创建相同表";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // cbxTableName
            // 
            this.cbxTableName.FormattingEnabled = true;
            this.cbxTableName.Location = new System.Drawing.Point(112, 38);
            this.cbxTableName.Name = "cbxTableName";
            this.cbxTableName.Size = new System.Drawing.Size(309, 25);
            this.cbxTableName.TabIndex = 1;
            // 
            // dtpCreateStart
            // 
            this.dtpCreateStart.CustomFormat = "yyyy-MM";
            this.dtpCreateStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCreateStart.Location = new System.Drawing.Point(37, 133);
            this.dtpCreateStart.Name = "dtpCreateStart";
            this.dtpCreateStart.Size = new System.Drawing.Size(85, 23);
            this.dtpCreateStart.TabIndex = 2;
            // 
            // txtCreateNumber
            // 
            this.txtCreateNumber.Location = new System.Drawing.Point(148, 48);
            this.txtCreateNumber.Name = "txtCreateNumber";
            this.txtCreateNumber.Size = new System.Drawing.Size(75, 23);
            this.txtCreateNumber.TabIndex = 3;
            this.txtCreateNumber.Text = "12";
            // 
            // btnCompare
            // 
            this.btnCompare.Location = new System.Drawing.Point(23, 43);
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(124, 23);
            this.btnCompare.TabIndex = 4;
            this.btnCompare.Text = "比较表结构";
            this.btnCompare.UseVisualStyleBackColor = true;
            this.btnCompare.Click += new System.EventHandler(this.btnCompare_Click);
            // 
            // btnSync
            // 
            this.btnSync.Location = new System.Drawing.Point(251, 43);
            this.btnSync.Name = "btnSync";
            this.btnSync.Size = new System.Drawing.Size(147, 23);
            this.btnSync.TabIndex = 6;
            this.btnSync.Text = "同步表结构(不包括索引)";
            this.btnSync.UseVisualStyleBackColor = true;
            this.btnSync.Click += new System.EventHandler(this.btnSync_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "创建表开始月份";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Cornsilk;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtCreateNumber);
            this.panel1.Controls.Add(this.btnCreate);
            this.panel1.Location = new System.Drawing.Point(23, 87);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(422, 87);
            this.panel1.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(148, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "连续创建多少张表";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkGray;
            this.panel2.Controls.Add(this.btnSync);
            this.panel2.Controls.Add(this.btnCompare);
            this.panel2.Location = new System.Drawing.Point(23, 216);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(422, 102);
            this.panel2.TabIndex = 9;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Tan;
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.btnExecIndex);
            this.panel3.Controls.Add(this.txtTargetIndexSql);
            this.panel3.Controls.Add(this.txtSourceIndexSql);
            this.panel3.Controls.Add(this.btnIndex);
            this.panel3.Location = new System.Drawing.Point(23, 343);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(422, 437);
            this.panel3.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(23, 179);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 17);
            this.label5.TabIndex = 13;
            this.label5.Text = "生成后多表SQL语句";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(23, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "创建或修改索引语句";
            // 
            // btnExecIndex
            // 
            this.btnExecIndex.Location = new System.Drawing.Point(239, 147);
            this.btnExecIndex.Name = "btnExecIndex";
            this.btnExecIndex.Size = new System.Drawing.Size(124, 23);
            this.btnExecIndex.TabIndex = 10;
            this.btnExecIndex.Text = "执行生成索引语句";
            this.btnExecIndex.UseVisualStyleBackColor = true;
            this.btnExecIndex.Click += new System.EventHandler(this.btnExecIndex_Click);
            // 
            // txtTargetIndexSql
            // 
            this.txtTargetIndexSql.Location = new System.Drawing.Point(23, 199);
            this.txtTargetIndexSql.MaxLength = 50000;
            this.txtTargetIndexSql.Multiline = true;
            this.txtTargetIndexSql.Name = "txtTargetIndexSql";
            this.txtTargetIndexSql.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtTargetIndexSql.Size = new System.Drawing.Size(375, 206);
            this.txtTargetIndexSql.TabIndex = 9;
            this.txtTargetIndexSql.WordWrap = false;
            // 
            // txtSourceIndexSql
            // 
            this.txtSourceIndexSql.Location = new System.Drawing.Point(23, 33);
            this.txtSourceIndexSql.MaxLength = 1000;
            this.txtSourceIndexSql.Multiline = true;
            this.txtSourceIndexSql.Name = "txtSourceIndexSql";
            this.txtSourceIndexSql.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtSourceIndexSql.Size = new System.Drawing.Size(375, 93);
            this.txtSourceIndexSql.TabIndex = 8;
            this.txtSourceIndexSql.WordWrap = false;
            // 
            // btnIndex
            // 
            this.btnIndex.Location = new System.Drawing.Point(45, 147);
            this.btnIndex.Name = "btnIndex";
            this.btnIndex.Size = new System.Drawing.Size(124, 23);
            this.btnIndex.TabIndex = 7;
            this.btnIndex.Text = "获取相同表索引语句";
            this.btnIndex.UseVisualStyleBackColor = true;
            this.btnIndex.Click += new System.EventHandler(this.btnIndex_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "选择表";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Right;
            this.dataGridView1.Location = new System.Drawing.Point(532, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(649, 787);
            this.dataGridView1.TabIndex = 12;
            this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "table";
            this.Column1.FillWeight = 10F;
            this.Column1.HeaderText = "表名";
            this.Column1.MinimumWidth = 200;
            this.Column1.Name = "Column1";
            this.Column1.Width = 200;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "result";
            this.Column2.FillWeight = 5F;
            this.Column2.HeaderText = "相同";
            this.Column2.MinimumWidth = 50;
            this.Column2.Name = "Column2";
            this.Column2.Width = 50;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "columns";
            this.Column3.FillWeight = 210.0006F;
            this.Column3.HeaderText = "不同列";
            this.Column3.MinimumWidth = 50;
            this.Column3.Name = "Column3";
            this.Column3.Width = 193;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "indexs";
            this.Column4.FillWeight = 176.6497F;
            this.Column4.HeaderText = "不同索引";
            this.Column4.MinimumWidth = 50;
            this.Column4.Name = "Column4";
            this.Column4.Width = 163;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1181, 787);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpCreateStart);
            this.Controls.Add(this.cbxTableName);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "Form1";
            this.Text = "票机表结构比较工具(By wei.hu)";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.ComboBox cbxTableName;
        private System.Windows.Forms.DateTimePicker dtpCreateStart;
        private System.Windows.Forms.TextBox txtCreateNumber;
        private System.Windows.Forms.Button btnCompare;
        private System.Windows.Forms.Button btnSync;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtTargetIndexSql;
        private System.Windows.Forms.TextBox txtSourceIndexSql;
        private System.Windows.Forms.Button btnIndex;
        private System.Windows.Forms.Button btnExecIndex;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}

