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
using System.IO;
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
            string path = @"c:\CNMatching";
            if (!Directory.Exists(path))
            {
                
                Form2 newForm2 = new Form2();
                newForm2.ShowDialog();

            }

            StreamReader x;

            //Colocando o endereço físico (caminho do arquivo texto)


            //abrindo um arquivo texto indicado
            string caminho = @"c:\CNMatching\config.txt";
            x = File.OpenText(caminho);

            //lendo conteúdo da linha do arquivo texto
            string texto = x.ReadLine();
            var array = texto.Split(';');
            string linha = array[0];
            string modelo = array[1];
            label1.Text = linha;
            x.Close();

            mDataSet = new DataSet();
            mConn = new MySqlConnection("server=192.168.0.14; database=line-feeder-db; uid=Luciano; pwd=Luciano405060#");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamReader y;
            string caminho = @"c:\CNMatching\config.txt";
            y = File.OpenText(caminho);

            //lendo conteúdo da linha do arquivo texto
            string texto = y.ReadLine();
            var array = texto.Split(';');
            string linha = array[0];
            string modelo = array[1];
            label1.Text = linha;
            y.Close();
            
            if(button1.BackColor == Color.Gray)
            {
                try
                {
                    string MyConnect = "Server=192.168.0.14; Database=line-feeder-db; Uid=Luciano; Pwd=Luciano405060#";
                    string Query = "UPDATE linhas SET status = 1, modelo = '" + modelo + "' WHERE linha = '" + linha + "'";
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
                    button1.BackColor = Color.Azure;
                }
                catch (System.Exception error)
                {
                    MessageBox.Show(error.Message.ToString());
                }
            }
            else
            {
                try
                {
                    string MyConnect = "Server=192.168.0.14; Database=line-feeder-db; Uid=Luciano; Pwd=Luciano405060#";
                    string Query = "UPDATE linhas SET status = 0, modelo = '" + modelo + "' WHERE linha = '" + linha + "'";
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
                    button1.BackColor = Color.Gray;
                }
                catch (System.Exception error)
                {
                    MessageBox.Show(error.Message.ToString());
                }
            }

            
        }

        private void opçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Form2 newForm2 = new Form2();
            
            newForm2.ShowDialog();
            
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
