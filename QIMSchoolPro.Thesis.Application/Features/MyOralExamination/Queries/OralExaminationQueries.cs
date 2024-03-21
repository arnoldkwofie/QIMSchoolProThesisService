using MediatR;
using QIMSchoolPro.Thesis.Domain.Entities;
using QIMSchoolPro.Thesis.Processors.Dtos;
using QIMSchoolPro.Thesis.Processors.Processors;
using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace QIMSchoolPro.Thesis.Application.Features.MySubmission.Queries
{

    public static class GetAll
    {
        public class Query : IRequest<IEnumerable<OralExaminationDto>>
        {
            public Query()
            {

            }
        }

        public class Handler : IRequestHandler<Query, IEnumerable<OralExaminationDto>>
        {
            private readonly OralExaminationProcessor _oralExaminationProcessor;

            public Handler(OralExaminationProcessor oralExaminationProcessor)
            {
                _oralExaminationProcessor = oralExaminationProcessor;
            }

            public async Task<IEnumerable<OralExaminationDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _oralExaminationProcessor.GetAll();
                return result;
            }
        }
    }



}
   
