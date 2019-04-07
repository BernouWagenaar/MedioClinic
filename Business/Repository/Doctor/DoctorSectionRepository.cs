using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Dto.Doctors;
using Business.Services.Query;
using CMS.DocumentEngine.Types.MedioClinic;

namespace Business.Repository.Doctor
{
    public class DoctorSectionRepository : BaseRepository, IDoctorSectionRepository
    {
        public DoctorSectionRepository(IDocumentQueryService documentQueryService) : base(documentQueryService)
        {
        }

        public DoctorSectionDto GetDoctorSection()
        {
            // Get a DoctorSection (generated class) and map/convert it to a DoctorSectionDto
            return DocumentQueryService.GetDocument<DoctorSection>()
                .AddColumns(
                    nameof(DoctorSection.Title)
                )
                .Select(m => new DoctorSectionDto()
                {
                    Header = m.Title
                })
                .FirstOrDefault();
        }
    }
}
