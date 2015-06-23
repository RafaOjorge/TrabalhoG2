using AluguelQuadras.Models.Entity;
using AluguelQuadrasDAO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace AluguelQuadras.Models.Repository
{
    public class AluguelRepository
    {
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
    }
}