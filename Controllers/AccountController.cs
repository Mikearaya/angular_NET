using System.Linq;
using angularNet.Models;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
public class AccountController : Controller
{
    private readonly smart_financeContext database;
    public AccountController(smart_financeContext database)
    {
        this.database = database;

    }
    [HttpGet("")]
    public IActionResult Index()
    {
        var account = this.database.AccountCategory.ToArray();
        return new JsonResult(account);
    }
    [HttpPost("/create")]
    public IActionResult create(AccountCategory category)
    {   
        this.database.Add(category);
        this.database.SaveChanges();
        return new JsonResult(true);
    }
    public IActionResult Contact()
    {
        return View();
    }
    public IActionResult Error()
    {
        return View();
    }
}