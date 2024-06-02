using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Proyecto.Models
{
    public class Status
    {
        [Key]
        public int Status_Id { get; set; }

        [Column(TypeName = "varchar(100)")]
        public required string Status_Name { get; set; }

        [Column(TypeName = "varchar(max)")]
        public required string Status_Description { get; set; }

        public int Staty_Id { get; set; }
        public Status_Type? Statuses_Types { get; set; }
    }
}
