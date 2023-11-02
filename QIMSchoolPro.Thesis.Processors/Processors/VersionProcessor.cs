using Microsoft.AspNetCore.Http;
using QIMSchoolPro.Thesis.Domain.Entities;
using QIMSchoolPro.Thesis.Domain.Enums;
using QIMSchoolPro.Thesis.Domain.ValueObjects;
using QIMSchoolPro.Thesis.Persistence.Interfaces;
using QIMSchoolPro.Thesis.Persistence.Repositories;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Version = QIMSchoolPro.Thesis.Domain.Entities.Version;

namespace QIMSchoolPro.Thesis.Processors.Processors
{
    [ProcessorBase]
    public class VersionProcessor
    {
        private readonly IVersionRepository _versionRepository;

        public VersionProcessor(IVersionRepository versionRepository)
        {
            _versionRepository = versionRepository;
        }

        public async Task Create(int documentId, IFormFile file, CancellationToken cancellationToken)
        {
            try
            {

                if (file != null)
                {

                    var data = await _versionRepository.GetVersionsByDocumentId(documentId);
                    var lastRecord = data.LastOrDefault();
                    var index = lastRecord?.Index == null? 1 : lastRecord.Index + 1;

                    var version = Version.Create(documentId, "v" + index, file.FileName, index);
                    await _versionRepository.InsertAsync(version, cancellationToken);

                }


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }

    public class VersionCommand
    {
        public int DocumentId { get; set; }
        public string Name { get; set; }
        
    }

   
}
