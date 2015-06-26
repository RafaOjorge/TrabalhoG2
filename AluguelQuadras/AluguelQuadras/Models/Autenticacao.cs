using AluguelQuadrasDAO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web;

namespace AluguelQuadras.Models
{
    public class Autenticacao
    {
        [Display(Name = "Usuário:")]
        //[Required(ErrorMessage = "Informe um usuário.")]
        public string Usuario { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Senha:")]
        //[Required(ErrorMessage = "Informe uma senha.")]
        public string Senha { get; set; }

        public bool isValido(string pUsuario, string pSenha)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append("Select * ");
            sql.Append("From usuarios");

            MySqlDataReader dr = Conexao.Get(sql.ToString());

            while (dr.Read())
            {
                if (dr.GetString(1) == pUsuario)
                {
                    if (dr.GetString(2) == pSenha)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

    }
    
}