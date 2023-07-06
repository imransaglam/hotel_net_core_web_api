using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebApiJwt.Models
{
    //Token oluşturmak
    public class CreateToken
    {
        public string TokenCreate() 
        {
            var bytes = Encoding.UTF8.GetBytes("aspnetcoreapiapi");
            SymmetricSecurityKey key = new SymmetricSecurityKey(bytes);
            SigningCredentials credentials=new SigningCredentials(key,SecurityAlgorithms.HmacSha256);//HmacSha256=şifreleme algoritması 
            JwtSecurityToken token = new JwtSecurityToken(issuer:"http//localhost",audience:"http//localhost",
                notBefore:DateTime.Now,expires:DateTime.Now.AddMinutes(5),signingCredentials:credentials);//notbefore:neyden önce(DateTime.Now=önceden oluşturmuş olmalı),expires:tokenın geçerlilik süresi
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();//oluşturucu
            return handler.WriteToken(token);//token yaz

            //claim rollerin içeriği
        
        }
        public string TokenCreateAdmin() 
        {
            var bytes = Encoding.UTF8.GetBytes("aspnetcoreapiapi");
            SymmetricSecurityKey key=new SymmetricSecurityKey(bytes);
            SigningCredentials credentials = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier,Guid.NewGuid().ToString()),//name'in id değeri oluyor guid sayesinde
                new Claim(ClaimTypes.Role,"Admin"),
                new Claim(ClaimTypes.Role,"Visitor")
            };
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(issuer: "http://localhost", audience: "http://localhost",
                notBefore:DateTime.Now,expires:DateTime.Now.AddSeconds(30),signingCredentials:credentials,claims:claims);
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            return handler.WriteToken(jwtSecurityToken);
        }
    }
}
