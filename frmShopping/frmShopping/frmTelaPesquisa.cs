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
    public partial class frmTelaPesquisa : Form
    {
        FuncionariosDAO funcionariosDAO = new FuncionariosDAO();
        Funcionarios funcionarios = new Funcionarios();

        int i;

        int qtdRegistro;

        String codFunc;

        public frmTelaPesquisa()
        {
            InitializeComponent();
        }

     
        private void frmTelaPesquisa_Load(object sender, EventArgs e)
        {
            
        }

        private void btnPesq_Click(object sender, EventArgs e)
        {
            if (funcionariosDAO.pesquisarFunc(txtPesq.Text) == true)
            {

                codFunc = funcionariosDAO.Funcionarios.Id_func.ToString();

                // PESQUISAR PARA 1 INFO NO BD
                lblNomeFunc.Text = funcionariosDAO.Funcionarios.Nome_func;
                lblRG.Text = funcionariosDAO.Funcionarios.Rg_func;
                lblCPF.Text = funcionariosDAO.Funcionarios.Cpf_func;
                lblDataNasc.Text = funcionariosDAO.Funcionarios.Data_nasc.ToLongDateString();
                lblCategoria.Text = funcionariosDAO.Funcionarios.Classificacao;
                lblNomeLoja.Text = funcionariosDAO.Funcionarios.Id_loja.ToString();
                //foto
                //código de barras

                btnExc.Enabled = true;
                ////////////////////////////

                // PESQUISAR PARA LISTA DE INFORMAÇÕES
                if (funcionariosDAO.ListaFunc != null)
                {
                    qtdRegistro = funcionariosDAO.ListaFunc.Rows.Count;

                    i = 0;

                    btnProximo.Enabled = true;
                }
                else
                {
                    btnProximo.Enabled = false;
                    btnAnterior.Enabled = false;
                }
                //////////////////////////////////////
            }
            else
            {
                MessageBox.Show("Funcionário não cadastrado!!!");
                Limpar();
                
                btnExc.Enabled = false;
            }

        }

        private void Limpar()
        {
            lblNomeFunc.Text = "";
            lblRG.Text = "";
            lblCPF.Text = "";
            lblDataNasc.Text = "";
            lblNomeLoja.Text = "";
            lblCategoria.Text = "";
            //foto
            //código de barras
        }

        private void btnExc_Click(object sender, EventArgs e)
        {
            DialogResult op;

            op = MessageBox.Show(
                "Deseja realmente excluir estas informações?",
                "Excluir funcionário!",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (op == DialogResult.Yes)
            {
                funcionariosDAO.excluir(codFunc);
                MessageBox.Show("Funcionário excluído com sucesso!!");
            }
            else
            {
                MessageBox.Show("Cancelado!!");
            }

            Limpar();
            
            btnExc.Enabled = false;

            btnProximo.Enabled = false;
            btnAnterior.Enabled = false;
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            btnProximo.Enabled = true;

            i--;

            if (i >= 0)
            {
                codFunc = funcionariosDAO.ListaFunc.Rows[i]["id_func"].ToString();
                                
                lblNomeLoja.Text = funcionariosDAO.ListaFunc.Rows[i]["Id_loja"].ToString();
                lblNomeFunc.Text = funcionariosDAO.ListaFunc.Rows[i]["Nome_func"].ToString();
                lblRG.Text = funcionariosDAO.ListaFunc.Rows[i]["Rg_func"].ToString();
                lblCPF.Text = funcionariosDAO.ListaFunc.Rows[i]["Cpf_func"].ToString();
                //funcionarios.Foto_func = tabela_memoria.Rows[0]["Foto_func"].ToString();
                lblCategoria.Text = funcionariosDAO.ListaFunc.Rows[i]["Classificacao"].ToString();
                //funcionarios.Codigo_barras = tabela_memoria.Rows[0]["Codigo_barras"].ToString();
                
                // arrumando a data quando exibimos em LABEL´S
                DateTime dataCorreta;
                dataCorreta = Convert.ToDateTime(funcionariosDAO.ListaFunc.Rows[i]["Data_nasc"].ToString());
                lblDataNasc.Text = dataCorreta.ToLongDateString();
                //////////////////////////////////////////////////////

                if (i == 0)
                    btnAnterior.Enabled = false;
            }
        }

        private void btnProximo_Click(object sender, EventArgs e)
        {
            btnAnterior.Enabled = true;

            i++;

            if (i < qtdRegistro)
            {
                codFunc = funcionariosDAO.ListaFunc.Rows[i]["id_func"].ToString();

                lblNomeLoja.Text = funcionariosDAO.ListaFunc.Rows[i]["Id_loja"].ToString();
                lblNomeFunc.Text = funcionariosDAO.ListaFunc.Rows[i]["Nome_func"].ToString();
                lblRG.Text = funcionariosDAO.ListaFunc.Rows[i]["Rg_func"].ToString();
                lblCPF.Text = funcionariosDAO.ListaFunc.Rows[i]["Cpf_func"].ToString();
                //funcionarios.Foto_func = tabela_memoria.Rows[0]["Foto_func"].ToString();
                lblCategoria.Text = funcionariosDAO.ListaFunc.Rows[i]["Classificacao"].ToString();
                //funcionarios.Codigo_barras = tabela_memoria.Rows[0]["Codigo_barras"].ToString();

                // arrumando a data quando exibimos em LABEL´S
                DateTime dataCorreta;
                dataCorreta = Convert.ToDateTime(funcionariosDAO.ListaFunc.Rows[i]["Data_nasc"].ToString());
                lblDataNasc.Text = dataCorreta.ToLongDateString();
                //////////////////////////////////////////////////////

                if (i == (qtdRegistro - 1))
                    btnProximo.Enabled = false;
            }
        }

    }
}
