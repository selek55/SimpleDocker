using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDocker.Web.Data {

    public class JsonContent : StringContent {
        public JsonContent(object obj) :
            base(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json") { }
    }

    public class MyClient : HttpClient {
        public MyClient() {
            BaseAddress = new Uri("https://10.128.0.3:5001/");
        }

        public async Task<TOut> PostJsonAsync<TOut, TIn>(string url, TIn model) {
            var response = await PostAsync(url, new JsonContent(model));
            var returnValue = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TOut>(returnValue);
        }

        public async Task<TOut> GetJsonAsync<TOut>(string url) {
            var response = await GetAsync(url);
            var returnValue = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TOut>(returnValue);
        }
    }

    public class WeatherForecastService {

        public Task<WeatherForecast[]> GetForecastAsync() {
            using (var httpClient = new MyClient()) {
                return httpClient.GetJsonAsync<WeatherForecast[]>("WeatherForecast");
            }
        }
    }
}