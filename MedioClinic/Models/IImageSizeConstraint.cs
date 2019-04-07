using Kentico.Content.Web.Mvc;

namespace MedioClinic.Models
{
    /// <summary>
    /// Interface for size constrains so that we can avoid using Kentico code directly in views
    /// </summary>
    public interface IImageSizeConstraint
    {
        SizeConstraint GetSizeConstraint();
    }
}
