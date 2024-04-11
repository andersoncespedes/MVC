using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entity;
    public class Usuario : BaseEntity
    {
        public string Nombre {get; set;}
        public string Email {get; set;}
        public string Password {get; set;}
        public virtual ICollection<Rol> Roles {get; set;} = new HashSet<Rol>() ;
        public ICollection<UsuarioRol> UsuarioRols {get; set;}
    }