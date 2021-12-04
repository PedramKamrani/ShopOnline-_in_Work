using _1_QueryLayer.Query.Contract.Slider;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace ShopOnline.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
       

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
         
        }

        public void OnGet()
        {
         
        }
    }
}
