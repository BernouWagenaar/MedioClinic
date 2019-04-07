using System.Collections.Generic;
using System.Linq;
using Business.Dto.Company;
using Business.Services.Query;
using CompanyService = CMS.DocumentEngine.Types.MedioClinic.CompanyService;

namespace Business.Repository.Company
{
    public class CompanyServiceRepository : BaseRepository, ICompanyServiceRepository
    {
        public CompanyServiceRepository(IDocumentQueryService documentQueryService) : base(documentQueryService)
        {
        }

        public IEnumerable<CompanyServiceDto> GetCompanyServices()
        {
            return DocumentQueryService.GetDocuments<CompanyService>()
                .AddColumns(
                    nameof(CompanyService.Header), 
                    nameof(CompanyService.Text), 
                    nameof(CompanyService.Icon)
                )
                .OrderByAscending(nameof(CompanyService.NodeOrder))
                .ToList()
                .Select(m => new CompanyServiceDto()
                {
                    Header = m.Header,
                    Text = m.Text,
                    Icon = m.Fields.Icon
                });
        }
    }
}