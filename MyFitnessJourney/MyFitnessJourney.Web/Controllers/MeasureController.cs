using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyFitnessJourney.Service.Measure;
using MyFitnessJourney.Service.Models.Measure;
using System.Security.Claims;

namespace MyFitnessJourney.Web.Controllers
{
    [Authorize]
    public class MeasureController : Controller
    {
        private readonly IMeasureService _measureService;

        public MeasureController(IMeasureService measureService)
        {
            _measureService = measureService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<MeasureServiceModel> result = _measureService
                .GetAllByUserId(User.FindFirstValue(ClaimTypes.NameIdentifier))
                .AsEnumerable()
                .OrderByDescending(m => m.MeasureDate)
                .ToList();

            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(MeasureServiceModel measure)
        {
            Console.WriteLine(ModelState.IsValid);

            if (!ModelState.IsValid)
            {
                return View(measure);
            }

            Console.WriteLine("Valid model");

            measure.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            await _measureService.CreateAsync(measure);

            return RedirectToAction(nameof(GetAll));
        }

        public async Task<IActionResult> Delete(string id)
        {
            await _measureService.DeleteAsync(id);

            return RedirectToAction("GetAll", "Measure");
        }
    }
}
