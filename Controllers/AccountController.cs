using System.Collections.Generic;
using System.Linq;
using angularNet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
public class AccountController : Controller
{
    private readonly smart_financeContext database;
    public AccountController(smart_financeContext database)
    {
        this.database = database;

    }
    [HttpGet("")]
    public IList<AccountCategory> GetAllAccounts()
    {
        var account = this.database.AccountCategory.ToList();
        return account;
    }

    [HttpGet("{id}")]
    public AccountCategory GetAccount(int id)   {
        return this.database.AccountCategory.Find(id);        
    }

    [HttpPost("create")]
    public IActionResult create([FromBody]AccountCategory category)
    {   var cat = new AccountCategory() { Name = category.Name };
 
        this.database.Add(cat);
        this.database.SaveChanges();
        
        return new JsonResult(category);
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