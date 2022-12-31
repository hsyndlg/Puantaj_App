using Puantaj.Entity.Dtos;
using Puantaj.Utilities.Results.Abstract;

namespace Puantaj.Business.Abstract
{
    public interface IPersonelService
    {
        Task<IResult> AddAsync(PersonelAddDto personelAddDto, string createdByName);
        Task<IResult> UpdateAsync(PersonelUpdateDto personelUpdateDto, string modifiedByName);
        Task<IResult> DeleteAsync(int personelId);
        Task<IDataResult<PersonelDto>> GetAsync(int personelId);
        Task<IDataResult<PersonelListDto>> GetAllAsync();
    }
}