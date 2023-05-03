using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EasyMeterAPP.Controllers
{
    [AllowAnonymous]
    [Route("[controller]/[action]")]
    public class ConectarController : Controller
    {
        [HttpGet]
        public IActionResult BuscarToken()
        {
            var jwtSecurityToken = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("asdv234234^&%&^%&^hjsdfb2%%%");
            var jwtTokenDescriptor = new SecurityTokenDescriptor();

            jwtTokenDescriptor.Expires = DateTime.UtcNow.AddHours(2);
            jwtTokenDescriptor.SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);
            jwtTokenDescriptor.Subject = new ClaimsIdentity();
            jwtTokenDescriptor.Subject.AddClaim(new System.Security.Claims.Claim(ClaimTypes.Name, "Kaue Yorinori Souza"));

            var createToken = jwtSecurityToken.CreateToken(jwtTokenDescriptor);
            var token = jwtSecurityToken.WriteToken(createToken);


            return Ok(token);
        }


        //public string GerarToken(User user)
        //{
        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var key = Encoding.ASCII.GetBytes(Configuration.JwtKey);
        //    var claims = user.GetClaims();
        //    var tokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        Subject = new ClaimsIdentity(claims),
        //        Expires = DateTime.UtcNow.AddHours(8),
        //        SigningCredentials = new SigningCredentials(
        //            new SymmetricSecurityKey(key),
        //            SecurityAlgorithms.HmacSha256Signature)
        //    };
        //    var token = tokenHandler.CreateToken(tokenDescriptor);
        //    return tokenHandler.WriteToken(token);
        //}
    }
}
