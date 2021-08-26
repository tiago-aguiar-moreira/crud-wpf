using CadastroPessoasApp.Model;
using CadastroPessoasApp.Repository.Interface;
using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CadastroPessoasApp.Repository
{
    public class PeopleRepository : IPeopleRepository
    {
        private const string SqlObterTodos = @"
            SELECT id, nome, sobrenome, Cpf, Nascimento, Genero, Logradouro, Numero, Cidade, Estado, Complemento, CEP FROM Pessoa";

        private const string SqlObterPorId = @"
            SELECT id, nome, sobrenome, Cpf, Nascimento, Genero, Logradouro, Numero, Cidade, Estado, Complemento, CEP FROM Pessoa WHERE Id = @Id";

        private const string SqlIncluir = @"
            INSERT INTO Pessoa VALUES (@nome, @sobrenome, @Cpf, @Nascimento, @Genero, @Logradouro, @Numero, @Cidade, @Estado, @Complemento, @CEP);
            SELECT CAST(SCOPE_IDENTITY() AS INT)";

        private const string SqlRemover = @"DELETE FROM Pessoa WHERE Id = @Id";

        private const string SqlAlterar = @"
            UPDATE Pessoa
            SET Nome = @Nome,
                Sobrenome = @Sobrenome,
                Cpf = @Cpf,
                Nascimento = @Nascimento,
                Genero = @Genero,
                Logradouro = @Logradouro,
                Numero = @Numero,
                Cidade = @Cidade,
                Estado = @Estado,
                Complemento = @Complemento,
                Cep = @Cep
            WHERE Id = @Id";

        private SqlConnection GetConnection()
            => new SqlConnection("Server=localhost,1433;Initial Catalog=PlayStore;User ID=sa;Password=yourStrong(!)Pass");
        //=> new SqlConnection(_configuration.GetConnectionString("SqlServer"));

        public void UpdatePeople(PeopleRecord pessoa)
        {
            using (var connection = GetConnection())
            {
                var id = connection.Execute(SqlAlterar, new
                {
                    Id = pessoa.Id,
                    Nome = pessoa.Nome,
                    Sobrenome = pessoa.Sobrenome,
                    Cpf = pessoa.Cpf,
                    Nascimento = pessoa.Nascimento,
                    Genero = pessoa.Genero,
                    Logradouro = pessoa.Logradouro,
                    Numero = pessoa.Numero,
                    Cidade = pessoa.Cidade,
                    Estado = pessoa.Estado,
                    Complemento = pessoa.Complemento,
                    Cep = pessoa.Cep
                });
            }
        }

        public void AddPeople(PeopleRecord pessoa)
        {
            using (var connection = GetConnection())
            {
                var id = connection.QuerySingle<int>(SqlIncluir, new
                {
                    Nome = pessoa.Nome,
                    Sobrenome = pessoa.Sobrenome,
                    Cpf = pessoa.Cpf,
                    Nascimento = pessoa.Nascimento,
                    Genero = pessoa.Genero,
                    Logradouro = pessoa.Logradouro,
                    Numero = pessoa.Numero,
                    Cidade = pessoa.Cidade,
                    Estado = pessoa.Estado,
                    Complemento = pessoa.Complemento,
                    Cep = pessoa.Cep
                });

                pessoa.Id = id;
            }
        }

        public IEnumerable<PeopleRecord> GetAll()
        {
            using (var connection = GetConnection())
            {
                return connection.Query<PeopleRecord>(SqlObterTodos);
            }
        }

        public PeopleRecord Get(int id)
        {
            using (var connection = GetConnection())
            {
                return connection.QueryFirstOrDefault<PeopleRecord>(SqlObterPorId, new { Id = id });
            }
        }

        public void RemovePeople(int id)
        {
            using (var connection = GetConnection())
            {
                connection.Execute(SqlRemover, new { Id = id });
            }
        }
    }
}
