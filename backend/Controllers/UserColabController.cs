using System.Security.Cryptography;
using System.Text;
using backend.Data;
using backend.Models.Domain;
using backend.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserColabController : ControllerBase
    {
        private readonly AppDbContext dbContext;

        public UserColabController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // Registro de Usuario
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserColabDTO request)
        {
            // Verificar si ya existe el usuario o email
            if (await dbContext.user_colaborator.AnyAsync(u => u.username== request.username|| u.email== request.email))
            {
                return BadRequest(new { Message = "Username o Email ya están en uso." });
            }

            // Crear hash de contraseña
            var passwordHash = HashPassword(request.password);

            var user = new UserColab
            {
                username = request.username,
                email= request.email,
                password_hash= passwordHash
            };

            await dbContext.user_colaborator.AddAsync(user);
            await dbContext.SaveChangesAsync();

            return Ok(new { Message = "Usuario registrado exitosamente." });
        }

        // Login de Usuario
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserColabLoginDTO request)
        {
            var user = await dbContext.user_colaborator.Where(u => u.username == request.username)
            .FirstOrDefaultAsync();


            if (user == null || !VerifyPassword(request.password, user.password_hash))
            {
                return Unauthorized(new { Message = "Credenciales incorrectas." });
            }

            return Ok(new { Message = "Login exitoso.", User = user});
        }

        // Métodos para hash y verificación de contraseñas
        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }

        private bool VerifyPassword(string password, string hashedPassword)
        {
            var passwordHash = HashPassword(password);
            return passwordHash == hashedPassword;
        }
    }
}
