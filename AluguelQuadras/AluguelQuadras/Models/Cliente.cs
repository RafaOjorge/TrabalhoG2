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

        public List<Cliente> GetClientes()
        {
            StringBuilder sql = new StringBuilder();
            List<Cliente> listaClientes = new List<Cliente>();

            sql.Append("Select * ");
            sql.Append("From clientes ORDER BY nome ASC");

            MySqlDataReader dr = Conexao.Get(sql.ToString());

            while (dr.Read())
            {
                listaClientes.Add(new Cliente
                {
                    IdCliente = dr.GetInt32(0),
                    NomeCliente = dr.GetString(1),
                    EnderecoCliente = dr.GetString(2),
                    FoneCliente = dr.GetString(3),
                    EMailCliente = dr.GetString(4),
                });
            }
            return listaClientes;
        }

        public List<Cliente> GetClientesPorNome(string nome)
        {
            StringBuilder sql = new StringBuilder();
            List<Cliente> listaClientes = new List<Cliente>();

            sql.Append("SELECT * ");
            sql.Append("FROM clientes WHERE nome='");
            sql.Append(nome);
            sql.Append("'");
            MySqlDataReader dr = Conexao.Get(sql.ToString());

            while (dr.Read())
            {
                listaClientes.Add(new Cliente
                {
                    IdCliente = dr.GetInt32(0),
                    NomeCliente = dr.GetString(1),
                    EnderecoCliente = dr.GetString(2),
                    FoneCliente = dr.GetString(3),
                    EMailCliente = dr.GetString(4),
                });
            }
            return listaClientes;
        }

        public void Novo(Cliente pCliente)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();

            sql.Append("Insert into clientes (nome, endereco, fone, email) ");
            sql.Append(" Values (@nome, @endereco, @fone, @email) ");

            //cmd.Parameters.AddWithValue("@id", "");
            cmd.Parameters.AddWithValue("@nome", pCliente.NomeCliente);
            cmd.Parameters.AddWithValue("@endereco", pCliente.EnderecoCliente);
            cmd.Parameters.AddWithValue("@fone", pCliente.FoneCliente);
            cmd.Parameters.AddWithValue("@email", pCliente.EMailCliente);

            cmd.CommandText = sql.ToString();

            //passando o command para a dll conn resolver a persistência
            Conexao.CommandPersist(cmd);
        }

        public void Editar(Cliente pCliente)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();

            sql.Append("UPDATE clientes ");
            sql.Append("SET id = @id, nome = @nome, endereco = @endereco, fone = @fone, email = @email ");
            sql.Append("WHERE id = @id ");

            cmd.Parameters.AddWithValue("@id", pCliente.IdCliente);
            cmd.Parameters.AddWithValue("@nome", pCliente.NomeCliente);
            cmd.Parameters.AddWithValue("@endereco", pCliente.EnderecoCliente);
            cmd.Parameters.AddWithValue("@fone", pCliente.FoneCliente);
            cmd.Parameters.AddWithValue("@email", pCliente.EMailCliente);

            cmd.CommandText = sql.ToString();

            //passando o command para a dll conn resolver a persistência
            Conexao.CommandPersist(cmd);
        }

        public void Delete(int pId)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();

            sql.Append("DELETE FROM clientes");
            sql.Append(" WHERE id = @_id");

            cmd.Parameters.AddWithValue("@_id", pId);

            cmd.CommandText = sql.ToString();

            //passando o command para a dll conn resolver a persistência
            Conexao.CommandPersist(cmd);
        }
    }
}