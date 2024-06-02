using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Proyecto.Models
{
    public class Status_Type
    {
        [Key]
        public int Staty_Id { get; set; }

        [Column(TypeName = "varchar(100)")]
        public required string Staty_Name { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string? Staty_Description { get; set; }
    }
}
