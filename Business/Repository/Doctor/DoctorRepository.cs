using Business.Dto.Doctors;
using Business.Services.Query;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Repository.Doctor
{
    public class DoctorRepository : BaseRepository, IDoctorRepository
    {
        private readonly string[] _doctorColumns =
        {
            "NodeAlias",
            "Bio",
            "Degree",
            "EmergencyShift",
            "FirstName",
            "LastName",
            "Photo",
            "Specialty"
        };

        /// <summary>
        /// Func to map a Doctor to a DoctorDto
        /// </summary>
        private Func<CMS.DocumentEngine.Types.MedioClinic.Doctor, DoctorDto> DoctorDtoSelect => doctor => new DoctorDto()
        {
            NodeAlias = doctor.NodeAlias,
            NodeGuid = doctor.NodeGUID,
            NodeId = doctor.NodeID,
            Bio = doctor.Bio,
            Degree = doctor.Degree,
            EmergencyShift = doctor.EmergencyShift,
            FirstName = doctor.FirstName,
            LastName = doctor.LastName,
            Photo = doctor.Fields.Photo,
            Specialty = doctor.Specialty
        };

        public DoctorRepository(IDocumentQueryService documentQueryService) : base(documentQueryService)
        {
        }

        public IEnumerable<DoctorDto> GetDoctors()
        {
            return DocumentQueryService.GetDocuments<CMS.DocumentEngine.Types.MedioClinic.Doctor>()
                .AddColumns(_doctorColumns)
                .ToList()
                .Select(DoctorDtoSelect);
        }

        public DoctorDto GetDoctor(Guid nodeGuid)
        {
            return DocumentQueryService.GetDocument<CMS.DocumentEngine.Types.MedioClinic.Doctor>(nodeGuid)
                .AddColumns(_doctorColumns)
                .Select(DoctorDtoSelect)
                .FirstOrDefault();
        }
    }
}
