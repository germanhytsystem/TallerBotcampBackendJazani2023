using System;
using Jazani.Domain.Admins.Models;

namespace Jazani.Domain.Admins.Repositories
{
	public interface ILiabilitieRepository
    {
        // Método para buscar todas las instancias de Liabilitie de forma asíncrona
        Task<IReadOnlyList<Liabilitie>> FindAllAsync();
        // Método para buscar una instancia de Liabilitie por su ID de forma asíncrona
        Task<Liabilitie?> FindByIdAsync(int id);
        // Método para guardar una instancia de Liabilitie de forma asíncrona
        Task<Liabilitie> SaveAsync(Liabilitie liabilities);
	}
}

