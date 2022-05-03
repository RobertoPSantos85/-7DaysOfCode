using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desafio7DaysOfCode.APIService
{
    public class CatAsService
    {
        public CatModel GetCaracteristica(string Id)
        {
            var client = new RestClient("https://api.thecatapi.com/v1/breeds");
            client.AddDefaultParameter("q", Id);
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {

                List<CatModel> resultados = JsonConvert.DeserializeObject<List<CatModel>>(response.Content.ToString());

                for (int i = 0; i < resultados.Count; i++)
                {
                    if (resultados[i].name == Id)
                    {
                        return resultados[i];
                    }

                }
                return null;
            }
            else
                return null;
        }

        public List<CatModel> ObterRacas(List<CatModel> raca)
        {
            var client = new RestClient("https://api.thecatapi.com/v1/breeds");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            
            if (response.StatusCode == HttpStatusCode.OK)
            {

                List<CatModel> resultados = JsonConvert.DeserializeObject<List<CatModel>>(response.Content.ToString());
                return resultados;
            }
            else
                return null;
        }

        public void PostFavorito(PostCatModel Gato)
        {
            
            
            var client = new RestClient("https://api.thecatapi.com/v1/favourites");
            client.Timeout = -1;
            RestRequest request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("x-api-key", "a953fc37-2308-4e91-8b8a-7d9d303a3d93");
            var body = JsonConvert.SerializeObject(Gato);
            request.AddParameter("application/json", body, ParameterType.RequestBody);

            var response = client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                MessageBox.Show("Raça favoritada com sucesso!");
            }
            else
                MessageBox.Show("Ops, houve erro no processamento.");
        }

        public List<PostCatModel> GetFavorito(List<PostCatModel> Favoritos)
        {
            var client = new RestClient("https://api.thecatapi.com/v1/favourites");
            client.Timeout = -1;
            RestRequest request = new RestRequest(Method.GET);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("x-api-key", "a953fc37-2308-4e91-8b8a-7d9d303a3d93");
            request.AlwaysMultipartFormData = true;
            IRestResponse response = client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                List<PostCatModel> favoritos = JsonConvert.DeserializeObject<List<PostCatModel>>(response.Content.ToString());
                return favoritos;
            }
            else
                return null;
        }

        public PostCatModel Delete(string Id)
        {
            var client = new RestClient("https://api.thecatapi.com/v1/favourites/{favourite_id}");
            client.Timeout = -1;
            var request = new RestRequest(Method.DELETE);
            request.AddHeader("x-api-key", "a953fc37-2308-4e91-8b8a-7d9d303a3d93");
            request.AddHeader("Content-Type", "application/json");
            request.AddUrlSegment("favourite_id", Id);
            request.AlwaysMultipartFormData = true;
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                MessageBox.Show("O gato foi removido da lista.");
                return null;
            }
            else
                MessageBox.Show("Ops! Ocorreu um erro ao excluir o gato selecionado.");
            return null;
        }
    }


}

