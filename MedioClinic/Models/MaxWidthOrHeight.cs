using Kentico.Content.Web.Mvc;

namespace MedioClinic.Models
{
    /// <summary>
    /// Specifies the maximum width and height of the image
    /// </summary>
    public class MaxWidthOrHeight : IImageSizeConstraint
    {
        private readonly int _maxWidthOrHeight;

        public MaxWidthOrHeight(int maxWidthOrHeight)
        {
            _maxWidthOrHeight = maxWidthOrHeight;
        }

        public SizeConstraint GetSizeConstraint()
        {
            return SizeConstraint.MaxWidthOrHeight(_maxWidthOrHeight);
        }
    }
}