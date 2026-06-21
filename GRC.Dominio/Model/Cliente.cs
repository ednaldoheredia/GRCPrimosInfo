using Clientes.Dominio.Model;
using System.ComponentModel.DataAnnotations;

namespace GRC.Dominio.Model
{
    public class Cliente: Entity
    {
        [Key]
        [Required(ErrorMessage ="O campo {0} é requerido.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é requerido.")]
        [StringLength(50, MinimumLength =11,ErrorMessage ="O campo {0} ter no minom entre {2} e {1}, caracteres")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "O campo {0} é requerido.")]
        public string Numero { get; set; }
    }
}