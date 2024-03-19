using MediatR;
using QIMSchoolPro.Thesis.Processors.Processors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QIMSchoolPro.Thesis.Application.Features.MyGrade.Commands
{
    public static class SaveGrade
    {

        public class SaveGradeCommand : IRequest
        {
            public List<GradeCommand> Payload { get; set; }

        }

        public class Handler : IRequestHandler<SaveGradeCommand>
        {
            private readonly GradeProcessor _gradeProcessor;

            public Handler(GradeProcessor gradeProcessor)
            {
                _gradeProcessor = gradeProcessor;
            }
            public async Task Handle(SaveGradeCommand request, CancellationToken cancellationToken)
            {
                await _gradeProcessor.SaveGrade(request.Payload);
            }
        }

    }


    public static class UploadReport
    {

        public class UploadReportCommand : IRequest
        {
            public UploadCommand Payload { get; set; }

        }

        public class Handler : IRequestHandler<UploadReportCommand>
        {
            private readonly GradeProcessor _gradeProcessor;

            public Handler(GradeProcessor gradeProcessor)
            {
                _gradeProcessor = gradeProcessor;
            }
            public async Task Handle(UploadReportCommand request, CancellationToken cancellationToken)
            {
                await _gradeProcessor.UploadReport(request.Payload);
            }
        }

    }

}
