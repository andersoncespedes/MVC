using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entity;

namespace MVC.Models;
public class UpdateListDto
{
    public IEnumerable<Tipo> Tipos {get; set;}
    public ProductoDto Producto {get; set;}
}