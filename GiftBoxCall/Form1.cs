using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace GiftBoxCall
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.DataGrid mDataGrid;
        private MySqlConnection mConn;
        private MySqlDataAdapter mAdapter;
        private DataSet mDataSet;
        public Form1()
        {
            InitializeComponent();
            mDataSet = new DataSet();
            mConn = new MySqlConnection("server=192.168.0.14; database=line-feeder-db; uid=Luciano; pwd=Luciano405060#");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string MyConnect = "Server=192.168.0.14; Database=line-feeder-db; Uid=Luciano; Pwd=Luciano405060#";
                string Query = "UPDATE linhas SET status = 1 WHERE linha = 'W02'";
                MySqlConnection MyConn2 = new MySqlConnection(MyConnect);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2;
                MyConn2.Open();
                MyReader2 = MyCommand2.ExecuteReader();
                while (MyReader2.Read())
                {

                }
                MessageBox.Show(Query);
                MyConn2.Close();
            }catch(System.Exception error)
            {
                MessageBox.Show(error.Message.ToString());
            }
        }

        private void opçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 newForm2 = new Form2();
            newForm2.ShowDialog();
        }
    }
}
