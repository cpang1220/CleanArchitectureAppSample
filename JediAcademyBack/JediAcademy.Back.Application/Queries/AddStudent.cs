using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using JediAcademy.Back.Application.Interfaces;
using JediAcademy.Back.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace JediAcademy.Back.Application.Queries
{
    // Edited by CPang 2020-07-15 Challenge 2
    public class AddStudent
    {
        #region Request
        public class CreateRequest : IRequest<(bool IsSuccess, JediStudent Result, string Message)>
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Height { get; set; }
            public string Mass { get; set; }
            public string Species { get; set; }
            // Edited by CPang 2020-07-17 Challenge 3
            public string Planet { get; set; }
        }
        #endregion Request

        #region Handler

        public class Handler : IRequestHandler<CreateRequest, (bool IsSuccess, JediStudent Result, string Message)>
        {
            private readonly IJediStudentsDbContext _dbContext;

            public Handler(IJediStudentsDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<(bool IsSuccess, JediStudent Result, string Message)> Handle(CreateRequest request,
                                                                                                CancellationToken cancellationToken)
            {
                try
                {
                    var jediStudent = new JediStudent
                    {
                        Id = Guid.NewGuid().GetHashCode(),
                        Name = request.Name,
                        Height = request.Height,
                        Mass = request.Mass,
                        Species = request.Species,
                        // Edited by CPang 2020-07-17 Challenge 3
                        Planet = request.Planet
                    };
                    _dbContext.JediStudents.Add(jediStudent);

                    await _dbContext.SaveChangesAsync(cancellationToken);

                    return (true, jediStudent, null);
                }
                catch (Exception exception)
                {
                    return (false, null, exception.Message);
                }
            }
        }
        #endregion Handler
    }
}