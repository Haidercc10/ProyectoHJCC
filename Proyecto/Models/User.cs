using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Us_Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Us_Code { get; set; }


        [Column(TypeName="varchar(200)")]
        public required string Us_Name { get; set; }


        [Column(TypeName = "varchar(100)")]
        public required string DocType_Id { get; set; }
        public Document_Type? Docs_Types { get; set; }

        public int Rol_Id { get; set; }
        public Roles? Role { get; set; }

        public int Status_Id { get; set; }
        public Status? Statuses { get; set; }


        [Column(TypeName = "varchar(max)")]
        public required string Us_ProfessionalProfile { get; set; }


        [Column(TypeName = "date")]
        public required DateTime Us_DateBorn { get; set; }


        [Column(TypeName = "varchar(100)")]
        public required string Us_CityBorn { get; set; }


        public int Status_Civil { get; set; }
        public Status? CivilStatus { get; set; }


        [Column(TypeName = "varchar(50)")]
        public required string Us_Phone { get; set; }


        [Column(TypeName = "varchar(200)")]
        public required string Us_Email { get; set; }


        [Column(TypeName = "varchar(max)")]
        public required string Us_Adress { get; set; }


        [Column(TypeName = "varchar(100)")]
        public required string Us_CurrentCity { get; set; }


        [Column(TypeName = "date")]
        public required DateTime Us_DateCreation { get; set; }


        [Column(TypeName = "varchar(20)")]
        public required string Us_HourCreation { get; set; }


        [Column(TypeName = "varchar(max)")]
        public required string Us_Password { get; set; }


        [Column(TypeName = "varchar(max)")]
        public string? Us_Observation { get; set; }

    }
}
