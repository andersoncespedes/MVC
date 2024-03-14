
namespace Domain.Entity;
public class Tipo : BaseEntity
{
    public string Nombre { get; set; }
    public virtual ICollection<Producto> Productos {get; set;}
}