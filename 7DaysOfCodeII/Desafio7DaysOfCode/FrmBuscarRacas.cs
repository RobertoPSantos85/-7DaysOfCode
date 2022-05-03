using Desafio7DaysOfCode.APIService;
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
    public partial class FrmBuscarRacas : Form
    {
        private APIService.CatAsService ApiCatAsService;
        public FrmBuscarRacas()
        {
            InitializeComponent();
            ApiCatAsService = new APIService.CatAsService();
        }

        private void FrmBuscarRacas_Load(object sender, EventArgs e)
        {
            List<CatModel> ra = new List<CatModel>();
            CarregaLista(ApiCatAsService.ObterRacas(ra));
        }

        private void BtnBuscar_Click_1(object sender, EventArgs e)
        {
            if (CbxRaca.SelectedIndex != -1)
            {

                string IdRaca = CbxRaca.Text;
                CargaResultado(ApiCatAsService.GetCaracteristica(IdRaca));
            }
            else
            {
                MessageBox.Show("Selecione uma Raça para buscar");
                LimpaResultados();
                CbxRaca.Focus();
            }
        }

        private void BtnFavoritar_Click_1(object sender, EventArgs e)
        {
            if (CbxRaca.SelectedIndex != -1)
            {
                string IdRaca = CbxRaca.Text;
                CriaGato(ApiCatAsService.GetCaracteristica(IdRaca));
            }
        }

        private void CarregaLista(List<CatModel> raca)
        {
            if (raca != null)
            {
                for (int a = 0; a < raca.Count; a++)
                {
                    CbxRaca.Items.Add(raca[a].name);
                }
            }
            else
                MessageBox.Show("Houve um erro ao resgatar a lista dos gatos");
            
        }

        private void CriaGato(CatModel miau)
        {
            PostCatModel gato = new PostCatModel();

            gato.id = "0";
            gato.image_id = miau.reference_image_id;
            gato.sub_id = miau.sub_id;
            ApiCatAsService.PostFavorito(gato);
        }

        private void CargaResultado(CatModel Resultado)
        {
            TxtDescricao.Text = Resultado.description;
            LblOrigem.Text = Resultado.origin;
            LblTemperamento.Text = Resultado.temperament;
        }

        private void LimpaResultados()
        {
            TxtDescricao.Text = "Resultado";
            LblOrigem.Text = "Resultado";
            LblTemperamento.Text = "Resultado";
        }

        
    }
}

