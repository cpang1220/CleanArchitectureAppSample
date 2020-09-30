using JediAcademy.Presentation.ViewModels;
using System.Collections.Generic;

namespace JediAcademy.Presentation.Services
{
    public interface IJediEnrollmentService
    {
        System.Threading.Tasks.Task<(bool IsSuccess, IEnumerable<Species> Result)> GetAvailableSpecies();
        System.Threading.Tasks.Task<(bool IsSuccess, IEnumerable<JediStudent> Result)> GetExistingStudents();
        // Edited by CPang 2020-07-15 Challenge 2
        System.Threading.Tasks.Task<(bool IsSuccess, JediStudent Result)> AddStudent(JediEnrollmentViewModel jediStudentEnrollmentModel);
        // Edited by CPang 2020-07-17 Challenge 3
        System.Threading.Tasks.Task<(bool IsSuccess, IEnumerable<Planet> Result)> GetAvailablePlanets();
    }
}