using System.Collections.Generic;

namespace _1_QueryLayer.Query.Contract.Slider
{
    public interface ISliderQuery
    {
        List<SliderQueryModel> GetSliderQueries();
    }
}
