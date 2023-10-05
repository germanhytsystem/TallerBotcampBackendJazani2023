using System;
using Jazani.Domain.Admins.Models;
using Jazani.Domain.Cores.Repositories;

namespace Jazani.Domain.Admins.Repositories
{
	public interface IModuleRepository:ICrudRepository<Module,int>
	{
		//Task<IReadOnlyList<Module>> FindAllAsync();
		//Task<Module?> FindByIdAsync(int id);
		//Task<Module> SaveAsync(Module modules);
	}
}

