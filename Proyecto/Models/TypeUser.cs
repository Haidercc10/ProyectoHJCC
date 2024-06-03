using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto.Models
{
    public class TypeUser
    {
        [Key]
        public int TypeUser_Id { get; set; }

        [Column(TypeName = "varchar(100)")]
        public required string TypeUser_Name { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string? TypeUser_Description { get; set; }
    }
}
