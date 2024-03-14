
namespace Domain.Entity;
public class Rol : BaseEntity
{
    public string Nombre {get; set;}
    public virtual ICollection<Usuario> Usuarios {get; set;}
}