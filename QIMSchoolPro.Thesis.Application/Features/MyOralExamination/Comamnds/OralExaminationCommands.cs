using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using QIMSchoolPro.Thesis.Processors.Processors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QIMSchoolPro.Thesis.Application.Features.MyOralExamination.Commands
{
    public static class Schedule
    {
      
        public class MyScheduleCommand : IRequest
        {
            public ScheduleCommand Command { get; set; }
        }

        public class Handler : IRequestHandler<MyScheduleCommand>
        {
            private readonly OralExaminationProcessor _oralExaminationProcessor;

            public Handler(OralExaminationProcessor oralExaminationProcessor)
            {
                _oralExaminationProcessor = oralExaminationProcessor;
            }
            public async Task Handle(MyScheduleCommand request, CancellationToken cancellationToken)
            {
                await _oralExaminationProcessor.Schedule(request.Command, cancellationToken);
            }
        }


    }





}
