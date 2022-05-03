using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desafio7DaysOfCode
{
    public partial class FrmBemVindo : Form
    {
        public FrmBemVindo()
        {
            InitializeComponent();
        }

        private void buscarRaçasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBuscarRacas B = new FrmBuscarRacas();
            B.Show();
        }

        private void meusFavoritosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmFavoritos F = new FrmFavoritos();
            F.Show();
        }
    }
}
