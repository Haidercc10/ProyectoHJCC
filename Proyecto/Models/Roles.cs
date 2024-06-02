using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto.Models
{
    public class Roles
    {
        [Key]
        public int Rol_Id { get; set; }

        [Column(TypeName = "varchar(100)")]
        public required string Rol_Name { get; set; }

        [Column(TypeName = "varchar(max)")]
        public required string Rol_Description { get; set; }
    }
}
