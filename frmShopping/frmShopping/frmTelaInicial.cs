using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace frmShopping
{
    public partial class frmTelaInicial : Form
    {
        public frmTelaInicial()
        {
            InitializeComponent();
        }
        private void btnCadastro_Click(object sender, EventArgs e)
        {
            frmTelaCadastrar tela = new frmTelaCadastrar();
            tela.ShowDialog();
            

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            MessageBox.Show(Conexao.criar_Conexao());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmCadastroLoja tela = new frmCadastroLoja();
            tela.ShowDialog();
        }

        private void btnPesq_Click(object sender, EventArgs e)
        {
            frmTelaPesquisa tela = new frmTelaPesquisa();
            tela.ShowDialog();
        }
    }
}
