using System;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Order.domain.Entities;
using Order.domain.Interfaces;

namespace Order.infra.HttpRequests
{
    public class ProductRequest : IProductRequest
    {
        public Product GetProduct(int id)
        {
            var client = new HttpClient();

            try
            {
                var message = JsonConvert.SerializeObject(id);
                var request = new HttpRequestMessage(HttpMethod.Get, $"http://localhost:5002/v1/Product/{id}");
                request.Headers.Add("Accept", "application/json");
                request.Content = new StringContent(message.ToString(), Encoding.UTF8, "application/json");

                var response = client.SendAsync(request).Result;
                var result = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<Product>(result);
            }
            catch
            {
                throw new Exception("Produto não encontrado ou Serviço indisponível");
            }
        }
    }
}