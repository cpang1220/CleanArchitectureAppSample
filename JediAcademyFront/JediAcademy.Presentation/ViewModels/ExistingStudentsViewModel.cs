using System.Collections.Generic;

namespace JediAcademy.Presentation.ViewModels
{
    public class ExistingStudentsViewModel
    {
        public IEnumerable<JediStudent> JediStudents { get; set; }

        // Edited by CPang 2020-07-15 Challenge 1
        public IEnumerable<Species> Species { get; set; }
        // Edited by CPang 2020-07-17 Challenge 3
        public IEnumerable<Planet> Planets { get; set; }
    }
}