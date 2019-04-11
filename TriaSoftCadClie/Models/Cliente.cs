using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TriaSoftCadClie.Models
{
    public class Cliente
    {
        public int ID { get; set; }

        [Display(Name = "Nome da Empresa")]
        public string NomeEmpresa { get; set; }

        [Display(Name = "Nome do Cliente")]
        public string NomeCliente { get; set; }

        public string Telefone { get; set; }

        [Display(Name = "E-Mail")]
        public string Email { get; set; }
        public string Atendimento { get; set; }

        [Display(Name = "Data do Cadastro")]
        public DateTime DataCadastro { get; set; }

        [Display(Name = "Data do Atendimento")]
        public DateTime DataAtend { get; set; }

        public int ProdServID { get; set; }

        [ForeignKey("ProdServID")]
        public virtual ProdServ ProdServ { get; set; }
    }
}