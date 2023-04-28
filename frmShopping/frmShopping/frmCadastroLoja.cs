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
    public partial class frmCadastroLoja : Form
    {

        LojaDAO lojaDAO = new LojaDAO();
        Loja loja = new Loja();

        public frmCadastroLoja()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {

            if (txtNomeLoja.Text == string.Empty)
            {
                MessageBox.Show("Favor preencher todos os campos!", "ALERTA!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                if (txtNomeLoja.Text == string.Empty)
                    txtNomeLoja.BackColor = Color.Red;

            }

            else
            {

                loja.Nome_loja = txtNomeLoja.Text;

                lojaDAO.inserir(loja);

                Limpar();

                MessageBox.Show("Loja cadastrado com sucesso!");

            }

        }

        private void Limpar()
        {
            txtNomeLoja.Clear();
        }

        private void txtNomeLoja_TextChanged(object sender, EventArgs e)
        {
            txtNomeLoja.BackColor = Color.Empty;
        }

    }
}
