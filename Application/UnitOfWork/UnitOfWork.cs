using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Repository;
using Domain.Interface;
using Persistence.Data;
namespace Application.UnitOfWork;
public class UnitOfWorks(DBContext context) : IUnitOfWork, IDisposable
{
    private IProducto _producto;
    private IRol _rol;
    private IUsuario _usuario;
    private ITipo _tipo;
    private readonly DBContext _context = context;
    public IProducto Productos 
    {
        get
        {
            _producto ??= new ProductoRepository(_context);
            return _producto;
        }
    }

    public IRol Roles 
    {
        get
        {
            _rol ??= new RolRepository(_context);
            return _rol;
        }
    }

    public ITipo Tipos 
    {
        get
        {
            _tipo ??= new TipoRepository(_context);
            return _tipo;
        }
    }

    public IUsuario Usuarios
    {
        get
        {
            _usuario ??= new UsuarioRepository(_context);
            return _usuario;
        }
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }
}