using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Puantaj.Business.Abstract;
using Puantaj.Entity.Dtos;
using Puantaj.Utilities.Results.ComplexTypes;

namespace Puantaj.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ProjeController : Controller
    {
        private readonly IProjeService _projeService;

        public ProjeController(IProjeService projeService)
        {
            _projeService = projeService;
           
        }

        public async Task<IActionResult> Index()
        {
            var result = await _projeService.GetAllAsync();
            if (result.ResultStatus == ResultStatus.Success)
            {
                return View(result);
            }
            return RedirectToRoute("Admin/Home/Index");
        }
        [HttpPost]
        public async Task<IActionResult> Add(ProjeAddDto projeAddDto)
        {
            var result = await _projeService.AddAsync(projeAddDto, User.Identity.Name);
            if (result.ResultStatus == ResultStatus.Success)
            {
                return View(result);
            }
            return RedirectToRoute("Admin/Personel/Index");
        }
        [HttpPost]
        public async Task<IActionResult> Update(ProjeUpdateDto projeUpdateDto)
        {
            var result = await _projeService.UpdateAsync(projeUpdateDto, User.Identity.Name);
            if (result.ResultStatus == ResultStatus.Success)
            {
                return View(result);
            }
            return RedirectToRoute("Admin/Personel/Index");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int projeId)
        {
            var result = await _projeService.DeleteAsync(projeId);
            if (result.ResultStatus == ResultStatus.Success)
            {
                return View(result);
            }
            return RedirectToRoute("Admin/Personel/Index");
        }
    }
}