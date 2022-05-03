using Desafio7DaysOfCode.APIService;
using RestSharp;
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
    public partial class FrmFavoritos : Form
    {
        private APIService.CatAsService ApiCatAsService;
        public FrmFavoritos()
        {
            InitializeComponent();
            ApiCatAsService = new APIService.CatAsService();

        }

        private void FrmFavoritos_Load(object sender, EventArgs e)
        {

            CarregaListaFavoritos();

        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            List<CatModel> ra = new List<CatModel>();
            List<CatModel> listacats = new List<CatModel>(ApiCatAsService.ObterRacas(ra));

            List<PostCatModel> fa = new List<PostCatModel>();
            List<PostCatModel> preferidos = new List<PostCatModel>(ApiCatAsService.GetFavorito(fa));


            if (LstFavorito.SelectedIndex != -1)
            {
                foreach (CatModel listacat in listacats)
                {
                    if (LstFavorito.SelectedItem.ToString() == listacat.name)
                    {
                        foreach (PostCatModel preferido in preferidos)
                        {
                            if (listacat.reference_image_id == preferido.image_id)
                            {
                                ApiCatAsService.Delete(preferido.id);
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecione a raça que deseja excluir da lista.");
            }
            
            CarregaListaFavoritos();
        }

        

        private void CarregaListaFavoritos()

        {
            LstFavorito.Items.Clear();

            List<CatModel> h = new List<CatModel>();
            List<CatModel> listacaths = new List<CatModel>(ApiCatAsService.ObterRacas(h));

            List<PostCatModel> z = new List<PostCatModel>();
            List<PostCatModel> preferidosz = new List<PostCatModel>(ApiCatAsService.GetFavorito(z));


            foreach (PostCatModel preferido in preferidosz)
            {
                foreach (CatModel listacat in listacaths)
                {
                    if (preferido.image_id == listacat.reference_image_id)
                    {
                        LstFavorito.Items.Add(listacat.name);
                    }
                }
            }
        }

    }
}


    

               
            
                
                
        

            
                    
                       
                        
             
                
                
        
    

