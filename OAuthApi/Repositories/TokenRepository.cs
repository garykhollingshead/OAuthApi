using System.Threading.Tasks;
using OAuthApi.Models;

namespace OAuthApi.Controllers
{
    public class TokenRepository
    {
        private SqlAdapter SqlAdapter { get; set; }

        public TokenRepository()
        {
            SqlAdapter = new SqlAdapter();
        }

        public async Task<TokenResponse> ValidateCredentialsAsync(SignInRequest signInRequest)
        {
            var response = new TokenResponse();

            var credentail = await SqlAdapter.GetClientCredentailsAsync(signInRequest);

            return response;
        }
    }
}