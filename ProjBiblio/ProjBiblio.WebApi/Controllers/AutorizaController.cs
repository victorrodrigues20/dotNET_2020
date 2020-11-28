using System.IdentityModel.Tokens.Jwt;
using System.Linq.Expressions;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProjBiblio.Application.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace ProjBiblio.WebApi.Controllers
{
    [ApiController]
    [ApiVersion ("1")]
    [Route ("v{version:apiVersion}/[controller]")]
    [Produces ("application/json")]
    public class AutorizaController : ControllerBase {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IConfiguration _configuration;

        public AutorizaController (UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            IConfiguration configuration) {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        [HttpGet]
        public ActionResult<string> Get () {
            return "AutorizaController :: Acessado em: " +
                DateTime.Now.ToLongDateString ();
        }

        [HttpPost ("register")]
        public async Task<ActionResult> RegisterUser ([FromBody] UsuarioDTO model) {
            var user = new IdentityUser {
                UserName = model.Email,
                Email = model.Email,
                EmailConfirmed = true
            };

            // Cria os usuários
            var result = await _userManager.CreateAsync (user, model.Password);

            if (!result.Succeeded) {
                return BadRequest (result.Errors);
            }

            await _signInManager.SignInAsync (user, false);
            return Ok (GeraToken (model));
            //return Ok();
        }

        [HttpPost ("login")]
        public async Task<ActionResult> Login ([FromBody] UsuarioDTO userInfo) {
            //verifica as credenciais do usuário e retorna um valor
            var result = await _signInManager.PasswordSignInAsync (userInfo.Email,
                userInfo.Password, isPersistent : false, lockoutOnFailure : false);

            if (result.Succeeded) {
                return Ok (GeraToken (userInfo));
                // return Ok();
            }

            ModelState.AddModelError (string.Empty, "Login Inválido....");
            return BadRequest (ModelState);
        }

        private UsuarioTokenDTO GeraToken (UsuarioDTO userInfo) {

            //define declarações do usuário
            var claims = new [] {
                new Claim (JwtRegisteredClaimNames.UniqueName, userInfo.Email),
                new Claim ("idade", "sorvete"),
                new Claim (JwtRegisteredClaimNames.Jti, Guid.NewGuid ().ToString ())
            };

            //gera uma chave com base em um algoritmo simetrico
            var key = new SymmetricSecurityKey (
                Encoding.UTF8.GetBytes (_configuration["Jwt:key"]));
            //gera a assinatura digital do token usando o algoritmo Hmac e a chave privada
            var credenciais = new SigningCredentials (key, SecurityAlgorithms.HmacSha256);

            //Tempo de expiracão do token.
            var expiracao = _configuration["TokenConfiguration:ExpireHours"];
            var expiration = DateTime.UtcNow.AddHours (double.Parse (expiracao));

            // classe que representa um token JWT e gera o token
            JwtSecurityToken token = new JwtSecurityToken (
                issuer: _configuration["TokenConfiguration:Issuer"],
                audience : _configuration["TokenConfiguration:Audience"],
                claims : claims,
                expires : expiration,
                signingCredentials : credenciais);

            //retorna os dados com o token e informacoes
            return new UsuarioTokenDTO () {
                Authenticated = true,
                    Token = new JwtSecurityTokenHandler ().WriteToken (token),
                    Expiration = expiration,
                    Message = "Token JWT OK"
            };
        }
    }
}