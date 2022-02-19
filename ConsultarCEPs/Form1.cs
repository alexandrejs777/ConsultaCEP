using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsultarCEPs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnConsultaCEP_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(mskConsultarCEP.Text))
            {
                using(var ws = new WSCorreios.AtendeClienteClient())
                {
                    try
                    {
                        var endereco = ws.consultaCEP(mskConsultarCEP.Text.Trim().Replace(".", "").Replace("-", ""));
                        txtRua.Text = endereco.end;
                        txtBairro.Text = endereco.bairro;
                        txtCidade.Text = endereco.cidade;
                        txtEstado.Text = endereco.uf;
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Informe um CEP válido!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            mskConsultarCEP.Text = String.Empty;
            txtRua.Text = String.Empty;
            txtBairro.Text = String.Empty;
            txtCidade.Text = String.Empty;
            txtEstado.Text = String.Empty;

        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
