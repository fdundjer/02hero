using RestSharp;
using System.Threading.Tasks;

namespace SimpleApp.Services
{
    internal class RestSharpRecipeRestService : IRecipeRestService
    {
        private static readonly string BaseUrl = "https://func-we-rest-test.azurewebsites.net/api";
        private const string FunctionKeyHeader = "x-functions-key";
        private const string FunctionKey = "Qqe6h4MNxN4xTzA7UZmiD6KJkn81gLLjV8p09fQgkk6LssoRIBQmeA==";


        private RestClient _restClient;

        public RestSharpRecipeRestService()
        {
            _restClient = new RestClient(BaseUrl);
        }

        public async Task<object> GetRecipesAsync()
        {
            var request = new RestRequest("recipes")
                .AddHeader(FunctionKeyHeader, FunctionKey);

            var response = await _restClient.GetAsync(request);
            return response.Content;
        }

        public async Task PostRecipe(object newRecipe)
        {
            var request = new RestRequest("post")
                .AddHeader(FunctionKeyHeader, FunctionKey)
                .AddJsonBody(newRecipe);

            await _restClient.PostAsync(request);
        }
    }
}
