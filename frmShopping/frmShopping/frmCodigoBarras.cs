using Ean13Barcode2005;
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
    public partial class frmCodigoBarras : Form
    {
        String codigo;
        CodigoBarras codigoBarras = null;
        public frmCodigoBarras(String codigo, String msg)
        {
            InitializeComponent();

            lblMsg.Text = msg;
            this.codigo = codigo;
        }

        private void GerarCodigoBarras()
        {
            codigoBarras = new CodigoBarras();
            codigoBarras.CountryCode = codigo.Substring(0, 2); // 2 digitos
            codigoBarras.ManufacturerCode = codigo.Substring(2, 5); // 5 digitos
            codigoBarras.ProductCode = codigo.Substring(7, 5); // 5 digitos
            if (Convert.ToInt32(codigo.Substring(12, 1)) > 0)
                codigoBarras.ChecksumDigit = codigo.Substring(12, 1); // 1 digito
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            System.Drawing.Printing.PrintDocument pd = new System.Drawing.Printing.PrintDocument();
            pd.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.pd_PrintPage);
            pd.Print();
        }

        private void pd_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs ev)
        {
            GerarCodigoBarras();
            codigoBarras.Scale = (float)Convert.ToDecimal("2,0");
            codigoBarras.DrawEan13Barcode(ev.Graphics, new System.Drawing.Point(0, 0));

            // Add Code here to print other information.
            ev.Graphics.Dispose();
        }

        private void frmCodigoBarras_Load(object sender, EventArgs e)
        {
            butDraw.PerformClick();
        }

        private void butDraw_Click(object sender, EventArgs e)
        {
            GerarCodigoBarras();

            System.Drawing.Graphics g = this.picCodigoBarras.CreateGraphics();
            g.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.SystemColors.Control),
                new Rectangle(0, 0, picCodigoBarras.Width, picCodigoBarras.Height));
            codigoBarras.Scale = (float)Convert.ToDecimal("2,0");
            codigoBarras.DrawEan13Barcode(g, new System.Drawing.Point(0, 0));
            g.Dispose();
        }
    }
}
