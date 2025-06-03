using Microsoft.AspNetCore.Mvc;

namespace A_granel.Controllers
{
    // gerencia a página inicial
    public class HomeController : Controller
    {
        // método de ação para a página inicial
        public ActionResult Index()
        {
            // retorna a view padrao
            return View();
        }

    }
}