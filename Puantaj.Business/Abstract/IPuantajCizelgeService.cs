using Puantaj.Entity.Dtos;
using Puantaj.Utilities.Results.Abstract;

namespace Puantaj.Business.Abstract
{
    public interface IPuantajCizelgeService
    {
        Task<IResult> AddAsync(PuantajCizelgeAddDto puantajCizelgeAddDto, string createdByName);
        Task<IResult> UpdateAsync(PuantajCizelgeUpdateDto puantajCizelgeUpdateDto, string modifiedByName);
        Task<IResult> DeleteAsync(int puantajCizelgeId);
        Task<IDataResult<PuantajCizelgeDto>> GetAsync(int puantajCizelgeId);
        Task<IDataResult<PuantajCizelgeListDto>> GetAllAsync();
    }
}