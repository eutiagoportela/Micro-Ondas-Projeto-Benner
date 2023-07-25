using Micro.Dominio.Account;
using Micro.WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Micro.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IAutenticacao _autenticacao;
        private readonly IConfiguration _config;
        private readonly ILogger<MicroProgramasController> _logger;

        public TokenController(IAutenticacao autenticacao, IConfiguration config, ILogger<MicroProgramasController> logger)
        {
            _autenticacao = autenticacao ?? throw new ArgumentNullException(nameof(autenticacao));
            _config = config;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpPost("LoginUser")]
        public async Task<ActionResult<UserToken>> Login([FromBody] LoginModel userInfo)
        {
            _logger.LogInformation("#### Post -> Login Usuario");

            var result = await _autenticacao.Autenticar(userInfo.Email, userInfo.Password);

            if (result)
                return GenerateToken(userInfo);
            else
            {
                ModelState.AddModelError(string.Empty, "Login inválido");
                return BadRequest(ModelState);
            }
        }

        [HttpPost("CriarUsuario")]
        public async Task<ActionResult> CriarUsuario([FromBody] LoginModel userInfo)
        {
            _logger.LogInformation("#### Post -> Criar Usuario");

            var result = await _autenticacao.RegistrarUsuario(userInfo.Email, userInfo.Password);

            if (result)
                return Ok($"User {userInfo.Email} Usuario criado com sucesso");
            else
            {
                ModelState.AddModelError(string.Empty, "Login ou Senha inválido");
                return BadRequest(ModelState);
            }
        }

        private UserToken GenerateToken(LoginModel userInfo)
        {
            //declarações do usuário
            var claims = new[]
            {
                new Claim("email", userInfo.Email),
                new Claim("valor", "valorOK"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            //gerar chave privada para assinar o token
            var privateKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_config["Jwt:SecretKey"]));

            //gerar a assinatura digital padrão SHA1 (256 bits) 
            var credentials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);

            //definir o tempo de expiração do Token
            var expiration = DateTime.UtcNow.AddMinutes(8);

            //gerar o token
            JwtSecurityToken token = new JwtSecurityToken(
                //emissor
                issuer: _config["Jwt:Issuer"],
                //audiencia
                audience: _config["Jwt:Audience"],
                //claims
                claims: claims,
                //data de expiracao
                expires: expiration,
                //assinatura digital
                signingCredentials: credentials
                );

            return new UserToken()//resposta do Token
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };
        }
    }
}
