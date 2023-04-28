using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace frmShopping
{
    class FuncionariosDAO
    {
        Funcionarios funcionarios = new Funcionarios();

        internal Funcionarios Funcionarios { get => funcionarios; set => funcionarios = value; }

        // variaveis para acessar o MySql
        MySqlDataAdapter comando_sql;
        MySqlCommandBuilder executar_comando;
        DataTable tabela_memoria;

        // variável para carregar a lista de Alunos
        DataTable listaFunc;
        public DataTable ListaFunc { get => listaFunc; set => listaFunc = value; }


        // método private de acesso ao BD
        private void executarComando(string comando)
        {
            // criar uma sacolinha vazia
            tabela_memoria = new DataTable();

            // converter um texto (string) para um comando SQL
            comando_sql = new MySqlDataAdapter(comando, Conexao.Conectar);

            // executar o comando SQL 
            executar_comando = new MySqlCommandBuilder(comando_sql);

            // resposta que será armazenada 
            comando_sql.Fill(tabela_memoria);
        }

        public void inserir(Funcionarios funcionarios)
        {
            executarComando("INSERT INTO FUNCIONARIOS VALUES (0,'" + funcionarios.Id_loja + "','" + funcionarios.Nome_func + "','" + funcionarios.Rg_func + "','" + funcionarios.Cpf_func + "','" + funcionarios.Foto_func + "','" + funcionarios.Classificacao + "','" + funcionarios.Codigo_barras.ToString() + "','" + funcionarios.Data_nasc.ToString("yyyy/MM/dd") + "');");
        }

        public DataTable listarTudo()
        {
            executarComando("SELECT * FROM FUNCIONARIOS;");
            return tabela_memoria;
        }

        public DataTable listarCpfs()
        {
            executarComando("SELECT cpf_func FROM FUNCIONARIOS;");
            return tabela_memoria;
        }

        public Boolean pesquisarFunc(String nomePesquisado)
        {
            try
            {
                executarComando("SELECT * FROM FUNCIONARIOS F INNER JOIN LOJA L ON F.ID_LOJA = L.ID_LOJA WHERE F.NOME_FUNC = '" + nomePesquisado + "'");

                funcionarios.Id_func = Convert.ToInt32(tabela_memoria.Rows[0]["Id_func"].ToString());
                funcionarios.Id_loja = Convert.ToInt32(tabela_memoria.Rows[0]["Id_loja"].ToString());
                funcionarios.Nome_func = tabela_memoria.Rows[0]["Nome_func"].ToString();
                funcionarios.Rg_func = tabela_memoria.Rows[0]["Rg_func"].ToString();
                funcionarios.Cpf_func = tabela_memoria.Rows[0]["Cpf_func"].ToString();
                funcionarios.Foto_func = tabela_memoria.Rows[0]["Foto_func"].ToString();
                funcionarios.Classificacao = tabela_memoria.Rows[0]["Classificacao"].ToString();
                funcionarios.Codigo_barras = tabela_memoria.Rows[0]["Codigo_barras"].ToString();
                funcionarios.Data_nasc = Convert.ToDateTime(tabela_memoria.Rows[0]["Data_nasc"].ToString());

                if (tabela_memoria.Rows.Count > 1) // ou >=2
                {
                    listaFunc = tabela_memoria;
                }
                else
                {
                    listaFunc = null;
                }
                return true;
            }
            catch
            {
                return false;
            }

        }

        public void excluir(String idFuncPesquisado)
        {
            executarComando("DELETE FROM FUNCIONARIOS WHERE ID_FUNC='" + idFuncPesquisado + "';");
        }        
    }
}
