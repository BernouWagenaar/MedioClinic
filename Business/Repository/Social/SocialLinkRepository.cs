using System.Collections.Generic;
using System.Linq;
using Business.Dto.Social;
using Business.Services.Query;

namespace Business.Repository.Social
{
    public class SocialLinkRepository : BaseRepository, ISocialLinkRepository
    {
        public SocialLinkRepository(IDocumentQueryService documentQueryService) : base(documentQueryService)
        {
        }

        public IEnumerable<SocialLinkDto> GetSocialLinks()
        {
            return DocumentQueryService.GetDocuments<CMS.DocumentEngine.Types.MedioClinic.SocialLink>()
                .AddColumns(
                    nameof(CMS.DocumentEngine.Types.MedioClinic.SocialLink.Title),
                    nameof(CMS.DocumentEngine.Types.MedioClinic.SocialLink.Url),
                    nameof(CMS.DocumentEngine.Types.MedioClinic.SocialLink.Icon)
                )
                .OrderByAscending(nameof(CMS.DocumentEngine.Types.MedioClinic.SocialLink.NodeOrder))
                .ToList()
                .Select(m => new SocialLinkDto()
                {
                    Url = m.Url,
                    Title = m.Title,
                    Icon = m.Fields.Icon
                });
        }
    }
}