
using MVC.Helpers;
using Domain.Entity;
using Domain.Interface;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using AutoMapper;
using System.Security.Cryptography;
using Persistence.Data;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace MVC.Controllers;
[Authorize]
public class ProductoController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger<ProductoController> _logger;
    private readonly IHttpContextAccessor _contextAccessor;

    public ProductoController(ILogger<ProductoController> logger, IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContext)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _contextAccessor = httpContext;

    }
    public async Task<IActionResult> Index([FromQuery] Params Params){
        ClaimsPrincipal user = _contextAccessor.HttpContext.User;
        string NombreUsuario = "";
        if(!user.Identity.IsAuthenticated){
            return RedirectToAction("Login", "User");
        }
        NombreUsuario = user.Claims.Where(e => e.Type == ClaimTypes.Name).Select(e => e.Value).SingleOrDefault();
        ViewData["usuario"] = NombreUsuario;
        var labs = await _unitOfWork.Productos.Paginacion(Params.PageIndex, Params.PageSize, Params.Search);
        var map = _mapper.Map<List<ProductoDto>>(labs.registros);
        return View("Producto", new Pager<ProductoDto>(map, labs.totalRegistros, Params.PageIndex, Params.PageSize, Params.Search));
    }
    public async Task<IActionResult> SavePage(){
        IEnumerable<Tipo> lista = await _unitOfWork.Tipos.GetAll();
        return View("Guardar", lista);
    }
    [HttpPost]
    public async Task<IActionResult> Save( ProductoDto entity){
        
        Producto producto = _mapper.Map<Producto>(entity);
        byte[] salt = RandomNumberGenerator.GetBytes(9);
        producto.Codigo = Convert.ToBase64String(salt);
        _unitOfWork.Productos.Add(producto);
        await _unitOfWork.SaveAsync();
        return Redirect("Index");
    }
    [HttpPost]
    public async Task<IActionResult> Delete(int id){
        Producto producto = await _unitOfWork.Productos.GetById(id);
        if(producto == null){
            return View("Index");
        }
        _unitOfWork.Productos.Remove(producto);
        await _unitOfWork.SaveAsync();
        return Redirect("../Index");
    }
    public async Task<IActionResult> Store(int id){
        Producto producto = await _unitOfWork.Productos.GetById(id);
        IEnumerable<Tipo> lista = await _unitOfWork.Tipos.GetAll();
        if(producto == null){
            return View("Index", BadRequest());
        }
        ProductoDto prodDto = _mapper.Map<ProductoDto>(producto);
        return View("Update", new UpdateListDto{Producto = prodDto,Tipos =lista });
    }
}
