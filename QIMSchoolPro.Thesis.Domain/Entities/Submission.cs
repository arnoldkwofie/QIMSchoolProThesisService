using Qface.Domain.Shared.Common;
using QIMSchoolPro.Thesis.Domain.Enums;
using QIMSchoolPro.Thesis.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QIMSchoolPro.Thesis.Domain.Entities
{
    public class Submission : AuditableAutoEntity
    {
        public int Id { get; set; }
        [ForeignKey(nameof(Student))]
        public string StudentNumber { get; set; }
        //[NotMapped]
        public Student Student { get; set; }
        public string Title { get; set; }
        public string Abstract { get; set; }
        public TransitionState TransitionState { get; set; }
        public DateTime SubmissionDate { get; set; }
        public int Trip { get; set; }
        public AcademicPeriod AcademicPeriod { get; set; }
        public List<Document> Documents { get; set; }   
        public List<SubmissionHistory> SubmissionHistories { get; set; }

        public Submission() 
        {
        }

        public Submission(string studentNumber, string _abstract, string title, TransitionState transitionState, DateTime submissionDate, AcademicPeriod academicPeriod, int trip)
        {
            StudentNumber = studentNumber;
            Abstract = _abstract;
            Title = title;
            TransitionState = transitionState;
            SubmissionDate = submissionDate;
            AcademicPeriod = academicPeriod;
            Trip = trip;
        }

        public static Submission Create(string studentNumber, string _abstract, string title, TransitionState transitionState, DateTime submissionDate, AcademicPeriod academicPeriod, int trip)
        {
            return new Submission(
                studentNumber, _abstract, title, transitionState, submissionDate, academicPeriod, trip
            );
        }

		public Submission Update(string _abstract, string title, TransitionState transitionState, DateTime submissionDate, int trip)
		{
			Abstract = _abstract;
			Title = title;
            TransitionState=transitionState;
            SubmissionDate = submissionDate;
            Trip=trip;
            
			return this;
		}

        public Submission Transit(TransitionState transitionState)
        {
            TransitionState = transitionState;

            return this;
        }
    }
}
