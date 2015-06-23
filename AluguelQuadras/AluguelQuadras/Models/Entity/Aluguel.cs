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
    public class Aluguel : Quadra
    {
        [Display(Name = "Id:")]
        public int IdAluguel { get; set; }

        [Display(Name = "Valor à Pagar:")]
        [Required(ErrorMessage = "Informe um valor")]
        public double ValorAluguel { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data de Leitura. Ex.: 01/01/2000:")]
        [Required(ErrorMessage = "Informe uma data")]
        public DateTime DataAluguel { get; set; }

        
    }
}