
//using AutoMapper;
using AutoMapper;
using Qface.Application.Shared.Dtos;

using Qface.Domain.Shared.ValueObjects;
using QIMSchoolPro.Thesis.Domain.Entities;
using QIMSchoolPro.Thesis.Persistence.Configurations;
using Version = QIMSchoolPro.Thesis.Domain.Entities.Version;

namespace QIMSchoolPro.Students.Processors.Mappings
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{

			CreateMap<Submission, SubmissionDto>().ReverseMap();
            CreateMap<Document, DocumentDto>().ReverseMap();
			CreateMap<Version, VersionDto>().ReverseMap();
			CreateMap<SubmissionHistory, SubmissionHistoryDto>().ReverseMap();
			CreateMap<ThesisAssignment, ThesisAssignmentDto>().ReverseMap();
			CreateMap<Student, StudentDto>().ReverseMap();
			CreateMap<Programme, ProgrammeDto>().ReverseMap();
			CreateMap<Department, DepartmentDto>().ReverseMap();
			CreateMap<Party, PartyDto>().ReverseMap();
			CreateMap<Staff, StaffDto>().ReverseMap();
			CreateMap<Certificate, CertificateDto>().ReverseMap();
			
			
		}
	}
}
