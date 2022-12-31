using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Puantaj.Business.Abstract;
using Puantaj.Entity.Dtos;
using Puantaj.Utilities.Results.ComplexTypes;

namespace Puantaj.Mvc.Areas.Admin.Controllers
{ 
    [Area("Admin")]
    [Authorize]
    public class PuantajCizelgeController : Controller
    {
        private readonly IPuantajCizelgeService _puantajCizelgeService;

        public PuantajCizelgeController(IPuantajCizelgeService puantajCizelgeService)
        {
            _puantajCizelgeService = puantajCizelgeService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _puantajCizelgeService.GetAllAsync();
            if (result.ResultStatus == ResultStatus.Success)
            {
                return View(result);
            }
            return RedirectToRoute("Admin/Home/Index");
        }
        [HttpPost]
        public async Task<IActionResult> Add(PuantajCizelgeAddDto puantajCizelgeAddDto)
        {
            var result = await _puantajCizelgeService.AddAsync(puantajCizelgeAddDto, User.Identity.Name);
            if (result.ResultStatus == ResultStatus.Success)
            {
                return View(result);
            }
            return RedirectToRoute("Admin/Personel/Index");
        }
        [HttpPost]
        public async Task<IActionResult> Update(PuantajCizelgeUpdateDto puantajCizelgeUpdateDto)
        {
            var result = await _puantajCizelgeService.UpdateAsync(puantajCizelgeUpdateDto, User.Identity.Name);
            if (result.ResultStatus == ResultStatus.Success)
            {
                return View(result);
            }
            return RedirectToRoute("Admin/Personel/Index");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int puantajId)
        {
            var result = await _puantajCizelgeService.DeleteAsync(puantajId);
            if (result.ResultStatus == ResultStatus.Success)
            {
                return View(result);
            }
            return RedirectToRoute("Admin/Personel/Index");
        }
    }
}