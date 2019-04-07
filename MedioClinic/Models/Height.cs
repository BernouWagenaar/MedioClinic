using Kentico.Content.Web.Mvc;

namespace MedioClinic.Models
{
    /// <summary>
    /// Specifies the maximum height of the image
    /// </summary>
    public class Height : IImageSizeConstraint
    {
        private readonly int _height;

        public Height(int height)
        {
            _height = height;
        }

        public SizeConstraint GetSizeConstraint()
        {
            return SizeConstraint.Height(_height);
        }
    }
}