using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using OAuthApi.Models;

namespace OAuthApi.Controllers
{
    public class SignInController : ApiController
    {
        private TokenRepository TokenRepository { get; set; }

        public SignInController()
        {
            TokenRepository = new TokenRepository();
        }

        [Route("SignIn")]
        [HttpPost]
        public async Task<IHttpActionResult> PostClientCredentials(SignInRequest signInRequest)
        {
            var response = await TokenRepository.ValidateCredentialsAsync(signInRequest);
            return Ok(response);
        }
    }
}