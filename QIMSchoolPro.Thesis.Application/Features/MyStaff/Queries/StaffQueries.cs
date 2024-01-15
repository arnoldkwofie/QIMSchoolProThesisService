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
    
        public static class GetStaffLookup
    {
            public class Query : IRequest<IEnumerable<StaffLookUpModel>>
            {
                public int Id { get; set; }
                public Query(int id)
                {
                Id = id;
                }
            }

            public class Handler : IRequestHandler<Query, IEnumerable<StaffLookUpModel>>
            {
                private readonly StaffProcessor _staffProcessor;

                public Handler(StaffProcessor staffProcessor)
                {
                    _staffProcessor = staffProcessor;
                }

                public async Task<IEnumerable<StaffLookUpModel>> Handle(Query request, CancellationToken cancellationToken)
                {
                    var result = await _staffProcessor.StaffLookUp(request.Id);
                    return result;
                }
            }
        }


   
}
