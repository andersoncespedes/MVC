
using System.Data;
using MVC.Models;
using Persistence.Data;
using Domain.Entity;
using Domain.Interface;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
namespace MVC.Services;

public class UserService : IUserService
{
    private readonly DBContext _context;
    private readonly IPasswordHasher<Usuario> _passwordHasher;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IHttpContextAccessor _httpcontext;
    public UserService(DBContext context, IUnitOfWork unitOfWork, IPasswordHasher<Usuario> passwordHasher, IHttpContextAccessor httpContext){
        _context = context;
        _unitOfWork = unitOfWork;
        _passwordHasher = passwordHasher;
        _httpcontext = httpContext;
    }
    public async Task<string> RegisterUser(RegisterDto Model)
    {
        if(Model.Password != Model.PasswordConfirmation){
            throw new DataException("Las contraseñas no coinciden");
        }
        Usuario ? UsuarioEncontradoONull = _context.Usuarios.Where(e => e.Nombre == Model.Nombre).FirstOrDefault();
        if(UsuarioEncontradoONull != null) throw new Exception("Usuario Ya Registrado en la base de datos");
        Usuario NewUsuario = new()
        {
            Nombre = Model.Nombre,
            Email = Model.Email
        };
        NewUsuario.Password = _passwordHasher.HashPassword(NewUsuario, Model.Password);
        Rol rol = _unitOfWork.Roles.Find(e => e.Nombre == "Empleado").First();
        NewUsuario.Roles.Add(rol);
        _unitOfWork.Usuarios.Add(NewUsuario);
        int Saved = await _unitOfWork.SaveAsync();
        return "Usuario Registrado Exitosamente";
    }
    private Usuario FindUser(LoginDto login)
    {
        return _unitOfWork.Usuarios.Find(e => e.Email == login.Email).FirstOrDefault();
    }
    public async Task<string> Login(LoginDto login){
        Usuario usuarioFound = this.FindUser(login);
        if(usuarioFound == null)
        {
            return null;
        }
        PasswordVerificationResult result = _passwordHasher.VerifyHashedPassword(usuarioFound, usuarioFound.Password, login.Password );
        if(result == PasswordVerificationResult.Failed){
            return null;
        }
        List<Claim> claims = new List<Claim>(){
            new Claim(ClaimTypes.Name, usuarioFound.Email)
        };
        ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        AuthenticationProperties properties = new AuthenticationProperties(){
            AllowRefresh = true
        };
        await _httpcontext.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity), properties);
        return "Exito";
    }
}