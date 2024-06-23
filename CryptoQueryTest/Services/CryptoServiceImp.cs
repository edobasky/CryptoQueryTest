using CryptoQueryTest.Model;
using Newtonsoft.Json;
using RestSharp;
using System.Linq;

namespace CryptoQueryTest.Services
{
    public class CryptoServiceImp : ICryptoService
    {
        private readonly RestClient _client;
        private CryptoCurrencyResponse cryptos = new CryptoCurrencyResponse();

        public CryptoServiceImp()
        {
            _client = new RestClient("https://api.coincap.io/v2/");
            _client.AddDefaultHeader("Content-Type", "application/json");
        }

        public async Task<CryptoCurrencyResponse> GetAllCrypto()
        {

            return await CallExternalCryptoAPI();
        }
        public async Task<CryptoCurerency?> GetCryptoById(string Id)
        {
           
                var cryptosSearch = await CallExternalCryptoAPI();

                return cryptosSearch is not null ? cryptos.Data.FirstOrDefault(cr => cr.Id.Equals(Id)) : default(CryptoCurerency);
            
        }

        private async Task<CryptoCurrencyResponse> CallExternalCryptoAPI()
        {
            try
            {
                var request = new RestRequest("assets", Method.Get);

                var cryptoInfoRequest = await _client.ExecuteAsync<CryptoCurrencyResponse>(request);

                if (cryptoInfoRequest.IsSuccessStatusCode)
                {
                    var responseMap = JsonConvert.DeserializeObject<CryptoCurrencyResponse>(cryptoInfoRequest.Content);

                    if (responseMap is not null)
                    {
                        cryptos = responseMap;
                    }

                    return responseMap;
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("An error occured : {0}", ex.Message);
                // This would be logged to a file.....!
            }

            return default(CryptoCurrencyResponse);
        }

    }
}
