using AutoMapper;
using Puantaj.Business.Abstract;
using Puantaj.Data.Abstract;
using Puantaj.Entity.Concrete;
using Puantaj.Entity.Dtos;
using Puantaj.Utilities.Results.Abstract;
using Puantaj.Utilities.Results.ComplexTypes;
using Puantaj.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puantaj.Business.Concrete
{
    internal class ProjeManager : ManagerBase, IProjeService
    {
        public ProjeManager(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<IResult> AddAsync(ProjeAddDto projeAddDto, string createdByName)
        {
            var proje = Mapper.Map<Proje>(projeAddDto);
            proje.CreatedByName = createdByName;
            proje.ModifiedByName = createdByName;
            var addedproje = await UnitOfWork.Proje.AddAsync(proje);
            await UnitOfWork.SaveAsync();
            return new DataResult<ProjeAddDto>(ResultStatus.Success, "Proje eklendi", new ProjeAddDto
            {
                Proje = addedproje,
                ResultStatus = ResultStatus.Success,
                Message = "Proje eklendi"
            });
        }

        public async Task<IResult> DeleteAsync(int projeId)
        {
            var proje = await UnitOfWork.Proje.GetAsync(p => p.Id == projeId);
            if (proje != null)
            {
                await UnitOfWork.Proje.DeleteAsync(proje);
                await UnitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, "Proje silindi.");
            }
            return new Result(ResultStatus.Error, "Proje silinemedi.");
        }

        public async Task<IDataResult<ProjeListDto>> GetAllAsync()
        {
            var projes = await UnitOfWork.Proje.GetAllAsync();
            return new DataResult<ProjeListDto>(ResultStatus.Success, new ProjeListDto()
            {
                Projes = projes,
                ResultStatus = ResultStatus.Success
            });
        }

        public async Task<IDataResult<ProjeDto>> GetAsync(int projeId)
        {
            var Proje = await UnitOfWork.Proje.GetAsync(p => p.Id == projeId);
            if (Proje != null)
            {
                return new DataResult<ProjeDto>(ResultStatus.Success, new ProjeDto
                {
                    Proje = Proje,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<ProjeDto>(ResultStatus.Success, "Proje Bulunamadı", new ProjeDto
            {
                Proje = Proje,
                //ResultStatus = ResultStatus.Success,
                //Message = "Proje Bulunamadı"
            });
        }

        public async Task<IResult> UpdateAsync(ProjeUpdateDto projeUpdateDto, string modifiedByName)
        {
            var oldproje = await UnitOfWork.Proje.GetAsync(c => c.Id == projeUpdateDto.Id);
            var proje = Mapper.Map<ProjeUpdateDto, Proje>(projeUpdateDto, oldproje);
            proje.ModifiedByName = modifiedByName;
            var updatedproje = await UnitOfWork.Proje.UpdateAsync(proje);
            await UnitOfWork.SaveAsync();
            return new DataResult<ProjeDto>(ResultStatus.Success, "Proje Güncellendi.", new ProjeDto
            {
                Proje = updatedproje,
                //ResultStatus = ResultStatus.Success,
                //Message = "Proje Güncellendi."
            });
        }
    }
}
