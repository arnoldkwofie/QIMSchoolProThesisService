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
    
        public static class GetSubmissionHistoryBySubmissionId
    {
            public class Query : IRequest<IEnumerable<SubmissionHistoryDto>>
            {
                public Query(int id)
                {
                    Id= id;
                }
                public int Id { get; set; }

        }

            public class Handler : IRequestHandler<Query, IEnumerable<SubmissionHistoryDto>>
            {
                private readonly SubmissionHistoryProcessor _submissionHistoryProcessor;

                public Handler(SubmissionHistoryProcessor submissionHistoryProcessor)
                {
                    _submissionHistoryProcessor = submissionHistoryProcessor;
                }

                public async Task<IEnumerable<SubmissionHistoryDto>> Handle(Query request, CancellationToken cancellationToken)
                {
                    var result = await _submissionHistoryProcessor.GetSubmissionHistoryBySubmissionId(request.Id);
                    return result;
                }
            }
        }

    
}
