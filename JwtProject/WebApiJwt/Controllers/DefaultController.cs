using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiJwt.Models;

namespace WebApiJwt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        //http://localhost:5094/api/Default/Test token oluşturdu oluşan tokenı jwt.io adresinde kopyala ve decoded et
        [HttpGet("[action]")]   
        public IActionResult TokenOlustur() 
        {
            return Ok(new CreateToken().TokenCreate());
        }
        [HttpGet("[action]")]
        public IActionResult AdminTokenOlustur()
        {
            return Ok(new CreateToken().TokenCreateAdmin());
        }

        [Authorize]
        [HttpGet("[action]")] 
        public IActionResult Test2()
        {
            return Ok("Hoş Geldiniz");
        }

        [Authorize(Roles ="Admin,Visitor")]
        [HttpGet("[action]")]
        public IActionResult Test3()
        {
            return Ok("Token Başarılı bir şekilde giriş yaptı");
        }
    }
}
