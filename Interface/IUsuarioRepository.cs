using System;
using Cadastro.Entity;

namespace Cadastro.Interface
{
	public interface IUsuarioRepository : IRepository<Usuario>
	{
		Usuario ObterComPedidos (int id);
	}
}