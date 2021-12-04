using _0_FramWork.Application;
using _0_FramWork.BaseClass;
using ShopManagement.Application.Contract.SliderDTO;
using ShopManagement.Domain.SliderAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastrucer.Repository
{
    public class SliderRepository : BaseRepository<long, Slider>, ISlider
    {
        private readonly ShopContext _context;
        public SliderRepository(ShopContext context) : base(context)
        {
            _context = context;
        }

        public List<SliderDTO> GetAllSliderList()
        {
            return _context.Sliders.Select(x => new SliderDTO
            {
                CreationDate = x.CreationDate.ToFarsi(),
                Heading = x.Heading,
                Id = x.Id,
                IsRemoved = x.IsRemoved,
                Picture = x.Picture,
                Title = x.Title
            }).ToList();
        }



        public EditSlider GetDetails(long id)
        {
            return _context.Sliders.Select(c => new EditSlider
            {
                Id = c.Id,
                BtnText=c.BtnText,
                Heading=c.Heading,
                IsRemoved=c.IsRemoved,
                Link=c.Link,
                
                PictureAlt=c.PictureAlt,
                PictureTitle=c.PictureTitle,
                Text=c.Text,
                Title=c.Title
            }).FirstOrDefault(c => c.Id == id);
        }

        
    }
}
