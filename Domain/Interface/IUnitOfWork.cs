using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interface;
public interface IUnitOfWork
{
    IProducto Productos {get;}
    IRol Roles{get;}
    ITipo Tipos {get;}
    IUsuario Usuarios {get;}
    Task<int> SaveAsync();
}
