using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TRADE24.Data;
using TRADE24.Domain;

namespace TRADE24.Controllers
{
    public class AccountController : Controller
    {
        private readonly Trade24Context _context;
        public AccountController(Trade24Context context)
        {
            _context = context;
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([FromBody] LoginFormVM request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.Usuario) || string.IsNullOrWhiteSpace(request.Password))
            {
                return Json(new { success = false, message = "Datos incompletos." });
            }

            // Busca al usuario en tu tabla (ajusta según tu modelo generado por el scaffold)
            var usuarioDb = _context.SyUsers
                .FirstOrDefault(u => u.UserId == request.Usuario);

            if (usuarioDb == null || request.Password != usuarioDb.Password) //!VerificarPassword(request.Password, usuarioDb.Password))
            {
                return Json(new { success = false, message = "Usuario o contraseña incorrectos." });
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, usuarioDb.UserName ?? ""),
                new Claim(ClaimTypes.NameIdentifier, usuarioDb.UserId)
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                new AuthenticationProperties { IsPersistent = true });

            return Json(new { success = true, redirectUrl = Url.Action("Index", "Home") });
        }

        private bool VerificarPassword(string passwordIngresado, string passwordHashGuardado)
        {
            // Aquí deberías usar BCrypt o similar, nunca comparar texto plano
            return BCrypt.Net.BCrypt.Verify(passwordIngresado, passwordHashGuardado);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult ForgotPassword([FromBody] ForgotPasswordVM request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.UserId))
            {
                return Json(new { success = false, message = "Por favor ingresa tu ID de usuario." });
            }

            var usuarioDb = _context.SyUsers.FirstOrDefault(u => u.UserId == request.UserId);
            if (usuarioDb == null)
            {
                return Json(new { success = false, message = "El usuario especificado no fue encontrado en el sistema." });
            }

            return Json(new
            {
                success = true,
                message = $"Se ha enviado un correo con las instrucciones y el enlace para restablecer tu contraseña."
            });
        }
    }
}
