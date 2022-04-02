using Refit;
using SimpleApp.Rest;
using System.Threading.Tasks;

namespace SimpleApp.Services
{
    internal class RefitRecipeRestService : IRecipeRestService
    {
        private static readonly string BaseUrl = "https://func-we-rest-test.azurewebsites.net/api";

        public async Task<object> GetRecipesAsync()
        {
            var recipeApi = RestService.For<IRecipeApi>(BaseUrl);
            var response = await recipeApi.GetRecipesAsync();
            return response;
        }
    }
}
