using QIMSchoolPro.Thesis.Domain.Enums;
using QIMSchoolPro.Thesis.Processors.Dtos;

namespace QIMSchoolPro.Thesis.Domain.Entities
{
    public class ThesisAssignmentDto 
    {
        public int Id { get; set; }
        public int SubmissionId { get; set; }
        public SubmissionDto Submission { get; set; }
        public int StaffId { get; set; }
        public StaffDto Staff { get; set; }
        public ReviewDecision Decision { get; set; }
        public ReviewerType ReviewerType { get; set; }
        public DateTime Deadline { get; set; }
        public bool Assessment { get; set; }
        public List<GradeDto> Grades { get; set; }
        public List<ExaminerReportDto> ExaminerReports { get; set; }

    }

    public class ThesisAssignmentDtoAnnex
    {
        public int Id { get; set; }
        public int SubmissionId { get; set; }
        public int StaffId { get; set; }
        public StaffDto Staff { get; set; }
        public ReviewDecision Decision { get; set; }
        public ReviewerType ReviewerType { get; set; }
        public DateTime Deadline { get; set; }
        public bool Assessment { get; set; }

    }
}
