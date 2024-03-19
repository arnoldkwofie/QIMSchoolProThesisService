using FluentValidation;
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
    public static class SubmissionCreate
    {
      
        public class Command : IRequest
        {
            
            public string Title { get; set; }
            public string Abstract { get; set; }
            public IFormFile PrimaryFile { get; set; }
            public IFormFile ThesisForm { get; set; }
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
                await _submissionprocessor.Create(request.Title, request.Abstract, request.PrimaryFile, request.ThesisForm, request.SecondaryFile, cancellationToken);
            }
        }


    }


    public static class SubmissionDecision
    {

        public class DecideCommand : IRequest
        {

            public int id { get; set; }
            public int decision { get; set; }
           

        }

        public class Handler : IRequestHandler<DecideCommand>
        {
            private readonly SubmissionProcessor _submissionprocessor;

            public Handler(SubmissionProcessor submissionProcessor)
            {
                _submissionprocessor = submissionProcessor;

            }
            public async Task Handle(DecideCommand request, CancellationToken cancellationToken)
            {
                await _submissionprocessor.SubmissionDecision(request.id, request.decision);
            }
        }
    }


    public static class Publish
    {

        public class PublishCommand : IRequest
        {
            public int id { get; set; }
        }

        public class Handler : IRequestHandler<PublishCommand>
        {
            private readonly SubmissionProcessor _submissionprocessor;

            public Handler(SubmissionProcessor submissionProcessor)
            {
                _submissionprocessor = submissionProcessor;

            }
            public async Task Handle(PublishCommand request, CancellationToken cancellationToken)
            {
                await _submissionprocessor.Publish(request.id);
            }
        }


    }

    public static class PostSubmission
	{

		public class PostSubmissionCommand : IRequest
		{
			public SubmissionCommand Payload { get; set; }

		}

		public class Handler : IRequestHandler<PostSubmissionCommand>
		{
			private readonly SubmissionProcessor _submissionprocessor;

			public Handler(SubmissionProcessor submissionprocessor)
			{
				_submissionprocessor = submissionprocessor;

			}
			public async Task Handle(PostSubmissionCommand request, CancellationToken cancellationToken)
			{
				await _submissionprocessor.PostSubmission(request.Payload, cancellationToken);
			}
		}


	}


    public static class DeleteSubmission { 

        public class Command : IRequest<long>
        {
            public long Id { get; set; }
        }

        public class Handler : IRequestHandler<Command, long>
        {
            private readonly SubmissionProcessor _submissionProcessor;

            public Handler(SubmissionProcessor submissionprocessor)
            {
                _submissionProcessor = submissionprocessor;
            }
            public async Task<long> Handle(Command request, CancellationToken cancellationToken)
            {
                await _submissionProcessor.DeleteSubmission(request.Id);

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
