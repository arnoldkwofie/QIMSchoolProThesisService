using Microsoft.AspNetCore.Http;

using QIMSchoolPro.Thesis.Persistence.Interfaces;


using Version = QIMSchoolPro.Thesis.Domain.Entities.Version;

namespace QIMSchoolPro.Thesis.Processors.Processors
{
    [ProcessorBase]
    public class VersionProcessor
    {
        private readonly IVersionRepository _versionRepository;
        private readonly IDocumentRepository _documentRepository;
        private readonly ISubmissionRepository _submissionRepository;

        public VersionProcessor(IVersionRepository versionRepository, IDocumentRepository documentRepository, ISubmissionRepository submissionRepository)
        {
            _versionRepository = versionRepository;
            _documentRepository = documentRepository;
            _submissionRepository = submissionRepository;
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

                    var document = await _documentRepository.GetAsync(documentId);
                    if (document != null && document.Submission.Publish)
                    {
                        var submission = await _submissionRepository.GetAsync(document.SubmissionId);
                        int trip = submission.Trip + 1;
                        var model = submission.GoOnTrip(trip);
                        await _submissionRepository.UpdateAsync(model, cancellationToken);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task DeleteVersion(long id)
        {
            var version = await _versionRepository.GetAsync((int)id);
            if (version == null)
            {
                throw new FileNotFoundException("File not found");
            }

            await _versionRepository.SoftDeleteAsync(version);
        }


    }

    public class VersionCommand
    {
        public int DocumentId { get; set; }
        public string Name { get; set; }
        
    }

   
}
