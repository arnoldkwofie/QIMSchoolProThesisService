using MediatR;
using Microsoft.AspNetCore.Http;
using QIMSchoolPro.Thesis.Domain.Entities;
using QIMSchoolPro.Thesis.Processors.Processors;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QIMSchoolPro.Thesis.Application.Features.MyThesisAssignment.ThesisAssignmentCommands
{
	//[SwaggerSchemaId("ThesisAssignmentCreate_Command")]
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


    public static class MakeDecision
    {
        public class Commandx : IRequest
        {
            public DecisionCommand command { get; set; }
        }

        public class Handler : IRequestHandler<Commandx>
        {
            private readonly ThesisAssignmentProcessor _thesisAssignmentProcessor;

            public Handler(ThesisAssignmentProcessor thesisAssignmentProcessor)
            {
                _thesisAssignmentProcessor = thesisAssignmentProcessor;
            }

            public async Task Handle(Commandx request, CancellationToken cancellationToken)
            {
                await _thesisAssignmentProcessor.Decide(request.command);
                
            }
        }
    }







}
