using Core.Entities;

namespace Entities.Concrete
{
    public class CarImage : IEntity
    {
        public CarImage()
        {
            Date = DateTime.Now;
        }

        public int CarImageId { get; set; }
        public int CarId { get; set; }
        public string? ImagePath { get; set; }
        public DateTime Date { get; set; }

        public void SetImagePath(string imagePath)
        {
            this.ImagePath = imagePath;
        }
    }
}
