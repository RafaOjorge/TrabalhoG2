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
    public class Aluguel : Quadra
    {
        public int IdAluguel { get; set; }
        public double ValorAluguel { get; set; }
        public DateTime DataAluguel { get; set; }

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
                    ModalidadeQuadra = dr.GetString(2),
                    ValorAluguel = dr.GetDouble(3),
                    NomeCliente = dr.GetString(4),
                    EnderecoCliente = dr.GetString(5),
                    FoneCliente = dr.GetString(6),
                    EMailCliente = dr.GetString(7),
                    DataAluguel = dr.GetDateTime(8),
                });
            }
            return listaAlugueis;
        }

        public void Novo(Aluguel pAluguel)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();

            sql.Append("Insert into alugueis (nomeQuadra, modalidadeQuadra, valorAluguel, nomeCliente, enderecoCliente, foneCliente, emailCliente, dataAluguel) ");
            sql.Append(" Values (@nomeQuadra, @modalidadeQuadra, @valorAluguel, @nomeCliente, @enderecoCliente, @foneCliente, @emailCliente, @dataAluguel) ");

            //cmd.Parameters.AddWithValue("@id", "");
            cmd.Parameters.AddWithValue("@nomeQuadra", pAluguel.NomeQuadra);
            cmd.Parameters.AddWithValue("@modalidadeQuadra", pAluguel.ModalidadeQuadra);
            cmd.Parameters.AddWithValue("@valorAluguel", pAluguel.ValorAluguel);
            cmd.Parameters.AddWithValue("@nomeCliente", pAluguel.NomeCliente);
            cmd.Parameters.AddWithValue("@enderecoCliente", pAluguel.EnderecoCliente);
            cmd.Parameters.AddWithValue("@foneCliente", pAluguel.FoneCliente);
            cmd.Parameters.AddWithValue("@emailCliente", pAluguel.EMailCliente);
            cmd.Parameters.AddWithValue("@dataAluguel", pAluguel.DataAluguel);

            cmd.CommandText = sql.ToString();

            //passando o command para a dll conn resolver a persistência
            Conexao.CommandPersist(cmd);
        }
    }
}