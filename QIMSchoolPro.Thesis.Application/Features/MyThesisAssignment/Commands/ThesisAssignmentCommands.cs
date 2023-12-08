using MediatR;
using Microsoft.AspNetCore.Http;
using QIMSchoolPro.Thesis.Processors.Processors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QIMSchoolPro.Thesis.Application.Features.MyThesisAssignment.ThesisAssignmentCommands
{
    public static class ThesisAssignmentCreate
    {
      
        public class Command : IRequest
        {
           public ThesisAssignmentCommand Payload { get; set; }
            
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly ThesisAssignmentProcessor _thesisAssignmentProcessor;

            public Handler(ThesisAssignmentProcessor thesisAssignmentProcessor)
            {
                _thesisAssignmentProcessor = thesisAssignmentProcessor;

            }
            public async Task Handle(Command request, CancellationToken cancellationToken)
            {
                await _thesisAssignmentProcessor.Create(request.Payload,cancellationToken);
            }
        }


    }

}
