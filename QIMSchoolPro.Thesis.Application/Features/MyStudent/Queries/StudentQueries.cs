using MediatR;
using QIMSchoolPro.Thesis.Domain.Entities;
using QIMSchoolPro.Thesis.Processors.Processors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace QIMSchoolPro.Thesis.Application.Features.MySubmission.Queries
{
    
     




    public static class GetStudent
    {
        public class Query : IRequest<StudentDto>
        {
            public Query(int id)
            {
                Id = id;
            }

            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, StudentDto>
        {
            private readonly StudentProcessor _studentProcessor;

            public Handler(StudentProcessor studentProcessor)
            {
                _studentProcessor = studentProcessor;
            }

            public async Task<StudentDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _studentProcessor.Get(request.Id);
                return result;
            }
        }
    }
}
