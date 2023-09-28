using System;
using Cadastro.Entity;

namespace Cadastro.Interface
{
	public interface IRepository<T> where T : Entidade
	{
        IList<T> ObterTodos();

        T ObterPorId(int id);

        void Cadastrar(T usuario);

        void Alterar(T usuario);

        void Deletar(int id);
    }
}

