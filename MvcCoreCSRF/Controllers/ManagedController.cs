using Microsoft.AspNetCore.Mvc;

namespace MvcCoreCSRF.Controllers
{
    public class ManagedController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //Funcion para el login
        [HttpPost]
        public IActionResult Login(string usuario, string password)
        {
            if(usuario.ToLower() == "admin" && password.ToLower() == "admin")
            {
                //ALMACENAMOS EL USUARIO EN SESSION
                HttpContext.Session.SetString("USUARIO", usuario);
                return RedirectToAction("Productos", "Tienda");
            }
            else
            {
                ViewData["MENSAJE"] = "Usuario/Password incorecctos";
                return View();
            }
        }

        //Cuando se niega el acceso
        public IActionResult AccesoDenegado()
        {
            return View();
        }

    }
}
