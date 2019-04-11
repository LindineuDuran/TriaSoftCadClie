using System.ComponentModel.DataAnnotations;

namespace TriaSoftCadClie.Models
{
    public class ProdServ
    {
        public int ProdServID { get; set; }

        [Display(Name = "Produto ou Serviço")]
        public string NomeProdServ { get; set; }
    }
}