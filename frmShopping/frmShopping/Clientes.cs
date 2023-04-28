using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace frmShopping
{
    class Clientes
    {
       int id_cliente, codigo_barras;

        public int Id_cliente { get => id_cliente; set => id_cliente = value; }
        public int Codigo_barras { get => codigo_barras; set => codigo_barras = value; }
    }
}
