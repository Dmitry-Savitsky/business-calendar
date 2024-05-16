using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using System.Threading.Tasks;
using System;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using EntityFrameworkCore.MySQL.Data;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly RepairManagementDbContext _context; // Ваш DbContext
        private readonly IConfiguration _configuration; // Для доступа к настройкам в appsettings.json

        public AuthController(RepairManagementDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public class CompanyRegistrationDto
        {
            public string CompanyName { get; set; }
            public string CompanyPhone { get; set; }
            public string CompanyAddress { get; set; }
            public string Login { get; set; }
            public string Password { get; set; }
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] CompanyRegistrationDto registrationDto)
        {
            if (registrationDto == null ||
                string.IsNullOrWhiteSpace(registrationDto.Password) ||
                string.IsNullOrWhiteSpace(registrationDto.Login))
            {
                return BadRequest("Invalid company data");
            }

            // Проверяем, существует ли уже компания с таким логином
            if (await _context.Companies.AnyAsync(x => x.Login == registrationDto.Login))
            {
                return BadRequest("Company with such login already exists");
            }

            // Создаем новый экземпляр Company и заполняем его данными из DTO
            var company = new Company
            {
                CompanyName = registrationDto.CompanyName,
                CompanyPhone = registrationDto.CompanyPhone,
                CompanyAddress = registrationDto.CompanyAddress,
                Login = registrationDto.Login,
                Password = BCrypt.Net.BCrypt.HashPassword(registrationDto.Password) // Хешируем пароль сразу
            };

            // Добавляем компанию в базу данных
            await _context.Companies.AddAsync(company);
            await _context.SaveChangesAsync();

            // Генерируем JWT токен
            var token = GenerateJwtToken(company);

            return Ok(new { token });
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            var company = await _context.Companies.SingleOrDefaultAsync(x => x.Login == loginRequest.Login);
            if (company == null || !BCrypt.Net.BCrypt.Verify(loginRequest.Password, company.Password))
            {
                return BadRequest("Invalid login or password");
            }

            var token = GenerateJwtToken(company);
            return Ok(new { token });
        }

        private string GenerateJwtToken(Company company)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, company.IdCompany.ToString()),
                new Claim(ClaimTypes.Name, company.CompanyName)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_configuration["Jwt:ExpireDays"]));

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Issuer"],
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

    public class LoginRequest
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}