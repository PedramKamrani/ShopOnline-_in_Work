using _1_QueryLayer.Query.Contract.Slider;
using ShopManagement.Infrastrucer;
using System.Collections.Generic;
using System.Linq;

namespace _1_QueryLayer.Query
{
    public class SliderQuery : ISliderQuery
    {
        private readonly ShopContext _context;

        public SliderQuery(ShopContext context)
        {
            _context = context;
        }

        public List<SliderQueryModel> GetSliderQueries()
        {
            var slider = _context.Sliders.Where(x => x.IsRemoved == false)
                .Select(x => new SliderQueryModel
                {
                    Title=x.Title,
                    Heading=x.Heading,
                    BtnText=x.BtnText,
                    Picture=x.Picture,
                    PictureAlt=x.PictureAlt,
                    PictureTitle=x.PictureTitle,
                    Text=x.Text,
                    Link=x.Link
                }).ToList();
            return slider;
        }
    }
}
