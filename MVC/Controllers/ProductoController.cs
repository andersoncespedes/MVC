
using MVC.Helpers;
using Domain.Entity;
using Domain.Interface;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers;
public class ProductoController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    private readonly ILogger<ProductoController> _logger;
    public ProductoController(ILogger<ProductoController> logger, IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }
    public async Task<IActionResult> Index([FromQuery] Params Params){
        var labs = await _unitOfWork.Productos.Paginacion(Params.PageIndex, Params.PageSize, Params.Search);
        return View("Producto", new Pager<Producto>(labs.registros, labs.totalRegistros, Params.PageIndex, Params.PageSize, Params.Search));
    }
}
