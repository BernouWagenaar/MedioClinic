using Kentico.Content.Web.Mvc;

namespace MedioClinic.Models
{
    /// <summary>
    /// Specifies the maximum width of the image
    /// </summary>
    public class Width : IImageSizeConstraint
    {
        private readonly int _width;

        public Width(int width)
        {
            _width = width;
        }

        public SizeConstraint GetSizeConstraint()
        {
            return SizeConstraint.Width(_width);
        }
    }
}