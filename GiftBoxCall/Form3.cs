using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace GiftBoxCall
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = @"c:\CNMatching";
            if (!Directory.Exists(path))
            {
                DirectoryInfo di = Directory.CreateDirectory(path);
     
                StreamWriter x;

                //Colocando o caminho fisico e o nome do arquivo a ser criado
                //finalizando com .txt
                string CaminhoNome = @"c:\CNMatching\config.txt";

                //utilizando o método para criar um arquivo texto
                //e associando o caminho e nome ao metodo
                x = File.CreateText(CaminhoNome);
                x.Close();
                
            }
            string CaminhoConfig = @"c:\CNMatching\config.txt";
            StreamWriter y;
            
            y = File.CreateText(CaminhoConfig);

            //continuando escrevendo neste arquivo
            //escrevendo a partir da ultima linha 
            y.WriteLine(comboBox1.Text + ";"+comboBox2.Text) ;
            y.Close();

            this.Close();
        }
    }
}
