﻿using Qface.Domain.Shared.Common;
using QIMSchoolPro.Thesis.Domain.Enums;
using QIMSchoolPro.Thesis.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QIMSchoolPro.Thesis.Domain.Entities
{
    public class Document : AuditableAutoEntity
    {
        public int Id { get; set; }
        public int SubmissionId { get; set; }
        public Submission Submission { get; set; }
        public string Name { get; set; }
        public DocumentType DocumentType { get; set; }


        public Document() 
        {
        }

        public Document(int submissionId, DocumentType documentType, string name)
        {
            SubmissionId = submissionId;
            Name = name;
        }

        public static Document Create(int submissionId, DocumentType documentType,  string name)
        {
            return new Document(
                submissionId, documentType, name
            );
        }
    }
}
