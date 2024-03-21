using QIMSchoolPro.Thesis.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace QIMSchoolPro.Thesis.Processors.Services
{
    public class HtmlMessage
    {
        public static string AssignmmentEmailMessage(AssignmmentEmailMessageModel model)
        {


            var message = "Dear " + model.ExaminerName + ",<br>" +
                "I write on behalf of the the School of Postgraduate Studies Board to appoint you as " + model.ReviewerType + "<br>" +
                "for a thesis titled <strong>" + model.Title + "</strong> submitted by a candidate with the details below: <br><br>" +
                "StudentName: " + model.StudentName + "<br>" +
                "StudentNumber: " + model.StudentNumber + "<br>" +
                "Programme: " + model.Programme + "<br>" +
                "Department: " + model.Department + "<br>" +
                "Submission No#: " + model.SubmissionNo + "<br><br>" +
                "please visit the Thesis Submission and Assessment Portal (TSAP) at <a href='https://portal.umat.edu.gh/thesis'>https://portal.umat.edu.gh/thesis</a> and login using your UMaT username and password or credentials sent to you. <br> <br> <br>" +
                "Sincerely <br>" +
                "UMaT Thesis Submission and Assesment Services <br>" +
                "School of Postgraduate Studies <br>";

            return message;
        }

        public static string AssignmmentSMSMessage(AssignmmentEmailMessageModel model)
        {


            var message = "Dear " + model.ExaminerName + ", you have been appointed as " + model.ReviewerType + " for " + model.Degree + " thesis. kindly check your email for detailed procedure";
               

            return message;
        }
    }

    public class AssignmmentEmailMessageModel
        {
        public string ExaminerName { get; set; }
        public string StudentName { get; set; }
        public string Programme { get; set; }
        public string StudentNumber { get; set; }
        public string Department { get; set; }
        public int SubmissionNo { get; set; }
        public string Title { get; set; }
        public ReviewerType ReviewerType { get; set; }
        public string Degree { get; set; }


    }
}
