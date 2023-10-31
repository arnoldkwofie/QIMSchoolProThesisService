using MediatR;
using Microsoft.AspNetCore.Http;
using QIMSchoolPro.Thesis.Processors.Processors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QIMSchoolPro.Thesis.Application.Features.MySubmission.Commands
{
    public static class Create
    {
      
        public class Command : IRequest
        {
            public string StudentNumber { get; set; }
            public string Title { get; set; }
            public string Abstract { get; set; }
            public IFormFile PrimaryFile { get; set; }
            public IFormFile SecondaryFile { get; set; }

        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly SubmissionProcessor _submissionprocessor;

            public Handler(SubmissionProcessor submissionProcessor)
            {
                _submissionprocessor = submissionProcessor;

            }
            public async Task Handle(Command request, CancellationToken cancellationToken)
            {
                await _submissionprocessor.Create(request.StudentNumber, request.Title, request.Abstract, request.PrimaryFile, request.SecondaryFile, cancellationToken);
            }
        }


    }

}
