using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Test_Versta24.Models;

namespace Test_Versta24.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}