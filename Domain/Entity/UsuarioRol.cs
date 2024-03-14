

namespace Domain.Entity;
public class UsuarioRol
{
    public int IdUsuarioFK {get; set;}
    public virtual Usuario Usuario {get; set;}
    public int IdRolFK {get;set;}
    public virtual Rol Rol {get;set;}  
}