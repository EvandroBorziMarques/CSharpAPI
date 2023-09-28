using System;
using Cadastro.Entity;
using Cadastro.Interface;

namespace Cadastro.Repository
{
    public abstract class DapperRepository<T> : IRepository<T> where T : Entidade
    {
        private readonly string _connectionString;

        protected string ConnectionString => _connectionString;

        public DapperRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetValue<string>("ConnectionStrings:ConnectionString");
        }

        public abstract IList<T> ObterTodos();

        public abstract T ObterPorId(int id);

        public abstract void Cadastrar(T usuario);

        public abstract void Alterar(T usuario);

        public abstract void Deletar(int id);
    }
}

