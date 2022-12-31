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
    public class PersonelManager : ManagerBase, IPersonelService
    {
        public PersonelManager(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<IResult> AddAsync(PersonelAddDto personelAddDto, string createdByName)
        {
            var personel = Mapper.Map<Personel>(personelAddDto);
            personel.YillikIzinBaslangicTarihiGun = personel.BaslangicTarihiGun;
            personel.YillikIzinBaslangicTarihiAy = personel.BaslangicTarihiAy;
            personel.YillikIzinBaslangicTarihiYil = personel.BaslangicTarihiYil + 1;
            personel.CreatedByName = createdByName;
            personel.ModifiedByName = createdByName;
            var addedPersonel = await UnitOfWork.Personel.AddAsync(personel);
            await UnitOfWork.SaveAsync();
            return new DataResult<PersonelDto>(ResultStatus.Success,"Personel eklendi",new PersonelDto
            {
                Personel = addedPersonel,
                ResultStatus = ResultStatus.Success,
                Message = "Personel eklendi"
            });
        }

        public async Task<IResult> DeleteAsync(int personelId)
        {
            var personel = await UnitOfWork.Personel.GetAsync(c => c.Id == personelId);
            if (personel != null)
            {
                await UnitOfWork.Personel.DeleteAsync(personel);
                await UnitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, "Personel başarıyla silindi.");
            }
            return new Result(ResultStatus.Error, "Personel silinemedi.");
        }

        public async Task<IResult> UpdateAsync(PersonelUpdateDto personelUpdateDto, string modifiedByName)
        {
            var oldpersonel = await UnitOfWork.Personel.GetAsync(c => c.Id == personelUpdateDto.Id);
            var personel = Mapper.Map<PersonelUpdateDto, Personel>(personelUpdateDto, oldpersonel);
            personel.ModifiedByName = modifiedByName;
            var updatedpersonel = await UnitOfWork.Personel.UpdateAsync(personel);
            await UnitOfWork.SaveAsync();
            return new DataResult<PersonelDto>(ResultStatus.Success, "Personel Güncellendi.", new PersonelDto
            {
                Personel = updatedpersonel,
                ResultStatus = ResultStatus.Success,
                Message = "Personel Güncellendi."
            });
        }

        public async Task<IDataResult<PersonelListDto>> GetAllAsync()
        {
            var personels = await UnitOfWork.Personel.GetAllAsync();
            return new DataResult<PersonelListDto>(ResultStatus.Success, new PersonelListDto()
            {
                Personels = personels,
                ResultStatus = ResultStatus.Success
            });
        }

        public async Task<IDataResult<PersonelDto>> GetAsync(int personelId)
        {
            var personel = await UnitOfWork.Personel.GetAsync(p => p.Id == personelId);
            if (personel != null)
            {
                return new DataResult<PersonelDto>(ResultStatus.Success, new PersonelDto
                {
                    Personel = personel,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<PersonelDto>(ResultStatus.Success,"Personel Bulunamadı", new PersonelDto
            {
                Personel = personel,
                ResultStatus = ResultStatus.Success,
                Message = "Personel Bulunamadı"
            });
        }
    }
}