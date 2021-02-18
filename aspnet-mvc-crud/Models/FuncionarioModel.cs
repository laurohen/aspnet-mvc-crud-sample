using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspnet_mvc_crud.Models
{
    public class FuncionarioModel
    {

        [Key]
        [Column("PK_Funcionario", TypeName = "int")]
        public int FuncionarioId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [DisplayName("Nome")]
        [Required(ErrorMessage = "Campo obrigatorio.")]
        [MaxLength(50, ErrorMessage = "Maximo de 50 caracteres.")]
        public string Nome { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [DisplayName("Email")]
        [Required(ErrorMessage = "Campo obrigatorio.")]
        [MaxLength(50, ErrorMessage = "Maximo de 50 caracteres.")]
        public string Email { get; set; }

        [Column(TypeName = "datetime")]
        [DisplayName("Data Nascimento")]
        public DateTime DataNascimento { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [DisplayName("Salario")]
        [Required(ErrorMessage = "Campo obrigatorio.")]
        //[MaxLength(50, ErrorMessage = "Maximo de 50 caracteres.")]
        public decimal Salario { get; set; }

        // Foreign key 
        [Display(Name = "Estado")]
        public int FK_Estado { get; set; }

        [ForeignKey("FK_Estado")]
        public virtual EstadoModel Estados { get; set; }
    }
}
