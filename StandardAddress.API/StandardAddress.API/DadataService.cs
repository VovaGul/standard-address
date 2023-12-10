using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;
using Dadata.Model;
using System.Web.Http;

namespace StandardAddress.API
{
    public class DadataService
    {
        private readonly HttpClient _httpClient;
        private readonly DadataAuth _auth;

        public DadataService(HttpClient httpClient, IOptions<DadataAuth> options) 
        {
            _httpClient = httpClient;

            _auth = options.Value;
        }

        public async Task<Address> CleanAsync(string rawAddress)
        {
            string apiUrl = "https://cleaner.dadata.ru/api/v1/clean/address";
            string jsonPayload = $"[ \"{rawAddress}\" ]";

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, apiUrl);

            // Добавляем заголовки
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Authorization", $"Token {_auth.Token}");
            request.Headers.Add("X-Secret", _auth.Secret);

            // Устанавливаем полезную нагрузку
            request.Content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            // Выполняем запрос
            HttpResponseMessage response = await _httpClient.SendAsync(request);

            // Обработка ответа
            if (!response.IsSuccessStatusCode) 
                throw new HttpResponseException(response);

            var responseBody = await response.Content.ReadAsStringAsync();
            var address = JsonConvert.DeserializeObject<List<Address>>(responseBody);
            return address.First();

        }
    }
}
