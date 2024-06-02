using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Proyecto.Models
{
    public class Document_Type
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column(TypeName = "varchar(100)")]
        public required string DocType_Id { get; set; }


        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DocType_Code { get; set; }


        [Column(TypeName = "varchar(100)")]
        public required string DocType_Name { get; set; }


        [Column(TypeName = "varchar(max)")]
        public string? DocType_Description { get; set; }
    }
}
