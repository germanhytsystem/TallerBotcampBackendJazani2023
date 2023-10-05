using Jazani.Domain.Cores.Repositories;
using Jazani.Domain.Generals.Models;

namespace Jazani.Domain.Generals.Repositories
{
    public interface ILiabilitieRepository:ICrudRepository<Liabilitie,int>
    {



        // Método para buscar todas las instancias de Liabilitie de forma asíncrona
      //Task<IReadOnlyList<LiabilitieType>> FindAllAsync();
        // Método para buscar una instancia de Liabilitie por su ID de forma asíncrona
      //Task<LiabilitieType?> FindByIdAsync(int id);
        // Método para guardar una instancia de Liabilitie de forma asíncrona
      //Task<LiabilitieType> SaveAsync(LiabilitieType liabilitieType);
    }
}
