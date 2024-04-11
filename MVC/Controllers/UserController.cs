using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using MVC.Services;

namespace MVC.Controllers;
public class UserController : Controller
{
    private readonly IUserService _service;
    public UserController(IUserService service)
    {
        _service = service;
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register(RegisterDto register )
    {
        await _service.RegisterUser(register);
        return RedirectToAction("Index", "Producto");
    }
    public async Task<IActionResult> RegisterView(){
        
        return View("Register", null);
    }
     public async Task<IActionResult> Login(LoginDto login)
     {
        string validacion = await _service.Login(login);
        return View("Register", null);
    }

}