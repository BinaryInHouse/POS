using System;
namespace POS.Infraestructure.Persistences.Interfaces
{
	public interface IUnitOfWork : IDisposable
	{
		//Declaracion o matricula de nuestra interface a nicel de repository
		ICategoryRepository Category { get; }
		IUserRepository User { get; }
		void SaveChanges();
		Task SaveChangesAsync();
	}
}

