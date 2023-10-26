using MediatR;
using QIMSchoolPro.Thesis.Domain.Entities;
using QIMSchoolPro.Thesis.Processors.Processors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace QIMSchoolPro.Thesis.Application.Features.Submission.Queries
{
    
        public static class GetSubmissions
        {
            public class Query : IRequest<List<SubmissionDto>>
            {
                public Query()
                {

                }
            }

            public class Handler : IRequestHandler<Query, List<SubmissionDto>>
            {
                private readonly SubmissionProcessor _submissionProcessor;

                public Handler(SubmissionProcessor submissionProcessor)
                {
                    _submissionProcessor = submissionProcessor;
                }

                public async Task<List<SubmissionDto>> Handle(Query request, CancellationToken cancellationToken)
                {
                    var result = await _submissionProcessor.Gets();
                    return result;
                }
            }

        
    }
}
