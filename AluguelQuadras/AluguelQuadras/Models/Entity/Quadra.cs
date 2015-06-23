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
    public class Quadra : Cliente
    {
        [Display(Name = "Id:")]
        public int IdQuadra { get; set; }

        [Display(Name = "Nome:")]
        [Required(ErrorMessage = "Informe um nome.")]
        public string NomeQuadra { get; set; }

        [Display(Name = "Modalidade:")]
        [Required(ErrorMessage = "Informe uma modalidade.")]
        public string ModalidadeQuadra { get; set; }
    }
}