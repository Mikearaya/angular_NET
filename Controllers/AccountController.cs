using System.Collections.Generic;
using System.Linq;
using angularNet.Models;
using angularNet.Repositories;
using angularNet.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
public class AccountController : Controller
{
    private readonly IAccountCategory database;
    public AccountController(IAccountCategory database)
    {
        this.database = database;

    }
    [HttpGet("")]
    public IEnumerable<AccountCategory> GetAllAccounts()
    {
         return   this.database.GetAll();
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(200, Type = typeof(AccountCategory))]
    [ProducesResponseType(400)]
    public IActionResult GetAccount(int id)   {
        if( id < 1) {
            return NotFound();
        }   else {
            return Ok(this.database.Get(id));
        }     
    }

    [HttpPost]
    public IActionResult create([FromForm] AccountCategory category)
    {   var cat = new AccountCategory() { Name = category.Name };
 
        this.database.Insert(cat);
        this.database.Save();
        
        return new JsonResult(cat);
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