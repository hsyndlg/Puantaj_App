using AutoMapper;
using Puantaj.Business.Abstract;
using Puantaj.Data.Abstract;
using Puantaj.Entity.Concrete;
using Puantaj.Entity.Dtos;
using Puantaj.Utilities.Results.Abstract;
using Puantaj.Utilities.Results.ComplexTypes;
using Puantaj.Utilities.Results.Concrete;

namespace Puantaj.Business.Concrete
{
    internal class PuantajCizelgeManager : ManagerBase, IPuantajCizelgeService
    {
        public PuantajCizelgeManager(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<IResult> AddAsync(PuantajCizelgeAddDto PuantajCizelgeAddDto, string createdByName)
        {
            var PuantajCizelge = Mapper.Map<PuantajCizelge>(PuantajCizelgeAddDto);
            PuantajCizelge.CreatedByName = createdByName;
            PuantajCizelge.ModifiedByName = createdByName;
            var addedPuantajCizelge = await UnitOfWork.PuantajCizelge.AddAsync(PuantajCizelge);
            await UnitOfWork.SaveAsync();
            return new DataResult<PuantajCizelgeAddDto>(ResultStatus.Success, "PuantajCizelge eklendi", new PuantajCizelgeAddDto
            {
                PuantajCizelge = addedPuantajCizelge,
                ResultStatus = ResultStatus.Success,
                Message = "PuantajCizelge eklendi"
            });
        }

        public async Task<IResult> DeleteAsync(int PuantajCizelgeId)
        {
            var PuantajCizelge = await UnitOfWork.PuantajCizelge.GetAsync(p => p.Id == PuantajCizelgeId);
            if (PuantajCizelge != null)
            {
                await UnitOfWork.PuantajCizelge.DeleteAsync(PuantajCizelge);
                await UnitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, "PuantajCizelge silindi.");
            }
            return new Result(ResultStatus.Error, "PuantajCizelge silinemedi.");
        }

        public async Task<IDataResult<PuantajCizelgeListDto>> GetAllAsync()
        {
            var PuantajCizelges = await UnitOfWork.PuantajCizelge.GetAllAsync();
            return new DataResult<PuantajCizelgeListDto>(ResultStatus.Success, new PuantajCizelgeListDto()
            {
                PuantajCizelges = PuantajCizelges,
                //ResultStatus = ResultStatus.Success
            });
        }

        public async Task<IDataResult<PuantajCizelgeDto>> GetAsync(int PuantajCizelgeId)
        {
            var PuantajCizelge = await UnitOfWork.PuantajCizelge.GetAsync(p => p.Id == PuantajCizelgeId);
            if (PuantajCizelge != null)
            {
                return new DataResult<PuantajCizelgeDto>(ResultStatus.Success, new PuantajCizelgeDto
                {
                    PuantajCizelge = PuantajCizelge,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<PuantajCizelgeDto>(ResultStatus.Success, "PuantajCizelge Bulunamadı", new PuantajCizelgeDto
            {
                PuantajCizelge = PuantajCizelge,
                ResultStatus = ResultStatus.Success,
                Message = "PuantajCizelge Bulunamadı"
            });
        }

        public async Task<IResult> UpdateAsync(PuantajCizelgeUpdateDto PuantajCizelgeUpdateDto, string modifiedByName)
        {
            var oldPuantajCizelge = await UnitOfWork.PuantajCizelge.GetAsync(c => c.Id == PuantajCizelgeUpdateDto.Id);
            var PuantajCizelge = Mapper.Map<PuantajCizelgeUpdateDto, PuantajCizelge>(PuantajCizelgeUpdateDto, oldPuantajCizelge);
            PuantajCizelge.ModifiedByName = modifiedByName;
            var updatedPuantajCizelge = await UnitOfWork.PuantajCizelge.UpdateAsync(PuantajCizelge);
            await UnitOfWork.SaveAsync();
            return new DataResult<PuantajCizelgeDto>(ResultStatus.Success, "PuantajCizelge Güncellendi.", new PuantajCizelgeDto
            {
                PuantajCizelge = updatedPuantajCizelge,
                ResultStatus = ResultStatus.Success,
                Message = "PuantajCizelge Güncellendi."
            });
        }
    }
}
