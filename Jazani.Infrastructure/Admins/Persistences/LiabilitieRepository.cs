using Jazani.Domain.Admins.Models;
using Jazani.Domain.Admins.Repositories;
using Jazani.Infrastructure.Cores.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Jazani.Infrastructure.Admins.Persistences
{
    public class LiabilitieRepository : ILiabilitieRepository
    {
        private readonly ApplicationDbContext _dbContext;

        // Constructor que recibe una instancia de ApplicationDbContext a través de la inyección de dependencias
        public LiabilitieRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Método para buscar todas las instancias de la tabla Liabilitie en la base de datos de forma asíncrona
        public async Task<IReadOnlyList<Liabilitie>> FindAllAsync()
        {
            // Se usa Entity Framework Core para obtener todas las instancias de Liabilitie y las convierte en una lista
            return await _dbContext.Liabilities.ToListAsync();
        }

        // Método para buscar una instancia de Liabilitie por su ID de forma asíncrona
        public async Task<Liabilitie?> FindByIdAsync(int id)
        {
            return await _dbContext.Liabilities
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        // Método para guardar una instancia de Liabilitie en la base de datos de forma asíncrona
        public async Task<Liabilitie> SaveAsync(Liabilitie liabilitie)
        {
            EntityState state = _dbContext.Entry(liabilitie).State; // Obtiene el estado de seguimiento de la entidad Liabilitie en el contexto de base de dato

            // Utiliza una expresión switch para determinar la acción a realizar según el estado de la entidad
            switch (state)
            {
                case EntityState.Detached:
                    _dbContext.Liabilities.Add(liabilitie);// Si el estado es "Detached" (sin seguimiento), agrega la entidad a la base de datos
                    break;
                case EntityState.Modified:
                    _dbContext.Liabilities.Update(liabilitie);// Si el estado es "Modified" (modificado), actualiza la entidad en la base de datos
                    break;
            }

            //Opcional
            //_ = state switch
            //{
            //    EntityState.Detached => _dbContext.Liabilities.Add(liabilitie),  
            //    EntityState.Modified => _dbContext.Liabilities.Update(liabilitie)  
            //};


            // Guarda los cambios en la base de datos de forma asíncrona
            await _dbContext.SaveChangesAsync();

            return liabilitie;
        }

    }
}

