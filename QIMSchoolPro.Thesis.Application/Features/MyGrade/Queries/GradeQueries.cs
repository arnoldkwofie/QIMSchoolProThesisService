using MediatR;
using QIMSchoolPro.Thesis.Domain.Entities;
using QIMSchoolPro.Thesis.Processors.Processors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace QIMSchoolPro.Thesis.Application.Features.MyStaff.Queries
{
    
        public static class GetGradeParams
    {
            public class Query : IRequest<IEnumerable<GradeParamDto>>
            {
                public Query()
                {
               
                }
            }

            public class Handler : IRequestHandler<Query, IEnumerable<GradeParamDto>>
            {
                private readonly GradeParamProcessor _gradeParamProcessor;

                public Handler(GradeParamProcessor gradeParamProcessor)
                {
                    _gradeParamProcessor = gradeParamProcessor;
                }

                public async Task<IEnumerable<GradeParamDto>> Handle(Query request, CancellationToken cancellationToken)
                {
                var result = await _gradeParamProcessor.GetAll();
                    return result;
                }
            }
        }


   
}
