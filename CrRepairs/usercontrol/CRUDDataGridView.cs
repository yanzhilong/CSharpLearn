using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using xyz.ibean.model;
using MySql.Data.MySqlClient;
using System.Collections;

namespace CrRepairs.usercontrol
{
    public partial class CRUDDataGridView : UserControl
    {
        private RowSelect rowsele;
        private DataTable MdataTable;

        public RowSelect Rowsele
        {
            get
            {
                return rowsele;
            }

            set
            {
                rowsele = value;
            }
        }

        public CRUDDataGridView()
        {
            InitializeComponent();
        }


        public void loadData(DataTable dataTable)
        {
            //自动列宽
            MdataTable = dataTable;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.DataSource = dataTable;
            dataGridView1.ReadOnly = true;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(this.rowsele == null)
            {
                return;
            }
            Hashtable hashtable = new Hashtable();
            //foreach (DictionaryEntry dict in titles)
            //{
            //    string key = (string)dict.Key;
            //    string value = dataGridView1.SelectedRows[0].Cells[(string)dict.Value].Value.ToString();
            //    hashtable.Add(key,value);
            //}
            //idtb.Text = dataGridView1.SelectedCells[0].Value.ToString();
            //nametb.Text = dataGridView1.SelectedCells[1].Value.ToString();
            //agetb.Text = dataGridView1.SelectedCells[2].Value.ToString();
            //dataGridView1.SelectedRows[0].Cells[""].Value.ToString();
            rowsele.rowSelect(hashtable);
        }

        public Hashtable getCurrentRowData()
        {
            //dataGridView1.CurrentRow.Index;
            Hashtable hashtable = new Hashtable();
            foreach (DataColumn dc in MdataTable.Columns)
            {
                string columName =  dc.ColumnName;
                string value = dataGridView1.CurrentRow.Cells[columName].Value.ToString();
                hashtable.Add(columName, value);
            }
            //foreach (DictionaryEntry dict in titles)
            //{
            //    string key = (string)dict.Key;
            //    string value = dataGridView1.CurrentRow.Cells[(string)dict.Value].Value.ToString();
            //    hashtable.Add(key, value);
            //}
            return hashtable;
        }

        public interface RowSelect{

            void rowSelect(Hashtable select);
        }

    }

}
