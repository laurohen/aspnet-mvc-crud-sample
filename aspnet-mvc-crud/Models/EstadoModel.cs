using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspnet_mvc_crud.Models
{
    public class EstadoModel
    {
        [Key]
        [Column(TypeName = "int")]
        public int PK_Estado { get; set; }

        [Column(TypeName = "nvarchar(2)")]
        [DisplayName("Sigla")]
        [Required(ErrorMessage = "Campo obrigatorio.")]
        [MaxLength(2, ErrorMessage = "Maximo de 2 caracteres.")]
        public string Sigla { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Nome")]
        [Required(ErrorMessage = "Campo obrigatorio.")]
        [MaxLength(100, ErrorMessage = "Maximo de 100 caracteres.")]
        public string Nome { get; set; }
    }
}
