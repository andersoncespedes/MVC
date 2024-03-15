using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entity;
using Domain.Interface;
using Persistence.Data;

namespace Application.Repository;
public class UsuarioRepository : GenericRepository<Usuario>, IUsuario
{
    public UsuarioRepository(DBContext Context) : base(Context)
    {
    }
}