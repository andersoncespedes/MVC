
using System.Data;
using MVC.Models;
using Persistence.Data;
using Domain.Entity;
using Domain.Interface;
using API.Helpers;
using Microsoft.AspNetCore.Identity;
namespace MVC.Services;
public class UserService : IUserService
{
    private readonly DBContext _context;
    private readonly IPasswordHasher<Usuario> _passwordHasher;
    private readonly IUnitOfWork _unitOfWork;
    public UserService(DBContext context, IUnitOfWork unitOfWork, IPasswordHasher<Usuario> passwordHasher){
        _context = context;
        _unitOfWork = unitOfWork;
        _passwordHasher = passwordHasher;
    }
    public async Task<string> RegisterUser(RegisterDto Model)
    {
        if(Model.Password != Model.PasswordConfirmation){
            throw new DataException("Las contraseñas no coinciden");
        }
        Usuario ? UsuarioEncontradoONull = _context.Usuarios.Where(e => e.Nombre == Model.Nombre).FirstOrDefault();
        if(UsuarioEncontradoONull != null) throw new Exception("Usuario Ya Registrado en la base de datos");
        Usuario NewUsuario = new Usuario
        {
            Nombre = Model.Nombre,
            Email = Model.Email
        };
        NewUsuario.Password = _passwordHasher.HashPassword(NewUsuario, Model.Password);
        Rol rol = _unitOfWork.Roles.Find(e => e.Nombre == Authorization.rol_default.ToString()).First();
        NewUsuario.Roles.Add(rol);
        _unitOfWork.Usuarios.Add(NewUsuario);
        int Saved = await _unitOfWork.SaveAsync();
        return "Usuario Registrado Exitosamente";
    }
}