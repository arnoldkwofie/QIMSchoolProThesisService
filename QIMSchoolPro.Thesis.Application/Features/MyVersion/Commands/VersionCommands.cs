using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using QIMSchoolPro.Thesis.Processors.Processors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QIMSchoolPro.Thesis.Application.Features.MyVersion.VersionCommands
{
    public static class VersionCreate
    {
      
        public class Command : IRequest
        {
            public int DocumentId { get; set; }
            public IFormFile File { get; set; }
            
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly VersionProcessor _versionProcessor;

            public Handler(VersionProcessor versionProcessor)
            {
                _versionProcessor = versionProcessor;

            }
            public async Task Handle(Command request, CancellationToken cancellationToken)
            {
                await _versionProcessor.Create(request.DocumentId, request.File, cancellationToken);
            }
        }


    }


    public static class DeleteVersion
    {

        public class Command : IRequest<long>
        {
            public long Id { get; set; }
        }

        public class Handler : IRequestHandler<Command, long>
        {
            private readonly VersionProcessor _versionProcessor;

            public Handler(VersionProcessor versionProcessor)
            {
                _versionProcessor = versionProcessor;
            }
            public async Task<long> Handle(Command request, CancellationToken cancellationToken)
            {
                await _versionProcessor.DeleteVersion(request.Id);

                return request.Id;
            }
        }
        public class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(x => x.Id).NotEmpty();
            }
        }

    }

}
