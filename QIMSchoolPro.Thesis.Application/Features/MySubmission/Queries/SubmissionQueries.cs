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
    
        public static class GetUserSubmissions
    {
            public class Query : IRequest<IEnumerable<SubmissionDto>>
            {
                public Query()
                {

                }
            }

            public class Handler : IRequestHandler<Query, IEnumerable<SubmissionDto>>
            {
                private readonly SubmissionProcessor _submissionProcessor;

                public Handler(SubmissionProcessor submissionProcessor)
                {
                    _submissionProcessor = submissionProcessor;
                }

                public async Task<IEnumerable<SubmissionDto>> Handle(Query request, CancellationToken cancellationToken)
                {
                    var result = await _submissionProcessor.GetUserSubmissions();
                    return result;
                }
            }
        }




    public static class GetDepartmentSubmissions
    {
        public class Query : IRequest<IEnumerable<SubmissionDto>>
        {
            public Query()
            {

            }
        }

        public class Handler : IRequestHandler<Query, IEnumerable<SubmissionDto>>
        {
            private readonly SubmissionProcessor _submissionProcessor;

            public Handler(SubmissionProcessor submissionProcessor)
            {
                _submissionProcessor = submissionProcessor;
            }

            public async Task<IEnumerable<SubmissionDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _submissionProcessor.GetDepartmentSubmissions();
                return result;
            }
        }
    }


    public static class GetSubmission
    {
        public class Query : IRequest<SubmissionDto>
        {
            public Query(int id)
            {
                Id = id;
            }

            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, SubmissionDto>
        {
            private readonly SubmissionProcessor _submissionProcessor;

            public Handler(SubmissionProcessor submissionProcessor)
            {
                _submissionProcessor = submissionProcessor;
            }

            public async Task<SubmissionDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _submissionProcessor.Get(request.Id);
                return result;
            }
        }
    }
}
