using Qface.Domain.Shared.Common;
using QIMSchoolPro.Thesis.Domain.Enums;
using QIMSchoolPro.Thesis.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QIMSchoolPro.Thesis.Domain.Entities
{
    public class Submission : AuditableAutoEntity
    {
        public int Id { get; set; }
        public string StudentNumber { get; set; }
        public string Title { get; set; }
        public string Abstract { get; set; }
        public TransitionState TransitionState { get; set; }
        public DateTime SubmissionDate { get; set; }
        public AcademicPeriod AcademicPeriod { get; set; }
        public List<Document> Documents { get; set; }   
        public List<SubmissionHistory> SubmissionHistories { get; set; }

        public Submission() 
        {
        }

        public Submission(string studentNumber, string _abstract, string title, TransitionState transitionState, DateTime submissionDate, AcademicPeriod academicPeriod)
        {
            StudentNumber = studentNumber;
            Abstract = _abstract;
            Title = title;
            TransitionState = transitionState;
            SubmissionDate = submissionDate;
            AcademicPeriod = academicPeriod;
        }

        public static Submission Create(string studentNumber, string _abstract, string title, TransitionState transitionState, DateTime submissionDate, AcademicPeriod academicPeriod)
        {
            return new Submission(
                studentNumber, _abstract, title, transitionState, submissionDate, academicPeriod
            );
        }
    }
}
