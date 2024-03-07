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
    
        public static class GetByStaffId
        {
            public class Query : IRequest<IEnumerable<ThesisAssignmentDto>>
            {
                public Query()
                {
                  
                }
            

            }

            public class Handler : IRequestHandler<Query, IEnumerable<ThesisAssignmentDto>>
            {
                private readonly ThesisAssignmentProcessor _thesisAssignmentProcessor;

                public Handler(ThesisAssignmentProcessor thesisAssignmentProcessor)
                {
                    _thesisAssignmentProcessor = thesisAssignmentProcessor;
                }

                public async Task<IEnumerable<ThesisAssignmentDto>> Handle(Query request, CancellationToken cancellationToken)
                {
                    var result = await _thesisAssignmentProcessor.GetByStaffId();
                    return result;
                }
            }
        }

    public static class GetApprovedByStaffId
    {
        public class Query : IRequest<IEnumerable<ThesisAssignmentDto>>
        {
            public Query()
            {

            }


        }

        public class Handler : IRequestHandler<Query, IEnumerable<ThesisAssignmentDto>>
        {
            private readonly ThesisAssignmentProcessor _thesisAssignmentProcessor;

            public Handler(ThesisAssignmentProcessor thesisAssignmentProcessor)
            {
                _thesisAssignmentProcessor = thesisAssignmentProcessor;
            }

            public async Task<IEnumerable<ThesisAssignmentDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _thesisAssignmentProcessor.GetApprovedByStaffId();
                return result;
            }
        }
    }


}
