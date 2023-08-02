using Data.Concretes.DbFirst;
using Entity.ModelsDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NLayer.API.Infrastructure.Tools;

namespace NLayerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly FirstDbContext _firstDbContext;

        public TokenController(FirstDbContext firstDbContext)
        {
            _firstDbContext = firstDbContext;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginDto u)
        {

            var username = _firstDbContext.AppUsers.Where(x => x.Username == u.UserName && x.Password == u.Password).Select(x => x.AppRole.Definition).FirstOrDefault();


            if (username != null)
            {
                LoginDto data = new LoginDto
                {
                    UserName = u.UserName,
                    Password = u.Password,
                    //Role = username


                };

                return Created("", JwtTokenGenerator.GenerateToken(data));
            }

            else
            {
                return BadRequest("Kullanıcı adi veya sifre hatali");
            }


        }
        [HttpGet("[action]")]
        [Authorize]
        public async Task<IActionResult> NetsisToken()
        {

            return Ok(TokenUret.Token());



        }


    }
}
