using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JediAcademy.Presentation.ViewModels
{
    public class JediEnrollmentViewModel
    {
        public JediEnrollmentViewModel()
        {
            Species = new List<SelectListItem>{new SelectListItem("Select...",null)};
            // Edited by CPang 2020-07-17 Challenge 3
            Planet = new List<SelectListItem> { new SelectListItem("Select...", null) };
        }
        public List<SelectListItem> Species { get; set; }
        [Required]
        [Range(0, 9, ErrorMessage = "Invalid Species")]
        public string SelectedSpecies { get; set; }
        // Edited by CPang 2020-07-15 Challenge 2
        [Required]
        [StringLength(50, ErrorMessage = "Name too long (50 character limit).")]
        public string Name { get; set; }
        [Required]
        [Range(0, Int32.MaxValue, ErrorMessage = "Height should not contain characters")]
        public string Height { get; set; }
        [Required]
        [Range(0, Int32.MaxValue, ErrorMessage = "Mass should not contain characters")]
        public string Mass { get; set; }
        // Edited by CPang 2020-07-17 Challenge 3
        public List<SelectListItem> Planet { get; set; }
        [Required]
        [Range(0, 9, ErrorMessage = "Invalid Planet")]
        public string SelectedPlanet { get; set; }
    }
}