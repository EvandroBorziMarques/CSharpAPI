using System;
using Cadastro.Entity;
using Cadastro.Repository;
using Microsoft.EntityFrameworkCore;

namespace Cadastro.Interface
{
	public interface IRepository<T> where T : Entidade
	{
        IList<T> ObterTodos();

        T ObterPorId(int id);

        void Cadastrar(T entidade);

        void Alterar(T entidade);

        void Deletar(int id);
    }
}

