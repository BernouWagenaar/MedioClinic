using System;
using System.Linq;
using CMS.DocumentEngine;
using Business.Services.Context;

namespace Business.Services.Query
{
    public class DocumentQueryService : BaseService, IDocumentQueryService
    {
        private ISiteContextService SiteContext { get; }

        private readonly string[] _coreColumns =
        {
            // Defines initial columns returned for optimization. If not set, all columns are returned.
            nameof(TreeNode.NodeGUID), nameof(TreeNode.DocumentID), nameof(TreeNode.NodeID)
        };

        public DocumentQueryService(ISiteContextService siteContext)
        {
            SiteContext = siteContext;
        }

        public DocumentQuery<TDocument> GetDocument<TDocument>(Guid nodeGuid) where TDocument : TreeNode, new()
        {
            return GetDocument<TDocument>()
                .WhereEquals(nameof(TreeNode.NodeGUID), nodeGuid);
        }

        public DocumentQuery<TDocument> GetDocument<TDocument>() where TDocument : TreeNode, new()
        {
            return GetDocuments<TDocument>()
                .TopN(1);
        }

        public DocumentQuery<TDocument> GetDocuments<TDocument>() where TDocument : TreeNode, new()
        {
            var query = DocumentHelper.GetDocuments<TDocument>()
                .OnSite(SiteContext.SiteName) // There could be more sites with matching documents
                .Columns(_coreColumns); // Sets initial columns returned for optimization.

            // Loads the latest version of documents as preview mode is enabled
            if (SiteContext.IsPreviewEnabled)
            {
                query = query
                    .AddColumn(nameof(TreeNode.NodeSiteID)) // Adds 'NoteSiteD' column required for the Preview mode.
                    .Published(false)
                    .LatestVersion()
                    .Culture(SiteContext.PreviewCulture);
            }
            else
            {
                query = query
                    .Published()
                    .PublishedVersion()
                    .Culture(SiteContext.CurrentSiteCulture);
            }

            return query;
        }
    }
}