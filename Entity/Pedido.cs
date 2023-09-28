using System;
namespace Cadastro.Entity
{
	public class Pedido : Entidade
	{
		public string NomeProduto { get; set; }

		public int UsuarioId { get; set; }
	}
}