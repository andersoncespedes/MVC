
using MVC.Helpers;
using Domain.Entity;
using Domain.Interface;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using AutoMapper;

namespace MVC.Controllers;
public class ProductoController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger<ProductoController> _logger;

    public ProductoController(ILogger<ProductoController> logger, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<IActionResult> Index([FromQuery] Params Params){
        var labs = await _unitOfWork.Productos.Paginacion(Params.PageIndex, Params.PageSize, Params.Search);
        var map = _mapper.Map<List<ProductoDto>>(labs.registros);
        return View("Producto", new Pager<ProductoDto>(map, labs.totalRegistros, Params.PageIndex, Params.PageSize, Params.Search));
    }
    public IActionResult SavePage(){
        return View("Guardar");
    }
}
