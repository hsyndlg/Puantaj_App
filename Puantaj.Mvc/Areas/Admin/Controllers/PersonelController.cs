using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Puantaj.Business.Abstract;
using Puantaj.Entity.Dtos;
using Puantaj.Utilities.Results.ComplexTypes;

namespace Puantaj.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class PersonelController : Controller
    {
        private IPersonelService _personelService;
        public PersonelController(IPersonelService personelService)
        {
            _personelService = personelService;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _personelService.GetAllAsync();
            if (result.ResultStatus == ResultStatus.Success)
            {
                return View(result);
            }
            return RedirectToRoute("Admin/Home/Index");
        }
        [HttpPost]
        public async Task<IActionResult> Add(PersonelAddDto personelAddDto)
        {
            var dogumtarihi = personelAddDto.DogumTarihi.Split('-');
            var baslangictarihi = personelAddDto.BaslangicTarihi.Split('-');
            personelAddDto.BaslangicTarihiGun = baslangictarihi[2];
            personelAddDto.BaslangicTarihiAy = baslangictarihi[1];
            personelAddDto.BaslangicTarihiYil = baslangictarihi[0];
            personelAddDto.DogumTarihiGun = dogumtarihi[2];
            personelAddDto.DogumTarihiAy = dogumtarihi[1];
            personelAddDto.DogumTarihiYil = dogumtarihi[0];
            var result = await _personelService.AddAsync(personelAddDto,User.Identity.Name);
            if (result.ResultStatus == ResultStatus.Success)
            {
                return View(result);
            }
            return RedirectToRoute("Admin/Personel/Index");
        }
        [HttpPost]
        public async Task<IActionResult> Update(PersonelUpdateDto personelUpdateDto)
        {
            var dogumtarihi = personelUpdateDto.DogumTarihi.Split('-');
            var baslangictarihi = personelUpdateDto.BaslangicTarihi.Split('-');
            personelUpdateDto.BaslangicTarihiGun = baslangictarihi[2];
            personelUpdateDto.BaslangicTarihiAy = baslangictarihi[1];
            personelUpdateDto.BaslangicTarihiYil = baslangictarihi[0];
            personelUpdateDto.DogumTarihiGun = dogumtarihi[2];
            personelUpdateDto.DogumTarihiAy = dogumtarihi[1];
            personelUpdateDto.DogumTarihiYil = dogumtarihi[0];
            var result = await _personelService.UpdateAsync(personelUpdateDto, User.Identity.Name);
            if (result.ResultStatus == ResultStatus.Success)
            {
                return View(result);
            }
            return RedirectToRoute("Admin/Personel/Index");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int personelId)
        {
            var result = await _personelService.DeleteAsync(personelId);
            if (result.ResultStatus == ResultStatus.Success)
            {
                return View(result);
            }
            return RedirectToRoute("Admin/Personel/Index");
        }
        public async Task<IActionResult> GetListPersonels()
        {
            var result = await _personelService.GetAllAsync();
            if (result.ResultStatus == ResultStatus.Success)
            {
                return Ok(result.Data.Personels);
            }
            return RedirectToRoute("Admin/Personel/Index");
        }
    }
}