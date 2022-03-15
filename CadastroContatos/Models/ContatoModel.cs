using System.ComponentModel.DataAnnotations;

namespace CadastroContatos.Models
{
    /*
     * Descreve as propriedades do objeto
     */
    public class ContatoModel
    {
        /*
         * Propriedades
         */
        public int id { get; set; }

        // VALIDAÇÕES CAMPO NOME
        [Required(ErrorMessage = "O campo NOME é obrigatório!")]
        public string Nome { get; set; }

        // VALIDAÇÕES CAMPO EMAIL
        [Required(ErrorMessage = "O campo EMAIL é obrigatório!")]
        [EmailAddress(ErrorMessage = "O Email informado não é válido!")]
        public string Email { get; set; }

        // VALIDAÇÕES CAMPO WHATSAPP
        [Required(ErrorMessage = "O campo WHATSAPP é obrigatório!")]
        [Phone(ErrorMessage = "O celular informado não é válido!")]
        public string WhatsApp { get; set; }    

    }
}
