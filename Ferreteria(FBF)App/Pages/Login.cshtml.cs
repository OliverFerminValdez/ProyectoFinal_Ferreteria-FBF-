using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Ferreteria_FBF_App.BLL;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ferreteria_FBF_App.Pages
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        public string ReturnUrl { get; set; }
        public async Task<IActionResult> OnGetAsync(string paramUsuario, string paramCOntraseña)
        {
            string returnUrl = Url.Content("~/");

            try
            {
                // Clear the existing external cookie
                await HttpContext
                    .SignOutAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme);
            }
            catch { }

            if (UsuariosBLL.ComprobarUsuario(paramUsuario, paramCOntraseña))
            {
                // *** !!! This is where you would validate the user !!! ***
                // In this example we just log the user in
                // (Always log the user in for this demo)
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, paramUsuario),
                    new Claim(ClaimTypes.Role, UsuariosBLL.GetNivelAcceso(paramUsuario)),
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true,
                    RedirectUri = this.Request.Host.Value
                };

                try
                {
                    await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);
                }
                catch (Exception ex)
                {
                    string error = ex.Message;
                }
            }

            return LocalRedirect(returnUrl);
        }
    }
}