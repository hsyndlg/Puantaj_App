using Puantaj.Entity.Dtos;
using Puantaj.Utilities.Results.Abstract;

namespace Puantaj.Business.Abstract
{
    public interface IProjeService
    {
        Task<IResult> AddAsync(ProjeAddDto projeAddDto, string createdByName);
        Task<IResult> UpdateAsync(ProjeUpdateDto projeUpdateDto, string modifiedByName);
        Task<IResult> DeleteAsync(int projeId);
        Task<IDataResult<ProjeDto>> GetAsync(int projeId);
        Task<IDataResult<ProjeListDto>> GetAllAsync();
    }
}