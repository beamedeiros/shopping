using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace frmShopping
{
    class Funcionarios
    {

        String nome_func, rg_func, foto_func, classificacao, cpf_func, codigo_barras;
        int id_func, id_loja;
        DateTime data_nasc;

        // Váriavel para carregar FK
        String loja;

        public string Nome_func { get => nome_func; set => nome_func = value; }
        public string Rg_func { get => rg_func; set => rg_func = value; }
        public string Foto_func { get => foto_func; set => foto_func = value; }
        public string Classificacao { get => classificacao; set => classificacao = value; }
        public int Id_func { get => id_func; set => id_func = value; }
        public int Id_loja { get => id_loja; set => id_loja = value; }
        public String Codigo_barras { get => codigo_barras; set => codigo_barras = value; }
        public DateTime Data_nasc { get => data_nasc; set => data_nasc = value; }
        public string Loja { get => loja; set => loja = value; }
        public string Cpf_func { get => cpf_func; set => cpf_func = value; }
    }
}
