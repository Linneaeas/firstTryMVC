using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using firstTryMVC.Models;

namespace firstTryMVC.Controllers;

public class CartController : Controller
{
    private readonly ILogger<ShopController> _logger;

    public CartController(ILogger<ShopController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}