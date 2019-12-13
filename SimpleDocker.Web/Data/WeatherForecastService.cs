using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDocker.Web.Data {

    public class JsonContent : StringContent {
        public JsonContent(object obj) :
            base(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json") { }
    }

    public class MyWebClient : WebClient {
        public MyWebClient() {
            BaseAddress = "http://34.70.167.135:6500/";
        }

        public async Task<TOut> GetJsonAsync<TOut>(string url) {
            try {
                var returnValue = this.DownloadString(url);
                return JsonConvert.DeserializeObject<TOut>(returnValue);
            } catch (Exception ex) {
                return default;
            }
        }
    }

    public class MyHttpClient : HttpClient {
        public MyHttpClient() {
            BaseAddress = new Uri("http://34.70.167.135:6500/");
            Timeout = TimeSpan.FromMinutes(5);
            MaxResponseContentBufferSize = 2147483647;
        }

        public async Task<TOut> PostJsonAsync<TOut, TIn>(string url, TIn model) {
            try {
                var response = await PostAsync(url, new JsonContent(model));
                var returnValue = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TOut>(returnValue);
            } catch (Exception ex) {
                return default;
            }
        }

        public async Task<TOut> GetJsonAsync<TOut>(string url) {
            try {
                var response = await GetAsync(url);
                var returnValue = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TOut>(returnValue);
            } catch (Exception ex) {
                return default;
            }
        }
    }

    public class WeatherForecastService {

        public Task<WeatherForecast[]> GetForecastAsync() {
            using (var httpClient = new MyWebClient()) {
                return httpClient.GetJsonAsync<WeatherForecast[]>("WeatherForecast");
            }
        }
    }
}