using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using AluguelQuadrasDAO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AluguelQuadras.Models
{
    public class Quadra : Cliente
    {
        public int IdQuadra { get; set; }
        public string NomeQuadra { get; set; }
        public string ModalidadeQuadra { get; set; }

        public List<Quadra> GetQuadras()
        {
            StringBuilder sql = new StringBuilder();
            List<Quadra> listaQuadras = new List<Quadra>();

            sql.Append("Select * ");
            sql.Append("From quadras ORDER BY nome ASC");

            MySqlDataReader dr = Conexao.Get(sql.ToString());

            while (dr.Read())
            {
                listaQuadras.Add(new Quadra
                {
                    IdQuadra = dr.GetInt32(0),
                    NomeQuadra = dr.GetString(1),
                    ModalidadeQuadra = dr.GetString(2),
                });
            }
            return listaQuadras;
        }
    }
}