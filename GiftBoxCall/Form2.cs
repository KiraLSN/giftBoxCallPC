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
    public partial class Form2 : Form
    {
        private MySqlConnection mConn;
        private MySqlDataAdapter mAdapter;
        private DataSet mDataSet;

        public Form2()
        {
            InitializeComponent();
            mConn = new MySqlConnection("server=192.168.0.14; database=line-feeder-db; uid=Luciano; pwd=Luciano405060#");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string login = textBox1.Text;
            string senha = textBox2.Text;
            int i = 0;
            try
            {
                string MyConnect = "Server=192.168.0.14; Database=line-feeder-db; Uid=Luciano; Pwd=Luciano405060#";
                string Query = "SELECT login, senha FROM users WHERE login = '"+ login +"' and senha = '"+ senha +"'";
                MySqlConnection MyConn2 = new MySqlConnection(MyConnect);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2;
                MyConn2.Open();
                MyReader2 = MyCommand2.ExecuteReader();
                MessageBox.Show(login);
                MessageBox.Show(senha);
                while (MyReader2.Read())
                {
                    i++;
                }
                MessageBox.Show(Query);
                MyConn2.Close();
                if (i > 0)
                {
                    Form3 newForm3 = new Form3();
                    newForm3.ShowDialog();
                }
                this.Close();
            }
            catch (System.Exception error)
            {
                MessageBox.Show(login);
                MessageBox.Show(senha);
                MessageBox.Show(error.Message.ToString());
            }
        }

        
    }
}
