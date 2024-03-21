﻿using MediatR;
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


    public static class DeapartmentApproval
    {

        public class Query : IRequest
        {
            public int SubmissionId { get; set; }
            public int ApprovalId { get; set; }
            public Query(int submissionId, int approvalId)
            {
                SubmissionId = submissionId;
                ApprovalId = approvalId;
            }
        }


        public class Handler : IRequestHandler<Query>
        {
            private readonly SubmissionProcessor _submissionprocessor;

            public Handler(SubmissionProcessor submissionprocessor)
            {
                _submissionprocessor = submissionprocessor;

            }
            public async Task Handle(Query request, CancellationToken cancellationToken)
            {
                await _submissionprocessor.DepartmentApproval(request.SubmissionId, request.ApprovalId, cancellationToken);
            }
        }


    }


    public static class SubmitToLibrary 
    {

        public class Query : IRequest
        {
            public int SubmissionId { get; set; }
            
            public Query(int submissionId)
            {
                SubmissionId = submissionId;
               
            }
        }


        public class Handler : IRequestHandler<Query>
        {
            private readonly SubmissionProcessor _submissionprocessor;

            public Handler(SubmissionProcessor submissionprocessor)
            {
                _submissionprocessor = submissionprocessor;

            }
            public async Task Handle(Query request, CancellationToken cancellationToken)
            {
                await _submissionprocessor.SubmitToLibrary(request.SubmissionId);
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

    public static class GetDepartmentProcessedReviews
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
                var result = await _submissionProcessor.GetDepartmentProcessedReviews();
                return result;
            }
        }
    }

    public static class GetSPSSubmissions
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
                var result = await _submissionProcessor.GetSPSSubmissions();
                return result;
            }
        }
    }


    public static class GetLibrarySubmissions
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
                var result = await _submissionProcessor.GetLibrarySubmissions();
                return result;
            }
        }
    }
    public static class GetSPSProcessedReviews
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
                var result = await _submissionProcessor.GetSPSProcessedReviews();
                return result;
            }
        }
    }

    public static class GetReportSubmissions
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
                var result = await _submissionProcessor.GetReportSubmissions();
                return result;
            }
        }
    }


    public static class GetStudentReportSubmissions
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
                var result = await _submissionProcessor.GetStudentReportSubmissions();
                return result;
            }
        }
    }


    public static class GetDepartmentReportSubmissions
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
                var result = await _submissionProcessor.GetDepartmentReportSubmissions();
                return result;
            }
        }
    }


    public static class GetReviewerReportSubmissions
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
                var result = await _thesisAssignmentProcessor.GetReviewerReportSubmissions();
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
