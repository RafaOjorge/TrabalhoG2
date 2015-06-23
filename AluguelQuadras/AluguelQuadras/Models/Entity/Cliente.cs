using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using AluguelQuadrasDAO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AluguelQuadras.Models.Entity
{
    public class Cliente
    {
        [Display(Name = "Id:")]
        public int IdCliente { get; set; }

        [Display(Name = "Nome:")]
        [Required(ErrorMessage = "Informe um nome.")]
        public string NomeCliente { get; set; }

        [Display(Name = "Endereço:")]
        [Required(ErrorMessage = "Informe um endereço.")]
        public string EnderecoCliente { get; set; }

        [Display(Name = "Telefone:")]
        [Required(ErrorMessage = "Informe um telefone.")]
        public string FoneCliente { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-Mail:")]
        [Required(ErrorMessage = "Informe um e-mail.")]
        public string EMailCliente { get; set; }

        
    }
}