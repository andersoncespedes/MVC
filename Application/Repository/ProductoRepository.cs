using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entity;
using Domain.Interface;
using Persistence.Data;

namespace Application.Repository;
public class ProductoRepository : GenericRepository<Producto>, IProducto
{
    public ProductoRepository(DBContext Context) : base(Context)
    {
    }
}
