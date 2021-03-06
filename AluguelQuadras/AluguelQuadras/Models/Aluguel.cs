﻿using MySql.Data.MySqlClient;
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
    public class Aluguel
    {
        [Display(Name = "Id:")]
        public int IdAluguel { get; set; }

        [Display(Name = "Valor à Pagar:")]
        [Required(ErrorMessage = "Informe um valor")]
        public double ValorAluguel { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data. Ex.: 01/01/2000:")]
        [Required(ErrorMessage = "Informe uma data")]
        public DateTime DataAluguel { get; set; }

        [Display(Name = "Nome do Cliente:")]
        [Required(ErrorMessage = "Informe um nome.")]
        public string NomeCliente { get; set; }

        [Display(Name = "Nome da Quadra:")]
        [Required(ErrorMessage = "Informe um nome.")]
        public string NomeQuadra { get; set; }

        public List<Aluguel> GetAlugueis()
        {
            StringBuilder sql = new StringBuilder();
            List<Aluguel> listaAlugueis = new List<Aluguel>();

            sql.Append("Select * ");
            sql.Append("From alugueis ORDER BY dataAluguel ASC");

            MySqlDataReader dr = Conexao.Get(sql.ToString());

            while (dr.Read())
            {
                listaAlugueis.Add(new Aluguel
                {
                    IdAluguel = dr.GetInt32(0),
                    NomeQuadra = dr.GetString(1),
                    ValorAluguel = dr.GetDouble(2),
                    NomeCliente = dr.GetString(3),
                    DataAluguel = dr.GetDateTime(4),
                });
            }
            return listaAlugueis;
        }

        public void Novo(Aluguel pAluguel)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();

            sql.Append("Insert into alugueis (nomeQuadra, valorAluguel, nomeCliente, dataAluguel) ");
            sql.Append(" Values (@nomeQuadra, @valorAluguel, @nomeCliente, @dataAluguel) ");

            //cmd.Parameters.AddWithValue("@id", "");
            cmd.Parameters.AddWithValue("@nomeQuadra", pAluguel.NomeQuadra);
            cmd.Parameters.AddWithValue("@valorAluguel", pAluguel.ValorAluguel);
            cmd.Parameters.AddWithValue("@nomeCliente", pAluguel.NomeCliente);
            cmd.Parameters.AddWithValue("@dataAluguel", pAluguel.DataAluguel);

            cmd.CommandText = sql.ToString();

            //passando o command para a dll conn resolver a persistência
            Conexao.CommandPersist(cmd);
        }

        public void Editar(Aluguel pAluguel)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();

            sql.Append("UPDATE alugueis ");
            sql.Append("SET id = @id, nomeQuadra = @nomeQuadra, valorAluguel = @valorAluguel, nomeCliente = @nomeCliente, dataAluguel = @dataAluguel ");
            sql.Append("WHERE id = @id ");

            cmd.Parameters.AddWithValue("@id", pAluguel.IdAluguel);
            cmd.Parameters.AddWithValue("@nomeQuadra", pAluguel.NomeQuadra);
            cmd.Parameters.AddWithValue("@valorAluguel", pAluguel.ValorAluguel);
            cmd.Parameters.AddWithValue("@nomeCliente", pAluguel.NomeCliente);
            cmd.Parameters.AddWithValue("@dataAluguel", pAluguel.DataAluguel);

            cmd.CommandText = sql.ToString();

            //passando o command para a dll conn resolver a persistência
            Conexao.CommandPersist(cmd);
        }

        public void Delete(int pId)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();

            sql.Append("DELETE FROM alugueis");
            sql.Append(" WHERE id = @_id");

            cmd.Parameters.AddWithValue("@_id", pId);

            cmd.CommandText = sql.ToString();

            //passando o command para a dll conn resolver a persistência
            Conexao.CommandPersist(cmd);
        }
    }
}