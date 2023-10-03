using System;
using Jazani.Domain.Admins.Models;

namespace Jazani.Domain.Admins.Repositories
{
	public interface IModuleRepository
	{
		Task<IReadOnlyList<Module>> FindAllAsync();
		Task<Module?> FindByIdAsync(int id);
		Task<Module> SaveAsync(Module modules);
	}
}

