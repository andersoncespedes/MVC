using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models;
    public class ProductoDto
    {
        public string Nombre {get; set;}
        public string Codigo {get; set;}
        public double Precio {get; set;}
        public int Cantidad {get; set;}
    }