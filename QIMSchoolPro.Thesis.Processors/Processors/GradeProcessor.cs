using AutoMapper;
using Microsoft.AspNetCore.Http;
using QIMSchoolPro.Thesis.Domain.Entities;
using QIMSchoolPro.Thesis.Domain.Enums;
using QIMSchoolPro.Thesis.Domain.ValueObjects;
using QIMSchoolPro.Thesis.Persistence.Interfaces;
using QIMSchoolPro.Thesis.Persistence.Repositories;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace QIMSchoolPro.Thesis.Processors.Processors
{
    [ProcessorBase]
    public class GradeProcessor
    {
        private readonly IGradeRepository _gradeRepository;
        private readonly IMapper _mapper;
        private readonly IThesisAssignmentRepository _thesisAssignment;
        private readonly IExaminerReportRepository _examinerReportRepository;
        public GradeProcessor(IGradeRepository gradeRepository, IMapper mapper, IThesisAssignmentRepository thesisAssignment, IExaminerReportRepository examinerReportRepository)
        {
            _gradeRepository = gradeRepository;
            _mapper = mapper;
            _thesisAssignment = thesisAssignment;
            _examinerReportRepository = examinerReportRepository;

        }

        public async Task UploadReport(UploadCommand command)
        {
            try
            {
                    var report = ExaminerReport.Create(command.ThesisAssignmentId, command.Path);
                    await _examinerReportRepository.InsertAsync(report);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task SaveGrade(List<GradeCommand> command)
        {
            var data = new List<Grade>();

            foreach (var commandItem in command)
            {
                var grade = Grade.Create(commandItem.AssignmentId, commandItem.GradeParamId, commandItem.Marks, commandItem.Comment);
                data.Add(grade);
            }
            await _gradeRepository.InsertAsync(data);

            var id = command.FirstOrDefault().AssignmentId;
            var assignment = await _thesisAssignment.GetAsync(id);
            var assessment = assignment.Assess();
            await _thesisAssignment.UpdateAsync(assessment);
        }

    }

    public class GradeCommand
    {
        public int AssignmentId { get; set; }
        public int GradeParamId { get; set; }
        public decimal Marks { get; set; }
        public string Comment { get; set; }
    }

    public class UploadCommand
    {
        public int ThesisAssignmentId { get; set; }
        public string Path { get; set; }
    }



}

