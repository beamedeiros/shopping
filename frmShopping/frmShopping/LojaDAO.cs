using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace frmShopping
{
    class LojaDAO
    {

        Loja loja = new Loja();

        internal Loja Loja { get => loja; set => loja = value; }

        // variaveis para acessar o MySql
        MySqlDataAdapter comando_sql;
        MySqlCommandBuilder executar_comando;
        DataTable tabela_memoria;

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

        public void inserir(Loja loja)
        {
            executarComando("INSERT INTO LOJA VALUES (0,'" + loja.Nome_loja + "');");
        }


        public DataTable listarTudo()
        {
            executarComando("SELECT * FROM LOJA;");
            return tabela_memoria;
        }
    }
}
