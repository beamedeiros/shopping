using Ean13Barcode2005;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace frmShopping
{
    public partial class frmTelaCadastrar : Form
    {
        String codigo;
        LojaDAO lojaDAO = new LojaDAO();
        FuncionariosDAO funcionariosDAO = new FuncionariosDAO();
        Funcionarios funcionarios = new Funcionarios();

        // CÓDIGO PARA TIRAR FOTO COM A WEBCAM
        public DirectX.Capture.Filter Camera;
        public DirectX.Capture.Capture CaptureInfo;
        public DirectX.Capture.Filters CamContainer;
        Image capturaImagem;
        bool foto_tirada = false;

        public frmTelaCadastrar()
        {
            InitializeComponent();
        }

        
        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == string.Empty ||
               cbLojas.SelectedIndex == -1 ||
               mskCPF.MaskFull == false || 
               mskDataNasc.MaskFull == false ||
               mskRG.MaskFull == false ||
               cbCategoria.SelectedIndex == -1 ||
               foto_tirada == false)
            {
                if (foto_tirada == false)
                    MessageBox.Show("Tire uma foto para realizar o cadastro!");
                else
                {
                    MessageBox.Show("Favor preencher todos os campos!", "ALERTA!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    if (cbLojas.SelectedIndex == -1)
                        cbLojas.BackColor = Color.Red;
                    if (txtNome.Text == string.Empty)
                        txtNome.BackColor = Color.Red;
                    if (mskCPF.MaskFull == false)
                        mskCPF.BackColor = Color.Red;
                    if (mskDataNasc.MaskFull == false)
                        mskDataNasc.BackColor = Color.Red;
                    if (mskRG.MaskFull == false)
                        mskRG.BackColor = Color.Red;
                    if (cbCategoria.SelectedIndex == -1)
                        cbCategoria.BackColor = Color.Red;
                }
            }

            else
            {
                try
                {
                    List<String> lista_cpfs = new List<string>();
                    foreach(DataRow row in funcionariosDAO.listarCpfs().Rows)
                    {
                        lista_cpfs.Add(row["cpf_func"].ToString());
                    }

                    if (lista_cpfs.Contains(mskCPF.Text))
                    {
                        MessageBox.Show("CPF já cadastrado no sistema! Digite outro para cadastrar!");
                        mskCPF.BackColor = Color.Red;
                    }
                    else if (!Validacao.ValidaCPF.IsCpf(mskCPF.Text))
                    {
                        MessageBox.Show("CPF inválido! Digite outro para cadastrar!");
                        mskCPF.BackColor = Color.Red;
                    }
                    else
                    {
                        //1 PASSO - TRANSFERIR AS INFO´S PARA O
                        //OBJETO MODELO

                        funcionarios.Id_loja = Convert.ToInt32(cbLojas.SelectedValue.ToString());
                        funcionarios.Nome_func = txtNome.Text;
                        funcionarios.Rg_func = mskRG.Text;
                        funcionarios.Cpf_func = mskCPF.Text;
                        String foto = SalvarImagem();
                        funcionarios.Foto_func = foto;

                        switch (cbCategoria.SelectedIndex)
                        {
                            case 0:
                                funcionarios.Classificacao = "Lojista";
                                break;
                            case 1:
                                funcionarios.Classificacao = "Funcionário";
                                break;
                            case 2:
                                funcionarios.Classificacao = "Prestador de Serviço";
                                break;
                        }

                        GerarCodigo();
                        funcionarios.Codigo_barras = codigo;

                        funcionarios.Data_nasc = Convert.ToDateTime(mskDataNasc.Text);

                        funcionariosDAO.inserir(funcionarios);

                        MessageBox.Show("Funcionário cadastrado com sucesso!");

                        frmCodigoBarras frmCodigoBarras = new frmCodigoBarras(codigo, "Código de barras do funcionário");
                        frmCodigoBarras.ShowDialog();

                        Limpar();
                    }
                }
                catch(FormatException)
                {
                    MessageBox.Show("Erro! Por favor revise as informações!");
                }
            }
        }

        private void frmTelaCadastrar_Load(object sender, EventArgs e)
        {
            CarregarComboBoxLojas();
            try
            {
                cbCategoria.SelectedIndex = 0;
                cbLojas.SelectedIndex = 0;
            }
            catch { }
            CamContainer = new DirectX.Capture.Filters();
            try
            {
                int no_of_cam = CamContainer.VideoInputDevices.Count;

                for (int i = 0; i < no_of_cam; i++)
                {
                    try
                    {
                        // obtém o dispositivo de entrada do vídeo
                        Camera = CamContainer.VideoInputDevices[i];

                        // inicializa a Captura usando o dispositivo
                        CaptureInfo = new DirectX.Capture.Capture(Camera, null);

                        // Define a janela de visualização do vídeo
                        CaptureInfo.PreviewWindow = this.picWebcam;

                        // Capturando o tratamento de evento
                        CaptureInfo.FrameCaptureComplete += CapturarImagem;

                        // Captura o frame do dispositivo
                        CaptureInfo.CaptureFrame();
                        

                        // Se o dispositivo foi encontrado e inicializado então sai sem checar o resto
                        break;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }
        }

        private void CapturarImagem(PictureBox frame)
        {
            try
            {
                capturaImagem = frame.Image;
                this.picFoto.Image = capturaImagem;
                if(foto_tirada)
                    picWebcam.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro " + ex.Message);
            }
        }

        private void btnTirar_Click(object sender, EventArgs e)
        {
            if (btnTirar.Text == "Tirar foto")
            {
                try
                {
                    CaptureInfo.CaptureFrame();
                    foto_tirada = true;
                    btnTirar.Text = "Tirar outra";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao tirar foto da webcam!");
                }
            }
            else
            {
                try
                {
                    picWebcam.Visible = true;
                    CaptureInfo.CaptureFrame();
                    foto_tirada = false;
                    btnTirar.Text = "Tirar foto";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao tirar outra foto da webcam!");
                }
            }
            
        }

        private String SalvarImagem()
        {
            try
            {
                String caminhoImagemSalva = "fotos\\" + "FotoWebCam" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Millisecond.ToString() + ".jpg";
                picFoto.Image.Save(caminhoImagemSalva, ImageFormat.Jpeg);
                return caminhoImagemSalva;
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        private void CarregarComboBoxLojas()
        {
            cbLojas.DataSource = lojaDAO.listarTudo();
            cbLojas.DisplayMember = "nome_loja";
            cbLojas.ValueMember = "id_loja";
        }

        private void frmTelaCadastrar_FormClosing(object sender, FormClosingEventArgs e)
        {
            CaptureInfo.Stop();
            CaptureInfo.DisposeCapture();
            CaptureInfo.Close();
        }

        private void Limpar()
        {
            txtNome.Clear();
            mskCPF.Clear();
            mskDataNasc.Clear();
            mskRG.Clear();
            foto_tirada = false;
            picWebcam.Visible = true;
            try
            {
                cbCategoria.SelectedIndex = 0;
                cbLojas.SelectedIndex = 0;
            }
            catch { }
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            txtNome.BackColor = Color.Empty;
        }

        private void mskRG_TextChanged(object sender, EventArgs e)
        {
            mskRG.BackColor = Color.Empty;
        }

        private void mskCPF_TextChanged(object sender, EventArgs e)
        {
            mskCPF.BackColor = Color.Empty;
        }

        private void mskDataNasc_TextChanged(object sender, EventArgs e)
        {
            mskDataNasc.BackColor = Color.Empty;
        }

        private void GerarCodigo()
        {
            Random randomizador = new Random();
            codigo = "";
            while (codigo.Length < 13)
            {
                codigo = codigo + randomizador.Next(0, 9);
            }
        }
    }
}
