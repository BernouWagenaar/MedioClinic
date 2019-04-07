using Business.Services;
using Business.Services.Context;
using Kentico.Content.Web.Mvc;
using Kentico.Web.Mvc;
using System.Web;

namespace MedioClinic.Utils
{
    public class SiteContextService : BaseService, ISiteContextService
    {
        public string SiteName { get; }

        public string CurrentSiteCulture { get; }

        public string PreviewCulture => HttpContext.Current.Kentico().Preview().CultureName;

        public bool IsPreviewEnabled => HttpContext.Current.Kentico().Preview().Enabled;

        public SiteContextService(string currentCulture, string sitename)
        {
            CurrentSiteCulture = currentCulture;
            SiteName = sitename;
        }
    }
}