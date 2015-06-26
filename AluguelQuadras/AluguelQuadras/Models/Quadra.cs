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
    public class Quadra
    {
        [Display(Name = "Id:")]
        public int IdQuadra { get; set; }

        [Display(Name = "Nome:")]
        [Required(ErrorMessage = "Informe um nome.")]
        public string NomeQuadra { get; set; }

        [Display(Name = "Modalidade:")]
        [Required(ErrorMessage = "Informe uma modalidade.")]
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

        public List<Quadra> GetQuadrasPorNome(string nome)
        {
            StringBuilder sql = new StringBuilder();
            List<Quadra> listaQuadras = new List<Quadra>();

            sql.Append("SELECT * ");
            sql.Append("FROM quadras WHERE nome='");
            sql.Append(nome);
            sql.Append("'");
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

        public void Novo(Quadra pQuadra)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();

            sql.Append("Insert into quadras (nome, modalidade) ");
            sql.Append(" Values (@nome, @modalidade) ");

            //cmd.Parameters.AddWithValue("@id", "");
            cmd.Parameters.AddWithValue("@nome", pQuadra.NomeQuadra);
            cmd.Parameters.AddWithValue("@modalidade", pQuadra.ModalidadeQuadra);

            cmd.CommandText = sql.ToString();

            //passando o command para a dll conn resolver a persistência
            Conexao.CommandPersist(cmd);
        }

        public void Editar(Quadra pQuadra)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();

            sql.Append("UPDATE quadras ");
            sql.Append("SET id = @id, nome = @nome, modalidade = @modalidade ");
            sql.Append("WHERE id = @id ");

            cmd.Parameters.AddWithValue("@id", pQuadra.IdQuadra);
            cmd.Parameters.AddWithValue("@nome", pQuadra.NomeQuadra);
            cmd.Parameters.AddWithValue("@modalidade", pQuadra.ModalidadeQuadra);

            cmd.CommandText = sql.ToString();

            //passando o command para a dll conn resolver a persistência
            Conexao.CommandPersist(cmd);
        }

        public void Delete(int pId)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();

            sql.Append("DELETE FROM quadras");
            sql.Append(" WHERE id = @_id");

            cmd.Parameters.AddWithValue("@_id", pId);

            cmd.CommandText = sql.ToString();

            //passando o command para a dll conn resolver a persistência
            Conexao.CommandPersist(cmd);
        }
    }
}