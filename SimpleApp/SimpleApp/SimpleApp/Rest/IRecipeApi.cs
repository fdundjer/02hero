using Refit;
using System.Threading.Tasks;

namespace SimpleApp.Rest
{
    [Headers("x-functions-key", "Qqe6h4MNxN4xTzA7UZmiD6KJkn81gLLjV8p09fQgkk6LssoRIBQmeA==")]
    public interface IRecipeApi
    {
        [Get("/recipes")]
        Task<object> GetRecipesAsync();

        [Post("/recipes")]
        Task PostRecipe([Body] object newRecipe);
    }
}
