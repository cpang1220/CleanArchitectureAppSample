using JediAcademy.Presentation.ViewModels;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace JediAcademy.Presentation.Services
{
    public class JediEnrollmentService : IJediEnrollmentService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<JediEnrollmentService> _logger;

        public JediEnrollmentService(IHttpClientFactory httpClientFactory, ILogger<JediEnrollmentService> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        // Edited by CPang 2020-07-17 Challenge 3
        public async Task<(bool IsSuccess, IEnumerable<Species> Result)> GetAvailableSpecies()
        {
            try
            {
                // Edited by CPang 2020-07-19 Docker
                var client = _httpClientFactory.CreateClient("Species");
                var response = await client.GetAsync("");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsByteArrayAsync();
                    var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    var result = JsonSerializer.Deserialize<IEnumerable<Species>>(content, options);
                    return (true, result);
                }

                return (false, null);
            }
            catch (Exception e)
            {
                _logger?.LogError(e.ToString());
                return (false, null);
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<JediStudent> Result)> GetExistingStudents()
        {
            try
            {
                var client = _httpClientFactory.CreateClient("Individuals");
                var response = await client.GetAsync("");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsByteArrayAsync();
                    var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    var result = JsonSerializer.Deserialize<IEnumerable<JediStudent>>(content, options);
                    return (true, result);
                }

                return (false, null);
            }
            catch (Exception e)
            {
                _logger?.LogError(e.ToString());
                return (false, null);
            }
        }

        // Edited by CPang 2020-07-15 Challenge 2
        public async Task<(bool IsSuccess, JediStudent Result)> AddStudent(JediEnrollmentViewModel jediStudentEnrollmentModel)
        {
            var jediStudent = new JediStudent
            {
                Name = jediStudentEnrollmentModel.Name,
                Height = jediStudentEnrollmentModel.Height,
                Mass = jediStudentEnrollmentModel.Mass,
                Species = jediStudentEnrollmentModel.SelectedSpecies,
                // Edited by CPang 2020-07-17 Challenge 3
                Planet = jediStudentEnrollmentModel.SelectedPlanet
            };
            try
            {
                var client = _httpClientFactory.CreateClient("Individuals");               
                var stringContent = new StringContent(JsonSerializer.Serialize(jediStudent), Encoding.UTF8, "application/json");
                var response = await client.PostAsync("", stringContent);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsByteArrayAsync();
                    var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    var result = JsonSerializer.Deserialize<JediStudent>(content, options);
                    return (true, result);
                }

                return (false, null);
            }
            catch (Exception e)
            {
                _logger?.LogError(e.ToString());
                return (false, null);
            }
        }

        // Edited by CPang 2020-07-17 Challenge 3
        public async Task<(bool IsSuccess, IEnumerable<Planet> Result)> GetAvailablePlanets()
        {
            try
            {
                // Edited by CPang 2020-07-19 Docker
                var client = _httpClientFactory.CreateClient("Planets");
                var response = await client.GetAsync("");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsByteArrayAsync();
                    var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    var result = JsonSerializer.Deserialize<IEnumerable<Planet>>(content, options);
                    return (true, result);
                }

                return (false, null);
            }
            catch (Exception e)
            {
                _logger?.LogError(e.ToString());
                return (false, null);
            }
        }
    }
}
