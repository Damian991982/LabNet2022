using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using PracticaWebApi.Entities;
using PracticaWebApi.Entities.DTOs;
using Newtonsoft.Json;

namespace PracticaWebApi.Logic
{
    public class StoreApiLogic
    {
        public async Task<List<StoreApiDto>> GetProducts()
        {
            string apiUrl = "https://fakestoreapi.com/products";
            HttpClient httpClient = new HttpClient();

            try
            {
                string responseJson = await httpClient.GetStringAsync(apiUrl);

                List<StoreApiDto> products = JsonConvert.
                    DeserializeObject<List<StoreApiDto>>(responseJson);

                return products;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

    }
}
