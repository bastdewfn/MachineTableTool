using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MachineTableTool
{
    public partial class Form1 : Form
    {
        static string connectStr= System.Configuration.ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
        MySql.Data.MySqlClient.MySqlConnection MySqlConnection = new MySql.Data.MySqlClient.MySqlConnection(connectStr);
        public Form1()
        {
            InitializeComponent();
        }
       

       

        private DataTable queryTable(String sql) {
            MySql.Data.MySqlClient.MySqlDataAdapter mySqlDataAdapter = new MySql.Data.MySqlClient.MySqlDataAdapter(new MySql.Data.MySqlClient.MySqlCommand(sql, MySqlConnection));
            DataTable dt = new DataTable();
            mySqlDataAdapter.Fill(dt);
            return dt;
        }
        private bool exec(String sql) {
            MySql.Data.MySqlClient.MySqlCommand command = new MySql.Data.MySqlClient.MySqlCommand(sql, MySqlConnection);
            try
            {
                MySqlConnection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误:"+ex.Message);
            }
            finally {
                MySqlConnection.Close();
            }
            return false;
        }
        private Object execOne(String sql)
        {
            MySql.Data.MySqlClient.MySqlCommand command = new MySql.Data.MySqlClient.MySqlCommand(sql, MySqlConnection);
            try
            {
                MySqlConnection.Open();
                return command.ExecuteScalar() ;
            }
            finally
            {
                MySqlConnection.Close();
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            string t = this.cbxTableName.Text.Trim();
            this.cbxTableName.DataSource = getAllTable();
            this.cbxTableName.Text = t;
        }

        

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (this.cbxTableName.Text.Trim() == "")
            {
                MessageBox.Show("选择表;"); return;
            }
            this.btnCreate.Enabled = false;
            String sourceTable = this.cbxTableName.Text.Trim();
            if (Regex.IsMatch(sourceTable, "[_]\\d{6}$")){
                sourceTable = sourceTable.Substring(0, sourceTable.Length - 7);
            }
            int num = int.Parse(this.txtCreateNumber.Text.Trim());
            DateTime startTableTime = this.dtpCreateStart.Value;
            if (DialogResult.No == MessageBox.Show("是否生成表!", "确认", MessageBoxButtons.YesNo,MessageBoxIcon.Information,MessageBoxDefaultButton.Button2)){
                this.btnCreate.Enabled = true;
                return;
            }
            int r = 0;
            for (int i = 0; i < num; i++)
            {
                String targetTable = sourceTable + "_" + startTableTime.AddMonths(i).ToString("yyyyMM");
                object exists= execOne(String.Format("SELECT * FROM information_schema.tables WHERE table_schema = 'TCBUSTicketMachineSystem' AND table_name = '{0}'", targetTable));
                if (exists == null) {
                    r += (exec(String.Format(" CREATE TABLE {0} LIKE {1};", targetTable, sourceTable)) ? 1 : 0);
                }
            }
            MessageBox.Show("共生成" + r + "张表");
            Form1_Load(null, null);
            this.btnCreate.Enabled = true;
        }

        private List<String> getAllTable() {
            List<String> list = new List<string>();
            DataTable dataTable = queryTable("SHOW TABLES;");
             foreach (DataRow row in dataTable.Rows)
            {
                list.Add(row["Tables_in_TCBUSTicketMachineSystem"].ToString());
            }
            return list;
        }

        private void btnCompare_Click(object sender, EventArgs e)
        {
            if (this.cbxTableName.Text.Trim() == "")
            {
                MessageBox.Show("选择表;"); return;
            }
            this.btnCompare.Enabled = false;
            String sourceTable = this.cbxTableName.Text.Trim();
            if (Regex.IsMatch(sourceTable, "[_]\\d{6}$"))
            {
                sourceTable = sourceTable.Substring(0, sourceTable.Length - 7);
            }
            List<String> tables = getAllTable().Where(item => item!= this.cbxTableName.Text.Trim()&& (item== sourceTable || item.StartsWith(sourceTable+"_"))).ToList();

            DataTable dataTable = queryTable("SHOW COLUMNS  FROM " + this.cbxTableName.Text.Trim());
            DataTable indexTable = queryTable("SHOW Index  FROM " + this.cbxTableName.Text.Trim());


            this.dataGridView1.Rows.Clear();
            
            foreach (var item in tables)
            {
                DataTable dataTableTarget = queryTable("SHOW COLUMNS  FROM " + item);

                Dictionary<string,string> differentCloums= getDifferentCloums(dataTable, dataTableTarget,item) ;

                DataTable indexTableTarget = queryTable("SHOW INDEX  FROM " + item);

                List<string> differentIndex = getDifferentIndex(indexTable, indexTableTarget);

                if (differentCloums.Count > 0 || differentIndex.Count > 0)
                {
                    dataGridView1.Rows.Add( new string[] { item,"否", String.Join(",", differentCloums.Select(item=>item.Key)), String.Join(",", differentIndex) });
                }
                else {
                    dataGridView1.Rows.Add( new string[] { item, "是"});
                }
            } 

     
            Form1_Load(null, null);
            this.btnCompare.Enabled = true;
        }
        private string convertAlterTableSql(DataRow item,string tableName,bool alter=true) {
            return String.Format("ALTER TABLE {0} {7} {1} {2} {3} {4} {5} {6};", tableName,
                            item["Field"].ToString(), item["Type"].ToString(), item["Null"].Equals("NO") ? "NOT NULL" : "",
                             (item["Default"] is System.DBNull)?"": item["Default"].ToString()== "CURRENT_TIMESTAMP" ? "DEFAULT CURRENT_TIMESTAMP" : "DEFAULT '" + item["Default"].ToString()+ "'", item["Extra"].ToString(), item["Key"].Equals("PRI") ? "PRIMARY KEY" : "",
                            alter? "MODIFY":"ADD");
        }
        private Dictionary<string, string> getDifferentCloums(DataTable sourceTable,DataTable targetTable,string tableName) {
            Dictionary<string,string> differentCloums = new Dictionary<string,string>();

            foreach (DataRow item in sourceTable.Rows)
            {
                DataRow findRow = targetTable.Select("Field='" + item["Field"].ToString()+"'").FirstOrDefault();
                
                if (findRow == null)
                {
                    differentCloums.Add(item["Field"].ToString(), convertAlterTableSql(item, tableName,false));
                }
                else {
                    if (!findRow["Type"].Equals(item["Type"]))
                    {
                        differentCloums.Add(item["Field"].ToString(), convertAlterTableSql(item, tableName));
                    }
                    else if (!findRow["Null"].Equals( item["Null"])) {
                        differentCloums.Add(item["Field"].ToString(), convertAlterTableSql(item, tableName));
                    }
                    else if (!findRow["Key"].Equals(item["Key"])&& item["Key"].Equals("PRI"))
                    {
                        differentCloums.Add(item["Field"].ToString(), convertAlterTableSql(item, tableName));
                    }
                    else if (!findRow["Default"].Equals(item["Default"]))
                    {
                        differentCloums.Add(item["Field"].ToString(), convertAlterTableSql(item, tableName));
                    }
                    else if (!findRow["Extra"].Equals(item["Extra"]))
                    {
                        differentCloums.Add(item["Field"].ToString(), convertAlterTableSql(item, tableName));
                    }
                }

            }
            if (differentCloums.Count > 0) {
                return differentCloums;
             }
            if (sourceTable.Rows.Count != targetTable.Rows.Count)
            {
                differentCloums.Add("存在多余字段","");
            }
            return differentCloums;
        }

        private List<String> getDifferentIndex(DataTable sourceIndexTable, DataTable targetIndexTable)
        {

       

            HashSet<string> differentIndex = new HashSet<string>();

            foreach (DataRow item in sourceIndexTable.Rows)
            {
                DataRow findRow = targetIndexTable.Select("Key_name='" + item["Key_name"].ToString()+"' and Seq_in_index="+ item["Seq_in_index"]).FirstOrDefault();
                if (findRow==null)
                {
                    differentIndex.Add(item["Key_name"].ToString());
                }
                else
                {
                    if (!findRow["Column_name"].Equals(item["Column_name"]))
                    {
                        differentIndex.Add(item["Key_name"].ToString());
                    }
                    else if (!findRow["Index_type"].Equals(item["Index_type"]))
                    {
                        differentIndex.Add(item["Key_name"].ToString());
                    }
                    else if (!findRow["Non_unique"].Equals(item["Non_unique"]))
                    {
                        differentIndex.Add(item["Key_name"].ToString());
                    }
                }

            }

            if (differentIndex.Count > 0)
            {
                return differentIndex.ToList();
            }
            if (sourceIndexTable.Rows.Count != targetIndexTable.Rows.Count)
            {
                differentIndex.Add("存在多余索引");
            }
            return differentIndex.ToList();
        }

        private void btnIndex_Click(object sender, EventArgs e)
        {
            string s_indexsql= this.txtSourceIndexSql.Text.Trim();
            Match match= Regex.Match(s_indexsql, "alter\\s+table\\s+`?(?<tableName>\\S+?)`?\\s+(add|drop).+",RegexOptions.IgnoreCase);
            if (!match.Success) {
                MessageBox.Show("不是正规修改或创建index语句");
                return;
            }
            string sourceTable = match.Groups["tableName"].Value;
            if (Regex.IsMatch(sourceTable, "[_]\\d{6}$"))
            {
                sourceTable = sourceTable.Substring(0, sourceTable.Length - 7);
            }
            List<String> tables = getAllTable().Where(item =>  (item == sourceTable || item.StartsWith(sourceTable + "_"))).ToList();
            List<string> resultSql = new List<string>();
            foreach (var table in tables)
            {
                resultSql.Add(Regex.Replace(s_indexsql, "(alter\\s+table\\s+`?)(\\S+?)(`?\\s+(add|drop).+)", "$1"+table+"$3", RegexOptions.IgnoreCase) );
            }
            this.txtTargetIndexSql.Text = string.Join("\r\n", resultSql);

        }

        private void btnExecIndex_Click(object sender, EventArgs e)
        {

            if (this.txtTargetIndexSql.Text.Trim() == "") {
                MessageBox.Show("没有语句;");return;
            }
            if (DialogResult.No == MessageBox.Show("确定执行索引SQL!", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2))
            {
               
                return;
            }
            this.btnExecIndex.Enabled = false;
            try
            {
                exec(this.txtTargetIndexSql.Text.Trim());
            }
            catch (Exception ex) {
                MessageBox.Show("语句不正确;" + ex.Message);
            }
            this.btnExecIndex.Enabled = true;
        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            if (DialogResult.No == MessageBox.Show("是否同步表结构!", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2))
            {
                return;
            }
            this.btnSync.Enabled = false;

            String sourceTable = this.cbxTableName.Text.Trim();
            if (Regex.IsMatch(sourceTable, "[_]\\d{6}$"))
            {
                sourceTable = sourceTable.Substring(0, sourceTable.Length - 7);
            }
            List<String> tables = getAllTable().Where(item => item != this.cbxTableName.Text.Trim() && (item == sourceTable || item.StartsWith(sourceTable + "_"))).ToList();

            DataTable dataTable = queryTable("SHOW COLUMNS  FROM " + this.cbxTableName.Text.Trim());


            this.dataGridView1.Rows.Clear();

            foreach (var item in tables)
            {
                DataTable dataTableTarget = queryTable("SHOW COLUMNS  FROM " + item);

                Dictionary<string, string> differentCloums = getDifferentCloums(dataTable, dataTableTarget, item);


                if (differentCloums.Count > 0)
                {
                    differentCloums.Select(item => item.Value).ToList().ForEach(sql =>
                    {
                        exec(sql);
                    });
                }
            }

            MessageBox.Show("同步成功");

            this.btnCompare_Click(sender, e);

            this.btnSync.Enabled = true;
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            // 绘制行号
            var grid = sender as DataGridView;
            var rowNumber = (e.RowIndex + 1).ToString();
            var centerFormat = new StringFormat()
            {
                // 水平居中
                Alignment = StringAlignment.Center,
                // 垂直居中
                LineAlignment = StringAlignment.Center
            };
            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowNumber, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }
    }
    
}
