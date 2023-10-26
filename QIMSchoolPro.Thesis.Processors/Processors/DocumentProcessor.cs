using Microsoft.AspNetCore.Http;
using QIMSchoolPro.Thesis.Domain.Entities;
using QIMSchoolPro.Thesis.Domain.Enums;
using QIMSchoolPro.Thesis.Domain.ValueObjects;
using QIMSchoolPro.Thesis.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QIMSchoolPro.Thesis.Processors.Processors
{
    [ProcessorBase]
    public class DocumentProcessor
    {
        private readonly IDocumentRepository _documentRepository;

        public DocumentProcessor(IDocumentRepository documentRepository)
        {
           _documentRepository = documentRepository;
        }

       

        //public async Task Create(DocumentCommand command, CancellationToken cancellationToken)
        //{
        //    try
        //    {
        //        var entity = Document.Create(command.SubmissionId, command.Name);

        //        await _documentRepository.InsertAsync(entity, cancellationToken);

        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}
    }



    public class DocumentCommand
    {
        public int SubmissionId { get; set; }
        public string Name { get; set; }
    }
}
