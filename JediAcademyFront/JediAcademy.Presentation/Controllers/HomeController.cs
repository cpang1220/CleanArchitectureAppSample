using JediAcademy.Presentation.Services;
using JediAcademy.Presentation.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace JediAcademy.Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly IJediEnrollmentService _jediEnrollmentService;

        public HomeController(IJediEnrollmentService jediEnrollmentService)
        {
            _jediEnrollmentService = jediEnrollmentService;
        }

        [HttpGet]
        public async Task<ViewResult> Index()
        {
            // Edited by CPang 2020-07-17 Challenge 3
            var (isSuccessGetSpecies, species) = await _jediEnrollmentService.GetAvailableSpecies();
            var (isSuccessGetPlanets, planets) = await _jediEnrollmentService.GetAvailablePlanets();
            var viewModel = new JediEnrollmentViewModel();
            if (isSuccessGetSpecies && isSuccessGetPlanets)
            {
                viewModel.Species.AddRange(species.Select(s => new SelectListItem(s.Name,s.Id)));
                viewModel.Planet.AddRange(planets.Select(p => new SelectListItem(p.Name, p.Id)));
            }        
            return View(viewModel);
        }

        // Edited by CPang 2020-07-15 Challenge 2
        [HttpPost]
        [ActionName("Index")]
        public async Task<IActionResult> AddStudent(JediEnrollmentViewModel jediStudentEnrollmentModel)
        {
            if (ModelState.IsValid)
            {
                var (isSuccess, jediStudentResult) = await _jediEnrollmentService.AddStudent(jediStudentEnrollmentModel);
                if (isSuccess)
                {
                    TempData["Message"] = "Student added successfully";
                }
                else
                {
                    TempData["Message"] = "Error. Please try again.";
                }
                return RedirectToAction("Index");
            }
            else
            {
                // Edited by CPang 2020-07-17 Challenge 3
                var (isSuccessGetSpecies, species) = await _jediEnrollmentService.GetAvailableSpecies();
                var (isSuccessGetPlanets, planets) = await _jediEnrollmentService.GetAvailablePlanets();
                var viewModel = new JediEnrollmentViewModel();
                if (isSuccessGetSpecies && isSuccessGetPlanets)
                {
                    viewModel.Species.AddRange(species.Select(s => new SelectListItem(s.Name, s.Id)));
                    viewModel.Planet.AddRange(planets.Select(p => new SelectListItem(p.Name, p.Id)));
                }
                return View(viewModel);
            }
        }

        public async Task<IActionResult> ExistingStudents()
        {
            // Edited by CPang 2020-07-15 Challenge 1
            var (isSuccessGetStudents, jediStudents) = await _jediEnrollmentService.GetExistingStudents();
            var (isSuccessGetSpecies, species) = await _jediEnrollmentService.GetAvailableSpecies();
            // Edited by CPang 2020-07-17 Challenge 3
            var (isSuccessGetPlanets, planets) = await _jediEnrollmentService.GetAvailablePlanets();
            var viewModel = new ExistingStudentsViewModel();
            if (isSuccessGetStudents && isSuccessGetSpecies && isSuccessGetPlanets)
            {
                viewModel.JediStudents = jediStudents;
                viewModel.Species = species;
                viewModel.Planets = planets;
            }
            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
