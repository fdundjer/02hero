using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SimpleApp.Services
{
    internal class HttpRecipeRestService : IRecipeRestService
    {
        private static readonly string BaseUrl = "https://func-we-rest-test.azurewebsites.net/api";
        private static readonly string GetAllRecipesUrl = $"{BaseUrl}/recipes";
        private const string FunctionKeyHeader = "x-functions-key";
        private const string FunctionKey = "Qqe6h4MNxN4xTzA7UZmiD6KJkn81gLLjV8p09fQgkk6LssoRIBQmeA==";
        private readonly IHttpClientFactory _httpClientFactory;

        public HttpRecipeRestService(IHttpClientFactory httpClientFctory)
        {
            _httpClientFactory = httpClientFctory;
        }

        public async Task<object> GetRecipesAsync()
        {
            using (var httpClient = _httpClientFactory.CreateClient())
            {
                httpClient.DefaultRequestHeaders.Add(FunctionKeyHeader, FunctionKey);
                var uri = new Uri(GetAllRecipesUrl);
                var result = await httpClient.GetStringAsync(uri);
                return result;
            }
        }

        public async Task PostRecipe(object newRecipe)
        {
            using (var httpClient = _httpClientFactory.CreateClient())
            {
                httpClient.DefaultRequestHeaders.Add(FunctionKeyHeader, FunctionKey);
                var uri = new Uri(GetAllRecipesUrl);
                var content = new StringContent(null);
                var result = await httpClient.PostAsync(uri, content);
            }
        }
    }
}
