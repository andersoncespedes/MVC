using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entity;
public class Producto : BaseEntity
{
    public string Nombre {get; set;}
    public string Codigo {get; set;}
    public double Precio {get; set;}
    public int Cantidad {get;set;}
    public int IdTipoFk {get; set;}
    public virtual Tipo Tipo {get; set;}
}