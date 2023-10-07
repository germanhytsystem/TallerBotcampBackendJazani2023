using System;
namespace Jazani.Application.Cores.Services
{
    public interface ICrudService<TDto, TDtoSave, ID> : 
        IQueryService<TDto, ID>, 
        ISaveService<TDto,TDtoSave,ID>,
        IDisableService<TDto,ID>
    {

        //Task<IReadOnlyList<TDto>> FindAllAsync();
        //Task<TDto?> FindByIdAsync(int id);
        //Task<TDto> CreateAsync(TDtoSave saveDto);
        //Task<TDto> EditAsync(int id, TDtoSave saveDto);
        //Task<TDto> DisabledAsync(int id);

    }
}
