using System;
using POS.Infraestructure.FileStorage;
namespace POS.Infraestructure.Persistences.Interfaces
{
	public interface IUnitOfWork : IDisposable
	{
		//Declaracion o matricula de nuestra interface a nicel de repository
		ICategoryRepository Category { get; }
		IUserRepository User { get; }
		IAzureStorage Storage { get; }
		void SaveChanges();
		Task SaveChangesAsync();
	}
}

