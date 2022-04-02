using System.Threading.Tasks;

namespace SimpleApp.Services
{
    public interface IRecipeRestService
    {
        Task<object> GetRecipesAsync();
    }
}
