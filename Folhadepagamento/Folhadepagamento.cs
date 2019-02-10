using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Folhadepagamento
{
    public partial class Folhadepagamento : Form
    {
        public Folhadepagamento()
        {
            InitializeComponent();
        }

        void Principal()
        {
            int ht, nDep;
            double vh, sb, inss, salir, ir, sl;
            try
            {
                ht = int.Parse(txtHT.Text);
                vh = float.Parse(txtVH.Text);
                nDep = int.Parse(txtDep.Text);

                sb = ht * vh;
                inss = Taxas.CalculaINSS(sb);

                salir = sb - inss - (nDep * 144.20);
                ir = Taxas.CalculaIR(salir);

                sl = sb - inss - ir;

                lblSB.Text = sb.ToString("###,###,##0.00");
                lblINSS.Text = inss.ToString("###,###,##0.00");
                lblIR.Text = ir.ToString("###,###,##0.00");
                lblSL.Text = sl.ToString("###,###,##0.00");
            }
            catch(Exception caught)
            { MessageBox.Show("Erro: " + caught.Message); }
        }

        private void btnCalcula_Click(object sender, EventArgs e)
        {
            Principal();
        }

        private void btnLimpa_Click(object sender, EventArgs e)
        {
            txtNome.Clear();
            txtHT.Clear();
            txtVH.Clear();
            txtDep.Clear();
            lblSB.Clear();
            lblINSS.Clear();
            lblIR.Clear();
            lblSL.Clear();
        }

        private void btnFim_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Testes.consistLet(e.KeyChar);
        }

        private void txtHT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtNome.Text.Trim() == "")
            {
                MessageBox.Show("Preencha o nome do funcionário.");
                txtNome.Focus();

            }
            if (e.KeyChar == ',')
            {
                e.KeyChar = Testes.soumaVirgula(txtHT.Text);
            }
            e.KeyChar = Testes.consistNum(e.KeyChar);
        }

        private void txtVH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ',')
            {
                e.KeyChar = Testes.soumaVirgula(txtVH.Text);
            }
            e.KeyChar = Testes.consistNum(e.KeyChar);
        }

        private void txtDep_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 0) || (e.KeyChar == ','))
                    {
                MessageBox.Show("Número inválido.");
                e.KeyChar = (char)8;
            }

            if(e.KeyChar == 13)
            {
                Principal();
            }
        }
    }
}
